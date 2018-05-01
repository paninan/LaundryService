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
    public partial class frmChoosePack : Form
    {
        frmPackage frmParent;
        frmOrder frmParentOrder;

        public frmChoosePack()
        {
            InitializeComponent();
        }


        public frmChoosePack(frmPackage frmParent)
        {
            InitializeComponent();
            this.frmParent = frmParent;
        }

        public frmChoosePack(frmOrder frmParentOrder,string cusID)
        {
            InitializeComponent();
            this.frmParentOrder = frmParentOrder;
        }



        private void frmChoosePack_Load(object sender, EventArgs e)
        {
            // show grid view
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            using (SqlConnection conn = LaundryServiceConn.GetConnection())
            {
                SqlDataReader sqlRead = null;
                SqlCommand scmd = new SqlCommand(" SELECT a.* , b.PROMO_NAME, b.PROMO_PRICE, b.PROMO_QTY FROM[promotionBuy] a LEFT JOIN[promotion] b ON a.PROMO_ID = b.PROMO_ID", conn);
                scmd.Parameters.Clear();
                //scmd.Parameters.AddWithValue("@cusId");

                if (ConnectionState.Closed == conn.State)
                    conn.Open();

                sqlRead = scmd.ExecuteReader();
                dataGridView1.ReadOnly = true;

                while (sqlRead.Read())
                {   
                    dataGridView1.Rows.Add(false, sqlRead["PROMOBUY_NO"].ToString(),sqlRead["PROMO_NAME"].ToString(), sqlRead["TOTAL"].ToString());
                }

                conn.Close();
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // apply
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    frmParentOrder.updateDataGridPackage(row.Cells[2].Value.ToString(), int.Parse(row.Cells[3].Value.ToString()) );
                }
            }
            
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // clear other checkbox
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    row.Cells[0].Value = false;
                }
            }


            //ref : https://msdn.microsoft.com/en-US/library/system.windows.forms.datagridview.currentcelldirtystatechanged(VS.80).aspx
            if (dataGridView1.Columns[e.ColumnIndex].Index == 0)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
                checkCell.Value = !(Boolean)checkCell.Value;                
            }
        }
    }
}
