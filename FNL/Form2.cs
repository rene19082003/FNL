using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Net.Http;



namespace FNL
{
    public partial class Form2 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public Form2()
        {
            InitializeComponent();


        }
        private void AdjustColumnAndRowSize()
        {


            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 110;
            }
            if (dataGridView1.Columns.Contains("Klub"))
                dataGridView1.Columns["Klub"].Width = 160;
            dataGridView1.RowTemplate.Height = 30;
        }

        private void FormatDataGridView()
        {
            if (!dataGridView1.Columns.Contains("Logo_URL"))
                return;
            if (!dataGridView1.Columns.Contains("Logo"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "Logo";
                imgColumn.HeaderText = "Logo";
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.Columns.Insert(1, imgColumn);
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Logo_URL"].Value != null)
                {
                    string imageUrl = row.Cells["Logo_URL"].Value.ToString();
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(imageUrl))
                        {
                            byte[] data = httpClient.GetByteArrayAsync(imageUrl).Result;
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
                            {
                                row.Cells["Logo"].Value = Image.FromStream(ms);
                            }
                        }
                    }
                    catch
                    {
                        row.Cells["Logo"].Value = null;
                    }
                }
            }
        }

        public void GetDataFromAccess()
        {
            using (OleDbConnection connection = new OleDbConnection(funkcije.ConnectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Ligaska_tablica", connection);
                DataTable dataTable = new DataTable();

                try
                {
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    if (dataGridView1.Columns.Contains("ID_liga"))
                        dataGridView1.Columns["ID_liga"].Visible = false;

                    if (dataGridView1.Columns.Contains("KlubID"))
                        dataGridView1.Columns["KlubID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (dataGridView1.Columns.Contains("Postignuti_golovi"))
                dataGridView1.Columns["Postignuti_golovi"].HeaderText = "G+";
            if (dataGridView1.Columns.Contains("Primljeni_golovi"))
                dataGridView1.Columns["Primljeni_golovi"].HeaderText = "G";
            if (dataGridView1.Columns.Contains("Gol_razlika"))
                dataGridView1.Columns["Gol_razlika"].HeaderText = "GR";

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetDataFromAccess();
            if (dataGridView1.Columns.Count > 0)
            {
                FormatDataGridView();
                if (dataGridView1.Columns.Contains("Logo_URL"))
                    dataGridView1.Columns["Logo_URL"].Visible = false;
                AdjustColumnAndRowSize();
            }


            dataGridView1.AutoSize = true;

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
