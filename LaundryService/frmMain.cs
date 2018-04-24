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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCustomer.Text))
            {
                MessageBox.Show("Enter ID customer,please.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //seach by phone

            if (checkBoxPhone.Checked == true)
            {
                SqlConnection connn = LaundryServiceConn.GetConnection();
                SqlCommand scmdd = new SqlCommand("select count (*) as cnt from [laundryService].[dbo].[customer]  where [CUS_PHONE]=@cusPhone", connn);
                scmdd.Parameters.Clear();
                scmdd.Parameters.AddWithValue("@cusPhone", txtCustomer.Text); 
               // scmdd.Parameters.AddWithValue("@cusId", txtCustomer.Text);

                connn.Open();
                if (scmdd.ExecuteScalar().ToString() == "1")
                {
                    String cusId = txtCustomer.Text;
                    Program.ACTIVE_CUSTOMER_ID = Int32.Parse(txtCustomer.Text);
                    frmParent frm = new frmParent(cusId);
                    frm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid ID customer or phone number,please enter again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomer.Clear();
                }
                connn.Close();
            }
            else  //seach by ID
            {
                SqlConnection conn = LaundryServiceConn.GetConnection();
                SqlCommand scmd = new SqlCommand("select count (*) as cnt from [laundryService].[dbo].[customer]  where [CUS_ID]=@cusId", conn);
                scmd.Parameters.Clear();
                scmd.Parameters.AddWithValue("@cusId", txtCustomer.Text);
                conn.Open();
                if (scmd.ExecuteScalar().ToString() == "1")
                {
                    String cusId = txtCustomer.Text;
                    Program.ACTIVE_CUSTOMER_ID = Int32.Parse(txtCustomer.Text);
                    frmParent frm = new frmParent(cusId);
                    frm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid ID customer or phone number,please enter again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomer.Clear();
                }
                conn.Close();
            }
           
           
           
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNewCus_Click(object sender, EventArgs e)
        {
            frmNewCus frm = new frmNewCus();
            frm.Show();
            this.Hide();
        }

        private void btnPackage_Click(object sender, EventArgs e)
        {
            frmAddPack frm = new frmAddPack();
            frm.Show();
            this.Hide();
        }
    }
}
