
namespace FilmKütüphanesiYönetimSistemi
{
    partial class FilmSayfası
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilmSayfası));
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.Panel();
            this.puan_label = new System.Windows.Forms.Label();
            this.btn_anasayfayaDon = new System.Windows.Forms.Button();
            this.ortpuan = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_gonder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btn_gonder);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1477, 888);
            this.panel2.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.puan_label);
            this.flowLayoutPanel2.Controls.Add(this.btn_anasayfayaDon);
            this.flowLayoutPanel2.Controls.Add(this.ortpuan);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 11);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(981, 842);
            this.flowLayoutPanel2.TabIndex = 3;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // puan_label
            // 
            this.puan_label.AutoSize = true;
            this.puan_label.BackColor = System.Drawing.Color.Transparent;
            this.puan_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.puan_label.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.puan_label.ForeColor = System.Drawing.Color.White;
            this.puan_label.Location = new System.Drawing.Point(141, 325);
            this.puan_label.Name = "puan_label";
            this.puan_label.Size = new System.Drawing.Size(64, 23);
            this.puan_label.TabIndex = 31;
            this.puan_label.Text = "Puan:";
            // 
            // btn_anasayfayaDon
            // 
            this.btn_anasayfayaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btn_anasayfayaDon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(88)))), ((int)(((byte)(72)))));
            this.btn_anasayfayaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_anasayfayaDon.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btn_anasayfayaDon.ForeColor = System.Drawing.Color.White;
            this.btn_anasayfayaDon.Location = new System.Drawing.Point(50, 797);
            this.btn_anasayfayaDon.Name = "btn_anasayfayaDon";
            this.btn_anasayfayaDon.Size = new System.Drawing.Size(105, 33);
            this.btn_anasayfayaDon.TabIndex = 28;
            this.btn_anasayfayaDon.Text = "Geri";
            this.btn_anasayfayaDon.UseVisualStyleBackColor = false;
            this.btn_anasayfayaDon.Click += new System.EventHandler(this.btn_anasayfayaDon_Click);
            // 
            // ortpuan
            // 
            this.ortpuan.AutoSize = true;
            this.ortpuan.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.ortpuan.ForeColor = System.Drawing.Color.White;
            this.ortpuan.Location = new System.Drawing.Point(211, 325);
            this.ortpuan.Name = "ortpuan";
            this.ortpuan.Size = new System.Drawing.Size(28, 23);
            this.ortpuan.TabIndex = 27;
            this.ortpuan.Text = "...";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(1015, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(392, 20);
            this.textBox1.TabIndex = 25;
            this.textBox1.Text = "puanınız(0-5)..";
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // btn_gonder
            // 
            this.btn_gonder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btn_gonder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(88)))), ((int)(((byte)(72)))));
            this.btn_gonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_gonder.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btn_gonder.ForeColor = System.Drawing.Color.White;
            this.btn_gonder.Location = new System.Drawing.Point(1342, 350);
            this.btn_gonder.Name = "btn_gonder";
            this.btn_gonder.Size = new System.Drawing.Size(105, 33);
            this.btn_gonder.TabIndex = 24;
            this.btn_gonder.Text = "Gönder";
            this.btn_gonder.UseVisualStyleBackColor = false;
            this.btn_gonder.Click += new System.EventHandler(this.btn_gonder_Click_1);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1011, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 453);
            this.panel1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.richTextBox1.Location = new System.Drawing.Point(1035, 210);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(382, 80);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "yorumunuz..";
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(991, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(456, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(991, 153);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(466, 191);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // FilmSayfası
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FilmSayfası";
            this.Text = "FilmSayfası";
            this.Load += new System.EventHandler(this.FilmSayfası_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel flowLayoutPanel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_gonder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_anasayfayaDon;
        private System.Windows.Forms.Label puan_label;
        private System.Windows.Forms.Label ortpuan;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}