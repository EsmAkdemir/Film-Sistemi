
namespace FilmKütüphanesiYönetimSistemi
{
    partial class Anasayfa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anasayfa));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.aramaLabel = new System.Windows.Forms.Label();
            this.profilfoto = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.Panel();
            this.btn_listeyeEkle = new System.Windows.Forms.Button();
            this.btn_goruntule = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilfoto)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.aramaLabel);
            this.panel1.Controls.Add(this.profilfoto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 60);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(948, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 29;
            this.label4.Text = "Admin";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // aramaLabel
            // 
            this.aramaLabel.AutoSize = true;
            this.aramaLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.aramaLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aramaLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aramaLabel.ForeColor = System.Drawing.Color.White;
            this.aramaLabel.Location = new System.Drawing.Point(1087, 23);
            this.aramaLabel.Name = "aramaLabel";
            this.aramaLabel.Size = new System.Drawing.Size(64, 19);
            this.aramaLabel.TabIndex = 28;
            this.aramaLabel.Text = "Arama\r\n";
            this.aramaLabel.Click += new System.EventHandler(this.aramaLabel_Click);
            // 
            // profilfoto
            // 
            this.profilfoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profilfoto.Image = ((System.Drawing.Image)(resources.GetObject("profilfoto.Image")));
            this.profilfoto.Location = new System.Drawing.Point(1436, 5);
            this.profilfoto.Name = "profilfoto";
            this.profilfoto.Size = new System.Drawing.Size(51, 50);
            this.profilfoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilfoto.TabIndex = 26;
            this.profilfoto.TabStop = false;
            this.profilfoto.Click += new System.EventHandler(this.profilfoto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1363, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "Profil";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1223, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Anasayfa";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1500, 1400);
            this.panel2.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btn_listeyeEkle);
            this.flowLayoutPanel2.Controls.Add(this.btn_goruntule);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1494, 744);
            this.flowLayoutPanel2.TabIndex = 2;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // btn_listeyeEkle
            // 
            this.btn_listeyeEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btn_listeyeEkle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(88)))), ((int)(((byte)(72)))));
            this.btn_listeyeEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_listeyeEkle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btn_listeyeEkle.ForeColor = System.Drawing.Color.White;
            this.btn_listeyeEkle.Location = new System.Drawing.Point(1251, 544);
            this.btn_listeyeEkle.Name = "btn_listeyeEkle";
            this.btn_listeyeEkle.Size = new System.Drawing.Size(184, 59);
            this.btn_listeyeEkle.TabIndex = 24;
            this.btn_listeyeEkle.Text = "Listeye Ekle";
            this.btn_listeyeEkle.UseVisualStyleBackColor = false;
            this.btn_listeyeEkle.Click += new System.EventHandler(this.btn_listeyeEkle_Click);
            // 
            // btn_goruntule
            // 
            this.btn_goruntule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btn_goruntule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(88)))), ((int)(((byte)(72)))));
            this.btn_goruntule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_goruntule.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btn_goruntule.ForeColor = System.Drawing.Color.White;
            this.btn_goruntule.Location = new System.Drawing.Point(1251, 631);
            this.btn_goruntule.Name = "btn_goruntule";
            this.btn_goruntule.Size = new System.Drawing.Size(184, 59);
            this.btn_goruntule.TabIndex = 23;
            this.btn_goruntule.Text = "Görüntüle";
            this.btn_goruntule.UseVisualStyleBackColor = false;
            this.btn_goruntule.Click += new System.EventHandler(this.btn_goruntule_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(73, 777);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1335, 600);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1500, 1100);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Anasayfa";
            this.Text = "Anasayfa";
            this.Load += new System.EventHandler(this.Anasayfa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilfoto)).EndInit();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox profilfoto;
        private System.Windows.Forms.Panel flowLayoutPanel2;
        private System.Windows.Forms.Button btn_goruntule;
        private System.Windows.Forms.Button btn_listeyeEkle;
        private System.Windows.Forms.Label aramaLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}