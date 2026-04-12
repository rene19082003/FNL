using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static funkcije;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FNL
{
    public partial class Form3 : Form
    {
        int i = 0;
        List<Utakmica> utakmice = funkcije.Dohvati_utakmice();
        public Form3()
        {
            InitializeComponent();
            


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            postavi_utakmice(utakmice, 0);
            stilizacija_kontrola();
        }
        private void postavi_utakmice(List<Utakmica> tekme, int k)
        {
            if (tekme == null || tekme.Count < 4 || k < 0 || (k + 3) >= tekme.Count)
            {
                MessageBox.Show("Nema igrača u bazi podataka.");
                return;
            }
            kolo_txt.Text = tekme[k].Kolo;
            d1_pb.Image = !string.IsNullOrEmpty(tekme[k].Slika_kluba_domacin) ? Utakmica.LoadImageFromUrl(tekme[k].Slika_kluba_domacin) : null;
            d2_pb.Image = !string.IsNullOrEmpty(tekme[k + 1].Slika_kluba_domacin) ? Utakmica.LoadImageFromUrl(tekme[k + 1].Slika_kluba_domacin) : null;
            d3_pb.Image = !string.IsNullOrEmpty(tekme[k + 2].Slika_kluba_domacin) ? Utakmica.LoadImageFromUrl(tekme[k + 2].Slika_kluba_domacin) : null;
            d4_pb.Image = !string.IsNullOrEmpty(tekme[k + 3].Slika_kluba_domacin) ? Utakmica.LoadImageFromUrl(tekme[k + 3].Slika_kluba_domacin) : null;

            g1_pb.Image = !string.IsNullOrEmpty(tekme[k].Slika_kluba_gost) ? Utakmica.LoadImageFromUrl(tekme[k].Slika_kluba_gost) : null;
            g2_pb.Image = !string.IsNullOrEmpty(tekme[k + 1].Slika_kluba_gost) ? Utakmica.LoadImageFromUrl(tekme[k + 1].Slika_kluba_gost) : null;
            g3_pb.Image = !string.IsNullOrEmpty(tekme[k + 2].Slika_kluba_gost) ? Utakmica.LoadImageFromUrl(tekme[k + 2].Slika_kluba_gost) : null;
            g4_pb.Image = !string.IsNullOrEmpty(tekme[k + 3].Slika_kluba_gost) ? Utakmica.LoadImageFromUrl(tekme[k + 3].Slika_kluba_gost) : null;

            d1_txt.Text = tekme[k].Domacin;
            d2_txt.Text = tekme[k + 1].Domacin;
            d3_txt.Text = tekme[k + 2].Domacin;
            d4_txt.Text = tekme[k + 3].Domacin;

            g1_txt.Text = tekme[k].Gost;
            g2_txt.Text = tekme[k + 1].Gost;
            g3_txt.Text = tekme[k + 2].Gost;
            g4_txt.Text = tekme[k + 3].Gost;

            gd1.Text = tekme[k].Golovi_domaci.ToString();
            gd2.Text = tekme[k + 1].Golovi_domaci.ToString();
            gd3.Text = tekme[k + 2].Golovi_domaci.ToString();
            gd4.Text = tekme[k + 3].Golovi_domaci.ToString();

            gg1.Text = tekme[k].Golovi_gosti.ToString();
            gg2.Text = tekme[k + 1].Golovi_gosti.ToString();
            gg3.Text = tekme[k + 2].Golovi_gosti.ToString();
            gg4.Text = tekme[k + 3].Golovi_gosti.ToString();


        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            if (utakmice == null || utakmice.Count < 4)
                return;
            i = i + 4;
            if ((i + 3) > utakmice.Count() - 1)
            {
                i = 0;
                postavi_utakmice(utakmice, i);
            }
            else
            {

                postavi_utakmice(utakmice, i);
            }


        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            if (utakmice == null || utakmice.Count < 4)
                return;
            i = i - 4;
            if (i < 0)
            {
                i = utakmice.Count() - 4;
                postavi_utakmice(utakmice, i);
            }
            else
            {

                postavi_utakmice(utakmice, i);
            }
        }
        private void stilizacija_kontrola()
        {
            StilizirajTextBoxove(this);
            stiliziraj_ostale_kontrole(this);
        }

        private void StilizirajTextBoxove(Control parent)
        {

            foreach (Control ctrl in parent.Controls)
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
             

                if (ctrl.HasChildren)
                {
                    StilizirajTextBoxove(ctrl);
                }
              
                
            }
            kolo_txt.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            kolo_txt.TextAlign = HorizontalAlignment.Center;
            kolo_txt.BorderStyle = BorderStyle.None;
            kolo_txt.BackColor = Color.FromArgb(173, 216, 255) ;
            kolo_txt.ForeColor = Color.Black;

           


        }
        private void stiliziraj_ostale_kontrole(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                 if (ctrl is PictureBox pictureBox)
                {
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.BackColor = Color.LightGray; 
                }
                if (ctrl is Button button )
                {
                    button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    button.BackColor = Color.SteelBlue;
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                }

                if (ctrl.HasChildren)
                {
                    stiliziraj_ostale_kontrole(ctrl);
                }
            }
            btn_left.Text = "◀";
            btn_left.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_left.BackColor = Color.LightSteelBlue;
            btn_left.FlatStyle = FlatStyle.Flat;
            btn_left.Size = new Size(30, kolo_txt.Height);
            btn_left.Location = new Point(kolo_txt.Left - btn_left.Width - 5, kolo_txt.Top);

          
            btn_right.Text = "▶";
            btn_right.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_right.BackColor = Color.LightSteelBlue;
            btn_right.FlatStyle = FlatStyle.Flat;
            btn_right.Size = new Size(30, kolo_txt.Height);
            btn_right.Location = new Point(kolo_txt.Right + 5, kolo_txt.Top);

        }
        private void game1_btn_Click(object sender, EventArgs e)
        {
            Form9 zapisnik = new Form9(i);
            zapisnik.ShowDialog();
        }

        private void game2_btn_Click(object sender, EventArgs e)
        {
            Form9 zapisnik = new Form9(i + 1);
            zapisnik.ShowDialog();
        }

        private void game3_btn_Click(object sender, EventArgs e)
        {
            Form9 zapisnik = new Form9(i + 2);
            zapisnik.ShowDialog();
        }

        private void game4_btn_Click(object sender, EventArgs e)
        {
            Form9 zapisnik = new Form9(i + 3);
            zapisnik.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
