namespace Görsel_Programlama
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.kg_filtre = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.kg_gelir = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Kapat = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            // kg_filtre
            // 
            this.kg_filtre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kg_filtre.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kg_filtre.ForeColor = System.Drawing.Color.White;
            this.kg_filtre.HintForeColor = System.Drawing.Color.Empty;
            this.kg_filtre.HintText = "";
            this.kg_filtre.isPassword = false;
            this.kg_filtre.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(52)))));
            this.kg_filtre.LineIdleColor = System.Drawing.Color.Gray;
            this.kg_filtre.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(52)))));
            this.kg_filtre.LineThickness = 3;
            this.kg_filtre.Location = new System.Drawing.Point(11, 158);
            this.kg_filtre.Margin = new System.Windows.Forms.Padding(4);
            this.kg_filtre.Name = "kg_filtre";
            this.kg_filtre.Size = new System.Drawing.Size(291, 41);
            this.kg_filtre.TabIndex = 4;
            this.kg_filtre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kg_filtre.OnValueChanged += new System.EventHandler(this.kg_filtre_OnValueChanged);
            this.kg_filtre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kg_filtre_KeyPress);
            // 
            // kg_gelir
            // 
            this.kg_gelir.Animated = true;
            this.kg_gelir.AutoRoundedCorners = true;
            this.kg_gelir.BackColor = System.Drawing.Color.Transparent;
            this.kg_gelir.BorderRadius = 15;
            this.kg_gelir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.kg_gelir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.kg_gelir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.kg_gelir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.kg_gelir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(52)))));
            this.kg_gelir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.kg_gelir.ForeColor = System.Drawing.Color.White;
            this.kg_gelir.Location = new System.Drawing.Point(11, 211);
            this.kg_gelir.Name = "kg_gelir";
            this.kg_gelir.Size = new System.Drawing.Size(291, 32);
            this.kg_gelir.TabIndex = 11;
            this.kg_gelir.Text = "GELİR EKLE";
            this.kg_gelir.UseTransparentBackground = true;
            this.kg_gelir.Click += new System.EventHandler(this.kg_gelir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 112);
            this.label1.TabIndex = 12;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Kapat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 30);
            this.panel1.TabIndex = 14;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "GELİR EKLE";
            // 
            // Kapat
            // 
            this.Kapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Kapat.Dock = System.Windows.Forms.DockStyle.Right;
            this.Kapat.Image = ((System.Drawing.Image)(resources.GetObject("Kapat.Image")));
            this.Kapat.Location = new System.Drawing.Point(289, 0);
            this.Kapat.Name = "Kapat";
            this.Kapat.Size = new System.Drawing.Size(30, 30);
            this.Kapat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Kapat.TabIndex = 0;
            this.Kapat.TabStop = false;
            this.Kapat.Click += new System.EventHandler(this.Kapat_Click);
            this.Kapat.MouseLeave += new System.EventHandler(this.Kapat_MouseLeave);
            this.Kapat.MouseHover += new System.EventHandler(this.Kapat_MouseHover);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(319, 255);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kg_gelir);
            this.Controls.Add(this.kg_filtre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gelir Ekle";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kapat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox kg_filtre;
        private Guna.UI2.WinForms.Guna2Button kg_gelir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Kapat;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
    }
}