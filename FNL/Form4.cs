using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;

namespace FNL
{


    public partial class Form4 : Form
    {
        int i = 0;
        List<Igraci> igraci = funkcije.DohvatiIgrace();
        public Form4()
        {
            InitializeComponent();

        }

        private void Postavi_Igraca(List<Igraci> igraci, int j)
        {
            if (igraci == null || igraci.Count == 0 || j >= igraci.Count || j < 0)
            {
                MessageBox.Show("Nema igrača u bazi podataka.");
                return;
            }

            textBox_ime.Text = igraci[j].Ime;
            textBox8_prezime.Text = igraci[j].Prezime;
            textBox_golovi.Text = igraci[j].Pogoci.ToString();
            textBox_datum_rodjenja.Text = igraci[j].DatumRodjenja;
            textBox_mjesto_rodjenja.Text = igraci[j].MjestoRodjenja;
            textBox_klub.Text = igraci[j].Klub;
            textBox_11start.Text = igraci[j].Zapoceo.ToString();
            textBox_crv.Text = igraci[j].CrvKartoni.ToString();
            textBox_zut.Text = igraci[j].ZutKartoni.ToString();
            textBox_klupa.Text = igraci[j].UsaoSKlupe.ToString();
            textBox_nastupi.Text = igraci[j].Nastupi.ToString();

            pictureBox1.Image = !string.IsNullOrEmpty(igraci[j].Slika) ? Igraci.LoadImageFromUrl(igraci[j].Slika) : null;
            pictureBox2.Image = !string.IsNullOrEmpty(igraci[j].GrbKluba) ? Igraci.LoadImageFromUrl(igraci[j].GrbKluba) : null;
        }



        private void Form4_Load(object sender, EventArgs e)
        {

            Postavi_Igraca(igraci, 0);
            StilizirajKontrole();

            search_txt.ReadOnly = false;
            search_txt.Enabled = true;


        }
        private void StilizirajKontrole()
        {



            button1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);

            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is TextBox textBox)
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.Black;
                    textBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.TextAlign = HorizontalAlignment.Left;
                    textBox.ReadOnly = true;
                    textBox.Enabled = false;
                }
                textBox_datum_rodjenja.Width = 180;

                if (ctrl is Label label)
                {
                    label.ForeColor = Color.FromArgb(51, 51, 51);
                    label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    label.TextAlign = ContentAlignment.MiddleLeft;
                    label.AutoSize = true;
                }


                if (ctrl is Button button)
                {
                    button.BackColor = Color.FromArgb(33, 150, 243);
                    button.ForeColor = Color.White;
                    button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Height = 30;
                    button.Width = 100;
                    button.Cursor = Cursors.Hand;


                    button.MouseEnter += (s, e) =>
                    {
                        button.BackColor = Color.FromArgb(25, 118, 210);
                    };

                    button.MouseLeave += (s, e) =>
                    {
                        button.BackColor = Color.FromArgb(33, 150, 243);
                    };
                }
                button1.Text = "←";
                button2.Text = "→";
                button1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
                button2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
                button1.TextAlign = ContentAlignment.MiddleCenter;
                button2.TextAlign = ContentAlignment.MiddleCenter;
                button1.Size = new Size(40, 50);
                button2.Size = new Size(40, 50);
                button1.BackColor = Color.FromArgb(33, 150, 243);
                button2.BackColor = Color.FromArgb(33, 150, 243);

                search_btn.Text = "🔍";
                search_btn.Size = new Size(70, 40);
                search_btn.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
                search_btn.TextAlign = ContentAlignment.MiddleCenter;
                search_btn.BackColor = Color.White;
                search_btn.ForeColor = Color.Black;
                search_btn.FlatStyle = FlatStyle.Flat;
                search_btn.FlatAppearance.BorderSize = 1;
                search_btn.FlatAppearance.BorderColor = Color.Silver;
                search_btn.Cursor = Cursors.Hand;
                search_btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, search_btn.Width, search_btn.Height, 10, 10));

            }
        }
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
    int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
    int nWidthEllipse, int nHeightEllipse);


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            i++;

            if (i > igraci.Count() - 1)
            {
                i = 0;
                Postavi_Igraca(igraci, i);
            }
            else
            {

                Postavi_Igraca(igraci, i);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 0)
            {
                i = igraci.Count() - 1;
                Postavi_Igraca(igraci, i);
            }
            else
            {

                Postavi_Igraca(igraci, i);
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {

            search();
        }
        private void search()
        {
            int k;
            bool pronaden = false;
            string usporedba = "";
            for (k = 0; k < igraci.Count(); k++)
            {
                usporedba = igraci[k].Ime + " " + igraci[k].Prezime;
                if (search_txt.Text == usporedba)
                {
                    pronaden = true;
                    i = k;

                    break;
                }

            }
            if (pronaden == false)
            {
                MessageBox.Show("Nema tog igrača!");
            }
            else
            {
                Postavi_Igraca(igraci, i);
            }
        }

        private void search_txt_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
                e.Handled = true;
            }
        }

        private void search_btn_MouseEnter(object sender, EventArgs e)
        {
            search_btn.BackColor = Color.Gainsboro;
        }

        private void search_btn_MouseLeave(object sender, EventArgs e)
        {
            search_btn.BackColor = Color.White;
        }

        private void search_btn_MouseHover(object sender, EventArgs e)
        {
            search_btn.BackColor = Color.White;
        }
    }
}
