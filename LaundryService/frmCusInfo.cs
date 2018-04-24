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
    public partial class frmCusInfo : Form
    {
        String cusID = null;

        public frmCusInfo(String cusId)
        {
            InitializeComponent();
            cusID = cusId;
        }

        private void frmCusInfo_Load(object sender, EventArgs e)
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
                txtCusId.Text = "" + reader["CUS_ID"].ToString();
                txtCusname.Text = reader["CUS_NAME"].ToString();
                txtCusPhone.Text = reader["CUS_PHONE"].ToString();
                txtCusAddress.Text = reader["CUS_ADDRESS"].ToString();

            }
            conn.Close();
            

        }


        private void update()
        {
           
                SqlConnection conn = LaundryServiceConn.GetConnection();
                SqlCommand scmd = new SqlCommand("UPDATE customer SET  [CUS_NAME] =@cusName ,[CUS_PHONE] = @cusPhone,[CUS_ADDRESS] = @cusAddress WHERE [CUS_ID]= @cusId", conn);
                conn.Open();


                scmd.Parameters.AddWithValue("@cusName", txtCusname.Text);
                scmd.Parameters.AddWithValue("@cusPhone", txtCusPhone.Text);
                scmd.Parameters.AddWithValue("@cusAddress", txtCusAddress.Text);
            scmd.Parameters.AddWithValue("@cusId", txtCusId.Text);

            scmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successed");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
            txtCusname.Enabled = false;
            txtCusPhone.Enabled = false;
            txtCusAddress.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            txtCusname.Enabled = true;
            txtCusPhone.Enabled = true;
            txtCusAddress.Enabled = true;
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            txtCusname.Enabled = false;
            txtCusPhone.Enabled = false;
            txtCusAddress.Enabled = false;
        }
    }
}
