using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Görsel_Programlama
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            FormClosing += Form2_FormClosing;
        }

        int x;
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (x == 9999)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
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
            this.DialogResult = DialogResult.OK;
        }

        private void vt_sunucu_Enter(object sender, EventArgs e)
        {
            if (vt_sunucu.Text == "SUNUCU")
            {
                vt_sunucu.Text = "";
            }
        }

        private void vt_sunucu_Leave(object sender, EventArgs e)
        {
            if (vt_sunucu.Text == "")
            {
                vt_sunucu.Text = "SUNUCU";
            }
        }

        private void vt_kullanıcı_Enter(object sender, EventArgs e)
        {
            if (vt_kullanıcı.Text == "KULLANICI")
            {
                vt_kullanıcı.Text = "";
            }
        }

        private void vt_kullanıcı_Leave(object sender, EventArgs e)
        {
            if (vt_kullanıcı.Text == "")
            {
                vt_kullanıcı.Text = "KULLANICI";
            }
        }

        private void vt_sifre_Enter(object sender, EventArgs e)
        {
            if (vt_sifre.Text == "ŞİFRE")
            {
                vt_sifre.Text = "";
                vt_sifre.isPassword = true;
            }
        }

        private void vt_sifre_Leave(object sender, EventArgs e)
        {
            if (vt_sifre.Text == "")
            {
                vt_sifre.Text = "ŞİFRE";
                vt_sifre.isPassword = false;
            }
        }

        MySqlConnection con;
        MySqlCommand cmd;

        string host, kullanici, sifre, line;

        private void Form5_Load(object sender, EventArgs e)
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
                durum.BackColor = Color.Green;
                baglanti.Text = "Bağlanılan sunucu: " + host + " (" + kullanici + ")";
            }
        }

        private void vt_kontrol_Click(object sender, EventArgs e)
        {
            string path1 = @"C:\Users\" + SystemInformation.UserName + @"\AppData\OST\config.txt";
            string subPath1 = @"C:\Users\" + SystemInformation.UserName + @"\AppData\OST";
            if (!Directory.Exists(subPath1))
            {
                Directory.CreateDirectory(subPath1);
                using (StreamWriter sw = System.IO.File.AppendText(path1))
                {
                    sw.WriteLine("Sunucu=''");
                    sw.WriteLine("Kullanıcı=''");
                    sw.WriteLine("Şifre=''");
                }
            }
            if (((vt_sunucu.Text != "") && (vt_sunucu.Text != "SUNUCU")) && ((vt_kullanıcı.Text != "") && (vt_kullanıcı.Text != "KULLANICI")) && vt_sifre.isPassword == true)
            {
                con = new MySqlConnection("server=" + vt_sunucu.Text + ";user=" + vt_kullanıcı.Text + ";password=" + vt_sifre.Text);
                try
                {
                    using (con)
                    {

                        host = vt_sunucu.Text;
                        kullanici = vt_kullanıcı.Text;
                        sifre = vt_sifre.Text;
                        con.Open();
                        MessageBox.Show("Veri tabanı bağlantısı başarıyla kuruldu!");
                        string path = @"C:\Users\" + SystemInformation.UserName + @"\AppData\OST\config.txt";
                        System.IO.File.Delete(path);
                        using (StreamWriter sw = System.IO.File.AppendText(path))
                        {
                            sw.WriteLine("Sunucu=" + vt_sunucu.Text);
                            sw.WriteLine("Kullanıcı=" + vt_kullanıcı.Text);
                            sw.WriteLine("Şifre=" + vt_sifre.Text);
                        }
                        durum.BackColor = Color.Green;
                        baglanti.Text = "Bağlanılan sunucu: " + vt_sunucu.Text + " (" + vt_kullanıcı.Text + ")";
                        x = 9999;
                        using (var connection = new MySqlConnection("server=" + vt_sunucu.Text + ";user=" + vt_kullanıcı.Text + ";password=" + vt_sifre.Text + ";database=GorselProgramlama"))
                        {
                            var command = con.CreateCommand();
                            command = con.CreateCommand();
                            command.CommandText = "create schema if not exists GorselProgramlama";
                            command.ExecuteNonQuery();
                            connection.Open();
                            MySqlCommand Create_table;
                            Create_table = new MySqlCommand("CREATE TABLE if not exists Kullanicilar (id INT NOT NULL AUTO_INCREMENT, kullanici VARCHAR(1500), sifre VARCHAR(1500), PRIMARY KEY (id))", connection);
                            Create_table.ExecuteNonQuery();
                            Create_table = new MySqlCommand("CREATE TABLE if not exists Musteriler (id INT NOT NULL AUTO_INCREMENT, musteri VARCHAR(500), telefon VARCHAR(500), arac VARCHAR(500),  yil VARCHAR(500),  plaka VARCHAR(500), şase VARCHAR(500), işlem VARCHAR(500), ücret VARCHAR(500), km VARCHAR(500), renk VARCHAR(1500), ariza VARCHAR(500), depo VARCHAR(500), tarih VARCHAR(500), ek1 VARCHAR(500), ek2 VARCHAR(500), ek3 VARCHAR(500), ek4 VARCHAR(500), PRIMARY KEY (id))", connection);
                            Create_table.ExecuteNonQuery();
                            Create_table = new MySqlCommand("CREATE TABLE if not exists Gecmis (id INT NOT NULL AUTO_INCREMENT, musteri VARCHAR(500), telefon VARCHAR(500), arac VARCHAR(500),  yil VARCHAR(500),  plaka VARCHAR(500), şase VARCHAR(500), işlem VARCHAR(500), ücret VARCHAR(500), km VARCHAR(500), renk VARCHAR(1500), ariza VARCHAR(500), depo VARCHAR(500), tarih VARCHAR(500), ek1 VARCHAR(500), ek2 VARCHAR(500), ek3 VARCHAR(500), ek4 VARCHAR(500), tarih2 VARCHAR(500), PRIMARY KEY (id))", connection);
                            Create_table.ExecuteNonQuery();
                            Create_table = new MySqlCommand("CREATE TABLE if not exists Gelir (islem VARCHAR(500), ücret VARCHAR(500), gun VARCHAR(500), ay VARCHAR(500), yil VARCHAR(500))", connection);
                            Create_table.ExecuteNonQuery();
                            Create_table = new MySqlCommand("CREATE TABLE if not exists Gider (islem VARCHAR(500), ücret VARCHAR(500), gun VARCHAR(500), ay VARCHAR(500), yil VARCHAR(500))", connection);
                            Create_table.ExecuteNonQuery();
                            Create_table = new MySqlCommand("CREATE TABLE if not exists Veresiye (İsim VARCHAR(500), Telefon VARCHAR(500), Alacak VARCHAR(500), Tarih VARCHAR(500))", connection);
                            Create_table.ExecuteNonQuery();
                            Create_table = new MySqlCommand("CREATE TABLE if not exists Siparis (Adet VARCHAR(500), Sipariş VARCHAR(600))", connection);
                            Create_table.ExecuteNonQuery();
                            Create_table = new MySqlCommand("CREATE TABLE if not exists SiparisMusteri (Adet VARCHAR(500), Sipariş VARCHAR(600), Müşteri VARCHAR(500), Telefon VARCHAR(500), Alacak VARCHAR(500), Kapora VARCHAR(500), Kalan VARCHAR(500))", connection);
                            Create_table.ExecuteNonQuery();
                            Create_table = new MySqlCommand("CREATE TABLE if not exists notlar (baslik VARCHAR(500), gövde VARCHAR(2000))", connection);
                            Create_table.ExecuteNonQuery();
                            cmd = connection.CreateCommand();
                            cmd.CommandText = "SELECT COUNT(*) from Kullanicilar";
                            int result = int.Parse(cmd.ExecuteScalar().ToString());
                            if (result == 0)
                            {
                                Form2 fr = new Form2();
                                fr.host = vt_sunucu.Text;
                                fr.user = vt_kullanıcı.Text;
                                fr.pw = vt_sifre.Text;
                                fr.ShowDialog();
                                cmd = connection.CreateCommand();
                                cmd.CommandText = "SELECT COUNT(*) from Kullanicilar";
                                result = int.Parse(cmd.ExecuteScalar().ToString());
                                if (result == 0)
                                {
                                    MessageBox.Show("Yönetici hesabı şifresi belirlemediğiniz için veri tabanı bağlantısı kesildi!");
                                    durum.BackColor = Color.FromArgb(192, 0, 0);
                                    baglanti.Text = "Bağlantı yok!";
                                    x = 0;
                                    Directory.Delete(@"C:\Users\" + SystemInformation.UserName + @"\AppData\OST", true);
                                }
                                else
                                {
                                    x = 9999;
                                    this.Close();
                                }
                            }
                            connection.Close();
                        }
                        con.Close();
                        vt_sunucu.Text = "SUNUCU";
                        vt_kullanıcı.Text = "KULLANICI";
                        vt_sifre.Text = "ŞİFRE";
                        vt_sifre.isPassword = false;
                    }
                }
                catch (Exception ex)
                {
                    durum.BackColor = Color.FromArgb(192, 0, 0);
                    baglanti.Text = "Bağlantı yok!";
                    MessageBox.Show("Veri tabanına bağlanılamadı!\n\n" + ex.Message);
                    x = 0;
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bütün alanları doldurun.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
