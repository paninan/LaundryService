﻿using System;
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
        
        private class ItemCombo
        {
            public string Name;
            public int Value;
            public ItemCombo(int value, string name)
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
                dataGridView2.Rows.Add(sqlRead["CL_ID"].ToString(), sqlRead["CL_NAME"].ToString(), sqlRead["PRICE_ADD"].ToString() );
            }
            conn.Close();
        }

        private void showDataGrid(int  typeId)
        {            
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
                dataGridView2.Rows.Add(sqlRead["CL_ID"].ToString(), sqlRead["CL_NAME"].ToString(), sqlRead["PRICE_ADD"].ToString());
            }
            conn.Close();
        }


        private void dataGridView2_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            String id = dataGridView2[0, e.RowIndex].Value.ToString();
            String name = dataGridView2[1, e.RowIndex].Value.ToString();
            String price = dataGridView2[2, e.RowIndex].Value.ToString();
           
            dataGridView1.Rows.Add(id,name, price);
            updateBlance();
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
                    comboBox1.Items.Add(new ItemCombo(
                        Int32.Parse(sqlReader["TYPE_ID"].ToString()), sqlReader["TYPE_NAME"].ToString())
                    );                    
                }

                sqlReader.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemCombo itm = (ItemCombo)comboBox1.SelectedItem;            
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // open choose package
            if(e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                //DataGridViewCell dtCell = dataGridView1[3, dataGridView1.CurrentCell.RowIndex];
                openFrmChoosePackage();
            }               

        }

        private void openFrmChoosePackage()
        {
            frmChoosePackage frmChoosePkg = new frmChoosePackage(this,cusID);
            frmChoosePkg.Show();
        }

        public void updateDataGridPackage(string packageID, string packageName,int balance)
        {
            DataGridViewCell dtCellPackageID = dataGridView1[4, dataGridView1.CurrentCell.RowIndex];
            DataGridViewCell dtCellPackageName = dataGridView1[5, dataGridView1.CurrentCell.RowIndex];
            DataGridViewCell dtCellBalance = dataGridView1[6, dataGridView1.CurrentCell.RowIndex];
            dtCellPackageID.Value = packageID;
            dtCellPackageName.Value = packageName;
            dtCellBalance.Value = balance.ToString();
        }
        
        private void updateBlance()
        {
            double total = 0.0;
            double Receive = 0.0;
            double sumPrice = 0.0;
            float qty = 1.0f;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // price
                double price = row.Cells[3].Value == null ? 0.0 : float.Parse(row.Cells[3].Value.ToString());
                if (row.Cells[2].Value != null )
                {

                    if (row.Cells[4].Value == null || row.Cells[4].Value.ToString() == "0")
                    {
                        sumPrice += float.Parse(row.Cells[2].Value.ToString()) * price ;
                    }
                    
                }
            }

            txtTotal.Text = sumPrice.ToString("F");
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateBlance();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateBlance();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateBlance();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if( checkInput() == false )
            {
                MessageBox.Show("Please ,Fill your input");
                return;
            }

            if (Double.Parse(txtReceive.Text) < Double.Parse(txtTotal.Text) || String.IsNullOrEmpty(txtReceive.Text))
            {
                MessageBox.Show("Sorry, not enough money.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReceive.Text = "";
            }
            else
            {
                // check all value to calculate                
                double moneychange = 0.0;
                moneychange = Double.Parse(txtReceive.Text) - Double.Parse(txtTotal.Text);
                txtChange.Text = moneychange.ToString("F");

                // CHECK PACKAGE BALANCE
                if (checkPackageBalance())
                {
                    // SAVE AND UPDATE BALANCE
                    string orderNo = generateOrderNo();
                    using (SqlConnection conn = LaundryServiceConn.GetConnection())
                    {
                        // date row data from dataGridView1
                        int cntSavedItem = 0;
                        int cntItem = dataGridView1.RowCount;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            string saveNewOrder = " INSERT INTO [order] " +
                            " ([ORDER_NO],[ORDER_REGISTER_DATE],[ORDER_COMPETE],[ORDER_EXPIRE],[PROMO_ID], [CUS_ID] ,[CL_ID] ,[ORDER_QTY] , [ORDER_PRICE] ) " +
                            " VALUES " +
                            " ( @orderNo, @orderRegisDate, @orderCompleteDate, @orderExpireDate, @promoId, @cusId , @clotherId ,@orderQty , @orderPrice) ";
                            SqlCommand scmd = new SqlCommand(saveNewOrder, conn);

                            if (ConnectionState.Closed == conn.State)
                                conn.Open();

                            String clotherId = row.Cells[0].Value.ToString();
                            String orderPrice = row.Cells[2].Value.ToString();
                            String orderQty = row.Cells[3].Value.ToString();
                            String promoId = row.Cells[4].Value.ToString();

                            scmd.Parameters.Clear();
                            scmd.Parameters.AddWithValue("@orderNo", orderNo);
                            scmd.Parameters.AddWithValue("@orderRegisDate", DateTime.Now.Date);
                            scmd.Parameters.AddWithValue("@orderCompleteDate", dateTimePicker2.Value.Date);
                            scmd.Parameters.AddWithValue("@orderExpireDate", DateTime.Now.AddYears(1));
                            scmd.Parameters.AddWithValue("@promoId", promoId);
                            scmd.Parameters.AddWithValue("@cusId", cusID);
                            scmd.Parameters.AddWithValue("@clotherId", clotherId);
                            scmd.Parameters.AddWithValue("@orderQty", orderQty);
                            scmd.Parameters.AddWithValue("@orderPrice", orderPrice);

                            //check ( pakacge id  , promotion id ) is 0 not update promotion balance
                            if (promoId != "0")
                            {
                            
                                // update balance in [promotionCondition]
                                string upDate = "UPDATE [promotionCondition] SET [BALANCE] = [BALANCE] - @balance WHERE [PROMO_ID] = @promoId AND[CUS_ID] = @cusId ";
                                SqlCommand ucmd = new SqlCommand(upDate, conn);
                                if (ConnectionState.Closed == conn.State)
                                    conn.Open();

                                ucmd.Parameters.Clear();
                                ucmd.Parameters.AddWithValue("@balance", orderQty);
                                ucmd.Parameters.AddWithValue("@promoId", promoId);
                                ucmd.Parameters.AddWithValue("@cusId", cusID);
                                ucmd.ExecuteNonQuery();
                            }

                            cntSavedItem += scmd.ExecuteNonQuery();

                           

                        }


                        if (cntSavedItem == cntItem)
                        {
                            MessageBox.Show("Save complete");
                            dataGridView1.Rows.Clear();
                            dataGridView1.Refresh();
                            txtReceive.Text = "0";
                            txtChange.Text = "";
                            txtTotal.Text = "";


                        }
                        else
                        {
                            MessageBox.Show("Save not complete");
                        }

                        conn.Close();
                    }

                }

            }
            
        }

        private string generateOrderNo()
        {
            // format : REGISTERDATE-CUS_ID-RANDOM(6)
            Random rnd = new Random();
            int rnum = rnd.Next(1, 999999);            
            String orderNo = string.Format("{0:yyyyMMdd}-{1,6:D6}-{2,6:D6}", DateTime.Now.Date, int.Parse(cusID), rnd.Next(1, 999999));
            return orderNo;
        }


        private  Boolean checkPackageBalance()
        {
            // summary qty by package
            Dictionary<int, int> pkgs = new Dictionary<int, int>();
            Dictionary<int, String> pkgNames = new Dictionary<int, String>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int qty = int.Parse( row.Cells[3].Value.ToString() ) ;                
                int packageId = int.Parse( row.Cells[4].Value.ToString() );
                String packageName = row.Cells[5].Value.ToString();
                int balance = int.Parse(row.Cells[6].Value.ToString());
                int balEntry = 0;

                // package id == 0 ; not check condition
                if(packageId == 0)
                {
                    continue;
                }

                if (pkgs.TryGetValue(packageId, out balEntry))
                {
                    pkgs.Remove(packageId);
                    pkgs.Add( packageId,  balEntry- qty);
                }
                else
                {
                    pkgs.Add(packageId, balance - qty);
                    pkgNames.Add(packageId, packageName); 
                }
            }
            

            String errorMessage = "";
            foreach (KeyValuePair<int, int> entry in pkgs)
            {
                if( entry.Value < 0 )
                {
                    errorMessage += String.Format("{0} balance is not enough ({1}) \n",pkgNames[entry.Key] , entry.Value);
                }
            }

            
            if(errorMessage == "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
            
            return false;
        }

        private Boolean checkInput()
        {
            Boolean valid = true;
            valid = !String.IsNullOrWhiteSpace(txtReceive.Text) && valid;

            // check grid qty
            if(dataGridView1.RowCount > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    valid = (row.Cells[3].Value != null) && valid;

                    if( row.Cells[4].Value == null )
                    {
                        row.Cells[4].Value = 0;     // package id
                        row.Cells[5].Value = "-";   // package name
                        row.Cells[6].Value = 0;     // balance
                    }
                }
            }

            return valid;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
