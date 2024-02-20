using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace FilmKütüphanesiYönetimSistemi
{
    public partial class Profil : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234");
        public PictureBox clickedPictureBox;
        public Form1 form1;
        public giriş girişForm;
        public List<FilmData> selectedFilms;
        public Anasayfa anasayfa;
        public PopUp popUp;
        public üyeol üyeolForm;
        private FilmUserControl lastClickedFilmUserControl;
        DatabaseManager databaseManager = new DatabaseManager();
        private FilmData selectedFilmData;

        public List<UserData> Users { get; set; }

        public Profil(giriş girişForm, List<UserData> users, Anasayfa anasayfa, Form1 form1, üyeol üyeolForm, List<FilmData> selectedFilms)
        {
            InitializeComponent();
            this.girişForm = girişForm;
            this.Users = users;
            this.anasayfa = anasayfa;
            this.form1 = form1;
            this.üyeolForm = üyeolForm;
            this.selectedFilms = selectedFilms;
            Set_PictureBoxes();
            DisplayListedFilms();
        }
        private void DisplayListedFilms()
        {

            List<FilmData> listedFilms = GetListedFilms();

            flowLayoutPanel1.Controls.Clear();

            foreach (var filmData in listedFilms)
            {

                FilmUserControl filmUserControl = new FilmUserControl(filmData.FilmId, filmData.FilmName, filmData.Director, filmData.ImagePath, filmData.PosterPath, filmData.Description, filmData.OrtPuan, filmData.Yorum, form1, girişForm, üyeolForm, Users, this);
                filmUserControl.Size = new Size(75, 110);

                filmUserControl.FilmClicked += FilmUserControl_FilmClicked;

                flowLayoutPanel1.Controls.Add(filmUserControl);
     


            }
        }

        public void FilmUserControl_FilmClicked(object sender, EventArgs e)
        {
            if (sender is FilmUserControl filmUserControl)
            {
                if (lastClickedFilmUserControl != null)
                {
                    lastClickedFilmUserControl.BackColor = System.Drawing.Color.Transparent;
                }

                

                selectedFilmData = new FilmData
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


                filmUserControl.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);

                lastClickedFilmUserControl = filmUserControl;
            }
        }
      
      

        private List<FilmData> GetListedFilms()
        {

            List<FilmData> listedFilms = new List<FilmData>();

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234"))
            {
                conn.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM list", conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FilmData filmData = new FilmData
                            {
                                FilmId = Convert.ToInt32(reader["filmid"]),
                                FilmName = reader["filmname"].ToString(),
                                Director = reader["director"].ToString(),
                                ImagePath = reader["imagepath"].ToString(),
                                PosterPath = reader["posterpath"].ToString(),
                                Description = reader["description"].ToString(),
                                OrtPuan = Convert.ToDouble(reader["ortpuan"]),
                                Yorum = Convert.ToInt32(reader["yorum"])
                            };

                            listedFilms.Add(filmData);
                        }
                    }
                }
            }

            return listedFilms;
        }
        public void Kullanıcı_Bilgileri(UserData selectedUser)
        {
            int paslength;

            if (selectedUser != null)
            {
                kad.Text = selectedUser.UserName;
                paslength = selectedUser.Password.Length;
                sif.Text = new string('*', paslength);
                üyp.Text = selectedUser.UserType.ToString();

        
                tcLabel.Text = selectedUser.TC.ToString();
                cinsiyetLabel.Text = selectedUser.Cinsiyet ? "Kadın" : "Erkek";
                dogumTarihiLabel.Text = selectedUser.DogumTarihi.ToString("yyyy-MM-dd");
                adSoyadLabel.Text = selectedUser.AdSoyad;
           
            }

            else
            {
                MessageBox.Show("hiçbir alan boş bırakılamaz..");
            }
        }

        private void Profil_Load(object sender, EventArgs e)
        {
            pictureBox14.Visible = false;
            

            if (flowLayoutPanel1.Controls.Count == 0)
            {
                pictureBox14.BringToFront();
                pictureBox14.Visible = true;
            }
            if (UserManager.Instance != null)
            {
              

                List<UserData> users = UserManager.Instance.Users;

                if (users != null && users.Count > 0)
                {
                    UserData user = users[0];
                    Kullanıcı_Bilgileri(user);
                    if (user != null && user.UserType == UserType.Admin)
                    {
                        label7.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("No users available.");
                }
            }
            else
            {
              
                MessageBox.Show("No UserManager.Instance available.");
            }

        }

        public void ProfilUpdate()
        {
            List<UserData> users = UserManager.Instance.Users;

            if (users != null && users.Count > 0)
            {
                UserData user = users[0];
                Kullanıcı_Bilgileri(user);
            }
            else
            {
                MessageBox.Show("No users available.");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            KullanıcıAdıŞifreDeğiştir KullanıcıBilgi_değiştir = new KullanıcıAdıŞifreDeğiştir(girişForm, Users);

            KullanıcıBilgi_değiştir.Show();

        }
        private void Set_PictureBoxes()
        {
            for (int i = 2; i <= 13; i++) 
            {
                string pictureBoxName = $"pictureBox{i}";
                Control[] controls = Controls.Find(pictureBoxName, true);

                if (controls.Length > 0 && controls[0] is PictureBox pictureBox)
                {
                    pictureBox.Click += PictureBox_Click;
                }
                else
                {
                    MessageBox.Show($"PictureBox '{pictureBoxName}' not found or is not of the expected type.");
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            clickedPictureBox = (PictureBox)sender;
            pictureBox1.Image = clickedPictureBox.Image;

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (clickedPictureBox != null && clickedPictureBox != pictureBox1)
            {
                if (clickedPictureBox.Image != null)
                {
                    Set_ProfilePicture(clickedPictureBox);
                }
                else
                {
                    MessageBox.Show("The clicked PictureBox does not have a valid image.");
                }
            }
            else
            {
                MessageBox.Show("Please click on a valid PictureBox (pictureBox2 to pictureBox13) first.");
            }
        }

        public void Set_ProfilePicture(PictureBox sourcePictureBox)
        {
            anasayfa.profilfoto.Image = sourcePictureBox.Image;
            pictureBox1.Image = sourcePictureBox.Image;
        }
        public void Call_Popup_Ask(string message, int size)
        {
            popUp = new PopUp();
            popUp.Size = new Size(size, size / 2);
            popUp.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);
            popUp.label3.Text = message;
          
            popUp.label3.TextAlign = ContentAlignment.MiddleCenter;
            popUp.evet.Visible = true;
            popUp.hayır.Visible = true;

            popUp.panel1.Location = new Point(
            (popUp.ClientSize.Width - popUp.panel1.Width) / 2,
            (popUp.ClientSize.Height - popUp.panel1.Height) / 4);


            popUp.ShowDialog();
        }
        public void Call_Popup(string message, int size)
        {
            popUp = new PopUp();
            popUp.Size = new Size(size, size);
            popUp.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);
            popUp.label3.Text = message;

            popUp.evet.Visible = false;
            popUp.hayır.Visible = false;

            popUp.panel1.Location = new Point(
            (popUp.ClientSize.Width - popUp.panel1.Width) / 2,
            (popUp.ClientSize.Height - popUp.panel1.Height) / 2);
            popUp.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Call_Popup_Ask("Hesabı silmek istediğinize \n emin misiniz?", 400);

            if (popUp != null && popUp.IsEvetClicked)
            {
                // Delete all rows from the "list" table
                databaseManager.DeleteAllRowsFromTable("list");

                List<UserData> users = UserManager.Instance.Users;

                if (users != null && users.Count > 0)
                {
                    UserData user = users[0];

                    if (user != null)
                    {
                        if (user.UserId > 0)
                        {
                            UserManager.Instance.DeleteUser(user.UserId);
                            UserManager.Instance.Users.Clear();
                            Call_Popup("Hesabınız silindi...", 200);
                            if (selectedFilmData != null)
                                databaseManager.DeleteFilmDataFromDatabase(selectedFilmData);
                            form1.Form_Yukle(new giriş(form1));
                        }
                        else
                        {
                            MessageBox.Show("User ID is not valid.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User data is null.");
                    }
                }
                else
                {
                    MessageBox.Show("No users available.");
                }
            }
            else
            {
                popUp.Close();
            }
        }





        private void label4_Click(object sender, EventArgs e)
        {
            Call_Popup_Ask("Çıkış yapmak istediğinize \n emin misiniz?", 400);

            if (popUp != null && popUp.IsEvetClicked)
            {
                
                databaseManager.DeleteAllRowsFromTable("list");

                if (selectedFilmData != null)
                {
                    databaseManager.DeleteFilmDataFromDatabase(selectedFilmData);
                }

                form1.Form_Yukle(new giriş(form1));
                UserManager.Instance.Users.Clear();
            }
            else
            {
                popUp.Close();
            }
        }



        private void label7_Click(object sender, EventArgs e)
        {
            /*
            List<UserData> users = UserManager.Instance.Users;
            UserData user = users[0];
            PopUp popUp = new PopUp();

            if (users != null && users.Count > 0 && user.UserType == UserType.Admin)
            {
                Call_Popup_Ask("Zaten Adminsiniz\n yine de plan değiştirmek istiyor musunuz?", 400);

               
                popUp.ShowDialog();

                if (popUp.IsEvetClicked)
                {


                    popUp.Close();

                    PopUp popUp2 = new PopUp();

                    PlanDeğiştir planDeğiştir = new PlanDeğiştir(girişForm, Users, üyeolForm);
                    popUp2.Form_Yukle(planDeğiştir);


                    popUp2.ShowDialog();
                }
                else
                {
                    //Console.WriteLine("Evet button not clicked");
                }
            }
            else if (users != null && users.Count > 0 && user.UserType != UserType.Admin)
            {
                
                popUp.Show();
                PlanDeğiştir planDeğiştir = new PlanDeğiştir(girişForm, Users, üyeolForm);
                popUp.Form_Yukle(planDeğiştir);
            }
            */
            
            PopUp popUp = new PopUp();
            popUp.Show();
            PlanDeğiştir planDeğiştir = new PlanDeğiştir(girişForm, Users, üyeolForm);
            popUp.Form_Yukle(planDeğiştir);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedFilmData != null)
            {
                
                databaseManager.DeleteFilmDataFromDatabase(selectedFilmData);
                Call_Popup("Listeden Silindi", 200);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedFilmData != null)
            {
                
                anasayfa.Form_Yukle(new FilmSayfası(selectedFilmData, girişForm, Users, üyeolForm));
            }
        }
    }
}