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
        Double total = 0.0;
        

        public frmPackage(String cusId)
        {
            InitializeComponent();
            cusID = cusId;
        }

        private void frmPackage_Load(object sender, EventArgs e)
        {
            showDataGrid();
            updateTotalPrice();
        }
        private void showDataGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

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
                    sqlRead["PROMO_ID"].ToString(),
                    sqlRead["PROMO_NAME"].ToString(),
                    sqlRead["PROMO_QTY"].ToString(),
                    sqlRead["PROMO_PRICE"].ToString()
                    );
            }
            conn.Close();


        }



        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String promoID = dataGridView1[0, e.RowIndex].Value.ToString();
            String promoName = dataGridView1[1, e.RowIndex].Value.ToString();
            String promoQty = dataGridView1[2, e.RowIndex].Value.ToString();
            String proPrice = dataGridView1[3, e.RowIndex].Value.ToString();
            //MessageBox.Show("1" + promoID + "2" + promoName + proPrice);
            dataGridView2.Rows.Add(promoID, promoName, promoQty, proPrice);
            updateTotalPrice();


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Double.Parse(txtReceive.Text) < total || String.IsNullOrEmpty(txtReceive.Text))
            {
                MessageBox.Show("Sorry, not enough money.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReceive.Text = "";
            }
            else
            {

                Double change = Double.Parse(txtReceive.Text) - total;
                txtChange.Text = change.ToString();

                
                SqlConnection conn = LaundryServiceConn.GetConnection();

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                   // String cellProID = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
                    Int32 cellProID = row.Cells[0].Value == null ? 0 : Int32.Parse(row.Cells[0].Value.ToString());
                    Int32 cellProQty = row.Cells[2].Value == null ? 0 : Int32.Parse(row.Cells[2].Value.ToString());
                    //String cellProName = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                    //Double cellProPrice = row.Cells[2].Value == null ? 0 : Double.Parse(row.Cells[2].Value.ToString());
                    DateTime thisDay = DateTime.Today;



                    string scmd = "INSERT INTO promotionCondition ([PROMO_ID],[CUS_ID],[PRO_DATE_BUY],[QTY_ITEM] ,[BALANCE] ,[TOTAL]) VALUES ( @promoID, @cusID, @proDateBuy, @qty,@balance,@total)";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(scmd, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        cmd.Parameters.AddWithValue("@promoID", cellProID);
                        cmd.Parameters.AddWithValue("@cusID", cusID);
                        cmd.Parameters.AddWithValue("@proDateBuy", thisDay);
                        cmd.Parameters.AddWithValue("@qty", cellProQty);
                        cmd.Parameters.AddWithValue("@balance", cellProQty);
                        cmd.Parameters.AddWithValue("@total", total);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                        

                    }

                }
                MessageBox.Show("successed, thanks.");

                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
                txtChange.Text = "";
                txtReceive.Text = "";
                txtTotal.Text = "";



            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void updateTotalPrice()
        {
            total = 0.0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {                
                DataGridViewCell cellTotal = row.Cells[3];
                if (cellTotal.Value == null)
                {
                    total += 0.0;
                }
                else
                {
                    Int32 intValue = 0;
                    float floatValue = 0.0f;
                    if (Int32.TryParse(cellTotal.Value.ToString(), out intValue) || float.TryParse(cellTotal.Value.ToString(), out floatValue))
                        total += Double.Parse(cellTotal.Value.ToString());
                }
            }

            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
            txtTotal.Text = total.ToString("F");
        
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateTotalPrice();
        }

        private void txtReceive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
