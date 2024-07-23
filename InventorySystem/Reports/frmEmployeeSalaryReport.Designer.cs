
namespace PickAndChooseGroceryStore
{
    partial class frmEmployeeSalaryReport
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
            this.lblTodaysReport = new System.Windows.Forms.Label();
            this.chkBoxPAID = new System.Windows.Forms.CheckBox();
            this.chkBoxPending = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSalary = new System.Windows.Forms.DataGridView();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTodaysReport
            // 
            this.lblTodaysReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTodaysReport.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTodaysReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTodaysReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTodaysReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTodaysReport.ForeColor = System.Drawing.Color.White;
            this.lblTodaysReport.Location = new System.Drawing.Point(543, 2);
            this.lblTodaysReport.Name = "lblTodaysReport";
            this.lblTodaysReport.Size = new System.Drawing.Size(141, 36);
            this.lblTodaysReport.TabIndex = 55;
            this.lblTodaysReport.Text = "All Record";
            this.lblTodaysReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTodaysReport.Click += new System.EventHandler(this.lblTodaysReport_Click);
            // 
            // chkBoxPAID
            // 
            this.chkBoxPAID.AutoSize = true;
            this.chkBoxPAID.Location = new System.Drawing.Point(322, 121);
            this.chkBoxPAID.Name = "chkBoxPAID";
            this.chkBoxPAID.Size = new System.Drawing.Size(47, 17);
            this.chkBoxPAID.TabIndex = 53;
            this.chkBoxPAID.Text = "Paid";
            this.chkBoxPAID.UseVisualStyleBackColor = true;
            this.chkBoxPAID.Click += new System.EventHandler(this.chkBoxPAID_Click);
            // 
            // chkBoxPending
            // 
            this.chkBoxPending.AutoSize = true;
            this.chkBoxPending.Location = new System.Drawing.Point(372, 121);
            this.chkBoxPending.Name = "chkBoxPending";
            this.chkBoxPending.Size = new System.Drawing.Size(65, 17);
            this.chkBoxPending.TabIndex = 51;
            this.chkBoxPending.Text = "Pending";
            this.chkBoxPending.UseVisualStyleBackColor = true;
            this.chkBoxPending.Click += new System.EventHandler(this.chkBoxPending_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(245, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 50;
            this.label4.Text = "Status";
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(89, 118);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(145, 21);
            this.cmbMonth.TabIndex = 49;
            this.cmbMonth.SelectionChangeCommitted += new System.EventHandler(this.cmbMonth_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(5, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 48;
            this.label2.Text = "Months";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(177)))), ((int)(((byte)(160)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(686, 41);
            this.label1.TabIndex = 47;
            this.label1.Text = "Salary Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSalary
            // 
            this.dgvSalary.AllowUserToAddRows = false;
            this.dgvSalary.AllowUserToDeleteRows = false;
            this.dgvSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalary.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvSalary.Location = new System.Drawing.Point(0, 145);
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.ReadOnly = true;
            this.dgvSalary.RowHeadersVisible = false;
            this.dgvSalary.RowTemplate.Height = 25;
            this.dgvSalary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalary.Size = new System.Drawing.Size(686, 504);
            this.dgvSalary.TabIndex = 46;
            this.dgvSalary.TabStop = false;
            this.dgvSalary.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvSalary_ColumnAdded);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(347, 67);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 35);
            this.btnReset.TabIndex = 67;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(220, 80);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(118, 20);
            this.dtToDate.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(219, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 65;
            this.label7.Text = "TO DATE :";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(145, 67);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 35);
            this.btnSearch.TabIndex = 64;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(8, 80);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(126, 20);
            this.dtFromDate.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(7, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 25);
            this.label8.TabIndex = 62;
            this.label8.Text = "FROM DATE :";
            // 
            // frmEmployeeSalaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(686, 649);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTodaysReport);
            this.Controls.Add(this.chkBoxPAID);
            this.Controls.Add(this.chkBoxPending);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSalary);
            this.Name = "frmEmployeeSalaryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeeSalaryReport";
            this.Load += new System.EventHandler(this.frmEmployeeSalaryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTodaysReport;
        private System.Windows.Forms.CheckBox chkBoxPAID;
        private System.Windows.Forms.CheckBox chkBoxPending;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSalary;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label8;
    }
}