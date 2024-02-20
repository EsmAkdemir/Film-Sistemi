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
    public partial class üyeol : Form
    {
        public Boolean log = false;
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234");
        private int sayaç = 0;
        private int sayaç2 = 0;
        public List<UserData> Users { get; set; }
        public Form1 form1;
        public Profil profilForm;
        public Anasayfa anasayfa;
        public giriş girişForm;

        public giriş GirişForm
        {
            get { return girişForm; }
            set { girişForm = value; }
        }

        public üyeol(Form1 form1, giriş girişForm, Anasayfa anasayfa, Profil profilForm)
        {
            InitializeComponent();
            this.Users = new List<UserData>();
            this.form1 = form1;
            this.girişForm = girişForm;
            this.anasayfa = anasayfa;
            this.profilForm = profilForm;
        }

        private bool IsValidInput()
        {
            // Kullanıcı adı kontrolü
            if (string.IsNullOrEmpty(KullanıcıTxtBox.Text))
            {
                MessageBox.Show("Lütfen bir kullanıcı adı girin.");
                return false;
            }

            // Ad soyad kontrolü
            if (string.IsNullOrEmpty(AdSoyadTxtBox.Text))
            {
                MessageBox.Show("Lütfen adınızı ve soyadınızı girin.");
                return false;
            }

            // TC kimlik numarası kontrolü
            if (string.IsNullOrEmpty(TcNoTxtBox.Text) || !long.TryParse(TcNoTxtBox.Text, out _))
            {
                MessageBox.Show("Lütfen geçerli bir TC kimlik numarası girin.");
                return false;
            }

            // Şifre kontrolü
            if (string.IsNullOrEmpty(ŞifreTxtBox.Text) || ŞifreTxtBox.Text.Length < 6)
            {
                MessageBox.Show("Lütfen en az 6 karakterden oluşan bir şifre girin.");
                return false;
            }

            // Şifre tekrarı kontrolü
            if (ŞifreTxtBox.Text != ŞifreTxtBox2.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor. Lütfen doğru bir şekilde tekrar girin.");
                return false;
            }

            // Cinsiyet seçimi kontrolü (Opsiyonel, eğer cinsiyet seçimi yapılması gerekiyorsa)
            if (cinsiyetCmbBx.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen cinsiyetinizi seçin.");
                return false;
            }

            // Doğum tarihi kontrolü
            if (DgmTarihiDate.Value > DateTime.Now.AddYears(-18))
            {
                MessageBox.Show("Üzgünüz, sadece 18 yaş ve üzeri kullanıcılar üye olabilir.");
                return false;
            }

            // Üyelik türü seçimi kontrolü
            if (groupBox1.BackColor != System.Drawing.Color.FromArgb(215, 88, 72) &&
                groupBox2.BackColor != System.Drawing.Color.FromArgb(215, 88, 72))
            {
                MessageBox.Show("Lütfen üyelik türünüzü seçin.");
                return false;
            }

            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sayaç++;
            if (sayaç % 2 == 1)
            {
                groupBox1.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);
                StandartAylıkLabel.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);
                sayaç2 = 0; // Reset counter for groupBox2
                groupBox2.BackColor = System.Drawing.Color.Transparent; // Make sure only one is selected
                PremiumAylıkLabel.BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                groupBox1.BackColor = System.Drawing.Color.Transparent;
                StandartAylıkLabel.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            sayaç++;
            if (sayaç % 2 == 1)
            {
                groupBox1.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);
                StandartAylıkLabel.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);
                sayaç2 = 0; // Reset counter for groupBox2
                groupBox2.BackColor = System.Drawing.Color.Transparent; // Make sure only one is selected
                PremiumAylıkLabel.BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                groupBox1.BackColor = System.Drawing.Color.Transparent;
                StandartAylıkLabel.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            sayaç2++;
            if (sayaç2 % 2 == 1)
            {
                groupBox2.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);
                PremiumAylıkLabel.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);
                sayaç = 0; // Reset counter for groupBox1
                groupBox1.BackColor = System.Drawing.Color.Transparent; // Make sure only one is selected
                StandartAylıkLabel.BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                groupBox2.BackColor = System.Drawing.Color.Transparent;
                PremiumAylıkLabel.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sayaç2++;
            if (sayaç2 % 2 == 1)
            {
                groupBox2.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);
                PremiumAylıkLabel.BackColor = System.Drawing.Color.FromArgb(215, 88, 72);
                sayaç = 0; // Reset counter for groupBox1
                groupBox1.BackColor = System.Drawing.Color.Transparent; // Make sure only one is selected
                StandartAylıkLabel.BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                groupBox2.BackColor = System.Drawing.Color.Transparent;
                PremiumAylıkLabel.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void üyeol_Load(object sender, EventArgs e)
        {

            /*
            Standart_Kullanıcı standart_Kullanıcı = new Standart_Kullanıcı();
            Premium_Kullanıcı premium_Kullanıcı = new Premium_Kullanıcı();

            StandartAylıkLabel.Text = standart_Kullanıcı.Aylık_Ücret.ToString();
            PremiumAylıkLabel.Text = premium_Kullanıcı.Aylık_Ücret.ToString();
            */
        }

        private void InsertNewMember(UserData newMember)
        {
            NpgsqlCommand countCommand = new NpgsqlCommand("SELECT COUNT(*) FROM \"users\"", conn);

            conn.Open();

            // Fetch the current member count
            int currentMemberCount = Convert.ToInt32(countCommand.ExecuteScalar());

            // Close the connection for now
            conn.Close();

            // Now, increment the count to get the new userId
            int newUserId = currentMemberCount + 1;

            // Reopen the connection to insert the new member
            conn.Open();

            NpgsqlCommand insertCommand = new NpgsqlCommand();
            insertCommand.Connection = conn;
            insertCommand.CommandType = CommandType.Text;
            insertCommand.CommandText = "INSERT INTO \"users\" (username, password, \"userType\", tc, cinsiyet, dogumtarihi, adsoyad, \"userId\") VALUES (@username, @password, @userType, @tc, @cinsiyet, @dogumtarihi, @adsoyad, @userId)";

            // Add parameters
            insertCommand.Parameters.AddWithValue("@username", newMember.UserName);
            insertCommand.Parameters.AddWithValue("@password", newMember.Password);
            insertCommand.Parameters.AddWithValue("@userType", Convert.ToInt32(newMember.UserType));
            insertCommand.Parameters.AddWithValue("@tc", Convert.ToInt64(newMember.TC));
            insertCommand.Parameters.AddWithValue("@cinsiyet", Convert.ToBoolean(newMember.Cinsiyet));
            insertCommand.Parameters.AddWithValue("@dogumtarihi", newMember.DogumTarihi);
            insertCommand.Parameters.AddWithValue("@adsoyad", newMember.AdSoyad);
            insertCommand.Parameters.AddWithValue("@userId", newUserId);

            // Execute the insert query
            int rowsAffected = insertCommand.ExecuteNonQuery();

            // Close the connection after inserting
            conn.Close();

            // Check if the insert was successful
            if (rowsAffected > 0)
            {
                // Update the userId property of the new member
                newMember.UserId = newUserId;

                // Add the new member to the Users list
                this.Users.Add(newMember);

                // Now you have the new member with the correct userId, and you can use it as needed
                MessageBox.Show("New member added successfully with userId: " + newUserId);
            }
            else
            {
                MessageBox.Show("Failed to add the new member.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsValidInput())
            {
                return;
            }

            if (groupBox1.BackColor == System.Drawing.Color.FromArgb(215, 88, 72))
            {
                // Create a new Standart_Kullanıcı without specifying UserId
                Standart_Kullanıcı newMember = new Standart_Kullanıcı(
                    KullanıcıTxtBox.Text,
                    ŞifreTxtBox.Text,
                    UserType.Standard,
                    Convert.ToInt64(TcNoTxtBox.Text),
                    (cinsiyetCmbBx.SelectedItem.ToString() == "Kadın"),
                    DgmTarihiDate.Value,
                    AdSoyadTxtBox.Text,
                    0
                );

                // Save the new member to the database and retrieve the assigned UserId
                int newUserId = SaveUserAndGetUserId(newMember);

                // Update the UserId property of the new member
                newMember.UserId = newUserId;

                // Add the new member to the UserManager's Users list
                UserManager.Instance.Users.Add(newMember);

                // Now you have the new member with the correct UserId
                MessageBox.Show("New member added successfully with userId: " + newUserId);
            }
            else if(groupBox2.BackColor == System.Drawing.Color.FromArgb(215, 88, 72))
            {
                // Create a new Standart_Kullanıcı without specifying UserId
                Premium_Kullanıcı newMember = new Premium_Kullanıcı(
                    KullanıcıTxtBox.Text,
                    ŞifreTxtBox.Text,
                    UserType.Premium,
                    Convert.ToInt64(TcNoTxtBox.Text),
                    (cinsiyetCmbBx.SelectedItem.ToString() == "Kadın"),
                    DgmTarihiDate.Value,
                    AdSoyadTxtBox.Text,
                    0
                );

                // Save the new member to the database and retrieve the assigned UserId
                int newUserId = SaveUserAndGetUserId(newMember);

                // Update the UserId property of the new member
                newMember.UserId = newUserId;

                // Add the new member to the UserManager's Users list
                UserManager.Instance.Users.Add(newMember);

                // Now you have the new member with the correct UserId
                MessageBox.Show("New member added successfully with userId: " + newUserId);
            }

            form1.Form_Yukle(new Anasayfa(form1, girişForm, this, UserManager.Instance.Users, profilForm));
        }
        private int SaveUserAndGetUserId(Standart_Kullanıcı newMember)
        {
            int newUserId = 0;

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234"))
            {
                conn.Open();

                // Fetch the current member count
                NpgsqlCommand countCommand = new NpgsqlCommand("SELECT COUNT(*) FROM \"users\"", conn);
                int currentMemberCount = Convert.ToInt32(countCommand.ExecuteScalar());

                // Increment the count to get the new userId
                newUserId = currentMemberCount + 1;

                // Reopen the connection to insert the new member
                NpgsqlCommand insertCommand = new NpgsqlCommand();
                insertCommand.Connection = conn;
                insertCommand.CommandType = CommandType.Text;
                insertCommand.CommandText = "INSERT INTO \"users\" (username, password, \"userType\", tc, cinsiyet, dogumtarihi, adsoyad, \"userId\") VALUES (@username, @password, @userType, @tc, @cinsiyet, @dogumtarihi, @adsoyad, @userId)";

                // Add parameters
                insertCommand.Parameters.AddWithValue("@username", newMember.UserName);
                insertCommand.Parameters.AddWithValue("@password", newMember.Password);
                insertCommand.Parameters.AddWithValue("@userType", Convert.ToInt32(newMember.UserType));
                insertCommand.Parameters.AddWithValue("@tc", Convert.ToInt64(newMember.TC));
                insertCommand.Parameters.AddWithValue("@cinsiyet", Convert.ToBoolean(newMember.Cinsiyet));
                insertCommand.Parameters.AddWithValue("@dogumtarihi", newMember.DogumTarihi);
                insertCommand.Parameters.AddWithValue("@adsoyad", newMember.AdSoyad);
                insertCommand.Parameters.AddWithValue("@userId", newUserId);

                // Execute the insert query
                int rowsAffected = insertCommand.ExecuteNonQuery();

                // Close the connection after inserting
                conn.Close();
            }

            return newUserId;
        }
        private int SaveUserAndGetUserId(Premium_Kullanıcı newMember)
        {
            int newUserId = 0;

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234"))
            {
                conn.Open();

                // Fetch the current member count
                NpgsqlCommand countCommand = new NpgsqlCommand("SELECT COUNT(*) FROM \"users\"", conn);
                int currentMemberCount = Convert.ToInt32(countCommand.ExecuteScalar());

                // Increment the count to get the new userId
                newUserId = currentMemberCount + 1;

                // Reopen the connection to insert the new member
                NpgsqlCommand insertCommand = new NpgsqlCommand();
                insertCommand.Connection = conn;
                insertCommand.CommandType = CommandType.Text;
                insertCommand.CommandText = "INSERT INTO \"users\" (username, password, \"userType\", tc, cinsiyet, dogumtarihi, adsoyad, \"userId\") VALUES (@username, @password, @userType, @tc, @cinsiyet, @dogumtarihi, @adsoyad, @userId)";

                // Add parameters
                insertCommand.Parameters.AddWithValue("@username", newMember.UserName);
                insertCommand.Parameters.AddWithValue("@password", newMember.Password);
                insertCommand.Parameters.AddWithValue("@userType", Convert.ToInt32(newMember.UserType));
                insertCommand.Parameters.AddWithValue("@tc", Convert.ToInt64(newMember.TC));
                insertCommand.Parameters.AddWithValue("@cinsiyet", Convert.ToBoolean(newMember.Cinsiyet));
                insertCommand.Parameters.AddWithValue("@dogumtarihi", newMember.DogumTarihi);
                insertCommand.Parameters.AddWithValue("@adsoyad", newMember.AdSoyad);
                insertCommand.Parameters.AddWithValue("@userId", newUserId);

                // Execute the insert query
                int rowsAffected = insertCommand.ExecuteNonQuery();

                // Close the connection after inserting
                conn.Close();
            }

            return newUserId;
        }

        private void KullanıcıTxtBox_MouseClick(object sender, MouseEventArgs e)
        {
            girişForm.txtBoxTemizle(KullanıcıTxtBox);
        }

        private void AdSoyadTxtBox_MouseClick(object sender, MouseEventArgs e)
        {
            girişForm.txtBoxTemizle(AdSoyadTxtBox);
        }

        private void TcNoTxtBox_MouseClick(object sender, MouseEventArgs e)
        {
            girişForm.txtBoxTemizle(TcNoTxtBox);
        }

        private void ŞifreTxtBox_MouseClick(object sender, MouseEventArgs e)
        {
            girişForm.txtBoxTemizle(ŞifreTxtBox);
        }

        private void ŞifreTxtBox2_MouseClick(object sender, MouseEventArgs e)
        {
            girişForm.txtBoxTemizle(ŞifreTxtBox2);
        }
    }
}
