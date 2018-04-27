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
    public partial class frmOrder : Form
    {
        String cusID = null;
        public frmOrder(string cusId)
        {
            InitializeComponent();
            cusID = cusId;
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlCommand scmd = new SqlCommand("select * from customer where [CUS_ID]=@cusId", conn);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@cusId", cusID);
            conn.Open();
            SqlDataReader reader = null;
            reader = scmd.ExecuteReader();
            while (reader.Read())
            {
                lblCusID.Text = "" + reader["CUS_ID"].ToString();
                lblCusName.Text = "" + reader["CUS_NAME"].ToString();
                
            }
            conn.Close();

            showDataGrid();

           // SqlConnection con = LaundryServiceConn.GetConnection();
           // SqlCommand cmd = new SqlCommand("select * from type ", con);
           // scmd.Parameters.Clear();
           //// cmd.Parameters.AddWithValue("@accNO", accNo);
           // con.Open();
           // SqlDataReader readerr = null;
           // readerr = cmd.ExecuteReader();
           // while (readerr.Read())
           // {
           //     comboBox1.Text = readerr["TYPE_NAME"].ToString();

            // }
            // con.Close();



        }
        private void showDataGrid()
        {
            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlDataReader sqlRead = null;
            SqlCommand scmd = new SqlCommand(
                " SELECT * FROM clothes", conn);
            scmd.Parameters.Clear();
           // scmd.Parameters.AddWithValue("@cusId", cusID);
            conn.Open();
            sqlRead = scmd.ExecuteReader();
            dataGridView2.ReadOnly = true;
            while (sqlRead.Read())
            {
                dataGridView2.Rows.Add(
                    sqlRead["CL_NAME"].ToString(),
                    sqlRead["PRICE_ADD"].ToString()
                    
                    );
            }
            conn.Close();
        }
      

        private void dataGridView2_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            String name = dataGridView2[0, e.RowIndex].Value.ToString();
            String price = dataGridView2[1, e.RowIndex].Value.ToString();
            //MessageBox.Show("1" + name + "2" + price);
            dataGridView1.Rows.Add(name, price);
        }
    }
}
