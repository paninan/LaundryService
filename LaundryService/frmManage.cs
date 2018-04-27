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
    public partial class frmManage : Form
    {
        public frmManage()
        {
            InitializeComponent();
        }

        private void promotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmAddType frm = new frmAddType();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void customerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            panel1.Controls.Clear();
            frmAddClothes frm = new frmAddClothes();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmAddPromotion frm = new frmAddPromotion();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void ออกจากรายการToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Hide();
        }
    }
}
