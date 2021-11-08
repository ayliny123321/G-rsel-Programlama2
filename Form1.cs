using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aylin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oleDbConnectionString = "Provider=SQLNCLI11;Data Source=LAB36\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=sirket";
            OleDbConnection oleDbConn = new OleDbConnection(oleDbConnectionString);
            try
            {
                OleDbDataAdapter sqlCommand = new OleDbDataAdapter("SELECT * FROM personel", oleDbConn);
                DataTable oleDbTable = new DataTable();

                oleDbConn.Open();
                MessageBox.Show("Bağlantı kuruldu!");
                sqlCommand.Fill(oleDbTable);

                oleDbConn.Close();

                dataGridView1.DataSource = oleDbTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sqldb_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "Data Source=LAB36\\SQLEXPRESS;Initial Catalog=sirket;Integrated Security=True";
            try
            {
                SqlDataAdapter oadaptor = new SqlDataAdapter("SELECT * FROM proje", sqlConn);
                DataSet ds = new DataSet();

                sqlConn.Open();
                MessageBox.Show("Bağlantı kuruldu!");
                oadaptor.Fill(ds);

                sqlConn.Close();

                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }
    }
}
