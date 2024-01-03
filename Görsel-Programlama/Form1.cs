using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Görsel_Programlama
{
    public partial class Form1 : Form
    {



        //---------------------------------> FORM EVENTLERİ

        public Form1()
        {
            InitializeComponent();
        }

        string line, host, kullanici, sifre;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer7.Start();
            string path = @"C:\Users\" + SystemInformation.UserName + @"\AppData\OST\config.txt";
            string subPath = @"C:\Users\" + SystemInformation.UserName + @"\AppData\OST";
            if (!Directory.Exists(subPath))
            {
                Directory.CreateDirectory(subPath);
                using (StreamWriter sw = System.IO.File.AppendText(path))
                {
                    sw.WriteLine("Sunucu=''");
                    sw.WriteLine("Kullanıcı=''");
                    sw.WriteLine("Şifre=''");
                }
            }
            int i = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    i++;
                    line = line.Split('=')[1];
                    if (i == 1) { host = line; }
                    if (i == 2) { kullanici = line; }
                    if (i == 3) { sifre = line; }
                }
            }
            if ((host != "''") && (kullanici != "''") && (sifre != "''"))
            {
                con = new MySqlConnection("server=" + host + ";user=" + kullanici + ";password=" + sifre + ";database=GorselProgramlama");
                try
                {
                    using (con)
                    {
                        con.Open();
                        giris_kullanici.Enabled = true;
                        giris_sifre.Enabled = true;
                        giris_buton.Enabled = true;
                        vt_error.Visible = false;
                        vt_menubutton.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri tabanına bağlanılamadı!\n\n" + ex.Message);
                    giris_kullanici.Enabled = false;
                    giris_sifre.Enabled = false;
                    giris_buton.Enabled = false;
                    vt_error.Visible = true;
                }
                finally
                {
                    con.Close();
                }
            }
        }



































        //---------------------------------> KAPATMA TUŞU

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
            if(a >= 250)
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
            Application.Exit();
        }





































        //---------------------------------> KÜÇÜLTME TUŞU

        private void Küçült_MouseHover(object sender, EventArgs e)
        {
            timer4.Stop();
            timer3.Start();
        }

        private void Küçült_MouseLeave(object sender, EventArgs e)
        {
            timer3.Stop();
            timer4.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int a = int.Parse(Küçült.BackColor.ToString().Split(',')[3].Split('=')[1].Split(']')[0]);
            a += 10;
            Küçült.BackColor = Color.FromArgb(40, 40, a);
            if (a >= 250)
            {
                timer3.Stop();
                Küçült.BackColor = Color.FromArgb(40, 40, 250);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            int a = int.Parse(Küçült.BackColor.ToString().Split(',')[3].Split('=')[1].Split(']')[0]);
            a -= 10;
            Küçült.BackColor = Color.FromArgb(40, 40, a);
            if (a <= 40)
            {
                timer4.Stop();
                Küçült.BackColor = Color.FromArgb(40, 40, 40);
            }
        }

        private void Küçült_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


































        //---------------------------------> VERİ TABANI


        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        private void vt_menubutton_Click(object sender, EventArgs e)
        {
            Form5 fr = new Form5();
            fr.ShowDialog();
            if(fr.DialogResult == DialogResult.Yes)
            {
                baglan();
            }
            else
            {
                string path = @"C:\Users\" + SystemInformation.UserName + @"\AppData\OST\config.txt";
                int i = 0;
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        i++;
                        line = line.Split('=')[1];
                        if (i == 1) { host = line; }
                        if (i == 2) { kullanici = line; }
                        if (i == 3) { sifre = line; }
                    }
                }
                if ((host == "''") && (kullanici == "''") && (sifre == "''"))
                {
                    baglantikes();
                }
            }
        }

        public void baglantikes()
        {
            MessageBox.Show("Veri tabanı bağlantısı iptal edildi!");
            giris_kullanici.Enabled = false;
            giris_sifre.Enabled = false;
            giris_buton.Enabled = false;
            vt_error.Visible = true;
            vt_menubutton.Visible = true;
        }

        public void baglan()
        {
            string path = @"C:\Users\" + SystemInformation.UserName + @"\AppData\OST\config.txt";
            int i = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    i++;
                    line = line.Split('=')[1];
                    if (i == 1) { host = line; }
                    if (i == 2) { kullanici = line; }
                    if (i == 3) { sifre = line; }
                }
            }
            if ((host != "''") && (kullanici != "''") && (sifre != "''"))
            {
                con = new MySqlConnection("server=" + host + ";user=" + kullanici + ";password=" + sifre + ";database=GorselProgramlama");
                try
                {
                    using (con)
                    {
                        con.Open();
                        giris_kullanici.Enabled = true;
                        giris_sifre.Enabled = true;
                        giris_buton.Enabled = true;
                        vt_error.Visible = false;
                        vt_menubutton.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri tabanına bağlanılamadı!\n\n" + ex.Message);
                    giris_kullanici.Enabled = false;
                    giris_sifre.Enabled = false;
                    giris_buton.Enabled = false;
                    vt_error.Visible = true;
                    vt_menubutton.Visible = true;
                }
                finally
                {
                    con.Close();
                }
            }
        }

      



































        //---------------------------------> GİRİŞ

        private void giris_kullanici_Enter(object sender, EventArgs e)
        {
            if(giris_kullanici.Text == "KULLANICI ADI")
            {
                giris_kullanici.Text = "";
            }
        }

        private void giris_kullanici_Leave(object sender, EventArgs e)
        {
            if (giris_kullanici.Text == "")
            {
                giris_kullanici.Text = "KULLANICI ADI";
            }
        }

        private void giris_sifre_Enter(object sender, EventArgs e)
        {
            if (giris_sifre.Text == "ŞİFRE")
            {
                giris_sifre.Text = "";
                goster.Checked = false;
                giris_sifre.isPassword = true;
            }
        }

        private void giris_sifre_Leave(object sender, EventArgs e)
        {
            if (giris_sifre.Text == "")
            {
                giris_sifre.Text = "ŞİFRE";
                goster.Checked = false;
                giris_sifre.isPassword = false;
            }
        }

        private void goster_CheckedChanged(object sender, EventArgs e)
        {
            if (giris_sifre.Text != "ŞİFRE")
            {
                if (goster.Checked == true) { giris_sifre.isPassword = false; }
                else { giris_sifre.isPassword = true; }
            }
            else
            {
                goster.Checked = false;
            }
        }

        SHA1 sha = new SHA1CryptoServiceProvider();

        private void giris_buton_Click(object sender, EventArgs e)
        {
            if(giris_kullanici.Text == "Admin")
            {
                string a1 = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(giris_kullanici.Text)));
                string a2 = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(giris_sifre.Text)));
                con.Open();
                string sorgu = "SELECT * FROM kullanicilar where kullanici='" + a1 + "' AND sifre='" + a2 + "'";
                cmd = new MySqlCommand(sorgu, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    kullanicilabel.Text = giris_kullanici.Text;
                    menu.Visible = true;
                    VeriTabanı.Visible = false;
                    m7.Visible= true;
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
                }
                con.Close();
            }
            else
            {
                string a2 = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(giris_sifre.Text)));
                con.Open();
                string sorgu = "SELECT * FROM kullanicilar where kullanici='" + giris_kullanici.Text + "' AND sifre='" + a2 + "'";
                cmd = new MySqlCommand(sorgu, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    kullanicilabel.Text = giris_kullanici.Text;
                    menu.Visible = true;
                    VeriTabanı.Visible = false;
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
                }
                con.Close();
            }
        }


































        //---------------------------------> GELİR GİDER

        private void gglist()
        {
            gg_gelir.Text = "GELİR: 0 TL";
            gg_gider.Text = "GİDER: 0 TL";
            gg_gun.Items.Clear();
            gg_ay.Items.Clear();
            gg_yil.Items.Clear();
            gg_gun.Items.Add("GÜN");
            gg_ay.Items.Add("AY");
            gg_yil.Items.Add("YIL");
            gg_gun.SelectedIndex = gg_gun.FindStringExact("GÜN");
            gg_ay.SelectedIndex = gg_ay.FindStringExact("AY");
            gg_yil.SelectedIndex = gg_yil.FindStringExact("YIL");
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM gelir";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (!gg_gun.Items.Contains(dr["gun"].ToString()))
                {
                    gg_gun.Items.Add(dr["gun"].ToString());
                }
                if (!gg_ay.Items.Contains(dr["ay"].ToString()))
                {
                    gg_ay.Items.Add(dr["ay"].ToString());
                }
                if (!gg_yil.Items.Contains(dr["yil"].ToString()))
                {
                    gg_yil.Items.Add(dr["yil"].ToString());
                }
            }
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM gider";
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                if (!gg_gun.Items.Contains(dr["gun"].ToString()))
                {
                    gg_gun.Items.Add(dr["gun"].ToString());
                }
                if (!gg_ay.Items.Contains(dr["ay"].ToString()))
                {
                    gg_ay.Items.Add(dr["ay"].ToString());
                }
                if (!gg_yil.Items.Contains(dr["yil"].ToString()))
                {
                    gg_yil.Items.Add(dr["yil"].ToString());
                }
            }
            con.Close();
        }

        string yil;

        private void gg_yillik_Click(object sender, EventArgs e)
        {
            if(gg_yil.Text != "YIL")
            {
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM gelir where yil='" + gg_yil.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    listBox3.Items.Add(dr["ücret"].ToString() + " TL - " + dr["islem"].ToString());
                }
                con.Close();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM gider where yil='" + gg_yil.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                da1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    listBox4.Items.Add(dr["ücret"].ToString() + " TL - " + dr["islem"].ToString());
                }
                con.Close();
                gghesap();
                yil = gg_yil.Text;
            }
            else
            {
                MessageBox.Show("Lütfen bir yıl seçin.");
            }
        }

        private void gg_aylik_Click(object sender, EventArgs e)
        {
            if ((gg_yil.Text != "YIL") && (gg_ay.Text != "AY"))
            {
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM gelir where yil='" + gg_yil.Text + "' AND ay='" + gg_ay.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    listBox3.Items.Add(dr["ücret"].ToString() + " TL - " + dr["islem"].ToString());
                }
                con.Close();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM gider where yil='" + gg_yil.Text + "' AND ay='" + gg_ay.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                da1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    listBox4.Items.Add(dr["ücret"].ToString() + " TL - " + dr["islem"].ToString());
                }
                con.Close();
                gghesap();
                yil = gg_yil.Text;
            }
            else
            {
                MessageBox.Show("Lütfen bir ay ve bir yıl seçin.");
            }
        }

        private void gg_gunluk_Click(object sender, EventArgs e)
        {
            if ((gg_yil.Text != "YIL") && (gg_ay.Text != "AY") && (gg_gun.Text != "GÜN"))
            {
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM gelir where yil='" + gg_yil.Text + "' AND ay='" + gg_ay.Text + "' AND gun='" + gg_gun.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    listBox3.Items.Add(dr["ücret"].ToString() + " TL - " + dr["islem"].ToString());
                }
                con.Close();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM gider where yil='" + gg_yil.Text + "' AND ay='" + gg_ay.Text + "' AND gun='" + gg_gun.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                da1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    listBox4.Items.Add(dr["ücret"].ToString() + " TL - " + dr["islem"].ToString());
                }
                con.Close();
                gghesap();
                yil = gg_yil.Text;
            }
            else
            {
                MessageBox.Show("Lütfen bir gün, bir ay ve bir yıl seçin.");
            }
        }

        private void gghesap()
        {
            int gelir = 0;
            int gider = 0;
            foreach (string line in listBox3.Items)
            {
                gelir += int.Parse(line.Split('-')[0].Split(' ')[0]);
            }
            foreach (string line in listBox4.Items)
            {
                gider += int.Parse(line.Split('-')[0].Split(' ')[0]);
            }
            gg_gelir.Text = "GELİR: " + gelir + " TL";
            gg_gider.Text = "GİDER: " + gider + " TL";
        }

        private void gg_gelirsil_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0)
            {
                if(MessageBox.Show("Seçilen veri kalıcı olarak silinecektir. Devam etmek istiyor musunuz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string a = listBox3.SelectedItem.ToString();
                    listBox3.Items.Remove(a);
                    string b = a.Split('-')[0].Split(' ')[0];
                    string c = a.Remove(0, a.Split('-')[0].Length+2);
                    string Query = "delete from gelir where islem='" + c + "' AND ücret='" + b + "' AND yil='" + yil + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    con.Close();
                    gghesap();
                    if((listBox3.Items.Count == 0) && (listBox4.Items.Count == 0))
                    {
                        gglist();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir veri seçin!");
            }
        }

        private void gg_gidersil_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Seçilen veri kalıcı olarak silinecektir. Devam etmek istiyor musunuz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string a = listBox4.SelectedItem.ToString();
                    listBox4.Items.Remove(a);
                    string b = a.Split('-')[0].Split(' ')[0];
                    string c = a.Remove(0, a.Split('-')[0].Length + 2);
                    string Query = "delete from gider where islem='" + c + "' AND ücret='" + b + "' AND yil='" + yil + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    con.Close();
                    gghesap();
                    if ((listBox3.Items.Count == 0) && (listBox4.Items.Count == 0))
                    {
                        gglist();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir veri seçin!");
            }
        }

        private void gg_islem_Enter(object sender, EventArgs e)
        {
            if(gg_islem.Text == "İŞLEM")
            {
                gg_islem.Text = "";
            }
        }

        private void gg_islem_Leave(object sender, EventArgs e)
        {
            if (gg_islem.Text == "")
            {
                gg_islem.Text = "İŞLEM";
            }
        }

        private void gg_ücret_Enter(object sender, EventArgs e)
        {
            if (gg_ücret.Text == "ÜCRET")
            {
                gg_ücret.Text = "";
            }
        }

        private void gg_ücret_Leave(object sender, EventArgs e)
        {
            if (gg_ücret.Text == "")
            {
                gg_ücret.Text = "ÜCRET";
            }
        }

        private void gg_gelirekle_Click(object sender, EventArgs e)
        {
            if((gg_islem.Text != "İŞLEM") && (gg_islem.Text != "") && (gg_ücret.Text != "ÜCRET") && (gg_ücret.Text != ""))
            {
                con.Open();
                cmd = con.CreateCommand();
                string gun = DateTime.Now.ToString().Split(' ')[0].Split('.')[0];
                string ay = DateTime.Now.ToString().Split(' ')[0].Split('.')[1];
                string yil = DateTime.Now.ToString().Split(' ')[0].Split('.')[2];
                cmd.CommandText = "INSERT INTO gelir (islem,ücret,gun,ay,yil) VALUES (@islem, @ücret, @gun, @ay, @yil)";
                cmd.Parameters.AddWithValue("@islem", gg_islem.Text);
                cmd.Parameters.AddWithValue("@ücret", gg_ücret.Text);
                cmd.Parameters.AddWithValue("@gun", gun);
                cmd.Parameters.AddWithValue("@ay", ay);
                cmd.Parameters.AddWithValue("@yil", yil);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(gg_islem.Text + " işlemi bulunduğunuz tarih ile gelir olarak kayıt edilmiştir.");
                gg_islem.Text = "İŞLEM";
                gg_ücret.Text = "ÜCRET";
                if (!gg_gun.Items.Contains(gun))
                {
                    gg_gun.Items.Add(gun);
                }
                if (!gg_ay.Items.Contains(ay))
                {
                    gg_ay.Items.Add(ay);
                }
                if (!gg_yil.Items.Contains(yil))
                {
                    gg_yil.Items.Add(yil);
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm boşlukları doldurun!");
            }
        }

        private void gg_giderekle_Click(object sender, EventArgs e)
        {
            if ((gg_islem.Text != "İŞLEM") && (gg_islem.Text != "") && (gg_ücret.Text != "ÜCRET") && (gg_ücret.Text != ""))
            {
                con.Open();
                cmd = con.CreateCommand();
                string gun = DateTime.Now.ToString().Split(' ')[0].Split('.')[0];
                string ay = DateTime.Now.ToString().Split(' ')[0].Split('.')[1];
                string yil = DateTime.Now.ToString().Split(' ')[0].Split('.')[2];
                cmd.CommandText = "INSERT INTO gider (islem,ücret,gun,ay,yil) VALUES (@islem, @ücret, @gun, @ay, @yil)";
                cmd.Parameters.AddWithValue("@islem", gg_islem.Text);
                cmd.Parameters.AddWithValue("@ücret", gg_ücret.Text);
                cmd.Parameters.AddWithValue("@gun", gun);
                cmd.Parameters.AddWithValue("@ay", ay);
                cmd.Parameters.AddWithValue("@yil", yil);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(gg_islem.Text + " işlemi bulunduğunuz tarih ile gider olarak kayıt edilmiştir.");
                gg_islem.Text = "İŞLEM";
                gg_ücret.Text = "ÜCRET";
                if (!gg_gun.Items.Contains(gun))
                {
                    gg_gun.Items.Add(gun);
                }
                if (!gg_ay.Items.Contains(ay))
                {
                    gg_ay.Items.Add(ay);
                }
                if (!gg_yil.Items.Contains(yil))
                {
                    gg_yil.Items.Add(yil);
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm boşlukları doldurun!");
            }
        }

































        //---------------------------------> GEÇMİŞ

        private void gecmisbul()
        {
            kg_bul.SelectedIndex = -1;
            kg_bul.Items.Clear();
            listBox2.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM gecmis";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                kg_bul.Items.Add(dr["musteri"].ToString() + " - " + dr["yil"].ToString() + " * " + dr["arac"].ToString());
            }
            con.Close();
        }

        private void kg_filtre_OnValueChanged(object sender, EventArgs e)
        {
            kg_bul.SelectedIndex = -1;
            listBox2.Items.Clear();
            kg_bul.Items.Clear();
            if ((kg_filtre.Text != "FİLTRELE") && (kg_filtre.Text != ""))
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM gecmis";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    if (!kg_bul.Items.Contains(dr["musteri"].ToString() + " - " + dr["yil"].ToString() + " * " + dr["arac"].ToString()))
                    {
                        string item = (dr["musteri"].ToString() + " " + dr["telefon"].ToString() + " " + dr["arac"].ToString() + " " + dr["yil"].ToString() + " " + dr["plaka"].ToString() + " " + dr["şase"].ToString() + " " + dr["işlem"].ToString() + " " + dr["ücret"].ToString() + " " + dr["km"].ToString() + " " + dr["renk"].ToString() + " " + dr["ariza"].ToString() + " " + dr["depo"].ToString() + " " + dr["tarih"].ToString());
                        if (item.Contains(kg_filtre.Text))
                        {
                            kg_bul.Items.Add(dr["musteri"].ToString() + " - " + dr["yil"].ToString() + " * " + dr["arac"].ToString());
                        }
                    }
                }
                con.Close();
            }
            else
            {
                gecmisbul();
            }
        }

        private void kg_bul_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kg_bul.SelectedIndex > -1)
            {
                con.Open();
                cmd.Connection = con;
                string a1 = kg_bul.SelectedItem.ToString().Split('-')[0].Remove(kg_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                string aa = kg_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                string a3 = aa.ToString().Split('*')[1].Remove(0, 1);
                cmd.CommandText = "SELECT * FROM gecmis where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                listBox2.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    listBox2.Items.Add("Müşteri Adı: " + dr["musteri"].ToString());
                    listBox2.Items.Add("Telefon No: " + dr["telefon"].ToString());
                    listBox2.Items.Add("Araç Modeli: " + dr["arac"].ToString());
                    listBox2.Items.Add("Model Yılı: " + dr["yil"].ToString());
                    listBox2.Items.Add("Plaka: " + dr["plaka"].ToString());
                    listBox2.Items.Add("Şase No: " + dr["şase"].ToString());
                    listBox2.Items.Add("İşlem: " + dr["işlem"].ToString());
                    listBox2.Items.Add("Ücret: " + dr["ücret"].ToString());
                    listBox2.Items.Add("Geliş KM: " + dr["km"].ToString());
                    listBox2.Items.Add("Araç Rengi: " + dr["renk"].ToString());
                    listBox2.Items.Add("Arıza Türü: " + dr["ariza"].ToString());
                    listBox2.Items.Add("Depo: " + dr["depo"].ToString());
                    listBox2.Items.Add("Kayıt Tarihi: " + dr["tarih"].ToString());
                    if (dr["ek1"].ToString() != "-")
                    {
                        listBox2.Items.Add("Ek İşlem: " + dr["ek1"].ToString());
                        if (dr["ek2"].ToString() != "-")
                        {
                            listBox2.Items.Add("Ek İşlem: " + dr["ek2"].ToString());
                            if (dr["ek3"].ToString() != "-")
                            {
                                listBox2.Items.Add("Ek İşlem: " + dr["ek3"].ToString());
                                if (dr["ek4"].ToString() != "-")
                                {
                                    listBox2.Items.Add("Ek İşlem: " + dr["ek4"].ToString());
                                }
                            }
                        }
                    }
                    listBox2.Items.Add("Arşiv Tarihi: " + dr["tarih2"].ToString());
                }
                con.Close();
            }
            else
            {
                listBox2.Items.Clear();
            }
        }
        private void kg_filtre_Leave(object sender, EventArgs e)
        {
            if (kg_filtre.Text == "")
            {
                kg_filtre.Text = "FİLTRELE";
            }
        }

        private void kg_filtre_Enter(object sender, EventArgs e)
        {
            if (kg_filtre.Text == "FİLTRELE")
            {
                kg_filtre.Text = "";
            }
        }

        private void kg_sil_Click(object sender, EventArgs e)
        {
            if (kg_bul.SelectedIndex >= 0)
            {
                if ((MessageBox.Show("Seçilen veriyi kalıcı olarak silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    string a1 = kg_bul.SelectedItem.ToString().Split('-')[0].Remove(kg_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                    string aa = kg_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                    string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                    string a3 = aa.ToString().Split('*')[1].Remove(0, 1);
                    string Query = "delete from gecmis where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    con.Close();
                    gecmisbul();
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce bir kayıt seçin!");
            }
        }

        public int gelir;
        private void kg_gelir_Click(object sender, EventArgs e)
        {
            if(kg_bul.SelectedIndex >= 0)
            {
                con.Open();
                cmd.Connection = con;
                string a1 = kg_bul.SelectedItem.ToString().Split('-')[0].Remove(kg_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                string aa = kg_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                string a3 = aa.ToString().Split('*')[1].Remove(0, 1);
                cmd.CommandText = "SELECT * FROM gecmis where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                string x;
                foreach (DataRow dr in dt.Rows)
                {
                    gelir = int.Parse(dr["ücret"].ToString());
                    if (dr["ek1"].ToString() != "-")
                    {
                        x = (dr["ek1"].ToString().Split('-')[0].Remove(dr["ek1"].ToString().Split('-')[0].Length - 1)).Split(' ')[0];
                        gelir += int.Parse(x);
                        if (dr["ek2"].ToString() != "-")
                        {
                            x = (dr["ek2"].ToString().Split('-')[0].Remove(dr["ek1"].ToString().Split('-')[0].Length - 1)).Split(' ')[0];
                            gelir += int.Parse(x);
                            if (dr["ek3"].ToString() != "-")
                            {
                                x = (dr["ek3"].ToString().Split('-')[0].Remove(dr["ek1"].ToString().Split('-')[0].Length - 1)).Split(' ')[0];
                                gelir += int.Parse(x);
                                if (dr["ek4"].ToString() != "-")
                                {
                                    x = (dr["ek4"].ToString().Split('-')[0].Remove(dr["ek1"].ToString().Split('-')[0].Length - 1)).Split(' ')[0];
                                    gelir += int.Parse(x);
                                }
                            }
                        }
                    }
                    Form3 fr = new Form3();
                    fr.gelir = gelir;
                    fr.ShowDialog();
                    if (fr.DialogResult == DialogResult.Yes)
                    {
                        gelir = fr.gelir;
                        con.Close();
                        con.Open();
                        cmd = con.CreateCommand();
                        string gun = DateTime.Now.ToString().Split(' ')[0].Split('.')[0];
                        string ay = DateTime.Now.ToString().Split(' ')[0].Split('.')[1];
                        string yil = DateTime.Now.ToString().Split(' ')[0].Split('.')[2];
                        cmd.CommandText = "INSERT INTO gelir (islem,ücret,gun,ay,yil) VALUES (@islem, @ücret, @gun, @ay, @yil)";
                        cmd.Parameters.AddWithValue("@islem", kg_bul.Text);
                        cmd.Parameters.AddWithValue("@ücret", gelir);
                        cmd.Parameters.AddWithValue("@gun", gun);
                        cmd.Parameters.AddWithValue("@ay", ay);
                        cmd.Parameters.AddWithValue("@yil", yil);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Lütfen önce bir kayıt seçin!");
            }
        }
































        //---------------------------------> VERESİYE

        private void vd_isim_Enter(object sender, EventArgs e)
        {
            if(vd_isim.Text == "İSİM SOYİSİM")
            {
                vd_isim.Text = "";
            }
        }

        private void vd_isim_Leave(object sender, EventArgs e)
        {
            if (vd_isim.Text == "")
            {
                vd_isim.Text = "İSİM SOYİSİM";
            }
        }

        private void vd_tel_Enter(object sender, EventArgs e)
        {
            if(vd_tel.Text == "TELEFON NO")
            {
                vd_tel.Text = "";
            }
        }

        private void vd_tel_Leave(object sender, EventArgs e)
        {
            if (vd_tel.Text == "")
            {
                vd_tel.Text = "TELEFON NO";
            }
        }

        private void vd_alacak_Enter(object sender, EventArgs e)
        {
            if (vd_alacak.Text == "ALACAK")
            {
                vd_alacak.Text = "";
            }
        }

        private void vd_alacak_Leave(object sender, EventArgs e)
        {
            if (vd_alacak.Text == "")
            {
                vd_alacak.Text = "ALACAK";
            }
        }

        private void vd_filtre_Enter(object sender, EventArgs e)
        {
            if (vd_filtre.Text == "FİLTRELE")
            {
                vd_filtre.Text = "";
            }
        }

        private void vd_filtre_Leave(object sender, EventArgs e)
        {
            if (vd_filtre.Text == "")
            {
                vd_filtre.Text = "FİLTRELE";
            }
        }

        DataTable dt1 = new DataTable();
        private void veresiye()
        {
            dt1.Clear();
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from veresiye", con);
            da.Fill(dt1);
            guna2DataGridView1.DataSource = dt1;
            con.Close();
        }

        private void vd_kayit_Click(object sender, EventArgs e)
        {
            if((vd_isim.Text != "İSİM SOYİSİM") && (vd_isim.Text != "") && (vd_tel.Text != "TELEFON NO") && (vd_tel.Text != "") && (vd_alacak.Text != "ALACAK") && (vd_alacak.Text != ""))
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO veresiye (İsim,Telefon,Alacak,Tarih) VALUES (@isim, @telefon, @alacak, @tarih)";
                cmd.Parameters.AddWithValue("@isim", vd_isim.Text);
                cmd.Parameters.AddWithValue("@telefon", vd_tel.Text);
                cmd.Parameters.AddWithValue("@alacak", vd_alacak.Text);
                cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString().Split(' ')[0]);
                cmd.ExecuteNonQuery();
                con.Close();
                vd_isim.Text = "İSİM SOYİSİM";
                vd_tel.Text = "TELEFON NO";
                vd_alacak.Text = "ALACAK";
                veresiye();
            }
            else
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurun!");
            }
        }

        private void vd_filtre_OnValueChanged(object sender, EventArgs e)
        {
            if (vd_tarihfiltre.Checked == true)
            {
                if (vd_filtre.Text != "FİLTRELE" && vd_filtre.Text != "")
                {
                    dt1.DefaultView.RowFilter = string.Format("İsim like '%" + vd_filtre.Text + "%' and Tarih like '%" + vd_tarih.Text + "%'");
                }
                else
                {
                    dt1.DefaultView.RowFilter = string.Format("Tarih like '%" + vd_tarih.Text + "%'");
                }
            }
            else
            {
                if (vd_filtre.Text != "FİLTRELE" && vd_filtre.Text != "")
                {
                    dt1.DefaultView.RowFilter = string.Format("İsim like '%" + vd_filtre.Text + "%'");
                }
                else
                {
                    dt1.DefaultView.RowFilter = string.Format("");
                }
            }
        }

        private void vd_tarihfiltre_CheckedChanged(object sender, EventArgs e)
        {
            if(vd_tarihfiltre.Checked == true)
            {
                if (vd_filtre.Text != "FİLTRELE" && vd_filtre.Text != "")
                {
                    dt1.DefaultView.RowFilter = string.Format("İsim like '%" + vd_filtre.Text + "%' and Tarih like '%" + vd_tarih.Text + "%'");
                }
                else
                {
                    dt1.DefaultView.RowFilter = string.Format("Tarih like '%" + vd_tarih.Text + "%'");
                }
            }
            else
            {
                if (vd_filtre.Text != "FİLTRELE" && vd_filtre.Text != "")
                {
                    dt1.DefaultView.RowFilter = string.Format("İsim like '%" + vd_filtre.Text + "%'");
                }
                else
                {
                    dt1.DefaultView.RowFilter = string.Format("");
                }
            }
        }

        private void vd_tarih_ValueChanged(object sender, EventArgs e)
        {
            if (vd_tarihfiltre.Checked == true)
            {
                if (vd_filtre.Text != "FİLTRELE" && vd_filtre.Text != "")
                {
                    dt1.DefaultView.RowFilter = string.Format("İsim like '%" + vd_filtre.Text + "%' and Tarih like '%" + vd_tarih.Text + "%'");
                }
                else
                {
                    dt1.DefaultView.RowFilter = string.Format("Tarih like '%" + vd_tarih.Text + "%'");
                }
            }
            else
            {
                if (vd_filtre.Text != "FİLTRELE" && vd_filtre.Text != "")
                {
                    dt1.DefaultView.RowFilter = string.Format("İsim like '%" + vd_filtre.Text + "%'");
                }
                else
                {
                    dt1.DefaultView.RowFilter = string.Format("");
                }
            }
        }

        private void vd_yukle_Click(object sender, EventArgs e)
        {
            if(vd_isim.Text == "İSİM SOYİSİM")
            {
                foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                {
                    vd_isim.Text = row.Cells[0].Value.ToString();
                    vd_tel.Text = row.Cells[1].Value.ToString();
                    vd_alacak.Text = row.Cells[2].Value.ToString();
                }
            }
            else
            {
                vd_isim.Text = "İSİM SOYİSİM";
                vd_tel.Text = "TELEFON NO";
                vd_alacak.Text = "ALACAK";
            }
        }

        string v1, v2, v3, v4, v5, v6, v7;
        private void vd_sil_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seçilen veriyi silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                {
                    v1 = row.Cells[0].Value.ToString();
                    v2 = row.Cells[1].Value.ToString();
                    v3 = row.Cells[2].Value.ToString();
                    v4 = row.Cells[3].Value.ToString();
                }
                string Query = "delete from veresiye where İsim='" + v1 + "' AND Telefon='" + v2 + "' AND Alacak='" + v3 + "' AND Tarih='" + v4 + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                MySqlDataReader MyReader2;
                con.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                con.Close();
                veresiye();
            }
        }

        private void vd_guncelle_Click(object sender, EventArgs e)
        {
            if ((vd_isim.Text != "İSİM SOYİSİM") && (vd_isim.Text != "") && (vd_tel.Text != "TELEFON NO") && (vd_tel.Text != "") && (vd_alacak.Text != "ALACAK") && (vd_alacak.Text != ""))
            {
                foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                {
                    v1 = row.Cells[0].Value.ToString();
                    v2 = row.Cells[1].Value.ToString();
                    v3 = row.Cells[2].Value.ToString();
                    v4 = row.Cells[3].Value.ToString();
                }
                if (MessageBox.Show("Seçilen veriyi aşağıdaki gibi düzenlemek istediğinize emin misiniz?\nİsim: " + v1 + " » " + vd_isim.Text + "\nTelefon: " + v2 + " » " + vd_tel.Text + "\nAlacak: " + v3 + " » " + vd_alacak.Text, "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    con.Open();
                    string Query = "update veresiye set İsim='" + vd_isim.Text + "', Telefon='" + vd_tel.Text + "', Alacak='" + vd_alacak.Text + "' where İsim='" + v1 + "' AND Telefon='" + v2 + "' AND Alacak='" + v3 + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    con.Close();
                    veresiye();
                    vd_isim.Text = "İSİM SOYİSİM";
                    vd_tel.Text = "TELEFON NO";
                    vd_alacak.Text = "ALACAK";
                }
            }
            else
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurun!");
            }
        }





































        //---------------------------------> SİPARİŞ

        DataTable dt2 = new DataTable();
        private void siparisdukkan()
        {
            dt2.Clear();
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from siparis", con);
            da.Fill(dt2);
            guna2DataGridView2.DataSource = dt2;
            con.Close();
        }

        private void sl_sd_Click(object sender, EventArgs e)
        {
            sl_sdpanel.Visible = true;
            sl_smpanel.Visible = false;
            slsd_adet.Text = "ADET";
            slsd_siparis.Text = "SİPARİŞ";
            siparisdukkan();
            DataGridViewColumn column = guna2DataGridView2.Columns[0];
            column.Width = 60;
        }

        private void slsd_adet_Enter(object sender, EventArgs e)
        {
            if(slsd_adet.Text == "ADET")
            {
                slsd_adet.Text = "";
            }
        }

        private void slsd_adet_Leave(object sender, EventArgs e)
        {
            if (slsd_adet.Text == "")
            {
                slsd_adet.Text = "ADET";
            }
        }

        private void slsd_siparis_Enter(object sender, EventArgs e)
        {
            if (slsd_siparis.Text == "SİPARİŞ")
            {
                slsd_siparis.Text = "";
            }
        }

        private void slsd_siparis_Leave(object sender, EventArgs e)
        {
            if (slsd_siparis.Text == "")
            {
                slsd_siparis.Text = "SİPARİŞ";
            }
        }

        private void slsd_kayit_Click(object sender, EventArgs e)
        {
            if(slsd_adet.Text != "" && slsd_adet.Text != "ADET" && slsd_siparis.Text != "" && slsd_siparis.Text != "SİPARİŞ")
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO siparis (Adet,Sipariş) VALUES (@adet, @siparis)";
                cmd.Parameters.AddWithValue("@adet", slsd_adet.Text);
                cmd.Parameters.AddWithValue("@siparis", slsd_siparis.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                slsd_siparis.Text = "SİPARİŞ";
                slsd_adet.Text = "ADET";
                siparisdukkan();
            }
            else
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurun!");
            }
        }

        private void slsd_sil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen veriyi silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in guna2DataGridView2.SelectedRows)
                {
                    v1 = row.Cells[0].Value.ToString();
                    v2 = row.Cells[1].Value.ToString();
                }
                string Query = "delete from siparis where Adet='" + v1 + "' AND Sipariş='" + v2 + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                MySqlDataReader MyReader2;
                con.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                con.Close();
                siparisdukkan();
            }
        }

        DataTable dt3 = new DataTable();
        private void siparismusteri()
        {
            dt3.Clear();
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from siparismusteri", con);
            da.Fill(dt3);
            guna2DataGridView3.DataSource = dt3;
            con.Close();
        }




        private void sl_sm_Click(object sender, EventArgs e)
        {
            sl_sdpanel.Visible = true;
            sl_smpanel.Visible = true;
            slsm_adet.Text = "ADET";
            slsm_siparis.Text = "SİPARİŞ";
            slsm_musteri.Text = "MÜŞTERİ";
            slsm_telefon.Text = "TELEFON";
            slsm_alacak.Text = "ALACAK";
            slsm_kapora.Text = "KAPORA";
            siparismusteri();
            DataGridViewColumn column = guna2DataGridView3.Columns[0];
            column.Width = 60;
        }

        private void slsm_adet_Enter(object sender, EventArgs e)
        {
            if(slsm_adet.Text == "ADET")
            {
                slsm_adet.Text = "";
            }
        }

        private void slsm_adet_Leave(object sender, EventArgs e)
        {
            if (slsm_adet.Text == "")
            {
                slsm_adet.Text = "ADET";
            }
        }

        private void slsm_siparis_Enter(object sender, EventArgs e)
        {
            if (slsm_siparis.Text == "SİPARİŞ")
            {
                slsm_siparis.Text = "";
            }
        }

        private void slsm_siparis_Leave(object sender, EventArgs e)
        {
            if (slsm_siparis.Text == "")
            {
                slsm_siparis.Text = "SİPARİŞ";
            }
        }

        private void slsm_musteri_Enter(object sender, EventArgs e)
        {
            if (slsm_musteri.Text == "MÜŞTERİ")
            {
                slsm_musteri.Text = "";
            }
        }

        private void slsm_musteri_Leave(object sender, EventArgs e)
        {
            if (slsm_musteri.Text == "")
            {
                slsm_musteri.Text = "MÜŞTERİ";
            }
        }

        private void slsm_telefon_Enter(object sender, EventArgs e)
        {
            if (slsm_telefon.Text == "TELEFON")
            {
                slsm_telefon.Text = "";
            }
        }

        private void slsm_telefon_Leave(object sender, EventArgs e)
        {
            if (slsm_telefon.Text == "")
            {
                slsm_telefon.Text = "TELEFON";
            }
        }

        private void slsm_alacak_Enter(object sender, EventArgs e)
        {
            if (slsm_alacak.Text == "ALACAK")
            {
                slsm_alacak.Text = "";
            }
        }

        private void slsm_alacak_Leave(object sender, EventArgs e)
        {
            if (slsm_alacak.Text == "")
            {
                slsm_alacak.Text = "ALACAK";
            }
        }

        private void slsm_kapora_Enter(object sender, EventArgs e)
        {
            if (slsm_kapora.Text == "KAPORA")
            {
                slsm_kapora.Text = "";
            }
        }

        private void slsm_kapora_Leave(object sender, EventArgs e)
        {
            if (slsm_kapora.Text == "")
            {
                slsm_kapora.Text = "KAPORA";
            }
        }

        private void slsm_kayit_Click(object sender, EventArgs e)
        {
            if (slsm_adet.Text != "" && slsm_adet.Text != "ADET" && slsm_siparis.Text != "" && slsm_siparis.Text != "SİPARİŞ" && slsm_musteri.Text != "" && slsm_musteri.Text != "MÜŞTERİ" && slsm_telefon.Text != "" && slsm_telefon.Text != "TELEFON" && slsm_alacak.Text != "" && slsm_alacak.Text != "ALACAK" && slsm_kapora.Text != "" && slsm_kapora.Text != "KAPORA" )
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO siparismusteri (Adet,Sipariş,Müşteri,Telefon,Alacak,Kapora,Kalan) VALUES (@adet, @siparis, @musteri, @telefon, @alacak, @kapora, @kalan)";
                cmd.Parameters.AddWithValue("@adet", slsm_adet.Text);
                cmd.Parameters.AddWithValue("@siparis", slsm_siparis.Text);
                cmd.Parameters.AddWithValue("@musteri", slsm_musteri.Text);
                cmd.Parameters.AddWithValue("@telefon", slsm_telefon.Text);
                cmd.Parameters.AddWithValue("@alacak", slsm_alacak.Text);
                cmd.Parameters.AddWithValue("@kapora", slsm_kapora.Text);
                cmd.Parameters.AddWithValue("@kalan", (int.Parse(slsm_alacak.Text) - int.Parse(slsm_kapora.Text)).ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                slsm_adet.Text = "ADET";
                slsm_siparis.Text = "SİPARİŞ";
                slsm_musteri.Text = "MÜŞTERİ";
                slsm_telefon.Text = "TELEFON";
                slsm_alacak.Text = "ALACAK";
                slsm_kapora.Text = "KAPORA";
                siparismusteri();
            }
            else
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurun!");
            }
        }

        private void slsm_sil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen veriyi silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in guna2DataGridView3.SelectedRows)
                {
                    v1 = row.Cells[0].Value.ToString();
                    v2 = row.Cells[1].Value.ToString();
                    v3 = row.Cells[2].Value.ToString();
                    v4 = row.Cells[3].Value.ToString();
                    v5 = row.Cells[4].Value.ToString();
                    v6 = row.Cells[5].Value.ToString();
                    v7 = row.Cells[6].Value.ToString();
                }
                string Query = "delete from siparismusteri where Adet='" + v1 + "' AND Sipariş='" + v2 + "' AND Müşteri='" + v3 + "' AND Telefon='" + v4 + "' AND Alacak='" + v5 + "' AND Kapora='" + v6 + "' AND Kalan='" + v7 + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                MySqlDataReader MyReader2;
                con.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                con.Close();
                siparismusteri();
            }
        }
































        //---------------------------------> YÖNETİM PANELİ

        DataTable dt4 = new DataTable();

        private void yp_vt_Click(object sender, EventArgs e)
        {
            Form5 fr = new Form5();
            fr.ShowDialog();
            if (fr.DialogResult == DialogResult.Yes)
            {
                baglan();
                MessageBox.Show("Değişikliklerin etkili olması için uygulamayı yeniden başlatmanız gerekiyor!");
                Application.Exit();
            }
            else
            {
                string path = @"C:\Users\" + SystemInformation.UserName + @"\AppData\OST\config.txt";
                int i = 0;
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        i++;
                        line = line.Split('=')[1];
                        if (i == 1) { host = line; }
                        if (i == 2) { kullanici = line; }
                        if (i == 3) { sifre = line; }
                    }
                }
                if ((host == "''") && (kullanici == "''") && (sifre == "''"))
                {
                    baglantikes();
                    MessageBox.Show("Değişikliklerin etkili olması için uygulamayı yeniden başlatmanız gerekiyor!");
                    Application.Exit();
                }
            }
        }
        private void yp()
        {
            dt4.Clear();
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from kullanicilar", con);
            da.Fill(dt4);
            DataRow[] dtr = dt4.Select("kullanici='Tnr+vPuuAAsix8heVWD4mioCgLQ='");
            foreach (var drow in dtr)
            {
                drow.Delete();
            }
            dt4.AcceptChanges();
            guna2DataGridView4.DataSource = dt4;
            con.Close();
            DataGridViewColumn column = guna2DataGridView4.Columns[0];
            column.Width = 60;
            
        }

        private void yp_kadi_Enter(object sender, EventArgs e)
        {
            if(yp_kadi.Text == "KULLANICI ADI")
            {
                yp_kadi.Text = "";
            }
        }

        private void yp_kadi_Leave(object sender, EventArgs e)
        {
            if (yp_kadi.Text == "")
            {
                yp_kadi.Text = "KULLANICI ADI";
            }
        }

        private void yp_sifre_Enter(object sender, EventArgs e)
        {
            if(yp_sifre.Text == "ŞİFRE")
            {
                yp_sifre.Text = "";
            }
        }

        private void yp_sifre_Leave(object sender, EventArgs e)
        {
            if (yp_sifre.Text == "")
            {
                yp_sifre.Text = "ŞİFRE";
            }
        }

        private void yp_kayit_Click(object sender, EventArgs e)
        {
            if(yp_kadi.Text != "" && yp_kadi.Text != "KULLANICI ADI" && yp_sifre.Text != "" && yp_sifre.Text != "ŞİFRE")
            {
                if(yp_sifre.Text.Length >= 8)
                {
                    con.Open();
                    string sorgu = "SELECT * FROM kullanicilar where kullanici='" + yp_kadi.Text + "'";
                    cmd = new MySqlCommand(sorgu, con);
                    dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        con.Close();
                        con.Open();
                        cmd = con.CreateCommand();
                        string a2 = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(yp_sifre.Text)));
                        cmd.CommandText = "INSERT INTO kullanicilar (kullanici,sifre) VALUES (@kullanici, @sifre)";
                        cmd.Parameters.AddWithValue("@kullanici", yp_kadi.Text);
                        cmd.Parameters.AddWithValue("@sifre", a2);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        yp_kadi.Text = "KULLANICI ADI";
                        yp_sifre.Text = "ŞİFRE";
                        yp();
                    }
                    else
                    {
                        MessageBox.Show("Böyle bir kullanıcı zaten mevcut!");
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Şifre 8 hane veya daha uzun olmalı!");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bütün alanları doldurun!");
            }
        }

        private void yp_sil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen veriyi silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in guna2DataGridView4.SelectedRows)
                {
                    v1 = row.Cells[1].Value.ToString();
                    v2 = row.Cells[2].Value.ToString();
                }
                string Query = "delete from kullanicilar where kullanici='" + v1 + "' AND sifre='" + v2 + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                MySqlDataReader MyReader2;
                con.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                con.Close();
                yp();
            }
        }













































        //---------------------------------> NOTLAR

        private void not()
        {
            listBox5.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM notlar";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (!listBox5.Items.Contains(dr["baslik"].ToString()))
                {
                    listBox5.Items.Add(dr["baslik"].ToString());
                }
            }
            con.Close();
        }

        private void n_baslik_Enter(object sender, EventArgs e)
        {
            if (n_baslik.Text == "NOT BAŞLIĞI")
            {
                n_baslik.Text = "";
            }
        }

        private void n_baslik_Leave(object sender, EventArgs e)
        {
            if (n_baslik.Text == "")
            {
                n_baslik.Text = "NOT BAŞLIĞI";
            }
        }

        private void n_olustur_Click(object sender, EventArgs e)
        {
            if (n_baslik.Text != "" && n_baslik.Text != "NOT BAŞLIĞI" && n_gövde.Text != "")
            {
                con.Open();
                string sorgu = "SELECT * FROM notlar where baslik='" + n_baslik.Text + "'";
                cmd = new MySqlCommand(sorgu, con);
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    con.Close();
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO notlar (baslik,gövde) VALUES (@baslik, @not)";
                    cmd.Parameters.AddWithValue("@baslik", n_baslik.Text);
                    cmd.Parameters.AddWithValue("@not", n_gövde.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    n_baslik.Text = "NOT BAŞLIĞI";
                    n_gövde.Text = "";
                    not();
                }
                else
                {
                    MessageBox.Show("Bu başlıkta bir not zaten mevcut!");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurun!");
            }
        }

        private void n_güncelle_Click(object sender, EventArgs e)
        {
            if (n_baslik.Text != "" && n_baslik.Text != "NOT BAŞLIĞI" && n_gövde.Text != "")
            {
                if (listBox5.SelectedIndex >= 0)
                {
                    con.Open();
                    string sorgu = "SELECT * FROM notlar where baslik='" + n_baslik.Text + "'";
                    cmd = new MySqlCommand(sorgu, con);
                    dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        if (MessageBox.Show("Seçilen notu güncellemek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            con.Close();
                            con.Open();
                            cmd = con.CreateCommand();
                            string Query = "update notlar set baslik='" + n_baslik.Text + "', gövde='" + n_gövde.Text + "' where baslik='" + listBox5.SelectedItem.ToString() + "'";
                            MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                            MySqlDataReader MyReader2;
                            MyReader2 = MyCommand2.ExecuteReader();
                            while (MyReader2.Read())
                            {
                            }
                            con.Close();
                            n_baslik.Text = "NOT BAŞLIĞI";
                            n_gövde.Text = "";
                            not();
                        }
                    }
                    else
                    {
                        if (listBox5.SelectedItem.ToString() == n_baslik.Text)
                        {
                            if (MessageBox.Show("Seçilen notu güncellemek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                con.Close();
                                con.Open();
                                cmd = con.CreateCommand();
                                string Query = "update notlar set baslik='" + n_baslik.Text + "', gövde='" + n_gövde.Text + "' where baslik='" + listBox5.SelectedItem.ToString() + "'";
                                MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                                MySqlDataReader MyReader2;
                                MyReader2 = MyCommand2.ExecuteReader();
                                while (MyReader2.Read())
                                {
                                }
                                con.Close();
                                n_baslik.Text = "NOT BAŞLIĞI";
                                n_gövde.Text = "";
                                not();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu başlıkta bir not zaten mevcut!");
                        }
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("LÜtfen önce bir veri seçin!");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurun!");
            }
        }

        private void n_sil_Click(object sender, EventArgs e)
        {
            if (listBox5.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Seçilen notu silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string Query = "delete from notlar where baslik='" + listBox5.SelectedItem.ToString() + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    con.Close();
                    not();
                    n_baslik.Text = "NOT BAŞLIĞI";
                    n_gövde.Text = "";
                }
            }
            else
            {
                MessageBox.Show("LÜtfen önce bir veri seçin!");
            }
        }

        private void listBox5_Click(object sender, EventArgs e)
        {
            if (listBox5.SelectedIndex >= 0)
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM notlar where baslik='" + listBox5.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    n_baslik.Text = dr["baslik"].ToString();
                    n_gövde.Text = dr["gövde"].ToString();
                }
                con.Close();
            }
        }




































        //---------------------------------> KAYIT

        private void musteribul()
        {
            mk_bul.SelectedIndex = -1;
            mk_bul.Items.Clear();
            listBox1.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM musteriler";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                mk_bul.Items.Add(dr["musteri"].ToString() + " - " + dr["yil"].ToString() + " * " + dr["arac"].ToString());
            }
            con.Close();
        }

        private void mk_bul_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mk_bul.SelectedIndex > -1)
            {
                mk_ekislem.Enabled = true;
                mk_ekücret.Enabled = true;
                mk_ekekle.Enabled = true;
                con.Open();
                cmd.Connection = con;
                string a1 = mk_bul.SelectedItem.ToString().Split('-')[0].Remove(mk_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                string aa = mk_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                string a3 = aa.ToString().Split('*')[1].Remove(0, 1);

                cmd.CommandText = "SELECT * FROM musteriler where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                listBox1.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    listBox1.Items.Add("Müşteri Adı: " + dr["musteri"].ToString());
                    listBox1.Items.Add("Telefon No: " + dr["telefon"].ToString());
                    listBox1.Items.Add("Araç Modeli: " + dr["arac"].ToString());
                    listBox1.Items.Add("Model Yılı: " + dr["yil"].ToString());
                    listBox1.Items.Add("Plaka: " + dr["plaka"].ToString());
                    listBox1.Items.Add("Şase No: " + dr["şase"].ToString());
                    listBox1.Items.Add("İşlem: " + dr["işlem"].ToString());
                    listBox1.Items.Add("Ücret: " + dr["ücret"].ToString());
                    listBox1.Items.Add("Geliş KM: " + dr["km"].ToString());
                    listBox1.Items.Add("Araç Rengi: " + dr["renk"].ToString());
                    listBox1.Items.Add("Arıza Türü: " + dr["ariza"].ToString());
                    listBox1.Items.Add("Depo: " + dr["depo"].ToString());
                    listBox1.Items.Add("Kayıt Tarihi: " + dr["tarih"].ToString());
                    if(dr["ek1"].ToString() != "-")
                    {
                        listBox1.Items.Add("Ek İşlem: " + dr["ek1"].ToString());
                        if (dr["ek2"].ToString() != "-")
                        {
                            listBox1.Items.Add("Ek İşlem: " + dr["ek2"].ToString());
                            if (dr["ek3"].ToString() != "-")
                            {
                                listBox1.Items.Add("Ek İşlem: " + dr["ek3"].ToString());
                                if (dr["ek4"].ToString() != "-")
                                {
                                    listBox1.Items.Add("Ek İşlem: " + dr["ek4"].ToString());
                                    mk_ekislem.Enabled = false;
                                    mk_ekücret.Enabled = false;
                                    mk_ekekle.Enabled = false;
                                }
                            }
                        }

                    }
                }
                con.Close();
            }
            else
            {
                listBox1.Items.Clear();
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if ((mk_ad.Text != "") && (mk_ad.Text != "MÜŞTERİ ADI") && (mk_no.Text != "") && (mk_no.Text != "TELEFON") && (mk_model.Text != "") && (mk_model.Text != "ARAÇ MODELİ") && (mk_yil.Text != "") && (mk_yil.Text != "MODEL YILI") && (mk_plaka.Text != "") && (mk_plaka.Text != "PLAKA") && (mk_şase.Text != "") && (mk_şase.Text != "ŞASE NO") && (mk_işlem.Text != "") && (mk_işlem.Text != "İŞLEM") && (mk_ücret.Text != "") && (mk_ücret.Text != "ÜCRET") && (mk_km.Text != "") && (mk_km.Text != "GELİŞ KM") && (mk_renk.Text != "") && (mk_renk.Text != "ARAÇ RENGİ") && (mk_ariza.SelectedIndex >= 0) && (mk_depo.SelectedIndex >= 0))
            {
                string musteri = mk_ad.Text;
                string tel = mk_no.Text;
                string model = mk_model.Text;
                string yil = mk_yil.Text;
                string plaka = mk_plaka.Text;
                string şase = mk_şase.Text;
                string işlem = mk_işlem.Text;
                string ücret = mk_ücret.Text;
                string km = mk_km.Text;
                string renk = mk_renk.Text;
                string servis = mk_ariza.SelectedItem.ToString();
                string depo = mk_depo.SelectedItem.ToString();
                string tarih = DateTime.Now.ToString();
                con.Open();
                string sorgu = "SELECT * FROM musteriler where musteri='" + musteri + "' AND arac='" + model + "' AND yil='" + yil + "'";
                cmd = new MySqlCommand(sorgu, con);
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    con.Close();
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO musteriler (musteri,telefon,arac,yil,plaka,şase,işlem,ücret,km,renk,ariza,depo,tarih,ek1,ek2,ek3,ek4) VALUES (@musteri, @telefon, @arac, @yil, @plaka, @şase, @işlem, @ücret, @km, @renk, @ariza, @depo, @tarih, @ek1, @ek2, @ek3, @ek4)";
                    cmd.Parameters.AddWithValue("@musteri", musteri);
                    cmd.Parameters.AddWithValue("@telefon", tel);
                    cmd.Parameters.AddWithValue("@arac", model);
                    cmd.Parameters.AddWithValue("@yil", yil);
                    cmd.Parameters.AddWithValue("@plaka", plaka);
                    cmd.Parameters.AddWithValue("@şase", şase);
                    cmd.Parameters.AddWithValue("@işlem", işlem);
                    cmd.Parameters.AddWithValue("@ücret", ücret);
                    cmd.Parameters.AddWithValue("@km", km);
                    cmd.Parameters.AddWithValue("@renk", renk);
                    cmd.Parameters.AddWithValue("@ariza", servis);
                    cmd.Parameters.AddWithValue("@depo", depo);
                    cmd.Parameters.AddWithValue("@tarih", tarih);
                    cmd.Parameters.AddWithValue("@ek1", "-");
                    cmd.Parameters.AddWithValue("@ek2", "-");
                    cmd.Parameters.AddWithValue("@ek3", "-");
                    cmd.Parameters.AddWithValue("@ek4", "-");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    musteribul();
                    mk_bul.SelectedIndex = mk_bul.FindStringExact(mk_ad.Text + " - " + mk_yil.Text + " * " + mk_model.Text);
                    mk_ad.Text = "MÜŞTERİ ADI";
                    mk_no.Text = "TELEFON";
                    mk_model.Text = "ARAÇ MODELİ";
                    mk_yil.Text = "MODEL YILI";
                    mk_plaka.Text = "PLAKA";
                    mk_şase.Text = "ŞASE NO";
                    mk_işlem.Text = "İŞLEM";
                    mk_ücret.Text = "ÜCRET";
                    mk_km.Text = "GELİŞ KM";
                    mk_renk.Text = "ARAÇ RENGİ";
                    mk_ariza.SelectedIndex = -1;
                    mk_depo.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Böyle bir müşteri kaydı zaten yapılmış!");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurun!");
            }
        }

        private void mk_filtre_OnValueChanged(object sender, EventArgs e)
        {
            mk_bul.SelectedIndex = -1;
            listBox1.Items.Clear();
            mk_bul.Items.Clear();
            if ((mk_filtre.Text != "FİLTRELE") && (mk_filtre.Text != ""))
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM musteriler";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    if (!mk_bul.Items.Contains(dr["musteri"].ToString() + " - " + dr["yil"].ToString() + " * " + dr["arac"].ToString()))
                    {
                        string item = (dr["musteri"].ToString() + " " + dr["telefon"].ToString() + " " + dr["arac"].ToString() + " " + dr["yil"].ToString() + " " + dr["plaka"].ToString() + " " + dr["şase"].ToString() + " " + dr["işlem"].ToString() + " " + dr["ücret"].ToString() + " " + dr["km"].ToString() + " " + dr["renk"].ToString() + " " + dr["ariza"].ToString() + " " + dr["depo"].ToString() + " " + dr["tarih"].ToString());
                        if (item.Contains(mk_filtre.Text))
                        {
                            mk_bul.Items.Add(dr["musteri"].ToString() + " - " + dr["yil"].ToString() + " * " + dr["arac"].ToString());
                        }
                    }
                }
                con.Close();
            }
            else
            {
                musteribul();
            }
        }

        private void mk_yazdir_Click(object sender, EventArgs e)
        {
            if(mk_bul.SelectedIndex >= 0)
            {
                string a1 = mk_bul.SelectedItem.ToString().Split('-')[0].Remove(mk_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                string aa = mk_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                string a3 = aa.ToString().Split('*')[1].Remove(0, 1);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM musteriler where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "';";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                Yazdır fr = new Yazdır();
                foreach (DataRow dr in dt.Rows)
                {
                    fr.id = dr["id"].ToString();
                    fr.araba = dr["renk"].ToString() + " " +  dr["yil"].ToString() + " " + dr["arac"].ToString();
                    fr.plaka = dr["plaka"].ToString();
                    fr.tarih = dr["tarih"].ToString();
                }
                fr.ShowDialog();
                con.Close();
            }
            else
            {
                MessageBox.Show("Lütfen önce bir veri seçin!");
            }
        }


        private void mk_ekekle_Click(object sender, EventArgs e)
        {
            if((mk_ekislem.Text != "") && (mk_ekislem.Text != "EK İŞLEM") && (mk_ekücret.Text != "") && (mk_ekücret.Text != "EK İŞLEM ÜCRETİ"))
            {
                con.Open();
                cmd.Connection = con;
                string a1 = mk_bul.SelectedItem.ToString().Split('-')[0].Remove(mk_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                string aa = mk_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                string a3 = aa.ToString().Split('*')[1].Remove(0, 1);
                cmd.CommandText = "SELECT * FROM musteriler where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    if ((dr["ek4"].ToString() == "-") && (dr["ek3"].ToString() != "-") && (dr["ek2"].ToString() != "-") && (dr["ek1"].ToString() != "-"))
                    {
                        string Query = "update musteriler set ek4='" + mk_ekücret.Text + " TL - " + mk_ekislem.Text + "' where musteri='" + a1 + "' AND arac='" + a3 + "';";
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        con.Close();
                    }
                    else if ((dr["ek3"].ToString() == "-") && (dr["ek2"].ToString() != "-") && (dr["ek1"].ToString() != "-"))
                    {
                        string Query = "update musteriler set ek3='" + mk_ekücret.Text + " TL - " + mk_ekislem.Text + "' where musteri='" + a1 + "' AND arac='" + a3 + "';";
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        con.Close();
                    }
                    else if ((dr["ek2"].ToString() == "-") && (dr["ek1"].ToString() != "-"))
                    {
                        string Query = "update musteriler set ek2='" + mk_ekücret.Text + " TL - " + mk_ekislem.Text + "' where musteri='" + a1 + "' AND arac='" + a3 + "';";
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        con.Close();
                    }
                    else
                    {
                        string Query = "update musteriler set ek1='" + mk_ekücret.Text + " TL - " + mk_ekislem.Text + "' where musteri='" + a1 + "' AND arac='" + a3 + "';";
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        con.Close();
                    }
                }
                mk_ekislem.Text = "EK İŞLEM";
                mk_ekücret.Text = "EK İŞLEM ÜCRETİ";
                mk_bul.SelectedIndex = -1;
                mk_bul.SelectedIndex = mk_bul.FindStringExact(a1 + " - " + a2 + " * " + a3);
                con.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bütün alanları doldurunuz!");
            }
            con.Close();
        }

        private void kayitsil_Click(object sender, EventArgs e)
        {
            if (mk_bul.SelectedIndex >= 0)
            {
                if ((MessageBox.Show("Seçilen veriyi kalıcı olarak silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    string a1 = mk_bul.SelectedItem.ToString().Split('-')[0].Remove(mk_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                    string aa = mk_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                    string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                    string a3 = aa.ToString().Split('*')[1].Remove(0, 1);
                    string Query = "delete from musteriler where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    con.Close();
                    musteribul();
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce bir kayıt seçin!");
            }
        }

        private void mk_yükle_Click(object sender, EventArgs e)
        {
            if(mk_ad.Text == "MÜŞTERİ ADI")
            {
                if(mk_bul.SelectedIndex >= 0)
                {
                    
                    string a1 = mk_bul.SelectedItem.ToString().Split('-')[0].Remove(mk_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                    string aa = mk_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                    string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                    string a3 = aa.ToString().Split('*')[1].Remove(0, 1);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM musteriler where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "';";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        mk_ad.Text = dr["musteri"].ToString();
                        mk_no.Text = dr["telefon"].ToString();
                        mk_model.Text = dr["arac"].ToString();
                        mk_yil.Text = dr["yil"].ToString();
                        mk_plaka.Text = dr["plaka"].ToString();
                        mk_şase.Text = dr["şase"].ToString();
                        mk_işlem.Text = dr["işlem"].ToString();
                        mk_ücret.Text = dr["ücret"].ToString();
                        mk_km.Text = dr["km"].ToString();
                        mk_renk.Text = dr["renk"].ToString();
                        mk_ariza.SelectedIndex = mk_ariza.FindStringExact(dr["ariza"].ToString());
                        mk_depo.SelectedIndex = mk_depo.FindStringExact(dr["depo"].ToString());
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Lütfen önce bir müşteri seçin!");
                }
            }
            else
            {
                mk_ad.Text = "MÜŞTERİ ADI";
                mk_no.Text = "TELEFON";
                mk_model.Text = "ARAÇ MODELİ";
                mk_yil.Text = "MODEL YILI";
                mk_plaka.Text = "PLAKA";
                mk_şase.Text = "ŞASE NO";
                mk_işlem.Text = "İŞLEM";
                mk_ücret.Text = "ÜCRET";
                mk_km.Text = "GELİŞ KM";
                mk_renk.Text = "ARAÇ RENGİ";
                mk_ariza.SelectedIndex = -1;
                mk_depo.SelectedIndex = -1;
            }
        }

        string musteri1, tel1, model1, yil1, plaka1, şase1, işlem1, ücret1, km1, renk1, servis1, depo1, ek11, ek21, ek31, ek41, tarih1;

        private void mk_düzenle_Click(object sender, EventArgs e)
        {
            if (mk_bul.SelectedIndex >= 0)
            {
                if ((mk_ad.Text != "") && (mk_ad.Text != "MÜŞTERİ ADI") && (mk_no.Text != "") && (mk_no.Text != "TELEFON") && (mk_model.Text != "") && (mk_model.Text != "ARAÇ MODELİ") && (mk_yil.Text != "") && (mk_yil.Text != "MODEL YILI") && (mk_plaka.Text != "") && (mk_plaka.Text != "PLAKA") && (mk_şase.Text != "") && (mk_şase.Text != "ŞASE NO") && (mk_işlem.Text != "") && (mk_işlem.Text != "İŞLEM") && (mk_ücret.Text != "") && (mk_ücret.Text != "ÜCRET") && (mk_km.Text != "") && (mk_km.Text != "GELİŞ KM") && (mk_renk.Text != "") && (mk_renk.Text != "ARAÇ RENGİ") && (mk_ariza.SelectedIndex >= 0) && (mk_depo.SelectedIndex >= 0))
                {
                    string musteri = mk_ad.Text;
                    string tel = mk_no.Text;
                    string model = mk_model.Text;
                    string yil = mk_yil.Text;
                    string plaka = mk_plaka.Text;
                    string şase = mk_şase.Text;
                    string işlem = mk_işlem.Text;
                    string ücret = mk_ücret.Text;
                    string km = mk_km.Text;
                    string renk = mk_renk.Text;
                    string servis = mk_ariza.SelectedItem.ToString();
                    string depo = mk_depo.SelectedItem.ToString();
                    con.Open();
                    string sorgu = "SELECT * FROM musteriler where musteri='" + musteri + "' AND arac='" + model + "' AND yil='" + yil + "'";
                    cmd = new MySqlCommand(sorgu, con);
                    dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        string a1 = mk_bul.SelectedItem.ToString().Split('-')[0].Remove(mk_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                        string aa = mk_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                        string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                        string a3 = aa.ToString().Split('*')[1].Remove(0, 1);
                        con.Close();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT * FROM musteriler where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "';";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            musteri1 = dr["musteri"].ToString();
                            tel1 = dr["telefon"].ToString();
                            model1 = dr["arac"].ToString();
                            yil1 = dr["yil"].ToString();
                            plaka1 = dr["plaka"].ToString();
                            şase1 = dr["şase"].ToString();
                            işlem1 = dr["işlem"].ToString();
                            ücret1 = dr["ücret"].ToString();
                            km1 = dr["km"].ToString();
                            renk1 = dr["renk"].ToString();
                            servis1 = (dr["ariza"].ToString());
                            depo1 = (dr["depo"].ToString());
                        }
                        if ((MessageBox.Show("Seçilen müşteri verilerini aşağıdaki gibi düzenlemek istediğinize emin misiniz?\n\nMüşteri Adı: " + musteri1 + " » " + musteri + "\nTelefon: " + tel1 + " » " + tel + "\nAraç Modeli: " + model1 + " » " + model + "\nModel Yılı: " + yil1 + " » " + yil + "\nPlaka: " + plaka1 + " » " + plaka + "\nŞase No: " + şase1 + " » " + şase + "\nİşlem: " + işlem1 + " » " + işlem + "\nÜcret: " + ücret1 + " » " + ücret + "\nGeliş KM: " + km1 + " » " + km + "\nAraç Rengi: " + renk1 + " » " + renk + "\nArıza Türü: " + servis1 + " » " + servis + "\nDepo: " + depo1 + " » " + depo, "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                        {
                            con.Close();
                            con.Open();
                            cmd = con.CreateCommand();
                            string Query = "update musteriler set musteri='" + musteri + "', telefon='" + tel + "', arac='" + model + "', yil='" + yil + "', plaka='" + plaka + "', şase='" + şase + "', işlem='" + işlem + "', ücret='" + ücret + "', km='" + km + "', renk='" + renk + "', ariza='" + servis + "', depo='" + depo + "' where musteri='" + a1 + "' AND arac='" + a3 + "'";
                            MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                            MySqlDataReader MyReader2;
                            MyReader2 = MyCommand2.ExecuteReader();
                            while (MyReader2.Read())
                            {
                            }
                            con.Close();
                            musteribul();
                            mk_bul.SelectedIndex = mk_bul.FindStringExact(mk_ad.Text + " - " + mk_yil.Text + " * " + mk_model.Text);
                            mk_ad.Text = "MÜŞTERİ ADI";
                            mk_no.Text = "TELEFON";
                            mk_model.Text = "ARAÇ MODELİ";
                            mk_yil.Text = "MODEL YILI";
                            mk_plaka.Text = "PLAKA";
                            mk_şase.Text = "ŞASE NO";
                            mk_işlem.Text = "İŞLEM";
                            mk_ücret.Text = "ÜCRET";
                            mk_km.Text = "GELİŞ KM";
                            mk_renk.Text = "ARAÇ RENGİ";
                            mk_ariza.SelectedIndex = -1;
                            mk_depo.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        if(mk_bul.Text == musteri + " - " + yil + " * " + model)
                        {
                            string a1 = mk_bul.SelectedItem.ToString().Split('-')[0].Remove(mk_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                            string aa = mk_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                            string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                            string a3 = aa.ToString().Split('*')[1].Remove(0, 1);
                            con.Close();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "SELECT * FROM musteriler where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "';";
                            cmd.ExecuteNonQuery();
                            DataTable dt = new DataTable();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                musteri1 = dr["musteri"].ToString();
                                tel1 = dr["telefon"].ToString();
                                model1 = dr["arac"].ToString();
                                yil1 = dr["yil"].ToString();
                                plaka1 = dr["plaka"].ToString();
                                şase1 = dr["şase"].ToString();
                                işlem1 = dr["işlem"].ToString();
                                ücret1 = dr["ücret"].ToString();
                                km1 = dr["km"].ToString();
                                renk1 = dr["renk"].ToString();
                                servis1 = (dr["ariza"].ToString());
                                depo1 = (dr["depo"].ToString());
                            }
                            if ((MessageBox.Show("Seçilen müşteri verilerini aşağıdaki gibi düzenlemek istediğinize emin misiniz?\n\nMüşteri Adı: " + musteri1 + " » " + musteri + "\nTelefon: " + tel1 + " » " + tel + "\nAraç Modeli: " + model1 + " » " + model + "\nModel Yılı: " + yil1 + " » " + yil + "\nPlaka: " + plaka1 + " » " + plaka + "\nŞase No: " + şase1 + " » " + şase + "\nİşlem: " + işlem1 + " » " + işlem + "\nÜcret: " + ücret1 + " » " + ücret + "\nGeliş KM: " + km1 + " » " + km + "\nAraç Rengi: " + renk1 + " » " + renk + "\nArıza Türü: " + servis1 + " » " + servis + "\nDepo: " + depo1 + " » " + depo, "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                            {
                                con.Close();
                                con.Open();
                                cmd = con.CreateCommand();
                                string Query = "update musteriler set musteri='" + musteri + "', telefon='" + tel + "', arac='" + model + "', yil='" + yil + "', plaka='" + plaka + "', şase='" + şase + "', işlem='" + işlem + "', ücret='" + ücret + "', km='" + km + "', renk='" + renk + "', ariza='" + servis + "', depo='" + depo + "' where musteri='" + a1 + "' AND arac='" + a3 + "'";
                                MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                                MySqlDataReader MyReader2;
                                MyReader2 = MyCommand2.ExecuteReader();
                                while (MyReader2.Read())
                                {
                                }
                                con.Close();
                                musteribul();
                                mk_bul.SelectedIndex = mk_bul.FindStringExact(mk_ad.Text + " - " + mk_yil.Text + " * " + mk_model.Text);
                                mk_ad.Text = "MÜŞTERİ ADI";
                                mk_no.Text = "TELEFON";
                                mk_model.Text = "ARAÇ MODELİ";
                                mk_yil.Text = "MODEL YILI";
                                mk_plaka.Text = "PLAKA";
                                mk_şase.Text = "ŞASE NO";
                                mk_işlem.Text = "İŞLEM";
                                mk_ücret.Text = "ÜCRET";
                                mk_km.Text = "GELİŞ KM";
                                mk_renk.Text = "ARAÇ RENGİ";
                                mk_ariza.SelectedIndex = -1;
                                mk_depo.SelectedIndex = -1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Böyle bir müşteri kaydı zaten yapılmış!");
                        }
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Lütfen bütün boşlukları doldurun!");
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce bir müşteri seçin!");
            }
        }

        private void gecmis_Click(object sender, EventArgs e)
        {
            if (mk_bul.SelectedIndex >= 0)
            {
                string a1 = mk_bul.SelectedItem.ToString().Split('-')[0].Remove(mk_bul.SelectedItem.ToString().Split('-')[0].Length - 1);
                string aa = mk_bul.SelectedItem.ToString().Split('-')[1].Remove(0, 1);
                string a2 = aa.ToString().Split('*')[0].Remove(aa.ToString().Split('*')[0].Length - 1);
                string a3 = aa.ToString().Split('*')[1].Remove(0, 1);
                con.Open();
                string sorgu = "SELECT * FROM gecmis where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "'";
                cmd = new MySqlCommand(sorgu, con);
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    if ((MessageBox.Show("Seçilen müşteri verilerini geçmişe atmak istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                    {
                        con.Close();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT * FROM musteriler where musteri='" + a1 + "' AND arac='" + a3 + "' AND yil='" + a2 + "';";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            musteri1 = dr["musteri"].ToString();
                            tel1 = dr["telefon"].ToString();
                            model1 = dr["arac"].ToString();
                            yil1 = dr["yil"].ToString();
                            plaka1 = dr["plaka"].ToString();
                            şase1 = dr["şase"].ToString();
                            işlem1 = dr["işlem"].ToString();
                            ücret1 = dr["ücret"].ToString();
                            km1 = dr["km"].ToString();
                            renk1 = dr["renk"].ToString();
                            servis1 = (dr["ariza"].ToString());
                            depo1 = (dr["depo"].ToString());
                            tarih1 = (dr["tarih"].ToString());
                            ek11 = (dr["ek1"].ToString());
                            ek21 = (dr["ek2"].ToString());
                            ek31 = (dr["ek3"].ToString());
                            ek41 = (dr["ek4"].ToString());
                        }
                        con.Close();
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "INSERT INTO gecmis (musteri,telefon,arac,yil,plaka,şase,işlem,ücret,km,renk,ariza,depo,tarih,ek1,ek2,ek3,ek4,tarih2) VALUES (@musteri, @telefon, @arac, @yil, @plaka, @şase, @işlem, @ücret, @km, @renk, @ariza, @depo, @tarih, @ek1, @ek2, @ek3, @ek4, @tarih2)";
                        cmd.Parameters.AddWithValue("@musteri", musteri1);
                        cmd.Parameters.AddWithValue("@telefon", tel1);
                        cmd.Parameters.AddWithValue("@arac", model1);
                        cmd.Parameters.AddWithValue("@yil", yil1);
                        cmd.Parameters.AddWithValue("@plaka", plaka1);
                        cmd.Parameters.AddWithValue("@şase", şase1);
                        cmd.Parameters.AddWithValue("@işlem", işlem1);
                        cmd.Parameters.AddWithValue("@ücret", ücret1);
                        cmd.Parameters.AddWithValue("@km", km1);
                        cmd.Parameters.AddWithValue("@renk", renk1);
                        cmd.Parameters.AddWithValue("@ariza", servis1);
                        cmd.Parameters.AddWithValue("@depo", depo1);
                        cmd.Parameters.AddWithValue("@tarih", tarih1);
                        cmd.Parameters.AddWithValue("@ek1", ek11);
                        cmd.Parameters.AddWithValue("@ek2", ek21);
                        cmd.Parameters.AddWithValue("@ek3", ek31);
                        cmd.Parameters.AddWithValue("@ek4", ek41);
                        cmd.Parameters.AddWithValue("@tarih2", DateTime.Now);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        string Query = "delete from musteriler where musteri='" + musteri1 + "' AND arac='" + model1 + "' AND yil='" + yil1 + "';";
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        con.Close();
                        musteribul();
                    }
                }
                else
                {
                    MessageBox.Show("Geçmişte böyle bir kayıt zaten mevcut!");
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce bir müşteri seçin!");
            }
        }

        private void mk_ad_Enter(object sender, EventArgs e)
        {
            if(mk_ad.Text == "MÜŞTERİ ADI")
            {
                mk_ad.Text = "";
            }
        }

        private void mk_ad_Leave(object sender, EventArgs e)
        {
            if (mk_ad.Text == "")
            {
                mk_ad.Text = "MÜŞTERİ ADI";
            }
        }

        private void mk_no_Enter(object sender, EventArgs e)
        {
            if (mk_no.Text == "TELEFON")
            {
                mk_no.Text = "";
            }
        }
        private void mk_no_Leave(object sender, EventArgs e)
        {
            if (mk_no.Text == "")
            {
                mk_no.Text = "TELEFON";
            }
        }

        private void mk_model_Enter(object sender, EventArgs e)
        {
            if (mk_model.Text == "ARAÇ MODELİ")
            {
                mk_model.Text = "";
            }
        }

        private void mk_model_Leave(object sender, EventArgs e)
        {
            if (mk_model.Text == "")
            {
                mk_model.Text = "ARAÇ MODELİ";
            }
        }

        private void mk_yil_Enter(object sender, EventArgs e)
        {
            if (mk_yil.Text == "MODEL YILI")
            {
                mk_yil.Text = "";
            }
        }

        private void mk_yil_Leave(object sender, EventArgs e)
        {
            if (mk_yil.Text == "")
            {
                mk_yil.Text = "MODEL YILI";
            }
        }

        private void mk_plaka_Enter(object sender, EventArgs e)
        {
            if (mk_plaka.Text == "PLAKA")
            {
                mk_plaka.Text = "";
            }
        }

        private void mk_plaka_Leave(object sender, EventArgs e)
        {
            if (mk_plaka.Text == "")
            {
                mk_plaka.Text = "PLAKA";
            }
        }

        private void mk_şase_Enter(object sender, EventArgs e)
        {
            if (mk_şase.Text == "ŞASE NO")
            {
                mk_şase.Text = "";
            }
        }

        private void mk_şase_Leave(object sender, EventArgs e)
        {
            if (mk_şase.Text == "")
            {
                mk_şase.Text = "ŞASE NO";
            }
        }

        private void mk_işlem_Enter(object sender, EventArgs e)
        {
            if (mk_işlem.Text == "İŞLEM")
            {
                mk_işlem.Text = "";
            }
        }

        private void mk_işlem_Leave(object sender, EventArgs e)
        {
            if (mk_işlem.Text == "")
            {
                mk_işlem.Text = "İŞLEM";
            }
        }

        private void mk_ücret_Enter(object sender, EventArgs e)
        {
            if (mk_ücret.Text == "ÜCRET")
            {
                mk_ücret.Text = "";
            }
        }

        private void mk_ücret_Leave(object sender, EventArgs e)
        {
            if (mk_ücret.Text == "")
            {
                mk_ücret.Text = "ÜCRET";
            }
        }

        private void mk_km_Enter(object sender, EventArgs e)
        {
            if (mk_km.Text == "GELİŞ KM")
            {
                mk_km.Text = "";
            }
        }

        private void mk_km_Leave(object sender, EventArgs e)
        {
            if (mk_km.Text == "")
            {
                mk_km.Text = "GELİŞ KM";
            }
        }

        private void mk_renk_Enter(object sender, EventArgs e)
        {
            if (mk_renk.Text == "ARAÇ RENGİ")
            {
                mk_renk.Text = "";
            }
        }

        private void mk_renk_Leave(object sender, EventArgs e)
        {
            if (mk_renk.Text == "")
            {
                mk_renk.Text = "ARAÇ RENGİ";
            }
        }

        private void mk_filtre_Enter(object sender, EventArgs e)
        {
            if (mk_filtre.Text == "FİLTRELE")
            {
                mk_filtre.Text = "";
            }
        }

        private void mk_filtre_Leave(object sender, EventArgs e)
        {
            if (mk_filtre.Text == "")
            {
                mk_filtre.Text = "FİLTRELE";
            }
        }

        private void mk_ekislem_Enter(object sender, EventArgs e)
        {
            if (mk_ekislem.Text == "EK İŞLEM")
            {
                mk_ekislem.Text = "";
            }
        }

        private void mk_ekislem_Leave(object sender, EventArgs e)
        {
            if (mk_ekislem.Text == "")
            {
                mk_ekislem.Text = "EK İŞLEM";
            }
        }

        private void mk_ekücret_Leave(object sender, EventArgs e)
        {
            if (mk_ekücret.Text == "")
            {
                mk_ekücret.Text = "EK İŞLEM ÜCRETİ";
            }
        }

        private void mk_ekücret_Enter(object sender, EventArgs e)
        {
            if (mk_ekücret.Text == "EK İŞLEM ÜCRETİ")
            {
                mk_ekücret.Text = "";
            }
        }

        private void mk_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


































        //---------------------------------> MENÜ

        int x, p, y, op, fd1, fd2, isl;

        private void m1_Click(object sender, EventArgs e)
        {
            if (op != 1)
            {
                x = 26;
                y = 0;
                p = 1;
                timer5.Start();
                fd1 = panel6.Location.Y;
                fd2 = 38;
                if (fd1 > fd2) { isl = 1; }
                else { isl = 2; }
                timer6.Start();
                VeriTabanı.Visible = true;
                mk_1.Visible= true;
                mk_2.Visible= true;
                kg_1.Visible = false;
                kg_2.Visible = false;
                gg_1.Visible = false;
                gg_2.Visible = false;
                vd_1.Visible = false;
                vd_2.Visible = false;
                sl_1.Visible = false;
                sl_2.Visible = false;
                n1.Visible = false;
                yp2.Visible = false;
                yp1.Visible = false;
                n2.Visible = false;
                mk_ad.Text = "MÜŞTERİ ADI";
                mk_no.Text = "TELEFON";
                mk_model.Text = "ARAÇ MODELİ";
                mk_yil.Text = "MODEL YILI";
                mk_plaka.Text = "PLAKA";
                mk_şase.Text = "ŞASE NO";
                mk_işlem.Text = "İŞLEM";
                mk_ücret.Text = "ÜCRET";
                mk_km.Text = "GELİŞ KM";
                mk_renk.Text = "ARAÇ RENGİ";
                mk_ariza.SelectedIndex = -1;
                mk_depo.SelectedIndex = -1;
                mk_ekislem.Text = "EK İŞLEM";
                mk_ekücret.Text = "EK İŞLEM ÜCRETİ";
                mk_filtre.Text = "FİLTRELE";
                musteribul();
            }
        }

        private void m2_Click(object sender, EventArgs e)
        {
            if (op != 2)
            {
                x = 26;
                y = 0;
                p = 2;
                timer5.Start();
                fd1 = panel6.Location.Y;
                fd2 = 88;
                if (fd1 > fd2) { isl = 1; }
                else { isl = 2; }
                timer6.Start();
            }
            VeriTabanı.Visible = true;
            mk_1.Visible = true;
            mk_2.Visible = true;
            kg_1.Visible = true;
            kg_2.Visible = true;
            kg_filtre.Text = "FİLTRELE";
            gg_1.Visible = false;
            gg_2.Visible = false;
            vd_1.Visible = false;
            vd_2.Visible = false;
            sl_1.Visible = false;
            sl_2.Visible = false;
            n1.Visible = false;
            yp2.Visible = false;
            yp1.Visible = false;
            n2.Visible = false;
            gecmisbul();
        }

        private void m3_Click(object sender, EventArgs e)
        {
            if (op != 3)
            {
                x = 26;
                y = 0;
                p = 3;
                timer5.Start();
                fd1 = panel6.Location.Y;
                fd2 = 138;
                if (fd1 > fd2) { isl = 1; }
                else { isl = 2; }
                timer6.Start();
            }
            VeriTabanı.Visible = true;
            mk_1.Visible = true;
            mk_2.Visible = true;
            kg_1.Visible = true;
            kg_2.Visible = true;
            gg_1.Visible = true;
            gg_2.Visible = true;
            vd_1.Visible = false;
            vd_2.Visible = false;
            sl_1.Visible = false;
            sl_2.Visible = false;
            n1.Visible = false;
            yp2.Visible = false;
            yp1.Visible = false;
            n2.Visible = false;
            gg_islem.Text = "İŞLEM";
            gg_ücret.Text = "ÜCRET";
            gglist();
        }

        private void m4_Click(object sender, EventArgs e)
        {
            if (op != 4)
            {
                x = 26;
                y = 0;
                p = 4;
                timer5.Start();
                fd1 = panel6.Location.Y;
                fd2 = 188;
                if (fd1 > fd2) { isl = 1; }
                else { isl = 2; }
                timer6.Start();
            }
            VeriTabanı.Visible = true;
            mk_1.Visible = true;
            mk_2.Visible = true;
            kg_1.Visible = true;
            kg_2.Visible = true;
            gg_1.Visible = true;
            gg_2.Visible = true;
            vd_1.Visible = true;
            vd_2.Visible = true;
            sl_1.Visible = false;
            sl_2.Visible = false;
            n1.Visible = false;
            yp2.Visible = false;
            yp1.Visible = false;
            n2.Visible = false;
            vd_isim.Text = "İSİM SOYİSİM";
            vd_tel.Text = "TELEFON NO";
            vd_alacak.Text = "ALACAK";
            vd_filtre.Text = "FİLTRELE";
            vd_tarihfiltre.Checked = false;
            veresiye();
        }

        private void m5_Click(object sender, EventArgs e)
        {
            if (op != 5)
            {
                x = 26;
                y = 0;
                p = 5;
                timer5.Start();
                fd1 = panel6.Location.Y;
                fd2 = 238;
                if (fd1 > fd2) { isl = 1; }
                else { isl = 2; }
                timer6.Start();
            }
            VeriTabanı.Visible = true;
            mk_1.Visible = true;
            mk_2.Visible = true;
            kg_1.Visible = true;
            kg_2.Visible = true;
            gg_1.Visible = true;
            gg_2.Visible = true;
            vd_1.Visible = true;
            vd_2.Visible = true;
            sl_1.Visible = true;
            sl_2.Visible = true;
            n1.Visible = false;
            yp2.Visible = false;
            yp1.Visible = false;
            n2.Visible = false;
        }

        private void m6_Click(object sender, EventArgs e)
        {
            if (op != 6)
            {
                x = 26;
                y = 0;
                p = 6;
                timer5.Start();
                fd1 = panel6.Location.Y;
                fd2 = 288;
                if (fd1 > fd2) { isl = 1; }
                else { isl = 2; }
                timer6.Start();
            }
            VeriTabanı.Visible = true;
            mk_1.Visible = true;
            mk_2.Visible = true;
            kg_1.Visible = true;
            kg_2.Visible = true;
            gg_1.Visible = true;
            gg_2.Visible = true;
            vd_1.Visible = true;
            vd_2.Visible = true;
            sl_1.Visible = true;
            sl_2.Visible = true;
            n1.Visible = true;
            n2.Visible = true;
            yp2.Visible = false;
            yp1.Visible = false;
            n_baslik.Text = "NOT BAŞLIĞI";
            n_gövde.Text = "";
            not();
        }

        private void m7_Click(object sender, EventArgs e)
        {
            if (op != 7)
            {
                x = 26;
                y = 0;
                p = 7;
                timer5.Start();
                fd1 = panel6.Location.Y;
                fd2 = 338;
                if (fd1 > fd2) { isl = 1; }
                else { isl = 2; }
                timer6.Start();
            }
            VeriTabanı.Visible = true;
            mk_1.Visible = true;
            mk_2.Visible = true;
            kg_1.Visible = true;
            kg_2.Visible = true;
            gg_1.Visible = true;
            gg_2.Visible = true;
            vd_1.Visible = true;
            vd_2.Visible = true;
            sl_1.Visible = true;
            sl_2.Visible = true;
            n1.Visible = true;
            yp2.Visible = true;
            yp1.Visible = true;
            n2.Visible = true;
            yp();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (p == 1)
            {
                m1.BackColor = Color.FromArgb(x - 2, x - 2, x - 2);
            }
            if (op == 1)
            {
                m1.BackColor = Color.FromArgb(y + 2, y + 2, y + 2);
            }
            if (p == 2)
            {
                m2.BackColor = Color.FromArgb(x - 2, x - 2, x - 2);
            }
            if (op == 2)
            {
                m2.BackColor = Color.FromArgb(y + 2, y + 2, y + 2);
            }
            if (p == 3)
            {
                m3.BackColor = Color.FromArgb(x - 2, x - 2, x - 2);
            }
            if (op == 3)
            {
                m3.BackColor = Color.FromArgb(y + 2, y + 2, y + 2);
            }
            if (p == 4)
            {
                m4.BackColor = Color.FromArgb(x - 2, x - 2, x - 2);
            }
            if (op == 4)
            {
                m4.BackColor = Color.FromArgb(y + 2, y + 2, y + 2);
            }
            if (p == 5)
            {
                m5.BackColor = Color.FromArgb(x - 2, x - 2, x - 2);
            }
            if (op == 5)
            {
                m5.BackColor = Color.FromArgb(y + 2, y + 2, y + 2);
            }
            if (p == 6)
            {
                m6.BackColor = Color.FromArgb(x - 2, x - 2, x - 2);
            }
            if (op == 6)
            {
                m6.BackColor = Color.FromArgb(y + 2, y + 2, y + 2);
            }
            if (p == 7)
            {
                m7.BackColor = Color.FromArgb(x - 2, x - 2, x - 2);
            }
            if (op == 7)
            {
                m7.BackColor = Color.FromArgb(y + 2, y + 2, y + 2);
            }
            x = x - 2;
            y = y + 2;
            if (x == 0)
            {
                timer5.Stop();
                op = p;
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (isl == 1)
            {
                if (panel6.Location.Y > fd2)
                {
                    panel6.Location = new Point(0, panel6.Location.Y - 10);
                    if (panel6.Location.X < 0)
                    {
                        panel6.Location = new Point(panel6.Location.X + 1, panel6.Location.Y);
                    }
                }
                else
                {
                    timer6.Stop();
                }
            }
            else
            {
                if (panel6.Location.Y < fd2)
                {
                    panel6.Location = new Point(0, panel6.Location.Y + 10);
                    if (panel6.Location.X < 0)
                    {
                        panel6.Location = new Point(panel6.Location.X + 1, panel6.Location.Y);
                    }
                }
                else
                {
                    timer6.Stop();
                }
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            tarihsaat.Text = DateTime.Now.ToString();
        }



























        //---------------------------------> BİZE ULAŞIN

        private void facebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/harun.bulbul.5836");
        }

        private void instagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.instagram.com/hrn_blbl");
        }

        private void twitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitter.com/hrn_blbl");
        }
    }
}
