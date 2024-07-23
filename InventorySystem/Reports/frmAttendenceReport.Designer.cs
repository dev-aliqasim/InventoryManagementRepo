
namespace PickAndChooseGroceryStore
{
    partial class frmAttendenceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendenceReport));
            this.dgvAttendence = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBoxAbsent = new System.Windows.Forms.CheckBox();
            this.chkBoxLeave = new System.Windows.Forms.CheckBox();
            this.chkBoxPresent = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.btnEmployeeReset = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendence)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAttendence
            // 
            this.dgvAttendence.AllowUserToAddRows = false;
            this.dgvAttendence.AllowUserToDeleteRows = false;
            this.dgvAttendence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAttendence.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendence.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendence.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvAttendence.Location = new System.Drawing.Point(0, 139);
            this.dgvAttendence.Name = "dgvAttendence";
            this.dgvAttendence.ReadOnly = true;
            this.dgvAttendence.RowHeadersVisible = false;
            this.dgvAttendence.RowTemplate.Height = 25;
            this.dgvAttendence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendence.Size = new System.Drawing.Size(882, 510);
            this.dgvAttendence.TabIndex = 34;
            this.dgvAttendence.TabStop = false;
            this.dgvAttendence.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvAttendence_ColumnAdded);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(167)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(882, 48);
            this.label1.TabIndex = 35;
            this.label1.Text = "Attendance Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label2.Location = new System.Drawing.Point(171, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "Month";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label4.Location = new System.Drawing.Point(570, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 40;
            this.label4.Text = "Status";
            // 
            // chkBoxAbsent
            // 
            this.chkBoxAbsent.AutoSize = true;
            this.chkBoxAbsent.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.chkBoxAbsent.Location = new System.Drawing.Point(709, 66);
            this.chkBoxAbsent.Name = "chkBoxAbsent";
            this.chkBoxAbsent.Size = new System.Drawing.Size(59, 17);
            this.chkBoxAbsent.TabIndex = 41;
            this.chkBoxAbsent.Text = "Absent";
            this.chkBoxAbsent.UseVisualStyleBackColor = true;
            this.chkBoxAbsent.CheckedChanged += new System.EventHandler(this.chkBoxAbsent_CheckedChanged_1);
            this.chkBoxAbsent.Click += new System.EventHandler(this.chkBoxAbsent_Click);
            // 
            // chkBoxLeave
            // 
            this.chkBoxLeave.AutoSize = true;
            this.chkBoxLeave.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.chkBoxLeave.Location = new System.Drawing.Point(768, 66);
            this.chkBoxLeave.Name = "chkBoxLeave";
            this.chkBoxLeave.Size = new System.Drawing.Size(56, 17);
            this.chkBoxLeave.TabIndex = 42;
            this.chkBoxLeave.Text = "Leave";
            this.chkBoxLeave.UseVisualStyleBackColor = true;
            this.chkBoxLeave.CheckedChanged += new System.EventHandler(this.chkBoxLeave_CheckedChanged_1);
            this.chkBoxLeave.Click += new System.EventHandler(this.chkBoxLeave_Click);
            // 
            // chkBoxPresent
            // 
            this.chkBoxPresent.AutoSize = true;
            this.chkBoxPresent.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.chkBoxPresent.Location = new System.Drawing.Point(645, 66);
            this.chkBoxPresent.Name = "chkBoxPresent";
            this.chkBoxPresent.Size = new System.Drawing.Size(62, 17);
            this.chkBoxPresent.TabIndex = 43;
            this.chkBoxPresent.Text = "Present";
            this.chkBoxPresent.UseVisualStyleBackColor = true;
            this.chkBoxPresent.CheckedChanged += new System.EventHandler(this.chkBoxPresent_CheckedChanged_1);
            this.chkBoxPresent.Click += new System.EventHandler(this.chkBoxPresent_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label5.Location = new System.Drawing.Point(3, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 46;
            this.label5.Text = "Year";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Items.AddRange(new object[] {
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
            this.cmbEmployee.Location = new System.Drawing.Point(477, 100);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(147, 21);
            this.cmbEmployee.TabIndex = 49;
            this.cmbEmployee.Text = "Select an Employee";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label6.Location = new System.Drawing.Point(374, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 23);
            this.label6.TabIndex = 48;
            this.label6.Text = "Employee";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(71, 60);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(115, 20);
            this.dtFromDate.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label7.Location = new System.Drawing.Point(3, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 23);
            this.label7.TabIndex = 51;
            this.label7.Text = "From";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label8.Location = new System.Drawing.Point(280, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 23);
            this.label8.TabIndex = 53;
            this.label8.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(319, 61);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(120, 20);
            this.dtToDate.TabIndex = 52;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(167)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(194, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 35);
            this.btnSearch.TabIndex = 54;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(167)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(456, 52);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 35);
            this.btnReset.TabIndex = 55;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(167)))));
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApplyFilter.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyFilter.ForeColor = System.Drawing.Color.Black;
            this.btnApplyFilter.Location = new System.Drawing.Point(676, 92);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(148, 35);
            this.btnApplyFilter.TabIndex = 56;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(60, 101);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(105, 22);
            this.dtpYear.TabIndex = 57;
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MMM";
            this.dtpMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(251, 101);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(105, 22);
            this.dtpMonth.TabIndex = 58;
            // 
            // btnEmployeeReset
            // 
            this.btnEmployeeReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(167)))));
            this.btnEmployeeReset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEmployeeReset.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeReset.Image")));
            this.btnEmployeeReset.Location = new System.Drawing.Point(630, 99);
            this.btnEmployeeReset.Name = "btnEmployeeReset";
            this.btnEmployeeReset.Size = new System.Drawing.Size(29, 23);
            this.btnEmployeeReset.TabIndex = 59;
            this.btnEmployeeReset.Click += new System.EventHandler(this.btnEmployeeReset_Click);
            // 
            // frmAttendenceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(882, 649);
            this.Controls.Add(this.btnEmployeeReset);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkBoxPresent);
            this.Controls.Add(this.chkBoxLeave);
            this.Controls.Add(this.chkBoxAbsent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAttendence);
            this.Name = "frmAttendenceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAttendenceReport";
            this.Load += new System.EventHandler(this.frmAttendenceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAttendence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBoxAbsent;
        private System.Windows.Forms.CheckBox chkBoxLeave;
        private System.Windows.Forms.CheckBox chkBoxPresent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Label btnEmployeeReset;
    }
}