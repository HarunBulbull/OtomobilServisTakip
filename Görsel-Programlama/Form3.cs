using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Görsel_Programlama
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            FormClosing += Form2_FormClosing;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            x = 0;
            label1.Text = "Seçtiğiniz kayıt için tahmini gelir\n" + gelir + " TL olarak hesaplanmıştır.\nEğer farklı bir gelir girmek isterseniz\naşağıdaki alana girebilirsiniz.\nAşağıdaki alanı boş bırakmanız durumunda\ntahmini gelir kaydedilecektir.";
            kg_filtre.ForeColor = Color.White;
            kg_filtre.Text = gelir.ToString();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (x != 9999)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        public int gelir;
        int x;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            x = 9999;
            this.Close();
        }

        private void kg_filtre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kg_gelir_Click(object sender, EventArgs e)
        {
            if(kg_filtre.Text != "")
            {
                gelir= int.Parse(kg_filtre.Text);
            }
            this.Close();
        }

        private void kg_filtre_OnValueChanged(object sender, EventArgs e)
        {
            kg_filtre.ForeColor = Color.White;
        }

        private void Kapat_MouseHover(object sender, EventArgs e)
        {
            timer2.Stop();
            timer1.Start();
        }

        private void Kapat_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int a = int.Parse(Kapat.BackColor.ToString().Split(',')[1].Split('=')[1]);
            a += 10;
            Kapat.BackColor = Color.FromArgb(a, 40, 40);
            if (a >= 250)
            {
                timer1.Stop();
                Kapat.BackColor = Color.FromArgb(250, 40, 40);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int a = int.Parse(Kapat.BackColor.ToString().Split(',')[1].Split('=')[1]);
            a -= 10;
            Kapat.BackColor = Color.FromArgb(a, 40, 40);
            if (a <= 40)
            {
                timer2.Stop();
                Kapat.BackColor = Color.FromArgb(40, 40, 40);
            }
        }

        private void Kapat_Click(object sender, EventArgs e)
        {
            x = 9999;
            this.Close();
        }
    }
}
