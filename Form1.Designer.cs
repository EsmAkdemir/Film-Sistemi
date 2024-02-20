
namespace FilmKütüphanesiYönetimSistemi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.Close_Button = new System.Windows.Forms.PictureBox();
            this.Minimize_Button = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.panelTitleBar.Controls.Add(this.Close_Button);
            this.panelTitleBar.Controls.Add(this.Minimize_Button);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1500, 47);
            this.panelTitleBar.TabIndex = 0;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // Close_Button
            // 
            this.Close_Button.Image = ((System.Drawing.Image)(resources.GetObject("Close_Button.Image")));
            this.Close_Button.Location = new System.Drawing.Point(1463, 12);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(16, 15);
            this.Close_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Close_Button.TabIndex = 12;
            this.Close_Button.TabStop = false;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // Minimize_Button
            // 
            this.Minimize_Button.Image = ((System.Drawing.Image)(resources.GetObject("Minimize_Button.Image")));
            this.Minimize_Button.Location = new System.Drawing.Point(1423, 12);
            this.Minimize_Button.Name = "Minimize_Button";
            this.Minimize_Button.Size = new System.Drawing.Size(16, 15);
            this.Minimize_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Minimize_Button.TabIndex = 11;
            this.Minimize_Button.TabStop = false;
            this.Minimize_Button.Click += new System.EventHandler(this.Minimize_Button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1500, 900);
            this.panel2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1500, 949);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTitleBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize_Button)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox Minimize_Button;
        private System.Windows.Forms.PictureBox Close_Button;
    }
}

