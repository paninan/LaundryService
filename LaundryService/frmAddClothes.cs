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
    public partial class frmAddClothes : Form
    {
        public frmAddClothes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAddClothes_Load(object sender, EventArgs e)
        {
           
                SqlConnection conn = LaundryServiceConn.GetConnection();
                SqlDataReader sqlRead = null;
                SqlCommand scmd = new SqlCommand(
                    " SELECT * FROM clothes", conn);
                scmd.Parameters.Clear();
                conn.Open();
                sqlRead = scmd.ExecuteReader();
                dataGridView1.ReadOnly = true;
                while (sqlRead.Read())
                {
                    dataGridView1.Rows.Add(
                        sqlRead["CL_ID"].ToString(),
                        sqlRead["CL_NAME"].ToString(),
                        sqlRead["TYPE_ID"].ToString(),
                        sqlRead["PRICE_ADD"].ToString()
                        );
                }
                conn.Close();


            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String clothesID = dataGridView1[0, e.RowIndex].Value.ToString();
            String clothesName = dataGridView1[1, e.RowIndex].Value.ToString();
            String typeID = dataGridView1[2, e.RowIndex].Value.ToString();
            String priceAdd = dataGridView1[3, e.RowIndex].Value.ToString();
            txtClothesID.Text = clothesID;
            txtClothesName.Text = clothesName;
            txtClothesType.Text = typeID;
            txtClothesPrice.Text = priceAdd;
        }
    }
}
