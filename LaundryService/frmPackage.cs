using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaundryService
{
    public partial class frmPackage : Form
    {
        String cusID = null;

        public frmPackage(String cusId)
        {
            InitializeComponent();
            cusID = cusId;
        }

        private void frmPackage_Load(object sender, EventArgs e)
        {
            showDataGrid();

        }
        private void showDataGrid()
        {
            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlDataReader sqlRead = null;
            SqlCommand scmd = new SqlCommand(
                " SELECT * FROM promotion", conn);
            scmd.Parameters.Clear();
           // scmd.Parameters.AddWithValue("@cusId", cusID);
            conn.Open();
            sqlRead = scmd.ExecuteReader();
            dataGridView1.ReadOnly = true;
            while (sqlRead.Read())
            {
                dataGridView1.Rows.Add(
                    sqlRead["PROMO_NAME"].ToString(),
                    sqlRead["PROMO_QTY"].ToString(),
                    sqlRead["PROMO_PRICE"].ToString()
                    );
            }
            conn.Close();


        }



        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String accNo = dataGridView1[0, e.RowIndex].Value.ToString();
            String accName = dataGridView1[2, e.RowIndex].Value.ToString();
            //MessageBox.Show("1" + accNo + "2" + accName);
            dataGridView2.Rows.Add(accNo, accName);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
