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
    public partial class frmAddType : Form
    {
        public frmAddType()
        {
            InitializeComponent();
        }

        private void frmAddType_Load(object sender, EventArgs e)
        {
            SqlConnection conn = LaundryServiceConn.GetConnection();
            SqlDataReader sqlRead = null;
            SqlCommand scmd = new SqlCommand(
                " SELECT * FROM type", conn);
            scmd.Parameters.Clear();
            conn.Open();
            sqlRead = scmd.ExecuteReader();
            dataGridView1.ReadOnly = true;
            while (sqlRead.Read())
            {
                dataGridView1.Rows.Add(
                    sqlRead["TYPE_ID"].ToString(),
                    sqlRead["TYPE_NAME"].ToString()
                    
                    );
            }
            conn.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String typeID = dataGridView1[0, e.RowIndex].Value.ToString();
            String typeName = dataGridView1[1, e.RowIndex].Value.ToString();
            
            txtTypeID.Text = typeID;
            txtTypeName.Text = typeName;
        }
    }
}
