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
    public partial class frmParent : Form
    {
        String cusID = null;

        public frmParent(String cusId)
        {
            InitializeComponent();
            cusID = cusId;
        }

        private void frmParent_Load(object sender, EventArgs e)
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
                this.Text = "Customer : " + reader["CUS_NAME"].ToString();
            }
            conn.Close();

        }

        private void customerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmCusInfo frm = new frmCusInfo(cusID);
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Show();



        }

        private void promotionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            frmPackage frm = new frmPackage(cusID);
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Show();

        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmOrder frm = new frmOrder();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void รายการคงคางToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmRemain frm = new frmRemain();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Show();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void ออกจากรายการToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Hide();
        }
    }
}
