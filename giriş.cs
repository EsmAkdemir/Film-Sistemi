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
    public partial class giriş : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234");
        private Form1 form1;
        private Anasayfa anasayfa;
        public Profil profilForm;

        public üyeol üyeolForm;
        public PopUp popUp;

        public List<UserData> Users { get; set; }

        public giriş(Form1 form1)
        {
            InitializeComponent();
            this.Users = new List<UserData>();
            this.form1 = form1;
            this.anasayfa = new Anasayfa(form1, this, üyeolForm, Users, profilForm);
            
        }

        public bool AuthenticateUser(UserData user)
        {
            conn.Open();

        
            string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password AND \"userType\" = @userType";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@username", user.UserName);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@userType", (int)user.UserType);

            int result = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();

           
            return result > 0;
        }

        public UserData GetUserFromDatabase(string username, string password)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM \"users\" WHERE username = @username AND password = @password";

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            NpgsqlDataReader reader = command.ExecuteReader();

            UserData userData = null;

            if (reader.Read())
            {
                userData = new UserData(
                    reader["username"].ToString(),
                    reader["password"].ToString(),
                    (UserType)Convert.ToInt32(reader["userType"]),
                    Convert.ToInt64(reader["tc"]),
                    Convert.ToBoolean(reader["cinsiyet"]),
                    Convert.ToDateTime(reader["dogumtarihi"]),
                    reader["adsoyad"].ToString(),
                    Convert.ToInt32(reader["userId"])
                );

                Users.Add(userData);
            }

            conn.Close();

            return userData;
        }

        private void AuthenticateAndLoadForm()
        {
            UserData user = GetUserFromDatabase(KullanıcıTxtBox.Text, ŞifreTxtBox.Text);

            if (user != null && AuthenticateUser(user))
            {
                MessageBox.Show($"{user.UserType} {user.UserName} hoş geldiniz...");

                üyeolForm = new üyeol(form1, this, anasayfa, profilForm);
                form1.Form_Yukle(anasayfa);
            }
            else
            {
                MessageBox.Show("Invalid username, password, or user type");
            }
        }
        public UserData User_Set(string username, string password)
        {
            conn.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "SELECT * FROM \"users\" WHERE username = @username AND password = @password";

            komut.Parameters.AddWithValue("@username", username);
            komut.Parameters.AddWithValue("@password", password);

            NpgsqlDataReader reader = komut.ExecuteReader();

            UserData userData = null;

            if (reader.Read())
            {
                userData = new UserData(
                    reader["username"].ToString(),
                    reader["password"].ToString(),
                    (UserType)Convert.ToInt32(reader["userType"]),
                    Convert.ToInt64(reader["tc"]),
                    Convert.ToBoolean(reader["cinsiyet"]),
                    Convert.ToDateTime(reader["dogumtarihi"]),
                    reader["adsoyad"].ToString(),
                    Convert.ToInt32(reader["userId"])
                );

                // Add the retrieved user to UserManager.Instance.Users
                UserManager.Instance.Users.Add(userData);
            }

            conn.Close();

            return userData;
        }
        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            UserData user = User_Set(KullanıcıTxtBox.Text, ŞifreTxtBox.Text);

            if (user != null)
            {
                if (AuthenticateUser(user))
                {
                   
                    UserManager.Instance.Users.Add(user);

                    /*
                    switch (user.UserType)
                    {
                        case UserType.Admin:
                            MessageBox.Show(user.UserType + " " + user.UserName + " hoş geldiniz...");
                            break;
                        case UserType.Premium:
                            MessageBox.Show(user.UserType + " " + user.UserName + " hoş geldiniz...");
                            break;
                        case UserType.Standard:
                            MessageBox.Show(user.UserType + " " + user.UserName + " hoş geldiniz...");
                            break;
                        default:
                            // Handle other cases if needed
                            break;
                    }
                    */
                    form1.Form_Yukle(anasayfa);
                    
                }
                else
                {
                    MessageBox.Show("Invalid username, password, or user type");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            UserData user = User_Set(KullanıcıTxtBox.Text, ŞifreTxtBox.Text);

            if (user != null)
            {
                if (AuthenticateUser(user))
                {
                    
                    UserManager.Instance.Users.Add(user);

                    /*
                    switch (user.UserType)
                    {
                        case UserType.Admin:
                            MessageBox.Show(user.UserType + " " + user.UserName + " hoş geldiniz...");
                            break;
                        case UserType.Premium:
                            MessageBox.Show(user.UserType + " " + user.UserName + " hoş geldiniz...");
                            break;
                        case UserType.Standard:
                           
                            MessageBox.Show(user.UserType + " " + user.UserName + " hoş geldiniz...");
                            break;
                        default:
                            // Handle other cases if needed
                            break;
                    }
                    */
                    form1.Form_Yukle(anasayfa);
                    
                }
                else
                {
                    MessageBox.Show("geçersiz giriş");
                }
            }
            else
            {
                MessageBox.Show("geçersiz giriş");
            }
        }


        public void txtBoxTemizle(TextBox txt)
        {
            txt.Text = "";
        }

        private void KullanıcıTxtBox_MouseClick(object sender, MouseEventArgs e)
        {
            txtBoxTemizle(KullanıcıTxtBox);
        }

        private void ŞifreTxtBox_MouseClick(object sender, MouseEventArgs e)
        {
            txtBoxTemizle(ŞifreTxtBox);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            form1.Form_Yukle(new üyeol(form1, this, anasayfa, profilForm));
        }

        private void giriş_Load(object sender, EventArgs e)
        {
           
        }
    }
}
