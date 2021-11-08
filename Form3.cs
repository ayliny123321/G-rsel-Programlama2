using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace Aylin
{
    public partial class Form3 : Form
    {
        public string connString;
        public string query, query2;
        public OleDbDataAdapter dAdapter, dAdapter2;
        public DataTable dTable;
        public OleDbCommandBuilder cBuilder;
        public DataView myDataView, dTableSchema_dv;

        private void button1_Click(object sender, EventArgs e)
        {
            string myster;

            myster = "[Cinsiyet) = '" + textBox2.Text + "'";
            myDataView.RowFilter = myster;

            //if (myDataView.RowFilter == "")
            //{
            //    myster = "[" + dataGridView1.CurrentCell.OwningColumn.HeaderText.ToString() + "]";
            //    myster += " = '" + dataGridView1.CurrentCell.Value.ToString() + "'";
            //    myDataView.RowFilter = myster;
            //}

            //else
            //{
            //    myster = myDataView.RowFilter + " and ";
            //    myster += "[" + dataGridView1.CurrentCell.OwningColumn.HeaderText.ToString() + "]";
            //    myster += " = '" + dataGridView1.CurrentCell.Value.ToString() + "'";
            //    myDataView.RowFilter = myster;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myDataView.RowFilter = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            query2 = "SELECT * FROM il";
            dAdapter2 = new OleDbDataAdapter(query2, connString);
            dAdapter2.Fill(dTable);

            dataGridView1.DataSource = dTable;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tbl_str = "[" + dataGridView2.CurrentRow.Cells[1].Value.ToString() + "].[" +
            dataGridView2.CurrentRow.Cells[2].Value.ToString() + "]";

            query = "SELECT * FROM " + tbl_str + "";
            dAdapter = new OleDbDataAdapter(query, connString);
            dTable = new DataTable();
            cBuilder = new OleDbCommandBuilder(dAdapter);
            cBuilder.QuotePrefix = "[";
            cBuilder.QuoteSuffix = "]";
            myDataView = dTable.DefaultView;
            dAdapter.Fill(dTable);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            this.dataGridView1.DataSource = bSource;

            this.comboBox1.Items.Clear();

            for (int q = 0; q <= dataGridView1.ColumnCount - 1; q++)
            {
                this.comboBox1.Items.Add(this.dataGridView1.Columns[q].HeaderText.ToString());
            }
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            connString = "Provider=SQLNCLI11;Data Source=LAB36\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=sirket";
            query = "SELECT * FROM Personel";
            dAdapter = new OleDbDataAdapter(query, connString);
            dTable = new DataTable();
            cBuilder = new OleDbCommandBuilder(dAdapter);
            cBuilder.QuotePrefix = "[";
            cBuilder.QuoteSuffix = "]";
            myDataView = dTable.DefaultView;
            dAdapter.Fill(dTable);
            //dataGridView1.DataSource = dTable;
            BindingSource bndSource = new BindingSource();
            bndSource.DataSource = dTable;
            this.dataGridView1.DataSource = bndSource;


            for (int q = 0; q <= dataGridView1.ColumnCount - 1; q++)
            {
                this.comboBox1.Items.Add(this.dataGridView1.Columns[q].HeaderText.ToString());
            }
            OleDbConnection dbConn = new OleDbConnection(connString);
            dbConn.Open();
            DataTable dTableSchema = dbConn.GetSchema("Tables");

            dataGridView2.DataSource = dTableSchema;

            dTableSchema_dv = dTableSchema.DefaultView;
        }
    }
}


