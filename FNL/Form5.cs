using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNL
{
    public partial class Form5 : Form
    {
        private Button trenutnoAktivniPin = null;
        private List<Klubovi> klubovi = new List<Klubovi>();

        public Form5()
        {
            InitializeComponent();
        }

        private static string ImagePath(string fileName)
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Slike", fileName);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            klubovi = funkcije.Dohvati_klubove();
            if (klubovi.Count < 9)
            {
                MessageBox.Show("Nedovoljno klubova u bazi podataka.");
                return;
            }

            stiliziraj_gumbove();

            button1.Tag = klubovi[6];
            button2.Tag = klubovi[0];
            button3.Tag = klubovi[7];
            button4.Tag = klubovi[5];
            button5.Tag = klubovi[2];
            button6.Tag = klubovi[4];
            button7.Tag = klubovi[1];
            button8.Tag = klubovi[3];
            button9.Tag = klubovi[8];

            button1.Click += PinKliknut;
            button2.Click += PinKliknut;
            button3.Click += PinKliknut;
            button4.Click += PinKliknut;
            button5.Click += PinKliknut;
            button6.Click += PinKliknut;
            button7.Click += PinKliknut;
            button8.Click += PinKliknut;
            button9.Click += PinKliknut;
           



        }
        private void PinKliknut(object sender, EventArgs e)
        {
            Button pin = sender as Button;
            Klubovi klub = pin.Tag as Klubovi;
            if (klub == null)
                return;
          

            Panel infoPanel = panela();
            if (trenutnoAktivniPin == pin && infoPanel.Visible)
            {
                infoPanel.Visible = false;
                trenutnoAktivniPin = null;
                return;
            }
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Panel && ctrl != infoPanel)
                {
                    ctrl.Visible = false;
                }
            }
            trenutnoAktivniPin = pin;

            int panelWidth = infoPanel.Width;
            int panelHeight = infoPanel.Height;

            int pinX = pin.Location.X;
            int pinY = pin.Location.Y;

            int panelX = pinX - (panelWidth / 2) + (pin.Width / 2);
            int panelY = pinY - panelHeight - 10;

            if (panelX < 0) panelX = 0;
            if (panelY < 0) panelY = 0;

            infoPanel.Location = new Point(panelX, panelY);

            Label lblIme = infoPanel.Controls.Find("lblImeKluba", true).FirstOrDefault() as Label;
            Label lblAdresa = infoPanel.Controls.Find("lblAdresa", true).FirstOrDefault() as Label;
            Label lblStadion = infoPanel.Controls.Find("lblStadion", true).FirstOrDefault() as Label;
            Label lblOsnutak = infoPanel.Controls.Find("lblOsnutak", true).FirstOrDefault() as Label;
            PictureBox pbGrb = infoPanel.Controls.Find("pbGrb", true).FirstOrDefault() as PictureBox;

           
            if (lblIme != null) lblIme.Text = klub.Ime;
            if (lblAdresa != null) lblAdresa.Text = "Adresa: " + klub.Adresa;
            if (lblStadion != null) lblStadion.Text = "Stadion: " + klub.Stadion;
            if (lblOsnutak != null) lblOsnutak.Text = "Osnovan: " + klub.Osnutak;
            if (pbGrb != null) pbGrb.Image = Klubovi.LoadImageFromUrl(klub.Grb);

            infoPanel.Visible = true;
            infoPanel.BringToFront();
        }


        private Panel panela()
        {
            
            Panel panelInfo = new Panel();
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(350, 270);
            panelInfo.Location = new Point(500, 50); 
            panelInfo.BackColor = Color.LightGray;
            panelInfo.BorderStyle = BorderStyle.Fixed3D;
            panelInfo.Visible = false;
            this.Controls.Add(panelInfo);

            Button btnClose = new Button();
            btnClose.Text = "X";
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 30);
            btnClose.Location = new Point(panelInfo.Width - 40, 10); 
            btnClose.Click += BtnClose_Click;
            btnClose.BackColor = Color.Red;
            panelInfo.Controls.Add(btnClose);
           

            Label lblImeKluba = new Label();
            lblImeKluba.Name = "lblImeKluba";
            lblImeKluba.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblImeKluba.Location = new Point(10, 10);
            lblImeKluba.AutoSize = true;
            panelInfo.Controls.Add(lblImeKluba);

            
            PictureBox pbGrb = new PictureBox();
            pbGrb.Name = "pbGrb";
            pbGrb.Size = new Size(100, 100);
            pbGrb.Location = new Point(10, 50);
            pbGrb.SizeMode = PictureBoxSizeMode.StretchImage;
            panelInfo.Controls.Add(pbGrb);

         
            Label lblAdresa = new Label();
            lblAdresa.Name = "lblAdresa";
            lblAdresa.Location = new Point(10, 160);
            lblAdresa.AutoSize = true;
            panelInfo.Controls.Add(lblAdresa);

            
            Label lblStadion = new Label();
            lblStadion.Name = "lblStadion";
            lblStadion.Location = new Point(10, 190);
            lblStadion.AutoSize = true;
            panelInfo.Controls.Add(lblStadion);

           
            Label lblOsnutak = new Label();
            lblOsnutak.Name = "lblOsnutak";
            lblOsnutak.Location = new Point(10, 220);
            lblOsnutak.AutoSize = true;
            panelInfo.Controls.Add(lblOsnutak);
            return panelInfo;
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
           
            Button btnClose = sender as Button;
            Panel panel = btnClose.Parent as Panel;

            
            panel.Visible = false;
            trenutnoAktivniPin = null;  
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Size = new Size(48, 48); 
            btn.Location = new Point(btn.Left - 4, btn.Top - 4); 
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Size = new Size(40, 40); 
            btn.Location = new Point(btn.Left + 4, btn.Top + 4); 
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

        }

        private void stiliziraj_gumbove()
        {
            string pinPath = ImagePath("pngimg.com - google_maps_pin_PNG54.png");
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.Transparent;
                    btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    if (System.IO.File.Exists(pinPath))
                    {
                        btn.BackgroundImage = Image.FromFile(pinPath);
                    }
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Size = new Size(40, 40);
                    btn.Text="";
                    btn.MouseEnter += btn_MouseEnter;
                    btn.MouseLeave += btn_MouseLeave;
                   

                }
            }

        }
    }
}
