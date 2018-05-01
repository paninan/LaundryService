using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaundryService
{
    public partial class frmRemain : Form
    {
        String cusID = null;
        Double total = 0.0;

        public frmRemain()
        {
            InitializeComponent();
        }

        public frmRemain(String cusID)
        {
            InitializeComponent();
            this.cusID = cusID;
        }

        private void frmRemain_Load(object sender, EventArgs e)
        {
            showDataGridNoComplete();
            showDataGridComplete();
        }

        private void showDataGridNoComplete()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            using (SqlConnection conn = LaundryServiceConn.GetConnection())
            {
                SqlDataReader sqlRead = null;
                SqlCommand scmd = new SqlCommand(
                    " SELECT " +
                    "a.[ORDER_ID] , a.[ORDER_NO] ,a.[ORDER_REGISTER_DATE] , a.[ORDER_COMPETE] , a.[ORDER_EXPIRE] , a.[PROMO_ID] , a.[CUS_ID] , a.[CL_ID] , a.[ORDER_QTY] , a.[ORDER_PRICE] , a.[STATUS] , b.[PROMO_NAME] , b.[PROMO_PRICE] " +
                    " FROM[laundryService].[dbo].[order] a " +
                    " LEFT JOIN[laundryService].[dbo].[promotion]  b ON a.PROMO_ID = b.PROMO_ID " +
                    " WHERE a.[STATUS] = 0 AND a.[CUS_ID] = @cusId  " +
                    " ORDER BY a.[STATUS] ASC,a.[ORDER_NO], a.[ORDER_COMPETE] DESC", conn);
                scmd.Parameters.Clear();
                scmd.Parameters.AddWithValue("@cusId", cusID);

                if (ConnectionState.Closed == conn.State)
                    conn.Open();

                sqlRead = scmd.ExecuteReader();
                dataGridView1.ReadOnly = true;

                String orderNo = "";
                while (sqlRead.Read())
                {
                    orderNo = orderNo.Equals(sqlRead["ORDER_NO"].ToString() ) ? "" : sqlRead["ORDER_NO"].ToString();
                    DateTime regisDate = Convert.ToDateTime(sqlRead["ORDER_REGISTER_DATE"].ToString());
                    DateTime completeDate = Convert.ToDateTime(sqlRead["ORDER_COMPETE"].ToString());

                    dataGridView1.Rows.Add(
                        sqlRead["ORDER_ID"].ToString(),
                        orderNo,
                        sqlRead["ORDER_QTY"].ToString(),
                        sqlRead["ORDER_PRICE"].ToString(),
                        String.Format("{0:d}" , regisDate),
                        String.Format("{0:d}", completeDate),
                        sqlRead["STATUS"].ToString() == "1"
                    );
                }
                
                conn.Close();
                txtOrderRemain.Text = String.Format("{0} {1}", txtOrderRemain.Text, dataGridView1.RowCount);
            }
        }

        private void showDataGridComplete()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            using (SqlConnection conn = LaundryServiceConn.GetConnection())
            {
                SqlDataReader sqlRead = null;
                SqlCommand scmd = new SqlCommand(
                    " SELECT " +
                    "a.[ORDER_ID] , a.[ORDER_NO] ,a.[ORDER_REGISTER_DATE] , a.[ORDER_COMPETE] , a.[ORDER_EXPIRE] , a.[PROMO_ID] , a.[CUS_ID] , a.[CL_ID] , a.[ORDER_QTY] , a.[ORDER_PRICE] , a.[STATUS] , b.[PROMO_NAME] , b.[PROMO_PRICE] " +
                    " FROM[laundryService].[dbo].[order] a " +
                    " LEFT JOIN[laundryService].[dbo].[promotion]  b ON a.PROMO_ID = b.PROMO_ID " +
                    " WHERE a.[STATUS] = 1 AND a.[CUS_ID] = @cusId  " +
                    " ORDER BY a.[STATUS] ASC,a.[ORDER_NO], a.[ORDER_COMPETE] DESC", conn);
                scmd.Parameters.Clear();
                scmd.Parameters.AddWithValue("@cusId", cusID);

                if (ConnectionState.Closed == conn.State)
                    conn.Open();

                sqlRead = scmd.ExecuteReader();
                dataGridView2.ReadOnly = true;

                String orderNo = "";
                while (sqlRead.Read())
                {
                    //orderNo = orderNo.Equals(sqlRead["ORDER_NO"].ToString()) ? "" : sqlRead["ORDER_NO"].ToString();
                    orderNo = sqlRead["ORDER_NO"].ToString();
                    DateTime regisDate = Convert.ToDateTime(sqlRead["ORDER_REGISTER_DATE"].ToString());
                    DateTime completeDate = Convert.ToDateTime(sqlRead["ORDER_COMPETE"].ToString());

                    dataGridView2.Rows.Add(
                        sqlRead["ORDER_ID"].ToString(),
                        orderNo,
                        sqlRead["ORDER_QTY"].ToString(),
                        sqlRead["ORDER_PRICE"].ToString(),
                        String.Format("{0:d}", regisDate),
                        String.Format("{0:d}", completeDate),
                        sqlRead["STATUS"].ToString() == "1"
                    );
                }

                conn.Close();
                txtOrdComplete.Text = String.Format("{0} {1}", txtOrdComplete.Text, dataGridView2.RowCount);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Index == 6)
            {
                DataGridViewCheckBoxCell checkCell =(DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[6];
                checkCell.Value = !(Boolean)checkCell.Value;
                dataGridView1.Invalidate();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows )
            {
                if (bool.Parse(row.Cells[6].Value.ToString()) == true)
                {
                    String orderId = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
                    using (SqlConnection conn = LaundryServiceConn.GetConnection())
                    {
                        SqlCommand scmd = new SqlCommand("UPDATE [order] SET [STATUS] = @status WHERE [ORDER_ID] = @orderId", conn);
                        conn.Open();
                        scmd.Parameters.AddWithValue("@status", 1);
                        scmd.Parameters.AddWithValue("@orderId", orderId);

                        scmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    count++;
                }
            }

            showDataGridComplete();
            showDataGridNoComplete();
        }
    }
}
