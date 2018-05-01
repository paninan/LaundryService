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
    public partial class frmAddPromotion : Form
    {
        private class Item
        {
            public string Name;
            public int Value;
            public Item(int value, string name)
            {
                Name = name; Value = value;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public frmAddPromotion()
        {
            InitializeComponent();
        }

        private void frmAddPromotion_Load(object sender, EventArgs e)
        {
            txtPromoID.Enabled = false;
            txtPromoName.Enabled = false;
            txtPromoDisc.Enabled = false;
            txtPromoPrice.Enabled = false;
            txtPromoQty.Enabled = false;
            comboBox1.Enabled = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlDataReader sqlRead = null;
            SqlCommand scmd = new SqlCommand(
                " SELECT * FROM promotion", conn);
            scmd.Parameters.Clear();
            conn.Open();
            sqlRead = scmd.ExecuteReader();
            dataGridView1.ReadOnly = true;
            while (sqlRead.Read())
            {
                dataGridView1.Rows.Add(
                    sqlRead["PROMO_ID"].ToString(),
                    sqlRead["PROMO_NAME"].ToString(),
                    sqlRead["PROMO_DISCRIPTION"].ToString(),
                    sqlRead["PROMO_PRICE"].ToString(),
                    sqlRead["PROMO_QTY"].ToString(),
                    sqlRead["CL_ID"].ToString()
                    );
            }
            conn.Close();

            using (SqlConnection con = LaundryServiceConn.GetConnection())
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM clothes", con);
                con.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();


                while (sqlReader.Read())
                {
                    comboBox1.Items.Add(new Item(
                        Int32.Parse(sqlReader["CL_ID"].ToString()), sqlReader["CL_NAME"].ToString())
                    );
                }

                sqlReader.Close();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String promoID = dataGridView1[0, e.RowIndex].Value.ToString();
            String promoName = dataGridView1[1, e.RowIndex].Value.ToString();
            String promoDesc = dataGridView1[2, e.RowIndex].Value.ToString();
            String promoPrice = dataGridView1[3, e.RowIndex].Value.ToString();
            String promoQty = dataGridView1[4, e.RowIndex].Value.ToString();
            String clothesID = dataGridView1[5, e.RowIndex].Value.ToString();
            txtPromoID.Text = promoID;
            txtPromoName.Text = promoName;
            txtPromoDisc.Text = promoDesc;
            txtPromoPrice.Text = promoPrice;
            txtPromoQty.Text = promoQty;
            comboBox1.Text = clothesID;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            clear();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           // txtPromoID.Enabled = true;
            txtPromoName.Enabled = true;
            txtPromoDisc.Enabled = true;
            txtPromoPrice.Enabled = true;
            txtPromoQty.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (txtPromoName.Text == "" ||
                 txtPromoDisc.Text == "" ||
                 txtPromoPrice.Text == "" ||
                 txtPromoQty.Text == "" ||
                 comboBox1.Text == "")
            {
                MessageBox.Show("Enter all data ,please.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(txtPromoID.Text == "")
                {
                    // SAVE
                    SqlConnection conn = LaundryServiceConn.GetConnection();
                    SqlCommand scmd = new SqlCommand("INSERT INTO promotion ([PROMO_NAME],[PROMO_DISCRIPTION],[PROMO_PRICE],[PROMO_QTY],[CL_ID] ) VALUES ( @promoName,@promoDesc,@promoPrice,@promoQty,@clothesID )", conn);
                    conn.Open();

                    scmd.Parameters.AddWithValue("@promoName", txtPromoName.Text);
                    scmd.Parameters.AddWithValue("@promoDesc", txtPromoDisc.Text);
                    scmd.Parameters.AddWithValue("@promoPrice", txtPromoPrice.Text);
                    scmd.Parameters.AddWithValue("@promoQty", txtPromoQty.Text);
                    scmd.Parameters.AddWithValue("@clothesID", comboBox1.SelectedIndex + 1);

                    scmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successed");
                    
                }
                else
                {
                    // UPDATE


                    SqlConnection conn = LaundryServiceConn.GetConnection();
                    SqlCommand scmd = new SqlCommand("UPDATE promotion SET  [PROMO_NAME] = @promoName ,[PROMO_DISCRIPTION]= @promoDesc ,[PROMO_PRICE] = @promoPrice ,[PROMO_QTY] = @promoQty ,[CL_ID]= @clothesID WHERE [PROMO_ID]= @promoID", conn);
                    conn.Open();

                    scmd.Parameters.AddWithValue("@promoID", txtPromoID.Text);
                    scmd.Parameters.AddWithValue("@promoName", txtPromoName.Text);
                    scmd.Parameters.AddWithValue("@promoDesc", txtPromoDisc.Text);
                    scmd.Parameters.AddWithValue("@promoPrice", txtPromoPrice.Text);
                    scmd.Parameters.AddWithValue("@promoQty", txtPromoQty.Text);
                    scmd.Parameters.AddWithValue("@clothesID", comboBox1.SelectedIndex + 1);

                    scmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Update successed");
                }
                clear();
                datagridRefresh();

            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }
        private void clear()
        {
            //txtPromoID.Enabled = true;
            txtPromoName.Enabled = true;
            txtPromoDisc.Enabled = true;
            txtPromoPrice.Enabled = true;
            txtPromoQty.Enabled = true;
            comboBox1.Enabled = true;

            txtPromoID.Text = null;
            txtPromoName.Text = null;
            txtPromoDisc.Text = null;
            txtPromoPrice.Text = null;
            txtPromoQty.Text = null;
            comboBox1.Text = null;
        }

        private void datagridRefresh()
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlDataReader sqlRead = null;
            SqlCommand scmd = new SqlCommand(
                " SELECT * FROM promotion", conn);
            scmd.Parameters.Clear();
            conn.Open();
            sqlRead = scmd.ExecuteReader();
            dataGridView1.ReadOnly = true;
            while (sqlRead.Read())
            {
                dataGridView1.Rows.Add(
                    sqlRead["PROMO_ID"].ToString(),
                    sqlRead["PROMO_NAME"].ToString(),
                    sqlRead["PROMO_DISCRIPTION"].ToString(),
                    sqlRead["PROMO_PRICE"].ToString(),
                    sqlRead["PROMO_QTY"].ToString(),
                    sqlRead["CL_ID"].ToString()
                    );
            }
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            //DELETE

            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + txtPromoName.Text , "Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection conn = LaundryServiceConn.GetConnection();
                SqlCommand scmd = new SqlCommand("DELETE FROM promotion WHERE [PROMO_ID]=@promoID ", conn);
                conn.Open();

                scmd.Parameters.AddWithValue("@promoID", txtPromoID.Text);
                scmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Delete successed");

                clear();
                datagridRefresh();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void txtPromoPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPromoQty_KeyPress(object sender, KeyPressEventArgs e)
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
