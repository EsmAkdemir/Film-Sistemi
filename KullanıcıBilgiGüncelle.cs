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
    public partial class KullanıcıAdıŞifreDeğiştir : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234");
        private bool isTitleBarClicked = false;
        public UserData userData;
        public giriş girişForm;
        public Form1 form1;
        public Anasayfa anasayfa;
        public List<FilmData> selectedFilmsList;
        public üyeol üyeolForm;
        public List<UserData> Users { get; set; }
        public KullanıcıAdıŞifreDeğiştir(giriş girişForm, List<UserData> users)
        {
            InitializeComponent();
            this.girişForm = girişForm;
            this.Users = users;
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
            Profil profil = new Profil(girişForm, Users, anasayfa, form1, üyeolForm, selectedFilmsList);
            profil.Kullanıcı_Bilgileri(UserManager.Instance.Users[0]);
            KullanıcıAdıŞifreDeğiştir.ActiveForm.Close();
        }
        private void KullanıcıAdıŞifreDeğiştir_FormClosing(object sender, FormClosingEventArgs e)
        {
            Profil profil = new Profil(girişForm, Users, anasayfa, form1, üyeolForm, selectedFilmsList);
            profil.ProfilUpdate();
        }
        public void SetUserData()
        {
            List<UserData> users = UserManager.Instance.Users;

            if (users != null && users.Count > 0)
            {
                UserData user = users[0];
                KullanıcıTxtBox.Text = user.UserName;


                cinsiyetCmbBx.SelectedIndex = user.Cinsiyet ? 0 : 1;


                DgmTarihiDate.Value = user.DogumTarihi;

                AdSoyadTxtBox.Text = user.AdSoyad;

                TcNoTxtBox.Text = user.TC.ToString();
            }
        }
        private void KullanıcıAdıŞifreDeğiştir_Load(object sender, EventArgs e)
        {
            SetUserData();
            ŞifreTxtBox.Text = "";
            ŞifreTxtBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<UserData> users = UserManager.Instance.Users;

            if (users != null && users.Count > 0)
            {
                UserData user = users[0];

                // Check if the passwords match
                if (ŞifreTxtBox.Text != ŞifreTxtBox2.Text)
                {
                    MessageBox.Show("Şifreniz eşleşmeli.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                 if(ŞifreTxtBox.Text == "")
                {
                    MessageBox.Show("Şifreniz boş kalamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the user's data with the new values from text boxes
                user.UserName = KullanıcıTxtBox.Text;
                user.Password = ŞifreTxtBox.Text;
                user.TC = Convert.ToInt64(TcNoTxtBox.Text);
                //user.Cinsiyet = Convert.ToBoolean(cinsiyetCmbBx.SelectedItem);
                user.DogumTarihi = Convert.ToDateTime(DgmTarihiDate.Value);
                user.AdSoyad = AdSoyadTxtBox.Text;

                // Optionally, display a message to indicate the update
                MessageBox.Show("User data updated successfully.");

                // Call the method to update the database
                UpdateDatabase(user);

            }
            else
            {
                MessageBox.Show("No users available.");
            }
        }

        private void KullanıcıAdıŞifreDeğiştir_FormClosed(object sender, FormClosedEventArgs e)
        {
            Profil profil = new Profil(girişForm, Users, anasayfa, form1, üyeolForm, selectedFilmsList);
            // Refresh the Profil form when the KullanıcıAdıŞifreDeğiştir form is closed
            profil.ProfilUpdate();
        }

        private void UpdateDatabase(UserData user)
        {
            

            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "UPDATE users SET username = @username, password = @password, tc = @tc, cinsiyet = @cinsiyet, dogumtarihi = @dogumtarihi, adsoyad = @adsoyad WHERE \"userId\" = @userId";

            // Add parameters
            komut.Parameters.AddWithValue("@username", user.UserName);
            komut.Parameters.AddWithValue("@password", user.Password);
            komut.Parameters.AddWithValue("@userType", Convert.ToInt32(user.UserType));
            komut.Parameters.AddWithValue("@tc", Convert.ToInt64(user.TC));
            komut.Parameters.AddWithValue("@cinsiyet", Convert.ToBoolean(user.Cinsiyet));
            komut.Parameters.AddWithValue("@dogumtarihi", Convert.ToDateTime(user.DogumTarihi));
            komut.Parameters.AddWithValue("@adsoyad", user.AdSoyad);
            komut.Parameters.AddWithValue("@userId", Convert.ToInt32(user.UserId));


            conn.Open();
           // komut.ExecuteNonQuery();
            int rowsAffected = komut.ExecuteNonQuery();

            conn.Close();
        }

        private void KullanıcıTxtBox_MouseClick(object sender, MouseEventArgs e)
        {
            girişForm.txtBoxTemizle(KullanıcıTxtBox);
        }

        private void ŞifreTxtBox_MouseClick(object sender, MouseEventArgs e)
        {
            girişForm.txtBoxTemizle(ŞifreTxtBox);
        }

        private void ŞifreTxtBox2_MouseClick(object sender, MouseEventArgs e)
        {
            girişForm.txtBoxTemizle(ŞifreTxtBox2);
        }

        private void AdSoyadTxtBox_Click(object sender, EventArgs e)
        {
            girişForm.txtBoxTemizle(AdSoyadTxtBox);
        }

        private void TcNoTxtBox_Click(object sender, EventArgs e)
        {
            girişForm.txtBoxTemizle(TcNoTxtBox);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
