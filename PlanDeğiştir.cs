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
    public partial class PlanDeğiştir : Form
    {
        public giriş girişForm;
        private int sayaç = 0;
        private int sayaç2 = 0;
        public üyeol üyeolForm;
        public List<UserData> Users { get; set; }
        public PlanDeğiştir(giriş girişForm, List<UserData> users, üyeol üyeolForm)
        {
            this.girişForm = girişForm;
            this.Users = users;
            this.üyeolForm = üyeolForm;
            InitializeComponent();
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
       

        private void button1_Click(object sender, EventArgs e)
        {

            List<UserData> users = UserManager.Instance.Users;
            UserData user = users[0];
            PopUp popUp = new PopUp();
            if (groupBox1.BackColor == System.Drawing.Color.FromArgb(215, 88, 72))
            {
                user.UserType = UserType.Standard;
                popUp.Size = new Size(200, 200);
                popUp.evet.Visible = false;
                popUp.hayır.Visible = false;
                popUp.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(32, 32, 51);
                popUp.Show();
                popUp.label3.Text = "Üyeliğiniz güncellenmiştir";
               
                popUp.panel1.Location = new Point(
                (popUp.ClientSize.Width - popUp.panel1.Width) / 2,
                (popUp.ClientSize.Height - popUp.panel1.Height) / 2);
                if (popUp.isPb1Clicked == true)
                {
                    ActiveForm.Close();
                }


            }
            else if (groupBox2.BackColor == System.Drawing.Color.FromArgb(215, 88, 72))
            {
                user.UserType = UserType.Premium;
                popUp.Size = new Size(200, 200);
                popUp.evet.Visible = false;
                popUp.hayır.Visible = false;
                popUp.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(32, 32, 51);
                popUp.Show();
                popUp.label3.Text = "Üyeliğiniz güncellenmiştir";

                popUp.panel1.Location = new Point(
                 (popUp.ClientSize.Width - popUp.panel1.Width) / 2,
                 (popUp.ClientSize.Height - popUp.panel1.Height) / 2);
                if (popUp.isPb1Clicked == true)
                {
                    ActiveForm.Close();
                }
            }

        }

    }
}
