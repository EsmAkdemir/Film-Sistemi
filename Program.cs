using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmKütüphanesiYönetimSistemi
{
    static class Program
    {
        
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Reset application settings during development (remove in release)
#if DEBUG
                Properties.Settings.Default.Reset();
#endif

                // Check if it's the first run
                if (Properties.Settings.Default.IsFirstRun)
                {
                    // Show the splash screen
                    using (SplashScreen splashScreen = new SplashScreen())
                    {
                        splashScreen.ShowDialog();
                    }
                }

                // Run the main form
                Application.Run(new Form1());
            }
        }
    }

