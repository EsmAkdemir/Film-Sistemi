
namespace FilmKütüphanesiYönetimSistemi
{
    partial class PopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUp));
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Close_Button = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hayır = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.evet = new System.Windows.Forms.Button();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(88)))), ((int)(((byte)(72)))));
            this.panelTitleBar.Controls.Add(this.pictureBox1);
            this.panelTitleBar.Controls.Add(this.Close_Button);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(852, 40);
            this.panelTitleBar.TabIndex = 35;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(828, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(12, 12);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.Image = ((System.Drawing.Image)(resources.GetObject("Close_Button.Image")));
            this.Close_Button.Location = new System.Drawing.Point(999, 12);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(12, 12);
            this.Close_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Close_Button.TabIndex = 33;
            this.Close_Button.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 492);
            this.panel2.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hayır);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.evet);
            this.panel1.Location = new System.Drawing.Point(262, 187);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 100);
            this.panel1.TabIndex = 92;
            // 
            // hayır
            // 
            this.hayır.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.hayır.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(88)))), ((int)(((byte)(72)))));
            this.hayır.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hayır.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.hayır.ForeColor = System.Drawing.Color.White;
            this.hayır.Location = new System.Drawing.Point(150, 58);
            this.hayır.Name = "hayır";
            this.hayır.Size = new System.Drawing.Size(115, 30);
            this.hayır.TabIndex = 91;
            this.hayır.Text = "Hayır";
            this.hayır.UseVisualStyleBackColor = false;
            this.hayır.Click += new System.EventHandler(this.hayır_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.label3.Location = new System.Drawing.Point(85, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 89;
            this.label3.Text = "Aylık Ücret";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // evet
            // 
            this.evet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.evet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(88)))), ((int)(((byte)(72)))));
            this.evet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.evet.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.evet.ForeColor = System.Drawing.Color.White;
            this.evet.Location = new System.Drawing.Point(15, 58);
            this.evet.Name = "evet";
            this.evet.Size = new System.Drawing.Size(115, 30);
            this.evet.TabIndex = 90;
            this.evet.Text = "Evet";
            this.evet.UseVisualStyleBackColor = false;
            this.evet.Click += new System.EventHandler(this.evet_Click);
            // 
            // PopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 532);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlanDeğişikliği";
            this.panelTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.PictureBox Close_Button;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button hayır;
        public System.Windows.Forms.Button evet;
        public System.Windows.Forms.Panel panel1;
    }
}