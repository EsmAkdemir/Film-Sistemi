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
    public partial class PosterUserControl : UserControl
    {

        public string PosterPath{ get; private set; }

        public PosterUserControl(string posterPath, string FilmName, string Director, string Description, double OrtPuan, int Yorum)//
        {
            InitializeComponent();
            PosterPath = posterPath;
            try
            {
                pictureBox1.Image = Image.FromFile(posterPath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                FilmAdı.Text = FilmName;
                director.Text = Director;
                description.Text = Description;
                puan_label.Text = OrtPuan.ToString("N1");
                yorumSayisi_label.Text = Yorum.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void puan_label_Click(object sender, EventArgs e)
        {

        }

        public void SetLabel2Visibility(bool visible)
        {
            label2.Visible = visible;
        }

        public void SetPuanLabelVisibility(bool visible)
        {
            puan_label.Visible = visible;
        }
    }
}
