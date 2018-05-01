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

        public frmAddClothes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAddClothes_Load(object sender, EventArgs e)
        {
            txtClothesID.Enabled = false;
            txtClothesName.Enabled = false;
            txtClothesPrice.Enabled = false;
            comboBox1.Enabled = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
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

            using (SqlConnection con = LaundryServiceConn.GetConnection())
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM type", con);
                con.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();


                while (sqlReader.Read())
                {
                    comboBox1.Items.Add(new Item(
                        Int32.Parse(sqlReader["TYPE_ID"].ToString()), sqlReader["TYPE_NAME"].ToString())
                    );
                }

                sqlReader.Close();
            }



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
            comboBox1.Text = typeID;
            txtClothesPrice.Text = priceAdd;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()

        {
            txtClothesID.Enabled = false;
            txtClothesName.Enabled = true;
            txtClothesPrice.Enabled = true;
            comboBox1.Enabled = true;

            txtClothesID.Text = null;
            txtClothesName.Text = null;
            txtClothesPrice.Text = null;
            comboBox1.Text = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtClothesID.Enabled = false;
            txtClothesName.Enabled = true;
            txtClothesPrice.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtClothesName.Text == "" ||
                 txtClothesPrice.Text == "" ||
                 comboBox1.Text == "" )
            {
                MessageBox.Show("Enter all data ,please.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtClothesID.Text == "")
                {
                    // SAVE
                    SqlConnection conn = LaundryServiceConn.GetConnection();
                    SqlCommand scmd = new SqlCommand("INSERT INTO clothes ([CL_NAME],[TYPE_ID],[PRICE_ADD]) VALUES ( @clothesName,@typeID,@priceAdd)", conn);
                    conn.Open();

                    scmd.Parameters.AddWithValue("@clothesName", txtClothesName.Text);
                    scmd.Parameters.AddWithValue("@typeID", comboBox1.SelectedIndex + 1);
                    scmd.Parameters.AddWithValue("@priceAdd", txtClothesPrice.Text);
                    
                    scmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successed");

                }
                else
                {
                    // UPDATE


                    SqlConnection conn = LaundryServiceConn.GetConnection();
                    SqlCommand scmd = new SqlCommand("UPDATE clothes SET  [CL_NAME] = @clothesName ,[TYPE_ID]= @typeID ,[PRICE_ADD] = @priceAdd WHERE [CL_ID]= @clothesID", conn);
                    conn.Open();

                    scmd.Parameters.AddWithValue("@clothesID", txtClothesID.Text);
                    scmd.Parameters.AddWithValue("@clothesName", txtClothesName.Text);
                    scmd.Parameters.AddWithValue("@typeID", comboBox1.SelectedIndex + 1);
                    scmd.Parameters.AddWithValue("@priceAdd", txtClothesPrice.Text);

                    scmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Update successed");
                }
                clear();
                datagridRefresh();

            }
        }

        private void datagridRefresh()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

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

        private void btnDelete_Click(object sender, EventArgs e)
        {

            //DELETE

            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + txtClothesName.Text, "Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection conn = LaundryServiceConn.GetConnection();
                SqlCommand scmd = new SqlCommand("DELETE FROM clothes WHERE [CL_ID]=@clothesID ", conn);
                conn.Open();

                scmd.Parameters.AddWithValue("@clothesID", txtClothesID.Text);
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

        private void txtClothesPrice_KeyPress(object sender, KeyPressEventArgs e)
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
