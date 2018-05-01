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
    public partial class frmChoosePackage : Form
    {
        frmOrder frmParentOrder;
        string cusID;

        public frmChoosePackage()
        {
            InitializeComponent();
        }

        public frmChoosePackage(frmOrder frmOrder, string cusID)
        {
            InitializeComponent();
            frmParentOrder = frmOrder;
            this.cusID = cusID;

        }

        private void frmChoosePackage_Load(object sender, EventArgs e)
        {
            showDataGridPackage();
        }

        private void showDataGridPackage()
        {
            // show grid view
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            using (SqlConnection conn = LaundryServiceConn.GetConnection())
            {
                SqlDataReader sqlRead = null;
                SqlCommand scmd = new SqlCommand(
                  " SELECT a.[PROMO_ID]" +
                  " , a.[PROMO_NAME]" +
                  " , a.[PROMO_DISCRIPTION]" +
                  " , a.[PROMO_PRICE]" +
                  " , a.[PROMO_QTY]" +
                  " , a.[CL_ID]" +
                  " , b.BALANCE" +
                  " FROM[dbo].[promotion] a" +
                  " RIGHT JOIN[dbo].[promotionCondition] b ON a.[PROMO_ID] = b.PROMO_ID" +
                  " where b.CUS_ID = @cusId", conn);
                        scmd.Parameters.Clear();
                        scmd.Parameters.AddWithValue("@cusId", cusID);

                if (ConnectionState.Closed == conn.State)
                    conn.Open();

                sqlRead = scmd.ExecuteReader();
                dataGridView1.ReadOnly = true;

                while (sqlRead.Read())
                {
                    dataGridView1.Rows.Add(
                        sqlRead["PROMO_ID"].ToString(),
                        sqlRead["PROMO_NAME"].ToString(),
                        sqlRead["PROMO_QTY"].ToString(),
                        sqlRead["BALANCE"].ToString(),
                        sqlRead["PROMO_PRICE"].ToString()
                    );
                }

                conn.Close();
            }
        }
        
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.frmParentOrder.updateDataGridPackage( dataGridView1[1, e.RowIndex].Value.ToString(), int.Parse(dataGridView1[3, e.RowIndex].Value.ToString()) );
            this.Close();
        }
    }
}
