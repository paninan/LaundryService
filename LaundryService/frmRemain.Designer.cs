namespace LaundryService
{
    partial class frmRemain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.orderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateReceive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderID,
            this.orderName,
            this.qty,
            this.price,
            this.dateReceive,
            this.dateSend,
            this.back,
            this.pay});
            this.dataGridView1.Location = new System.Drawing.Point(2, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(614, 205);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(302, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // orderID
            // 
            this.orderID.HeaderText = "รหัสออเดอร์";
            this.orderID.Name = "orderID";
            this.orderID.ReadOnly = true;
            this.orderID.Width = 80;
            // 
            // orderName
            // 
            this.orderName.HeaderText = "ชื่อรายการ";
            this.orderName.Name = "orderName";
            this.orderName.ReadOnly = true;
            this.orderName.Width = 150;
            // 
            // qty
            // 
            this.qty.HeaderText = "จำนวน";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 50;
            // 
            // price
            // 
            this.price.HeaderText = "ราคา";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 50;
            // 
            // dateReceive
            // 
            this.dateReceive.HeaderText = "วันรับ";
            this.dateReceive.Name = "dateReceive";
            this.dateReceive.ReadOnly = true;
            this.dateReceive.Width = 70;
            // 
            // dateSend
            // 
            this.dateSend.HeaderText = "วันส่ง";
            this.dateSend.Name = "dateSend";
            this.dateSend.ReadOnly = true;
            this.dateSend.Width = 70;
            // 
            // back
            // 
            this.back.HeaderText = "คืนผ้า";
            this.back.Name = "back";
            this.back.ReadOnly = true;
            this.back.Width = 50;
            // 
            // pay
            // 
            this.pay.HeaderText = "จ่ายแล้ว";
            this.pay.Name = "pay";
            this.pay.ReadOnly = true;
            this.pay.Width = 50;
            // 
            // frmRemain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 600);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRemain";
            this.Text = "รายการคงค้าง";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateReceive;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSend;
        private System.Windows.Forms.DataGridViewCheckBoxColumn back;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pay;
    }
}