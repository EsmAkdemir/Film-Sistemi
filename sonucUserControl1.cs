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
    public partial class sonucUserControl1 : UserControl
    {
        public event EventHandler FilmClicked;
        public sonucUserControl1()
        {
            InitializeComponent();
        }

        // Yeni bir kurucu metod ekleyin
        public sonucUserControl1(string imagePath, string FilmName, string Director, string Description, double OrtPuan, int Yorum) : this() // Diğer kurucu metodu çağırın
        {
            SetValues(imagePath, FilmName, Director, Description, OrtPuan, Yorum); 
        }

        public void SetValues(string imagePath, string FilmName, string Director, string Description, double OrtPuan, int Yorum)
        {
            // Kontrol nesnelerine değerleri atayın
            pictureBox1.ImageLocation = imagePath;
            filmAdiLabel.Text = FilmName;
            yonetmenLabel.Text = Director;
            descriptionLabel.Text = Description;
            ortpuan_label.Text = OrtPuan.ToString("N1");
            yorumSayisi_label.Text = Yorum.ToString();
            
            filmAdiLabel.MaximumSize = new Size(230, 0);
            descriptionLabel.MaximumSize = new Size(220, 0);
            yonetmenLabel.MaximumSize = new Size(130, 0);

        }

        private void OnFilmClicked()
        {
            FilmClicked?.Invoke(this, EventArgs.Empty);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // PictureBox'a tıklandığında FilmClicked olayını tetikle
            OnFilmClicked();
        }

        private void sonucUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void ortpuan_label_Click(object sender, EventArgs e)
        {

        }

    }
}