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
            txtTypeID.Enabled = false;
            txtTypeName.Enabled = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()

        {
            txtTypeID.Enabled = false;
            txtTypeName.Enabled = true;


            txtTypeID.Text = null;
            txtTypeName.Text = null;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtTypeID.Enabled = false;
            txtTypeName.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtTypeName.Text == "" )
            {
                MessageBox.Show("Enter all data ,please.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtTypeID.Text == "")
                {
                    // SAVE
                    SqlConnection conn = LaundryServiceConn.GetConnection();
                    SqlCommand scmd = new SqlCommand("INSERT INTO type ([TYPE_NAME]) VALUES ( @typeName)", conn);
                    conn.Open();

                    scmd.Parameters.AddWithValue("@typeName", txtTypeName.Text);
                    
                    scmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successed");

                }
                else
                {
                    // UPDATE


                    SqlConnection conn = LaundryServiceConn.GetConnection();
                    SqlCommand scmd = new SqlCommand("UPDATE type SET  [TYPE_NAME] = @typeName WHERE [TYPE_ID]= @typeID", conn);
                    conn.Open();

                    scmd.Parameters.AddWithValue("@typeID", txtTypeID.Text);
                    scmd.Parameters.AddWithValue("@typeName", txtTypeName.Text);
                   
                    scmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Update successed");
                }
                clear();
                datagridRefresh();

            }

        }
        private void datagridRefresh()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

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

        private void btnDelete_Click(object sender, EventArgs e)
        {

            //DELETE

            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + txtTypeName.Text, "Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection conn = LaundryServiceConn.GetConnection();
                SqlCommand scmd = new SqlCommand("DELETE FROM type WHERE [TYPE_ID]=@typeID ", conn);
                conn.Open();

                scmd.Parameters.AddWithValue("@typeID", txtTypeID.Text);
                scmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Delete successed");

                clear();
                datagridRefresh();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
