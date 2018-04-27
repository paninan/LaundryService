namespace LaundryService
{
    partial class frmMain
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
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNewCus = new System.Windows.Forms.Button();
            this.checkBoxPhone = new System.Windows.Forms.CheckBox();
            this.btnPackage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCustomer.Location = new System.Drawing.Point(153, 82);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(138, 23);
            this.txtCustomer.TabIndex = 8;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(329, 82);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNewCus
            // 
            this.btnNewCus.Location = new System.Drawing.Point(153, 194);
            this.btnNewCus.Name = "btnNewCus";
            this.btnNewCus.Size = new System.Drawing.Size(175, 44);
            this.btnNewCus.TabIndex = 10;
            this.btnNewCus.Text = "ลูกค้าใหม่";
            this.btnNewCus.UseVisualStyleBackColor = true;
            this.btnNewCus.Click += new System.EventHandler(this.btnNewCus_Click);
            // 
            // checkBoxPhone
            // 
            this.checkBoxPhone.AutoSize = true;
            this.checkBoxPhone.Location = new System.Drawing.Point(153, 128);
            this.checkBoxPhone.Name = "checkBoxPhone";
            this.checkBoxPhone.Size = new System.Drawing.Size(115, 17);
            this.checkBoxPhone.TabIndex = 11;
            this.checkBoxPhone.Text = "ค้นหาด้วยเบอร์โทร";
            this.checkBoxPhone.UseVisualStyleBackColor = true;
            // 
            // btnPackage
            // 
            this.btnPackage.Location = new System.Drawing.Point(153, 256);
            this.btnPackage.Name = "btnPackage";
            this.btnPackage.Size = new System.Drawing.Size(175, 42);
            this.btnPackage.TabIndex = 12;
            this.btnPackage.Text = "จัดการ";
            this.btnPackage.UseVisualStyleBackColor = true;
            this.btnPackage.Click += new System.EventHandler(this.btnPackage_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = ".....";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPackage);
            this.Controls.Add(this.checkBoxPhone);
            this.Controls.Add(this.btnNewCus);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCustomer);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNewCus;
        private System.Windows.Forms.CheckBox checkBoxPhone;
        private System.Windows.Forms.Button btnPackage;
        private System.Windows.Forms.Button button1;
    }
}