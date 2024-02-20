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
namespace FilmKütüphanesiYönetimSistemi
{
    public partial class PopUp : Form
    {
        private bool isTitleBarClicked = false;
        public bool isPb1Clicked = false;
        public bool IsEvetClicked { get; private set; }

        public PopUp()
        {
            InitializeComponent();
        }
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
            Console.WriteLine("tr");
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();
        }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
            isPb1Clicked = true;
        }

        private void evet_Click(object sender, EventArgs e)
        {
            IsEvetClicked = true;
            this.Close();
        }
        private void hayır_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
