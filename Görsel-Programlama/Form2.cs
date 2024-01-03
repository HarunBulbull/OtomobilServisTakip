using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Görsel_Programlama
{
    public partial class Form2 : Form
    {

        //---------------------------------> FORM EVENTLERİ

        SHA1 sha = new SHA1CryptoServiceProvider();
        public Form2()
        {
            InitializeComponent();
            FormClosing += Form2_FormClosing;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }



        //---------------------------------> TEXTBOX EVENTLERİ

        private void sifre_Enter(object sender, EventArgs e)
        {
            if(sifre.Text == "ŞİFRE")
            {
                sifre.Text = "";
                goster.Checked = false;
                sifre.isPassword = true;
            }
        }

        private void sifre_Leave(object sender, EventArgs e)
        {
            if (sifre.Text == "")
            {
                sifre.Text = "ŞİFRE";
                goster.Checked = false;
                sifre.isPassword = false;
            }
        }



        //---------------------------------> ŞİFREYİ GÖSTER/GİZLE

        private void goster_CheckedChanged(object sender, EventArgs e)
        {
            if(sifre.Text != "ŞİFRE")
            {
                if (goster.Checked == true) { sifre.isPassword = false; }
                else { sifre.isPassword = true; }
            }
            else
            {
                goster.Checked = false;
            }
        }



        //---------------------------------> BUTON EVENTLERİ

        public string host, user, pw, form;

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
            this.Close();
        }

        private void giris_buton_Click(object sender, EventArgs e)
        {
            if (sifre.Text.Length >= 8)
            {
                MySqlConnection con = new MySqlConnection("server=" + host + ";user=" + user + ";password=" + pw + ";database=GorselProgramlama");
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                string a1 = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes("Admin")));
                string a2 = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(sifre.Text)));
                cmd.CommandText = "INSERT INTO kullanicilar (kullanici,sifre) VALUES (@kullanici, @sifre)";
                cmd.Parameters.AddWithValue("@kullanici", a1);
                cmd.Parameters.AddWithValue("@sifre", a2);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("İşlem başarılı!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Şifreniz 8 hane veya daha uzun olmalı!");
            }
        }
    }
}
