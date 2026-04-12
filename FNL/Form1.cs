namespace FNL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            glavni_izbornik.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            glavni_izbornik.BackColor = ColorTranslator.FromHtml("#D9ECF2");
            glavni_izbornik.ForeColor = ColorTranslator.FromHtml("#1A1A7D");
            glavni_izbornik.RenderMode = ToolStripRenderMode.Professional;
            glavni_izbornik.Renderer = new CustomMenuRenderer();




        }

        private static string ImagePath(string fileName)
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Slike", fileName);
        }

        public class CustomMenuRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#B0D9E5")), e.Item.ContentRectangle);
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string backgroundPath = ImagePath("10091forska_nl.png");
            if (System.IO.File.Exists(backgroundPath))
            {
                this.BackgroundImage = Image.FromFile(backgroundPath);
            }
            else
            {
                MessageBox.Show("Image file not found: " + backgroundPath);
            }
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void glavni_izbornik_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void kluboviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 tablica = new Form2();
            tablica.ShowDialog();

        }

        private void aktualnaSezonaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rasporedIRezultatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 raspored = new Form3();
            raspored.ShowDialog();
        }

        private void kluboviIIgraciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 klubovi_igraci = new Form4();
            klubovi_igraci.ShowDialog();
        }

        private void kluboviToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 klubovi = new Form5();
            klubovi.ShowDialog();
        }

        private void povijestLigeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 povijestFNL = new Form6();
            povijestFNL.ShowDialog();
        }

        private void prvaciKrozGodineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 prvaci = new Form7();
            prvaci.ShowDialog();
        }

      
    }
}
