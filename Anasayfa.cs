using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Npgsql;

namespace FilmKütüphanesiYönetimSistemi
{
    public partial class Anasayfa : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234");
        public giriş girişForm;
        public List<UserData> Users { get; set; }
        public üyeol üyeolForm;
        public FilmUserControl filmUserControl;
        public Profil profilForm;
        private NotifyIcon notifyIcon;

        public List<FilmData> selectedFilmsList = new List<FilmData>();
        DatabaseManager databaseManager = new DatabaseManager();

        public Anasayfa(Form1 form1, giriş girişForm, üyeol üyeolForm, List<UserData> users, Profil profilForm)
        {
            InitializeComponent();
            this.form1 = form1;
            this.girişForm = girişForm;
            this.üyeolForm = üyeolForm;
            this.Users = users;
            this.profilForm = profilForm;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            // Create a panel (panel2) to contain the two FlowLayoutPanels

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            notifyIcon.Visible = false;
            notifyIcon.Click += NotifyIcon_Click;

            panel2.Dock = DockStyle.Fill;
            panel2.AutoScroll = true;

            // Add the two FlowLayoutPanels to panel2
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel2.Dock = DockStyle.Top;

            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Controls.Add(flowLayoutPanel2);

            // Set panel2 as the main content of your form
            Controls.Add(panel2);

            Admin adminForm = new Admin(databaseManager, this, filmUserControl);
            adminForm.FilmsAdded += AdminForm_FilmsAdded;
            databaseManager.FilmAdded += DatabaseManager_FilmAdded;
        }
        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            // Handle the click on the NotifyIcon, e.g., open the Admin form
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void DatabaseManager_FilmAdded(object sender, EventArgs e)
        {
            // Show a notification using NotifyIcon
            notifyIcon.BalloonTipTitle = "New Film Added!";
            notifyIcon.BalloonTipText = "Check out the latest film.";
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(2000); // Display the notification for 2 seconds
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            

            label4.Visible = false;
            List<UserData> users = UserManager.Instance.Users;
            UserData user = users[0];
            if (users != null && users.Count > 0)
            {
                Data_Yükle();
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is FilmUserControl filmUserControl)
                    {
                        filmUserControl.FilmClicked += FilmUserControl_FilmClicked;
                    }
                }
            }
            else
            {
                MessageBox.Show("No users available.");
            }

            if (user.UserType == UserType.Admin)
            {
                label4.Visible = true;
            }
            

        }

        

        public Form1 form1;
        public FilmSayfası filmSayfası;
        public FilmData SelectedFilmData { get; set; }

        
        private void AdminForm_FilmsAdded(object sender, EventArgs e)
        {
            
            ShowFilmAddedNotification();

        }
        private void ShowFilmAddedNotification()
        {
            try
            {
         
                notifyIcon1.Icon = SystemIcons.Information;
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "Film Added";
                notifyIcon1.BalloonTipText = "New films have been added!";
                notifyIcon1.ShowBalloonTip(5000); // Display the notification for 5 seconds

                // Optionally, handle the BalloonTipClicked event to perform an action when the user clicks the notification

                // Dispose of the NotifyIcon after use
                notifyIcon1.Dispose();
           
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in ShowFilmAddedNotification: {ex.Message}");
            }
        }
        public void SetForm1Instance(Form1 form1Instance)
        {
            form1 = form1Instance;
        }

        private void Data_Yükle()
        {


            // You can use your SQL query to retrieve data
            string sqlQueryFilm = "SELECT filmid, filmname, director, imagepath, posterpath, description, ortpuan, yorum FROM Films"; //


            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            // Call VerileriGoster to load and display the data
            List<FilmData> filmDataList = form1.VerileriGoster(sqlQueryFilm, false);

            foreach (var filmData in filmDataList)
            {

                // Create an instance of FilmUserControl for each film
                FilmUserControl filmUserControl = new FilmUserControl(filmData.FilmId,filmData.FilmName, filmData.Director, filmData.ImagePath, filmData.PosterPath, filmData.Description, filmData.OrtPuan, filmData.Yorum, form1, girişForm, üyeolForm, Users, profilForm);

                // Add FilmUserControl to flowLayoutPanel1
                flowLayoutPanel1.Controls.Add(filmUserControl);

                filmUserControl.FilmClicked += FilmUserControl_FilmClicked;

                // Create an instance of PosterUserControl for each poster
                PosterUserControl posterUserControl = new PosterUserControl( filmData.PosterPath, filmData.FilmName, filmData.Director, filmData.Description, filmData.OrtPuan, filmData.Yorum); //

                // Add PosterUserControl to flowLayoutPanel2
                flowLayoutPanel2.Controls.Add(posterUserControl);

                //PictureBox pictureBox6 = new PictureBox();
                // Configure PictureBox properties
                
                panel2.Controls.Add(btn_goruntule);
        
                btn_goruntule.BringToFront();
                panel2.Controls.Add(btn_listeyeEkle);

                btn_listeyeEkle.BringToFront();

                // Associate the FilmUserControl with the corresponding PosterUserControl
                filmUserControl.AssociatedPoster = posterUserControl;
                filmUserControl.FilmClicked += FilmUserControl_FilmClicked;
            }


        }

        public void LoadPosterUserControl(string posterPath, string FilmName, string Director, string Description, double OrtPuan, int Yorum) //
        {
                // Clear existing controls in the poster panel and add the new PosterUserControl
                flowLayoutPanel2.Controls.Clear();
                PosterUserControl posterUserControl = new PosterUserControl( posterPath, FilmName, Director, Description, OrtPuan, Yorum); //
                flowLayoutPanel2.Controls.Add(posterUserControl);
        }

        public void FilmUserControl_FilmClicked(object sender, EventArgs e)
        {
            if (sender is FilmUserControl filmUserControl)
            {
              
                // Set the selected film data
                SelectedFilmData = new FilmData
                {
                    FilmId = filmUserControl.FilmId,
                    FilmName = filmUserControl.FilmName,
                    Director = filmUserControl.Director,
                    PosterPath = filmUserControl.PosterPath,
                    ImagePath = filmUserControl.ImagePath,
                    Description = filmUserControl.Description,
                    OrtPuan = filmUserControl.OrtPuan,
                    Yorum = filmUserControl.Yorum

                };

                // Load the corresponding PosterUserControl
                LoadPosterUserControl(filmUserControl.PosterPath, filmUserControl.FilmName, filmUserControl.Director, filmUserControl.Description, filmUserControl.OrtPuan, filmUserControl.Yorum); //
            }
        }


        // public void LoadSelectedFilmPoster()

        public void Form_Yukle(object Form)
        {
            // Dispose of the previous form
            if (panel2.Controls.Count > 0 && panel2.Controls[0] is Form previousForm)
            {
                previousForm.Dispose();
            }

            panel2.Controls.Clear(); // Clear existing controls
            panel2.Visible = true;

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form_Yukle(new Anasayfa(form1, girişForm, üyeolForm, Users, profilForm));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Assuming you have a list of users in your Anasayfa class
            Profil profilForm = new Profil(girişForm, Users, this, form1, üyeolForm, selectedFilmsList); // Pass the Users list to Profil form
            Form_Yukle(profilForm);
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aramaLabel_Click(object sender, EventArgs e)
        {
            Form_Yukle(new Arama(form1, this, girişForm, üyeolForm, Users, profilForm));
        }

        private void btn_listeyeEkle_Click(object sender, EventArgs e)
        {

            if (SelectedFilmData != null)
            {
                try
                {
                    // Open the database connection
                    conn.Open();

                    // Create the insert command
                    using (NpgsqlCommand insertCommand = new NpgsqlCommand())
                    {
                        insertCommand.Connection = conn;
                        insertCommand.CommandType = CommandType.Text;
                        insertCommand.CommandText = "INSERT INTO list (filmid, filmname, director, imagepath, posterpath, description, ortpuan, yorum) VALUES (@filmid, @filmname, @director, @imagepath, @posterpath, @description, @ortpuan, @yorum)";

                        // Add parameters
                        insertCommand.Parameters.AddWithValue("@filmid", SelectedFilmData.FilmId);
                        insertCommand.Parameters.AddWithValue("@filmname", SelectedFilmData.FilmName);
                        insertCommand.Parameters.AddWithValue("@director", SelectedFilmData.Director);
                        insertCommand.Parameters.AddWithValue("@imagepath", SelectedFilmData.ImagePath);
                        insertCommand.Parameters.AddWithValue("@posterpath", SelectedFilmData.PosterPath);
                        insertCommand.Parameters.AddWithValue("@description", SelectedFilmData.Description);
                        insertCommand.Parameters.AddWithValue("@ortpuan", SelectedFilmData.OrtPuan);
                        insertCommand.Parameters.AddWithValue("@yorum", SelectedFilmData.Yorum);

                        // Execute the insert query
                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Film added to the list.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add film to the list.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    // Close the database connection in the finally block to ensure it's always closed
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("No film data selected.");
            }
        }

        private void btn_goruntule_Click_1(object sender, EventArgs e)
        {
            if (SelectedFilmData != null)
            {
                Form_Yukle(new FilmSayfası(SelectedFilmData, girişForm, Users, üyeolForm));
            }
            else
            {
                MessageBox.Show("No film data selected.");
            }
        }
        private void profilfoto_Click(object sender, EventArgs e)
        {
            Form_Yukle(new Profil(girişForm, Users, this, form1, üyeolForm, selectedFilmsList));
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form_Yukle(new Admin(databaseManager, this, filmUserControl));

        }

    }
}
