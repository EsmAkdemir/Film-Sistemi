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
    public partial class Form1 : Form
    {
        public Anasayfa anasayfa;
        private bool isTitleBarClicked = false;
        public FilmSayfası filmSayfası;
        public List<UserData> Users { get; set; }
        public giriş girişForm;
        public üyeol üyeolForm;
        public Profil profilForm;
        DatabaseManager databaseManager = new DatabaseManager();
        public Form1()
        {
            InitializeComponent();
            anasayfa = new Anasayfa(this, girişForm, üyeolForm, Users, profilForm);

        }
       
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId = postgres; Password=1234");

        private void Form1_Load(object sender, EventArgs e)
        {
            anasayfa = new Anasayfa(this, girişForm, üyeolForm, Users, profilForm);
            anasayfa.SetForm1Instance(this);

            FilmData filmData = VeriGetir("SELECT filmid, filmname, director, imagepath, posterpath, description, ortpuan, yorum FROM \"films\"", false);//

            if (filmData != null)
            {
                FilmSayfası filmSayfası = new FilmSayfası(filmData, girişForm, Users, üyeolForm);
                filmSayfası.SetForm1Instance(this);

                Form_Yukle(new giriş(this));

                filmSayfası.LoadSelectedFilmPoster();
            }
            else
            {
                MessageBox.Show("Failed to retrieve film data.");
            }
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

        public List<FilmData> VerileriGoster(string txt, bool isPoster)
        {
            conn.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.Text;
            komut.CommandText = txt;
            NpgsqlDataReader reader = komut.ExecuteReader();
            List<FilmData> filmDataList = new List<FilmData>();

            while (reader.Read())
            {


                FilmData filmData = new FilmData
                {
                    
                    FilmId = Convert.ToInt32(reader["filmid"]),
                    FilmName = reader["filmname"].ToString(),
                    Director = reader["director"].ToString(),
                    Description = reader["description"].ToString(),
                    ImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reader["imagepath"].ToString()),
                    PosterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reader["posterpath"].ToString()),
                    OrtPuan = Convert.ToDouble(reader["ortpuan"]),
                    Yorum = Convert.ToInt32(reader["yorum"])
                };

                filmDataList.Add(filmData);
            }

            komut.Dispose();
            conn.Close();

            return filmDataList;
        }

        public FilmData VeriGetir(string txt, bool isPoster)
        {
            conn.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.Text;
            komut.CommandText = txt;
            NpgsqlDataReader reader = komut.ExecuteReader();

            FilmData filmData = null;

            if (reader.Read())
            {
                filmData = new FilmData
                {
                   
                    FilmId = Convert.ToInt32(reader["filmid"]),
                    FilmName = reader["filmname"].ToString(),
                    Director = reader["director"].ToString(),
                    Description = reader["description"].ToString(),
                    ImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reader["imagepath"].ToString()),
                    PosterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reader["posterpath"].ToString()),
                    OrtPuan = Convert.ToDouble(reader["ortpuan"]),
                    Yorum = Convert.ToInt32(reader["yorum"])
                };
            }

            komut.Dispose();
            conn.Close();

            return filmData;
        }


        //Sekmeler
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            isTitleBarClicked = e.Button == MouseButtons.Left;
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
            databaseManager.ResetDatabase("list");
        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


    }
}
