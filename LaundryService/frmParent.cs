using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaundryService
{
    public partial class frmParent : Form
    {
        public frmParent()
        {
            InitializeComponent();
        }

        private void customerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmCusInfo frm = new frmCusInfo();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Show();
           
            
        }

        private void promotionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            frmPackage frm = new frmPackage();
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

        private void frmParent_Load(object sender, EventArgs e)
        {

        }
    }
}
