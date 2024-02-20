
namespace FilmKütüphanesiYönetimSistemi
{
    partial class PosterUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PosterUserControl));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FilmAdı = new System.Windows.Forms.Label();
            this.director = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.yonetmen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.puan_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yorumSayisi_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1481, 876);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FilmAdı
            // 
            this.FilmAdı.AutoSize = true;
            this.FilmAdı.BackColor = System.Drawing.Color.Transparent;
            this.FilmAdı.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FilmAdı.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FilmAdı.ForeColor = System.Drawing.Color.White;
            this.FilmAdı.Location = new System.Drawing.Point(90, 677);
            this.FilmAdı.Name = "FilmAdı";
            this.FilmAdı.Size = new System.Drawing.Size(174, 47);
            this.FilmAdı.TabIndex = 23;
            this.FilmAdı.Text = "Film Adı";
            // 
            // director
            // 
            this.director.AutoSize = true;
            this.director.BackColor = System.Drawing.Color.Transparent;
            this.director.Cursor = System.Windows.Forms.Cursors.Hand;
            this.director.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.director.ForeColor = System.Drawing.Color.White;
            this.director.Location = new System.Drawing.Point(260, 263);
            this.director.Name = "director";
            this.director.Size = new System.Drawing.Size(86, 23);
            this.director.TabIndex = 24;
            this.director.Text = "Director";
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.description.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.description.ForeColor = System.Drawing.Color.White;
            this.description.Location = new System.Drawing.Point(125, 83);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(422, 149);
            this.description.TabIndex = 26;
            this.description.Text = "Description\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            // 
            // yonetmen
            // 
            this.yonetmen.AutoSize = true;
            this.yonetmen.BackColor = System.Drawing.Color.Transparent;
            this.yonetmen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yonetmen.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yonetmen.ForeColor = System.Drawing.Color.White;
            this.yonetmen.Location = new System.Drawing.Point(132, 263);
            this.yonetmen.Name = "yonetmen";
            this.yonetmen.Size = new System.Drawing.Size(122, 25);
            this.yonetmen.TabIndex = 27;
            this.yonetmen.Text = "Yönetmen:\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(132, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 29;
            this.label2.Text = "Puan:\r\n";
            // 
            // puan_label
            // 
            this.puan_label.AutoSize = true;
            this.puan_label.BackColor = System.Drawing.Color.Transparent;
            this.puan_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.puan_label.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.puan_label.ForeColor = System.Drawing.Color.White;
            this.puan_label.Location = new System.Drawing.Point(208, 327);
            this.puan_label.Name = "puan_label";
            this.puan_label.Size = new System.Drawing.Size(66, 25);
            this.puan_label.TabIndex = 30;
            this.puan_label.Text = "puan";
            this.puan_label.Click += new System.EventHandler(this.puan_label_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(132, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 25);
            this.label3.TabIndex = 31;
            this.label3.Text = "Yorum sayısı:";
            // 
            // yorumSayisi_label
            // 
            this.yorumSayisi_label.AutoSize = true;
            this.yorumSayisi_label.BackColor = System.Drawing.Color.Transparent;
            this.yorumSayisi_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yorumSayisi_label.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yorumSayisi_label.ForeColor = System.Drawing.Color.White;
            this.yorumSayisi_label.Location = new System.Drawing.Point(282, 376);
            this.yorumSayisi_label.Name = "yorumSayisi_label";
            this.yorumSayisi_label.Size = new System.Drawing.Size(137, 25);
            this.yorumSayisi_label.TabIndex = 32;
            this.yorumSayisi_label.Text = "yorum sayısı";
            // 
            // PosterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.yorumSayisi_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.puan_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yonetmen);
            this.Controls.Add(this.description);
            this.Controls.Add(this.director);
            this.Controls.Add(this.FilmAdı);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PosterUserControl";
            this.Size = new System.Drawing.Size(1500, 798);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label FilmAdı;
        private System.Windows.Forms.Label director;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label yonetmen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label puan_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label yorumSayisi_label;
    }
}
