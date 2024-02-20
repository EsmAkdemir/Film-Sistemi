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
    public partial class FilmUserControl : UserControl
    {
        public event EventHandler FilmClicked;
         public bool IsInProfilContext { get; set; }
        public int FilmId { get; private set; }
        public string ImagePath { get; private set; }
        public string PosterPath { get; private set; }
        public string FilmName { get; private set; }
        public string Director { get; private set; }
        public string Description { get; private set; }
        public double OrtPuan { get; private set; }
        public int Yorum { get; private set; }
        public Anasayfa anasayfa;
        public giriş girişForm;
        public FilmData selectedFilmData;
        public üyeol üyeolForm;
        public List<UserData> Users { get; set; }

        // Add the AssociatedPoster property
        public PosterUserControl AssociatedPoster { get; set; }

        public FilmUserControl(int filmId, string filmName, string director, string imagePath, string posterPath, string description, double ortpuan, int yorum, Form1 form1, giriş girişForm, üyeol üyeolForm, List<UserData> users, Profil profilForm)
        {
            InitializeComponent();

            // Set up PictureBox
            pictureBox1.Image = Image.FromFile(imagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Set up properties
            FilmId = filmId;
            ImagePath = imagePath;
            PosterPath = posterPath;
            FilmName = filmName;
            Director = director;
            Description = description;
            OrtPuan = ortpuan;
            Yorum = yorum;

            anasayfa = new Anasayfa(form1, girişForm, üyeolForm, users, profilForm);

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (IsInProfilContext == true)
            {

                FilmData clickedFilmData = new FilmData
                {
                    FilmId = this.FilmId,
                    FilmName = this.FilmName,
                    Director = this.Director,
                    PosterPath = this.PosterPath,
                    ImagePath = this.ImagePath,
                    Description = this.Description
                    // Add other properties if needed
                };
                // clickedFilmData = selectedFilmData; // Remove this line
                Console.WriteLine("a");
                // Invoke the FilmClicked event with clickedFilmData
                FilmClicked?.Invoke(this, new FilmClickedEventArgs(clickedFilmData));
                Console.WriteLine("b");

                // Use clickedFilmData here
                //FilmSayfası filmSayfası = new FilmSayfası(clickedFilmData, girişForm, Users, üyeolForm);
                //filmSayfası.Show();
                anasayfa.Form_Yukle(new FilmSayfası(clickedFilmData, girişForm, Users, üyeolForm));
                Console.WriteLine("c");

            }
            else
            {
                FilmData clickedFilmData = new FilmData
                {
                    FilmId = this.FilmId,
                    FilmName = this.FilmName,
                    Director = this.Director,
                    PosterPath = this.PosterPath,
                    ImagePath = this.ImagePath,
                    Description = this.Description
                    // Add other properties if needed
                };


                // Invoke the FilmClicked event
                FilmClicked?.Invoke(this, new FilmClickedEventArgs(clickedFilmData));
            }
        }
    }
}
