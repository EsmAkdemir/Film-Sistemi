using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmKütüphanesiYönetimSistemi
{
    public partial class Arama : Form
    {
        private Form1 form1;
        public List<FilmData> selectedFilms;
        public event EventHandler FilmClicked;
        public üyeol üyeolForm;
        public Anasayfa anasayfa;
        public List<UserData> Users;
        public giriş girişForm;
        public Profil profilForm;
       

        public Arama(Form1 form1, Anasayfa anasayfa, giriş girişForm, üyeol üyeolForm, List<UserData> users, Profil profilForm)
        {
            InitializeComponent();
            this.form1 = form1;
            this.Load += Arama_Load;
            this.anasayfa = anasayfa;
            this.girişForm = girişForm;
            this.üyeolForm = üyeolForm;
            this.Users = users;
            this.profilForm = profilForm;
     

        }

        private void Arama_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            // Arama işlemini gerçekleştir ve sonuçları göster
            AramaYap("");
        }

        private void FilmUserControl_Clicked(FilmData filmData)
        {


            // Tıklanan filmi kullanarak FilmSayfası'na yönlendirme
            if (filmData != null)
            {
                


                Console.WriteLine($"Clicked Film: {filmData.FilmName}, {filmData.Director}");
                anasayfa.Form_Yukle(new FilmSayfası(filmData, girişForm, Users, üyeolForm));
            }
        }


        private void AramaYap(string aramaKelimesi)
        {
            // Arama sorgusu
            string lowerSearchTerm = aramaKelimesi.ToLower();
            string sqlQuery = $"SELECT filmid, filmname, director, imagepath, posterpath, description, ortpuan, yorum FROM Films " +//, ortpuan
                       $"WHERE LOWER(filmname) LIKE '%{aramaKelimesi}%' OR LOWER(director) LIKE '%{aramaKelimesi}%' OR LOWER(description) LIKE '%{aramaKelimesi}%'";

            // Filmleri getir
            List<FilmData> filmDataList = form1.VerileriGoster(sqlQuery, false);

            // Paneli temizle
            flowLayoutPanel1.Controls.Clear();

            if (filmDataList.Count == 0)
            {
                // Veritabanında eşleşen bir şey bulunamadı, kullanıcıya bilgi mesajı göster
                MessageBox.Show("Aranan film bulunamadı. Lütfen başka bir şey arayın.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AramaYap("");
                return;
            }
            else
            {
                foreach (var filmData in filmDataList)
                {
                    sonucUserControl1 sonucUserControl = new sonucUserControl1(filmData.ImagePath, filmData.FilmName, filmData.Director, filmData.Description, filmData.OrtPuan, filmData.Yorum);

                    // Tıklama olayını ele al
                    sonucUserControl.FilmClicked += (sender, e) => { FilmUserControl_Clicked(filmData); };

                    flowLayoutPanel1.Controls.Add(sonucUserControl);
                }
            }

        }
        
       

        private void txtBoxTemizle(TextBox txt)
        {
            txt.Text = "";
        }


        private void txtArama_TextChanged_1(object sender, EventArgs e)
        {
            // Arama kutusundaki metin değiştiğinde yeni arama yap
            AramaYap(txtArama.Text);
        }

        private void txtArama_MouseClick_1(object sender, MouseEventArgs e)
        {
            txtBoxTemizle(txtArama);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaKelimesi;
            aramaKelimesi = txtArama.Text;
            AramaYap(aramaKelimesi);
        }

        private void btn_puan_Click(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT filmid, filmname, director, imagepath, posterpath, description, ortpuan, yorum " + //
                  "FROM Films " +
                  "ORDER BY ortpuan DESC";

            // Filmleri getir
            List<FilmData> filmDataList = form1.VerileriGoster(sqlQuery, false);

            // Paneli temizle
            flowLayoutPanel1.Controls.Clear();

            if (filmDataList.Count == 0)
            {
                // Veritabanında film bulunamadıysa bilgi mesajı göster
                MessageBox.Show("Hiç film bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var filmData in filmDataList)
            {
                sonucUserControl1 sonucUserControl = new sonucUserControl1(filmData.ImagePath, filmData.FilmName, filmData.Director, filmData.Description, filmData.OrtPuan, filmData.Yorum);

                // Tıklama olayını ele al
                sonucUserControl.FilmClicked += (s, eventArgs) => { FilmUserControl_Clicked(filmData); };

                flowLayoutPanel1.Controls.Add(sonucUserControl);
            }
        }
        
        private void btn_yorum_Click(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT filmid, filmname, director, imagepath, posterpath, description, ortpuan, yorum " +
                              "FROM Films " +
                              "ORDER BY yorum DESC";

            List<FilmData> filmDataList = form1.VerileriGoster(sqlQuery, false);

            flowLayoutPanel1.Controls.Clear();

            if (filmDataList.Count == 0)
            {
                MessageBox.Show("Hiç film bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var filmData in filmDataList)
            {
                sonucUserControl1 sonucUserControl = new sonucUserControl1(filmData.ImagePath, filmData.FilmName, filmData.Director, filmData.Description, filmData.OrtPuan, filmData.Yorum);

                sonucUserControl.FilmClicked += (s, eventArgs) => { FilmUserControl_Clicked(filmData); };

                flowLayoutPanel1.Controls.Add(sonucUserControl);
            }
        }
    }
}