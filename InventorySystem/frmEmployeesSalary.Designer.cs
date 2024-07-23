
namespace PickAndChooseGroceryStore
{
    partial class frmEmployeesSalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeesSalary));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvEmployeeSalary = new System.Windows.Forms.DataGridView();
            this.txtTotalAbsentees = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmployeeSalary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCalculatedSalary = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radiobtnPaid = new System.Windows.Forms.RadioButton();
            this.radiobtnPending = new System.Windows.Forms.RadioButton();
            this.cmbEmployeeName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAbsenteesGreaterThan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAmountToDeduct = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeSalary)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(177)))), ((int)(((byte)(160)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(672, 41);
            this.label1.TabIndex = 3;
            this.label1.Text = "Employees Salary";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(16, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Employee Name";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(399, 50);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(173, 20);
            this.dtDate.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(354, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Date";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(149, 49);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.ReadOnly = true;
            this.txtEmployeeID.Size = new System.Drawing.Size(156, 20);
            this.txtEmployeeID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(43, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Employee ID";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(281, 424);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 34);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(212, 424);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 34);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(73, 424);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 34);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(142, 424);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 34);
            this.btnEdit.TabIndex = 19;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(3, 424);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(64, 34);
            this.btnNew.TabIndex = 17;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvEmployeeSalary
            // 
            this.dgvEmployeeSalary.AllowUserToAddRows = false;
            this.dgvEmployeeSalary.AllowUserToDeleteRows = false;
            this.dgvEmployeeSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployeeSalary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployeeSalary.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployeeSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeSalary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvEmployeeSalary.Location = new System.Drawing.Point(3, 204);
            this.dgvEmployeeSalary.Name = "dgvEmployeeSalary";
            this.dgvEmployeeSalary.ReadOnly = true;
            this.dgvEmployeeSalary.RowHeadersVisible = false;
            this.dgvEmployeeSalary.RowTemplate.Height = 25;
            this.dgvEmployeeSalary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeSalary.Size = new System.Drawing.Size(665, 215);
            this.dgvEmployeeSalary.TabIndex = 34;
            this.dgvEmployeeSalary.TabStop = false;
            this.dgvEmployeeSalary.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvEmployeeSalary_ColumnAdded);
            this.dgvEmployeeSalary.SelectionChanged += new System.EventHandler(this.dgvEmployeeSalary_SelectionChanged);
            this.dgvEmployeeSalary.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEmployeeSalary_MouseDoubleClick);
            // 
            // txtTotalAbsentees
            // 
            this.txtTotalAbsentees.Location = new System.Drawing.Point(149, 146);
            this.txtTotalAbsentees.Name = "txtTotalAbsentees";
            this.txtTotalAbsentees.Size = new System.Drawing.Size(156, 20);
            this.txtTotalAbsentees.TabIndex = 10;
            this.txtTotalAbsentees.TextChanged += new System.EventHandler(this.txtTotalAbsentees_TextChanged);
            this.txtTotalAbsentees.Leave += new System.EventHandler(this.txtTotalAbsentees_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(23, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total Absentees";
            // 
            // txtEmployeeSalary
            // 
            this.txtEmployeeSalary.Location = new System.Drawing.Point(149, 99);
            this.txtEmployeeSalary.Name = "txtEmployeeSalary";
            this.txtEmployeeSalary.Size = new System.Drawing.Size(156, 20);
            this.txtEmployeeSalary.TabIndex = 5;
            this.txtEmployeeSalary.TextChanged += new System.EventHandler(this.txtEmployeeSalary_TextChanged);
            this.txtEmployeeSalary.Leave += new System.EventHandler(this.txtEmployeeSalary_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(15, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "Employee Salary";
            // 
            // txtCalculatedSalary
            // 
            this.txtCalculatedSalary.Location = new System.Drawing.Point(149, 171);
            this.txtCalculatedSalary.Name = "txtCalculatedSalary";
            this.txtCalculatedSalary.ReadOnly = true;
            this.txtCalculatedSalary.Size = new System.Drawing.Size(156, 20);
            this.txtCalculatedSalary.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(11, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "Calculated Salary";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(8, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Salary Paid Status";
            // 
            // radiobtnPaid
            // 
            this.radiobtnPaid.AutoSize = true;
            this.radiobtnPaid.Location = new System.Drawing.Point(150, 123);
            this.radiobtnPaid.Name = "radiobtnPaid";
            this.radiobtnPaid.Size = new System.Drawing.Size(46, 17);
            this.radiobtnPaid.TabIndex = 7;
            this.radiobtnPaid.TabStop = true;
            this.radiobtnPaid.Text = "Paid";
            this.radiobtnPaid.UseVisualStyleBackColor = true;
            this.radiobtnPaid.CheckedChanged += new System.EventHandler(this.radiobtnPaid_CheckedChanged);
            // 
            // radiobtnPending
            // 
            this.radiobtnPending.AutoSize = true;
            this.radiobtnPending.Location = new System.Drawing.Point(205, 123);
            this.radiobtnPending.Name = "radiobtnPending";
            this.radiobtnPending.Size = new System.Drawing.Size(64, 17);
            this.radiobtnPending.TabIndex = 8;
            this.radiobtnPending.TabStop = true;
            this.radiobtnPending.Text = "Pending";
            this.radiobtnPending.UseVisualStyleBackColor = true;
            this.radiobtnPending.CheckedChanged += new System.EventHandler(this.radiobtnPending_CheckedChanged);
            // 
            // cmbEmployeeName
            // 
            this.cmbEmployeeName.FormattingEnabled = true;
            this.cmbEmployeeName.Location = new System.Drawing.Point(149, 72);
            this.cmbEmployeeName.Name = "cmbEmployeeName";
            this.cmbEmployeeName.Size = new System.Drawing.Size(156, 21);
            this.cmbEmployeeName.TabIndex = 3;
            this.cmbEmployeeName.SelectionChangeCommitted += new System.EventHandler(this.cmbEmployeeName_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(7, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Salary Deduction Formula\r\n";
            // 
            // txtAbsenteesGreaterThan
            // 
            this.txtAbsenteesGreaterThan.Location = new System.Drawing.Point(205, 41);
            this.txtAbsenteesGreaterThan.Name = "txtAbsenteesGreaterThan";
            this.txtAbsenteesGreaterThan.Size = new System.Drawing.Size(80, 20);
            this.txtAbsenteesGreaterThan.TabIndex = 2;
            this.txtAbsenteesGreaterThan.Text = "0";
            this.txtAbsenteesGreaterThan.TextChanged += new System.EventHandler(this.txtAbsenteesGreaterThan_TextChanged);
            this.txtAbsenteesGreaterThan.Leave += new System.EventHandler(this.txtAbsenteesGreaterThan_Leave);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label10.Location = new System.Drawing.Point(7, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 33);
            this.label10.TabIndex = 1;
            this.label10.Text = "If Absentees is greater than";
            // 
            // txtAmountToDeduct
            // 
            this.txtAmountToDeduct.Location = new System.Drawing.Point(205, 79);
            this.txtAmountToDeduct.Name = "txtAmountToDeduct";
            this.txtAmountToDeduct.Size = new System.Drawing.Size(80, 20);
            this.txtAmountToDeduct.TabIndex = 4;
            this.txtAmountToDeduct.Text = "0";
            this.txtAmountToDeduct.TextChanged += new System.EventHandler(this.txtAmountToDeduct_TextChanged);
            this.txtAmountToDeduct.Leave += new System.EventHandler(this.txtAmountToDeduct_Leave);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label11.Location = new System.Drawing.Point(7, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 34);
            this.label11.TabIndex = 3;
            this.label11.Text = "Deduct Rs. from Salary";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(193)))), ((int)(((byte)(179)))));
            this.groupBox1.Controls.Add(this.txtAmountToDeduct);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtAbsenteesGreaterThan);
            this.groupBox1.Location = new System.Drawing.Point(354, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 120);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // frmEmployeesSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(672, 465);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbEmployeeName);
            this.Controls.Add(this.radiobtnPending);
            this.Controls.Add(this.radiobtnPaid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCalculatedSalary);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotalAbsentees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmployeeSalary);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvEmployeeSalary);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(688, 371);
            this.Name = "frmEmployeesSalary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeesSalary";
            this.Load += new System.EventHandler(this.frmEmployeesSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeSalary)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvEmployeeSalary;
        private System.Windows.Forms.TextBox txtTotalAbsentees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmployeeSalary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCalculatedSalary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radiobtnPaid;
        private System.Windows.Forms.RadioButton radiobtnPending;
        private System.Windows.Forms.ComboBox cmbEmployeeName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAbsenteesGreaterThan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAmountToDeduct;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}