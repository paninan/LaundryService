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
    public partial class frmNewCus : Form
    {
        public frmNewCus()
        {
            InitializeComponent();
        }

        private void frmNewCus_Load(object sender, EventArgs e)
        {

        }
        private void add()
        {
            // connect database & Add data

            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlCommand scmd = new SqlCommand("INSERT INTO customer ([CUS_NAME],[CUS_PHONE]),[CUS_ADDRESS]) VALUES ( @cusName ,@cusPhone,@cusAddress )", conn);
            conn.Open();

   
            scmd.Parameters.AddWithValue("@cusName", txtCusName.Text);
            scmd.Parameters.AddWithValue("@cusPhone", txtCusPhone.Text);
            scmd.Parameters.AddWithValue("@cusAddress", txtCusAddress.Text);

            conn.Close();
            MessageBox.Show("Saved successed");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            add();
        }
    }
}
