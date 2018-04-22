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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlCommand scmd = new SqlCommand("select count (*) as cnt from [laundryService].[dbo].[user]  where [USERNAME]=@usr and [PASSWORD]=@pwd", conn);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@usr", txtUsername.Text);
            scmd.Parameters.AddWithValue("@pwd", txtPassword.Text);
            conn.Open();
            if (scmd.ExecuteScalar().ToString() == "1")
            {
                MessageBox.Show("Login Success");
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            else
            {
                txtUsername.Clear();
                txtPassword.Clear();
            }
            conn.Close();
           
        }
    }
}
