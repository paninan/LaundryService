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
    public partial class frmAddPromotion : Form
    {
        public frmAddPromotion()
        {
            InitializeComponent();
        }

        private void frmAddPromotion_Load(object sender, EventArgs e)
        {
            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlDataReader sqlRead = null;
            SqlCommand scmd = new SqlCommand(
                " SELECT * FROM promotion", conn);
            scmd.Parameters.Clear();
            conn.Open();
            sqlRead = scmd.ExecuteReader();
            dataGridView1.ReadOnly = true;
            while (sqlRead.Read())
            {
                dataGridView1.Rows.Add(
                    sqlRead["PROMO_ID"].ToString(),
                    sqlRead["PROMO_NAME"].ToString(),
                    sqlRead["PROMO_DISCRIPTION"].ToString(),
                    sqlRead["PROMO_PRICE"].ToString(),
                    sqlRead["PROMO_QTY"].ToString(),
                    sqlRead["CL_ID"].ToString()
                    );
            }
            conn.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String promoID = dataGridView1[0, e.RowIndex].Value.ToString();
            String promoName = dataGridView1[1, e.RowIndex].Value.ToString();
            String promoDesc = dataGridView1[2, e.RowIndex].Value.ToString();
            String promoPrice = dataGridView1[3, e.RowIndex].Value.ToString();
            String promoQty = dataGridView1[4, e.RowIndex].Value.ToString();
            String clothesID = dataGridView1[5, e.RowIndex].Value.ToString();
            txtPromoID.Text = promoID;
            txtPromoName.Text = promoName;
            txtPromoDisc.Text = promoDesc;
            txtPromoPrice.Text = promoPrice;
            txtPromoQty.Text = promoQty;
            txtClothesID.Text = clothesID;
           
        }
    }
}
