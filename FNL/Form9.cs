using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FNL
{
    public partial class Form9 : Form
    {

        public Form9(int i)
        {

            InitializeComponent();
            int indeks = i;
            postavi_podatke(zapisnici, indeks);
            stiliziraj_kontrole();
        }
        List<Zapisnik> zapisnici = funkcije.Dohvati_zapisnike();
        List<Igraci> igraci = funkcije.DohvatiIgrace();
        private void Form9_Load(object sender, EventArgs e)
        {

        }
        private void stiliziraj_kontrole()
        {
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

                else if (ctrl is PictureBox pictureBox)
                {
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.BackColor = Color.LightGray;

                }
                else if (ctrl is Label label)
                {
                    label.ForeColor = Color.FromArgb(51, 51, 51);
                    label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.AutoSize = true;
                }

                else if (ctrl is RichTextBox rich)
                {
                    rich.BackColor = Color.White;
                    rich.ForeColor = Color.Black;
                    rich.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                    rich.BorderStyle = BorderStyle.FixedSingle;
                    rich.TabStop = false;
                    rich.Cursor = Cursors.Default;
                    rich.GotFocus += (s, e) => this.ActiveControl = null;
                    rich.MouseDown += (s, e) => this.ActiveControl = null;
                    rich.MouseMove += (s, e) => rich.SelectionLength = 0;
                    rich.KeyDown += (s, e) => e.SuppressKeyPress = true;
                    rich.ReadOnly = true;

                }




            }
        }

        private void postavi_podatke(List<Zapisnik> zapis, int l)
        {
            if (zapis == null || zapis.Count == 0 || l >= zapis.Count || l < 0)
            {
                MessageBox.Show("Nema igrača u bazi podataka.");
                return;
            }
            domaci_pb.Image = !string.IsNullOrEmpty(zapis[l].Slika_kluba_domacin) ? Zapisnik.LoadImageFromUrl(zapis[l].Slika_kluba_domacin) : null;
            gost_pb.Image = !string.IsNullOrEmpty(zapis[l].Slika_kluba_gost) ? Zapisnik.LoadImageFromUrl(zapis[l].Slika_kluba_gost) : null;
            kolo_txt.Text = zapis[l].Kolo;
            suci_txt.Text = zapis[l].Suci;
            stadion_txt.Text = zapis[l].Stadion;
            datum_txt.Text = zapis[l].Datum;
            domaci_txt.Text = zapis[l].Domacin;
            gost_txt.Text = zapis[l].Gost;
            gd_txt.Text = zapis[l].Golovi_domaci.ToString();
            gg_txt.Text = zapis[l].Golovi_gosti.ToString();


            zuti_txt.Text = Zapisnik.pretvori_u_redove(zapis[l].Zuti);
            crveni_txt.Text = Zapisnik.pretvori_u_redove(zapis[l].Crveni);
            golovi_txt.Text = Zapisnik.pretvori_u_redove(zapis[l].Golovi);
            ulasci_txt.Text = Zapisnik.pretvori_u_redove(zapis[l].Ulasci);
            izlasci_txt.Text = Zapisnik.pretvori_u_redove(zapis[l].Izlasci);

        }

        private void suci_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void izlasci_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void golovi_g_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ulasci_txt_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
