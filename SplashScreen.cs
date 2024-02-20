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
    public partial class SplashScreen : Form
    {
        private Timer delayTimer;
        private Timer growthTimer;
        private int growthRate = 10; // You can adjust this value to control the growth rate
        private int initialDelay = 400;

        public SplashScreen()
        {
            InitializeComponent();
            InitializeTimers();
        }

        private void InitializeTimers()
        {
            // Timer for initial delay
            delayTimer = new Timer();
            delayTimer.Interval = initialDelay;
            delayTimer.Tick += DelayTimer_Tick;
            delayTimer.Start();

            // Timer for growth after the initial delay
            growthTimer = new Timer();
            growthTimer.Interval = 50; // Adjust the interval as needed
            growthTimer.Tick += GrowthTimer_Tick;
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();

            // Start the growth timer after the initial delay
            growthTimer.Start();
        }

        private void GrowthTimer_Tick(object sender, EventArgs e)
        {
            // Calculate the growth of width and height
            int growth = growthRate;

            // Increase the height and width of the PictureBox
            pictureBox1.Width += growth;
            pictureBox1.Height += growth;

            // Calculate the new position to keep the PictureBox centered
            int newX = (this.Width - pictureBox1.Width) / 2;
            int newY = (this.Height - pictureBox1.Height) / 2;

            // Set the new location of the PictureBox
            pictureBox1.Location = new Point(newX, newY);

            // Invalidate the PictureBox to force a redraw
            pictureBox1.Invalidate();

            // Check if the desired size is reached
            if (pictureBox1.Width >= 300 && pictureBox1.Height >= 200)
            {
                growthTimer.Stop();
                // Optionally, close the splash screen or switch to the main form
                this.Close();

                // Set the IsFirstRun setting to false
                Properties.Settings.Default.IsFirstRun = false;
                Properties.Settings.Default.Save();
            }
        }
    }


}

