using Org.BouncyCastle.Crypto.Paddings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Görsel_Programlama
{
    public partial class Yazdır : Form
    {
        public Yazdır()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //See if any printers are installed  
            if (PrinterSettings.InstalledPrinters.Count <= 0)
            {
                MessageBox.Show("Printer not found!");
                return;
            }

            //Get all available printers and add them to the combo box  
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                guna2ComboBox1.Items.Add(printer.ToString());
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Create a PrintDocument object  
            PrintDocument pd = new PrintDocument();

            //Set PrinterName as the selected printer in the printers list  
            pd.PrinterSettings.PrinterName =
            guna2ComboBox1.SelectedItem.ToString();

            //Add PrintPage event handler  
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            //Print the document  
            PrintPreviewDialog p2d= new PrintPreviewDialog();
            p2d.Document= pd;
            p2d.ShowIcon= false;
            p2d.ShowDialog();
        }

        public string id, araba, plaka, tarih;

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

        public void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Graphics g = ev.Graphics; 
            g.DrawString("Müşteri ID: " + id +  "\nAraba: " + araba + "\nPlaka: " + plaka + "\nTarih: " + tarih, new Font("Century Gothic", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(10, 20, 200, 100));
           
        }
    }
}
