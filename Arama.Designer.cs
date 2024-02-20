
namespace FilmKütüphanesiYönetimSistemi
{
    partial class Arama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arama));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.btn_puan = new System.Windows.Forms.Button();
            this.btn_yorum = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(194)))), ((int)(((byte)(157)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(475, 252);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(970, 670);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // txtArama
            // 
            this.txtArama.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtArama.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtArama.Location = new System.Drawing.Point(851, 143);
            this.txtArama.Multiline = true;
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(460, 40);
            this.txtArama.TabIndex = 7;
            this.txtArama.Text = "Film/Yönetmen adı ya da Tür giriniz...";
            this.txtArama.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtArama_MouseClick_1);
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged_1);
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btnAra.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(88)))), ((int)(((byte)(72)))));
            this.btnAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAra.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnAra.ForeColor = System.Drawing.Color.White;
            this.btnAra.Location = new System.Drawing.Point(1360, 143);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(87, 40);
            this.btnAra.TabIndex = 26;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btn_puan
            // 
            this.btn_puan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btn_puan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(88)))), ((int)(((byte)(72)))));
            this.btn_puan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_puan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btn_puan.ForeColor = System.Drawing.Color.White;
            this.btn_puan.Location = new System.Drawing.Point(56, 317);
            this.btn_puan.Name = "btn_puan";
            this.btn_puan.Size = new System.Drawing.Size(195, 90);
            this.btn_puan.TabIndex = 27;
            this.btn_puan.Text = "PUANA GÖRE SIRALA";
            this.btn_puan.UseVisualStyleBackColor = false;
            this.btn_puan.Click += new System.EventHandler(this.btn_puan_Click);
            // 
            // btn_yorum
            // 
            this.btn_yorum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btn_yorum.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(88)))), ((int)(((byte)(72)))));
            this.btn_yorum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_yorum.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btn_yorum.ForeColor = System.Drawing.Color.White;
            this.btn_yorum.Location = new System.Drawing.Point(56, 460);
            this.btn_yorum.Name = "btn_yorum";
            this.btn_yorum.Size = new System.Drawing.Size(195, 90);
            this.btn_yorum.TabIndex = 28;
            this.btn_yorum.Text = "YORUM SAYISINA GÖRE SIRALA";
            this.btn_yorum.UseVisualStyleBackColor = false;
            this.btn_yorum.Click += new System.EventHandler(this.btn_yorum_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(814, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1179, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(323, 319);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(-27, -3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(373, 1002);
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(511, 150);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(103, 118);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(671, 94);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(208, 174);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 33;
            this.pictureBox5.TabStop = false;
            // 
            // Arama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1500, 946);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_yorum);
            this.Controls.Add(this.btn_puan);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Arama";
            this.Text = "Arama";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Button btn_puan;
        private System.Windows.Forms.Button btn_yorum;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}