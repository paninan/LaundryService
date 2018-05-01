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
        string typeID;

        // class entity -> helper to collect data
        private class EntityClother
        {
            public int clId;
            public string clName;
            public int typeId;
            public double priceAdd;            

            public EntityClother(int clotherID,string clotherName,int typeId,double price)
            {
                this.clId = clotherID;
                this.clName = clotherName;
                this.typeId = typeId;
                this.priceAdd = price;
            }

            public override string ToString()
            {
                return clName;
            }

        }

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

            comboType();

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
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

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
                EntityClother enClother = new EntityClother(
                    Int32.Parse( sqlRead["CL_ID"].ToString()),
                    sqlRead["CL_NAME"].ToString(),
                    Int32.Parse(sqlRead["TYPE_ID"].ToString()),
                    Double.Parse(sqlRead["PRICE_ADD"].ToString())
                );

                dataGridView2.Rows.Add( enClother,sqlRead["PRICE_ADD"].ToString() );
            }
            conn.Close();
        }

        private void showDataGrid(int  typeId)
        {
            MessageBox.Show(typeId.ToString());
            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlDataReader sqlRead = null;
            SqlCommand scmd = new SqlCommand(
                " SELECT * FROM clothes WHERE [TYPE_ID] = @typeId", conn);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@typeId", typeId);
            conn.Open();
            sqlRead = scmd.ExecuteReader();

            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            dataGridView2.ReadOnly = true;
            while (sqlRead.Read())
            {
                EntityClother enClother = new EntityClother(
                   Int32.Parse(sqlRead["CL_ID"].ToString()),
                   sqlRead["CL_NAME"].ToString(),
                   Int32.Parse(sqlRead["TYPE_ID"].ToString()),
                   Double.Parse(sqlRead["PRICE_ADD"].ToString())
               );

                dataGridView2.Rows.Add(
                    enClother,
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

        private void comboType()
        {
            // combobox           
            using (SqlConnection conn = LaundryServiceConn.GetConnection())
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM type", conn);
                conn.Open();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item itm = (Item)comboBox1.SelectedItem;            
            showDataGrid(itm.Value);
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // open choose package
            if(e.ColumnIndex == 3)
            {
                DataGridViewCell dtCell = dataGridView1[3, dataGridView1.CurrentCell.RowIndex];
                openFrmChoosePackage();
                //if (dtCell.Value == null)
                //{
                //    // new
                //    openFrmChoosePackage();                }
                //else
                //{
                //    MessageBox.Show("This Record Account No. [ " + dtCell.Value.ToString() + " ] ");
                //}
            }               

        }

        private void openFrmChoosePackage()
        {
            frmChoosePack frmChoosePackage = new frmChoosePack(this,cusID);
            frmChoosePackage.Show();
        }

        public void updateDataGridPackage(string packageName,int balance)
        {
            DataGridViewCell dtCellPackage = dataGridView1[3, dataGridView1.CurrentCell.RowIndex];
            DataGridViewCell dtCellBalance = dataGridView1[4, dataGridView1.CurrentCell.RowIndex];
            dtCellPackage.Value = packageName;
            dtCellBalance.Value = balance.ToString();
        }
        
    }
}
