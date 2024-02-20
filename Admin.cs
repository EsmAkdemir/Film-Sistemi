using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace FilmKütüphanesiYönetimSistemi
{
    public partial class Admin : Form
    {
        private NotifyIcon notifyIcon;
        public event EventHandler FilmsAdded;
        DatabaseManager databaseManager = new DatabaseManager();
        public List<FilmData> films = new List<FilmData>();
        public string FileName { get; set; }
        public string küçükresim { get; set; }
        public giriş girişForm;
        private FilmData selectedFilm;

        public FilmData before;
        public FilmUserControl filmUserControl;
        public üyeol üyeolForm;
        public PopUp popUp;
        public Form1 form1;
        public Profil profilForm;
        public List<UserData> Users { get; set; }
        public Anasayfa anasayfa;
        public Admin(DatabaseManager databaseManager, Anasayfa anasayfa, FilmUserControl filmUserControl)
        {
            InitializeComponent();
            this.databaseManager = databaseManager;
            this.anasayfa = anasayfa;
            this.filmUserControl = filmUserControl;

            databaseManager.FilmAdded += DatabaseManager_FilmAdded;

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            notifyIcon.Visible = false;
            notifyIcon.Click += NotifyIcon_Click;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void DatabaseManager_FilmAdded(object sender, EventArgs e)
        {
         
            notifyIcon.BalloonTipTitle = "New Film Added!";
            notifyIcon.BalloonTipText = "Check out the latest film.";
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(2000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files|*.*";



            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string selectedFilePath = openFileDialog.FileName;

                pictureBox6.Visible = false;
                pictureBox5.Visible = true;
                pictureBox5.Image = new System.Drawing.Bitmap(selectedFilePath);

                string fileName = Path.GetFileName(selectedFilePath);

                string destinationFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources\\films", fileName);
                FileName = fileName;

                try
                {
                    string destinationFolder = Path.GetDirectoryName(destinationFilePath);
                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    File.Copy(selectedFilePath, destinationFilePath, true);

                    MessageBox.Show($"File copied to: {destinationFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(filmAdı.Text) || string.IsNullOrWhiteSpace(yönetmen.Text) || string.IsNullOrWhiteSpace(açıklama.Text))
            {
                PopUp popUp = new PopUp();
                Profil profilForm = new Profil(girişForm, Users, anasayfa, form1, üyeolForm, films);
                profilForm.Call_Popup("film adı, yönetmen    \n açıklama kısmı boş kalamaz", 300);
                return;
            }
            Console.WriteLine("Button 1 clicked.");
            int yenifilmsayısı = 0;

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234"))
            {
                conn.Open();

                using (NpgsqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        NpgsqlCommand komut = new NpgsqlCommand("SELECT COUNT(*) FROM \"films\"", conn);
                        int filmsayısı = Convert.ToInt32(komut.ExecuteScalar());
                        yenifilmsayısı = filmsayısı + 1;

                        FilmData yenifilm = new FilmData
                        {
                            FilmId = yenifilmsayısı,
                            FilmName = filmAdı.Text,
                            Director = yönetmen.Text,
                            ImagePath = $"resources\\films\\{küçükresim}",
                            PosterPath = $"resources\\films\\{FileName}",
                            Description = açıklama.Text,
                            OrtPuan = 0,
                            Yorum = 0
                        };

                        databaseManager.SaveFilmToDatabase(yenifilm, "films");

                        string reviewTableName = $"reviews{yenifilmsayısı}";
                        string createReviewTableQuery = $"CREATE TABLE \"{reviewTableName}\" (puan INTEGER, yorum VARCHAR(255), ortpuan DOUBLE PRECISION);";
                        NpgsqlCommand createReviewTableCommand = new NpgsqlCommand(createReviewTableQuery, conn, transaction);
                        createReviewTableCommand.ExecuteNonQuery();

                        transaction.Commit();

                        Console.WriteLine("Before invoking FilmsAdded event.");
                        OnFilmsAdded(EventArgs.Empty);
                        Console.WriteLine("After invoking FilmsAdded event.");

                        Console.WriteLine($"Film inserted successfully with ID: {yenifilmsayısı}");
                        Console.WriteLine($"Table {reviewTableName} created successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

        protected virtual void OnFilmsAdded(EventArgs e)
        {
            FilmsAdded?.Invoke(this, e);
            Console.WriteLine("FilmsAdded event invoked.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files|*.*";



            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
                pictureBox6.Image = new System.Drawing.Bitmap(selectedFilePath);

                string fileName = Path.GetFileName(selectedFilePath);

                string destinationFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources\\films", fileName);
                küçükresim = fileName;

                try
                {
                    string destinationFolder = Path.GetDirectoryName(destinationFilePath);
                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    File.Copy(selectedFilePath, destinationFilePath, true);

                    MessageBox.Show($"File copied to: {destinationFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FilmUserControl_FilmClicked(object sender, EventArgs e)
        {
            FilmUserControl clickedFilmUserControl = sender as FilmUserControl;
            if (clickedFilmUserControl != null)
            {
                string filmName = clickedFilmUserControl.FilmName;
                string director = clickedFilmUserControl.Director;
                string desc = clickedFilmUserControl.Description;

                filmAdı.Text = filmName;
                yönetmen.Text = director;
                açıklama.Text = desc;

                selectedFilm = new FilmData
                {
                    FilmId = clickedFilmUserControl.FilmId,
                    FilmName = filmName,
                    Director = director,
                    ImagePath = clickedFilmUserControl.ImagePath,
                    PosterPath = clickedFilmUserControl.PosterPath,
                    Description = desc
                };
            }
        }

        private void PopulateFilmsInFlowLayoutPanel(FlowLayoutPanel flowLayoutPanel)
        {  
            List<FilmData> films = databaseManager.GetFilmsFromDatabase("Films");

            flowLayoutPanel.Controls.Clear();

            foreach (var filmData in films)
            {
                FilmUserControl filmUserControl = new FilmUserControl(
                    filmData.FilmId, filmData.FilmName, filmData.Director,
                    filmData.ImagePath, filmData.PosterPath, filmData.Description, filmData.OrtPuan, filmData.Yorum,
                    form1, girişForm, üyeolForm, Users, profilForm);

                filmUserControl.Size = new Size(100, 150);


                flowLayoutPanel.Controls.Add(filmUserControl);

                filmUserControl.FilmClicked += FilmUserControl_FilmClicked;


            }

        }

        private void Admin_Load(object sender, EventArgs e)
        {

            PopulateFilmsInFlowLayoutPanel(flowLayoutPanel1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedFilm != null)
            {
                // Update film details
                selectedFilm.FilmName = filmAdı.Text;
                selectedFilm.Director = yönetmen.Text;

                if (küçükresim == null)
                {
                    selectedFilm.ImagePath = selectedFilm.ImagePath;
                }
                else
                {
                    selectedFilm.ImagePath = $"resources\\films\\{küçükresim}";
                }

                if (FileName == null)
                {
                    selectedFilm.PosterPath = selectedFilm.PosterPath;
                }
                else
                {
                    selectedFilm.PosterPath = $"resources\\films\\{FileName}";
                }

                selectedFilm.Description = açıklama.Text;

                databaseManager.UpdateFilmInDatabase(selectedFilm);
            }
            else
            {
                profilForm.Call_Popup("güncellemek istediğiniz filmi seçiniz", 200);
            }
        }

        private void filmAdı_Click(object sender, EventArgs e)
        {
            giriş girişForm = new giriş(form1);
            girişForm.txtBoxTemizle(filmAdı);
        }

        private void yönetmen_Click(object sender, EventArgs e)
        {
            giriş girişForm = new giriş(form1);
            girişForm.txtBoxTemizle(yönetmen);
        }

        private void açıklama_Click(object sender, EventArgs e)
        {
            giriş girişForm = new giriş(form1);
            girişForm.txtBoxTemizle(açıklama);
        }
    }
}
