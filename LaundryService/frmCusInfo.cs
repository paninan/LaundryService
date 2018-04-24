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
        private void add()
        {
            // connect database & Add data
            
                SqlConnection conn = LaundryServiceConn.GetConnection();
                SqlCommand scmd = new SqlCommand("INSERT INTO customer ([CUS_ID],[CUS_NAME],[CUS_PHONE]),[CUS_ADDRESS]) VALUES ( @cusId ,@cusName ,@cusPhone,@cusAddress )", conn);
                conn.Open();

                scmd.Parameters.AddWithValue("@cusId", txtCusId.Text);
                scmd.Parameters.AddWithValue("@cusName", txtCusname.Text);
                scmd.Parameters.AddWithValue("@cusPhone", txtCusPhone.Text);
                scmd.Parameters.AddWithValue("@cusAddress", txtCusAddress.Text);
                
                scmd.ExecuteNonQuery();
                MessageBox.Show("Saved successed");
                
           
                conn.Close();
          
        }

        //private void update()
        //{
        //    // connect database & Add data
        //    try
        //    {
        //        conn = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["General_Journal.Properties.Settings.General_JournalConnectionString"].ConnectionString);

        //        string cmdText = "UPDATE accountNo SET [ACC_NAME] = @accName, [ACC_CATEGORY] = @accCat WHERE [ACC_NO] = @accNo";

        //        using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
        //        {
        //            conn.Open();
        //            cmd.Parameters.AddWithValue("@accName", txtAccName.Text);
        //            cmd.Parameters.AddWithValue("@accCat", cmbCategory.Text);
        //            cmd.Parameters.AddWithValue("@accNo", txtAccNo.Text);

        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Update successed");
        //        }


        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    btnAdd.Text = "Add";


        //}
        //private void delete()
        //{
        //    // connect database & Add data
        //    try
        //    {
        //        String accNo = dataGAccNo[0, dataGAccNo.CurrentCell.RowIndex].Value.ToString();
        //        conn = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["General_Journal.Properties.Settings.General_JournalConnectionString"].ConnectionString);

        //        string cmdText = "DELETE FROM accountNo  WHERE [ACC_NO] = @accNo";

        //        using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
        //        {
        //            conn.Open();
        //            cmd.Parameters.AddWithValue("@accNo", accNo);

        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Delete successed");
        //        }


        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
    }
}
