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


        //private void add4()
        //{
        //    int insertID = 0;
        //    string sqlIns = "INSERT INTO  customer ([CUS_NAME],[CUS_PHONE],[CUS_ADDRESS]) VALUES ( @cusName ,@cusPhone,@cusAddress )";
        //    SqlConnection conn = LaundryServiceConn.GetConnection();
        //    conn.Open();
        //    try
        //    {
        //        SqlCommand cmdIns = new SqlCommand(sqlIns, conn);
        //        cmdIns.Parameters.AddWithValue("@cusName", "test");
        //        cmdIns.Parameters.AddWithValue("@cusPhone", "0866954585");
        //        cmdIns.Parameters.AddWithValue("@cusAddress", "dindang");
        //        cmdIns.ExecuteNonQuery();

        //        cmdIns.Parameters.Clear();
        //        cmdIns.CommandText = "SELECT @@IDENTITY";

        //        // Get the last inserted id.
        //        insertID = Convert.ToInt32(cmdIns.ExecuteScalar());

        //        cmdIns.Dispose();
        //        cmdIns = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString(), ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    Console.WriteLine(insertID);
        //}

        //private void add3()
        //{
        //    using (SqlConnection conn = LaundryServiceConn.GetConnection())
        //    {
        //        string saveCus = "INSERT INTO customer ([CUS_NAME],[CUS_PHONE],[CUS_ADDRESS]) VALUES ( @cusName ,@cusPhone,@cusAddress )";

        //        using (SqlCommand querySaveCus = new SqlCommand(saveCus))
        //        {
        //            querySaveCus.Connection = conn;
        //            querySaveCus.Parameters.Add("@cusName", SqlDbType.NVarChar, 255).Value = txtCusName.Text;
        //            querySaveCus.Parameters.Add("@cusPhone", SqlDbType.NVarChar, 20).Value = txtCusPhone.Text;
        //            querySaveCus.Parameters.Add("@cusAddress", SqlDbType.NVarChar, 255).Value = txtCusAddress.Text;
        //            conn.Open();
        //        }
        //    }
        //}

        private void add()
        {
            // connect database & Add data

            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlCommand scmd = new SqlCommand("INSERT INTO customer ( [CUS_NAME],[CUS_PHONE],[CUS_ADDRESS] ) VALUES ( @cusName ,@cusPhone,@cusAddress )", conn);            
            conn.Open();

   
            scmd.Parameters.AddWithValue("@cusName", txtCusName.Text);
            scmd.Parameters.AddWithValue("@cusPhone", txtCusPhone.Text);
            scmd.Parameters.AddWithValue("@cusAddress", txtCusAddress.Text);

            scmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Saved successed");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            add();
        }
    }
}
