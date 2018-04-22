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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmParent frm = new frmParent();
            frm.Show();
            this.Hide();
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNewCus_Click(object sender, EventArgs e)
        {
            frmNewCus frm = new frmNewCus();
            frm.Show();
            this.Hide();
        }

        private void btnPackage_Click(object sender, EventArgs e)
        {
            frmAddPack frm = new frmAddPack();
            frm.Show();
            this.Hide();
        }
    }
}
