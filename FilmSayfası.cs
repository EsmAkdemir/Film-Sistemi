using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace FilmKütüphanesiYönetimSistemi
{
    public partial class FilmSayfası : Form
    { 
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId = postgres; Password=1234");
        NpgsqlCommand komut = new NpgsqlCommand();
        public Anasayfa anasayfa;
        public Form1 form1;
        public PosterUserControl posterUserControl;
        public FilmUserControl filmUserControl;
        public FilmData filmData;
        public FilmData selectedFilmData;
        public üyeol üyeolForm;
        public giriş girişForm;
        public Profil profilForm;
        public List<UserData> Users { get; set; }

        public FilmSayfası(FilmData selectedFilmData, giriş girişForm, List<UserData> users, üyeol üyeolForm)
        {
            InitializeComponent();
            SetForm1Instance(form1);
            this.girişForm = girişForm;
            this.Users = users;
            this.üyeolForm = üyeolForm;
          

            this.selectedFilmData = selectedFilmData;
            LoadSelectedFilmPoster();        

        }


        public void Form_Yukle(object Form)
        {
            if (panel2.Controls.Count > 0 && panel2.Controls[0] is Form previousForm)
            {
                previousForm.Dispose();
            }

            panel2.Controls.Clear(); 
            panel2.Visible = true;

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();
        }

        private double CalculateAverageRatingFromDatabase(int filmId)
        {
            string sorgu = $"SELECT puan FROM \"reviews{filmId}\"";
            komut = new NpgsqlCommand(sorgu, conn);

            conn.Open();
            NpgsqlDataReader reader = komut.ExecuteReader();

            double totalRating = 0;
            int ratingCount = 0;

            while (reader.Read())
            {
                totalRating += Convert.ToDouble(reader["puan"]);
                ratingCount++;
            }

            conn.Close();

            return ratingCount > 0 ? totalRating / ratingCount : 0.0;
        }


        //YORUM İÇİN DE GÜNCELLEME GEREKİYOR
        private void UpdateAverageRatingLabel()
        {
            double averageRating = CalculateAverageRatingFromDatabase(selectedFilmData.FilmId);
            ortpuan.Text = $"{averageRating:F1}";
        }

        private void FilmSayfası_Load(object sender, EventArgs e)
        {
            //YORUM İÇİN DE EKLE
            Yetkilendirme();
            //yorumlar
            
            panel2.Controls.Add(richTextBox1);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(btn_gonder);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(ortpuan);
            panel2.Controls.Add(puan_label);
            panel2.Controls.Add(btn_anasayfayaDon);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(pictureBox2);
            
            panel2.BringToFront();
     
            pictureBox1.BringToFront();
            pictureBox2.BringToFront();
            ortpuan.BringToFront();
            puan_label.BringToFront();
            btn_anasayfayaDon.BringToFront();
            richTextBox1.BringToFront();
            panel1.BringToFront();
            btn_gonder.BringToFront();
            textBox1.BringToFront();
            //yorum yükle
            Yorum_Yükle(selectedFilmData.FilmId);


            //YORUM İÇİN DE GĞNCELLEME GEREKİYOR
            // Form yüklendiğinde geçmiş puanları göstermek için
            double initialAverageRating = CalculateAverageRatingFromDatabase(selectedFilmData.FilmId);
            ortpuan.Text = $"{initialAverageRating:F1}";

            SetForm1Instance(form1);

            if (form1 == null)
            {
                form1 = new Form1();
                SetForm1Instance(form1);
            }

            if (form1 == null)
            {
                MessageBox.Show("Form1 is not initialized.");
                return;
            }

            filmData = form1.VeriGetir("SELECT filmid, filmname, director, imagepath, posterpath, description, ortpuan, yorum FROM Films", false);//
            filmData = selectedFilmData;

            if (filmData != null)
            {
                flowLayoutPanel2.Controls.Clear();
                PosterUserControl posterUserControl = new PosterUserControl(selectedFilmData.PosterPath, selectedFilmData.FilmName, selectedFilmData.Director, selectedFilmData.Description, selectedFilmData.OrtPuan, selectedFilmData.Yorum);//
                flowLayoutPanel2.Controls.Add(posterUserControl);

                posterUserControl.SetLabel2Visibility(false); 
                posterUserControl.SetPuanLabelVisibility(false); 

                //YORUM İÇİN DE GİZLEME GEREKEBİLİR
            }
            else
            {
                MessageBox.Show("Failed to retrieve film data.");
                return;
            }

        }
        public void SetForm1Instance(Form1 form1Instance)
        {
            form1 = form1Instance;
        }

        
        public void Yetkilendirme()
        {
            List<UserData> users = UserManager.Instance.Users;
            UserData user = users[0];

            if (user.UserType == UserType.Standard)
            {
              
                textBox1.Visible = false;
                richTextBox1.Visible = false;
                btn_gonder.Visible = false;
                return;
            }
        }
       

        public void LoadSelectedFilmPoster()
        {
            PosterUserControl posterUserControl = new PosterUserControl(selectedFilmData.PosterPath, selectedFilmData.FilmName, selectedFilmData.Director, selectedFilmData.Description, selectedFilmData.OrtPuan, selectedFilmData.Yorum);//

            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Controls.Add(posterUserControl);
        }

        public void Yorum_Yap(int filmId)
        {
            string sorgu = $"INSERT INTO reviews{filmId} (puan, yorum) VALUES (@puan, @yorum)";
           
            komut = new NpgsqlCommand(sorgu, conn);
            komut.Parameters.AddWithValue("@puan", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@yorum", richTextBox1.Text);

            conn.Open();
            komut.ExecuteNonQuery();
            conn.Close();

            // Yorum eklemesi yapıldıktan sonra ortalama puanı güncelle
            UpdateAverageRatingLabel();

            UpdateAverageRatingInReviewsTable(filmId, CalculateAverageRatingFromDatabase(filmId));

            UpdateAverageRatingInFilmsTable(filmId, CalculateAverageRatingFromDatabase(filmId));

            UpdateCommentCountInFilmsTable(filmId);
        }

        private void UpdateCommentCountInFilmsTable(int filmId)
        {
            string countQuery = $"SELECT COUNT(*) FROM \"reviews{filmId}\"";
            komut = new NpgsqlCommand(countQuery, conn);

            conn.Open();
            int commentCount = Convert.ToInt32(komut.ExecuteScalar());
            conn.Close();

            string updateQuery = $"UPDATE \"films\" SET yorum = @commentCount WHERE filmid = @filmId";
            komut = new NpgsqlCommand(updateQuery, conn);
            komut.Parameters.AddWithValue("@commentCount", commentCount);
            komut.Parameters.AddWithValue("@filmId", filmId);

            conn.Open();
            komut.ExecuteNonQuery();
            conn.Close();
        }



        private void UpdateAverageRatingInReviewsTable(int filmId, double averageRating)
        {
            string updateQuery = $"UPDATE \"reviews{filmId}\" SET ortpuan = @averageRating";
            komut = new NpgsqlCommand(updateQuery, conn);
            komut.Parameters.AddWithValue("@averageRating", averageRating);

            conn.Open();
            komut.ExecuteNonQuery();
            conn.Close();
        }

        private void UpdateAverageRatingInFilmsTable(int filmId, double averageRating)
        {
            string updateQuery = $"UPDATE \"films\" SET ortpuan = @averageRating WHERE filmid = @filmId";
            komut = new NpgsqlCommand(updateQuery, conn);
            komut.Parameters.AddWithValue("@averageRating", averageRating);
            komut.Parameters.AddWithValue("@filmId", filmId);

            conn.Open();
            komut.ExecuteNonQuery();
            conn.Close();
        }


        public void Yorum_Yükle(int filmId)
        {
            //Console.WriteLine($"FilmId to be inserted: {selectedFilmData.FilmId}");
            string sorgu = $"SELECT * FROM \"reviews{filmId}\""; // \"reviews{filmId}\"
            komut = new NpgsqlCommand(sorgu, conn);
            //Console.WriteLine($"FilmId to be inserted: {filmId}");
            conn.Open();
            NpgsqlDataReader reader = komut.ExecuteReader();

            // Clear existing controls in panel1
            panel1.Controls.Clear();

            int userControlTop = 0;

            while (reader.Read())
            {
                YorumUserControl yorumUserControl = new YorumUserControl();
                yorumUserControl.yorumTxtBox.Text = reader["yorum"].ToString();
                yorumUserControl.label1.Text = reader["puan"].ToString();
                yorumUserControl.Top = userControlTop;

                panel1.Controls.Add(yorumUserControl); // Add the new YorumUserControl

                userControlTop += yorumUserControl.Height + 5;
            }

            panel1.AutoScroll = true; 

            conn.Close();
        }

        private void txtBoxTemizle(TextBox txt)
        {
            txt.Text = "";
        }

        private void btn_gonder_Click_1(object sender, EventArgs e)
        {
            Yorum_Yap(selectedFilmData.FilmId);
            Yorum_Yükle(selectedFilmData.FilmId);
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txtBoxTemizle(textBox1);
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void btn_anasayfayaDon_Click(object sender, EventArgs e)
        {
            Form_Yukle(new Anasayfa(form1, girişForm, üyeolForm, Users, profilForm));
        }
    }

}
