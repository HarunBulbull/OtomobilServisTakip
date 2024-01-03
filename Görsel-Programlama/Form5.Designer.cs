namespace Görsel_Programlama
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.baglanti = new System.Windows.Forms.Label();
            this.durum = new System.Windows.Forms.Panel();
            this.vt_sunucu = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.vt_kontrol = new Guna.UI2.WinForms.Guna2Button();
            this.vt_sifre = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.vt_kullanıcı = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Kapat = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kapat)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // baglanti
            // 
            this.baglanti.AutoSize = true;
            this.baglanti.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baglanti.ForeColor = System.Drawing.Color.White;
            this.baglanti.Location = new System.Drawing.Point(38, 233);
            this.baglanti.Name = "baglanti";
            this.baglanti.Size = new System.Drawing.Size(93, 16);
            this.baglanti.TabIndex = 17;
            this.baglanti.Text = "Bağlantı yok!";
            // 
            // durum
            // 
            this.durum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.durum.Location = new System.Drawing.Point(12, 231);
            this.durum.Name = "durum";
            this.durum.Size = new System.Drawing.Size(20, 20);
            this.durum.TabIndex = 16;
            // 
            // vt_sunucu
            // 
            this.vt_sunucu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.vt_sunucu.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vt_sunucu.ForeColor = System.Drawing.Color.White;
            this.vt_sunucu.HintForeColor = System.Drawing.Color.Empty;
            this.vt_sunucu.HintText = "";
            this.vt_sunucu.isPassword = false;
            this.vt_sunucu.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(52)))));
            this.vt_sunucu.LineIdleColor = System.Drawing.Color.Gray;
            this.vt_sunucu.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(52)))));
            this.vt_sunucu.LineThickness = 3;
            this.vt_sunucu.Location = new System.Drawing.Point(12, 43);
            this.vt_sunucu.Margin = new System.Windows.Forms.Padding(4);
            this.vt_sunucu.Name = "vt_sunucu";
            this.vt_sunucu.Size = new System.Drawing.Size(279, 41);
            this.vt_sunucu.TabIndex = 12;
            this.vt_sunucu.Text = "SUNUCU";
            this.vt_sunucu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.vt_sunucu.Enter += new System.EventHandler(this.vt_sunucu_Enter);
            this.vt_sunucu.Leave += new System.EventHandler(this.vt_sunucu_Leave);
            // 
            // vt_kontrol
            // 
            this.vt_kontrol.Animated = true;
            this.vt_kontrol.AutoRoundedCorners = true;
            this.vt_kontrol.BackColor = System.Drawing.Color.Transparent;
            this.vt_kontrol.BorderRadius = 17;
            this.vt_kontrol.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.vt_kontrol.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.vt_kontrol.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.vt_kontrol.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.vt_kontrol.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(52)))));
            this.vt_kontrol.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.vt_kontrol.ForeColor = System.Drawing.Color.White;
            this.vt_kontrol.Location = new System.Drawing.Point(12, 189);
            this.vt_kontrol.Name = "vt_kontrol";
            this.vt_kontrol.Size = new System.Drawing.Size(279, 36);
            this.vt_kontrol.TabIndex = 15;
            this.vt_kontrol.Text = "BAĞLAN";
            this.vt_kontrol.UseTransparentBackground = true;
            this.vt_kontrol.Click += new System.EventHandler(this.vt_kontrol_Click);
            // 
            // vt_sifre
            // 
            this.vt_sifre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.vt_sifre.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vt_sifre.ForeColor = System.Drawing.Color.White;
            this.vt_sifre.HintForeColor = System.Drawing.Color.Empty;
            this.vt_sifre.HintText = "";
            this.vt_sifre.isPassword = false;
            this.vt_sifre.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(52)))));
            this.vt_sifre.LineIdleColor = System.Drawing.Color.Gray;
            this.vt_sifre.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(52)))));
            this.vt_sifre.LineThickness = 3;
            this.vt_sifre.Location = new System.Drawing.Point(12, 141);
            this.vt_sifre.Margin = new System.Windows.Forms.Padding(4);
            this.vt_sifre.Name = "vt_sifre";
            this.vt_sifre.Size = new System.Drawing.Size(279, 41);
            this.vt_sifre.TabIndex = 14;
            this.vt_sifre.Text = "ŞİFRE";
            this.vt_sifre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.vt_sifre.Enter += new System.EventHandler(this.vt_sifre_Enter);
            this.vt_sifre.Leave += new System.EventHandler(this.vt_sifre_Leave);
            // 
            // vt_kullanıcı
            // 
            this.vt_kullanıcı.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.vt_kullanıcı.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vt_kullanıcı.ForeColor = System.Drawing.Color.White;
            this.vt_kullanıcı.HintForeColor = System.Drawing.Color.Empty;
            this.vt_kullanıcı.HintText = "";
            this.vt_kullanıcı.isPassword = false;
            this.vt_kullanıcı.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(52)))));
            this.vt_kullanıcı.LineIdleColor = System.Drawing.Color.Gray;
            this.vt_kullanıcı.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(52)))));
            this.vt_kullanıcı.LineThickness = 3;
            this.vt_kullanıcı.Location = new System.Drawing.Point(12, 92);
            this.vt_kullanıcı.Margin = new System.Windows.Forms.Padding(4);
            this.vt_kullanıcı.Name = "vt_kullanıcı";
            this.vt_kullanıcı.Size = new System.Drawing.Size(279, 41);
            this.vt_kullanıcı.TabIndex = 13;
            this.vt_kullanıcı.Text = "KULLANICI";
            this.vt_kullanıcı.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.vt_kullanıcı.Enter += new System.EventHandler(this.vt_kullanıcı_Enter);
            this.vt_kullanıcı.Leave += new System.EventHandler(this.vt_kullanıcı_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Kapat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 30);
            this.panel1.TabIndex = 18;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(0, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(30, 30);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 24;
            this.pictureBox7.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "VERİ TABANI";
            // 
            // Kapat
            // 
            this.Kapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Kapat.Dock = System.Windows.Forms.DockStyle.Right;
            this.Kapat.Image = ((System.Drawing.Image)(resources.GetObject("Kapat.Image")));
            this.Kapat.Location = new System.Drawing.Point(274, 0);
            this.Kapat.Name = "Kapat";
            this.Kapat.Size = new System.Drawing.Size(30, 30);
            this.Kapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Kapat.TabIndex = 0;
            this.Kapat.TabStop = false;
            this.Kapat.Click += new System.EventHandler(this.Kapat_Click);
            this.Kapat.MouseLeave += new System.EventHandler(this.Kapat_MouseLeave);
            this.Kapat.MouseHover += new System.EventHandler(this.Kapat_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(304, 263);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.baglanti);
            this.Controls.Add(this.durum);
            this.Controls.Add(this.vt_sunucu);
            this.Controls.Add(this.vt_kontrol);
            this.Controls.Add(this.vt_sifre);
            this.Controls.Add(this.vt_kullanıcı);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veri Tabanı";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kapat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label baglanti;
        private System.Windows.Forms.Panel durum;
        private Bunifu.Framework.UI.BunifuMaterialTextbox vt_sunucu;
        private Guna.UI2.WinForms.Guna2Button vt_kontrol;
        private Bunifu.Framework.UI.BunifuMaterialTextbox vt_sifre;
        private Bunifu.Framework.UI.BunifuMaterialTextbox vt_kullanıcı;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Kapat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}