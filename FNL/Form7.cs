using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FNL
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        public void Dohvati_prvake()
        {
            using (OleDbConnection connection = new OleDbConnection(funkcije.ConnectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Prvaci", connection);
                DataTable dataTable = new DataTable();

                try
                {
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Ime"] != DBNull.Value)
                        {
                            string originalName = row["Ime"].ToString();
                            row["Ime"] = funkcije.OcistiNaziv(originalName);  
                        }
                    }
                    dataGridViewprvaci.DataSource = dataTable;
                    if (dataGridViewprvaci.Columns.Contains("ID"))
                        dataGridViewprvaci.Columns["ID"].Visible = false;

               
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
           

        }
        private void PostaviDataGridViewPostavke()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is DataGridView dgv)
                {
                   
                    dgv.ReadOnly = true;

                    
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.Black;
                    dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                    dgv.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                    dgv.RowHeadersVisible = false;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.GridColor = Color.LightGray;
                    dgv.BackgroundColor = Color.WhiteSmoke;

                  
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        public DataTable IzracunajLjestvicuNaslova()
        {
            DataTable ljestvica = new DataTable();
            ljestvica.Columns.Add("Klub", typeof(string));
            ljestvica.Columns.Add("Naslovi", typeof(int));


            Dictionary<string, int> kluboviNaslovi = new Dictionary<string, int>();
            if (dataGridViewprvaci.DataSource is DataTable dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Ime"] != DBNull.Value)
                    {
                        string imeKluba = row["Ime"].ToString();

                        if (!kluboviNaslovi.ContainsKey(imeKluba))
                            kluboviNaslovi[imeKluba] = 1;
                        else
                            kluboviNaslovi[imeKluba]++;
                    }
                }

               
                foreach (var par in kluboviNaslovi.OrderByDescending(x => x.Value))
                {
                    ljestvica.Rows.Add(par.Key, par.Value);
                }
            }

            return ljestvica;
        }
        private void postavljanje_teksta()
        {
            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is RichTextBox rich)
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
                richTextBox_info.Text = "Kao liga se prvenstvo uz manje izuzetke počinje igrati 1970. godine\r\n↑19/20  " +
             "– u sezoni 2019./20. prvenstvo prekinuto nakon 14. kola zbog pandemije COVID-19 u svijetu i Hrvatskoj" +
             "Neke godine nisu navedene zbog nedostatka podataka u ratnim godinama ili zbog drugih razloga prekidanja igranja prvenstva.";

            }
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            Dohvati_prvake();
            dataGridView_ljestvica.DataSource = IzracunajLjestvicuNaslova();
            PostaviDataGridViewPostavke();
            postavljanje_teksta();

        }
      
    }
}
