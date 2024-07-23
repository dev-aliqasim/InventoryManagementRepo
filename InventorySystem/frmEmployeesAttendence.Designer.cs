
namespace PickAndChooseGroceryStore
{
    partial class frmEmployeesAttendence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeesAttendence));
            this.dgvEmployeeAttendence = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radiobtnPresent = new System.Windows.Forms.RadioButton();
            this.radiobtnAbsent = new System.Windows.Forms.RadioButton();
            this.radiobtnLeave = new System.Windows.Forms.RadioButton();
            this.cmbEmployeeName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblclockIN = new System.Windows.Forms.Label();
            this.dtClockIN = new System.Windows.Forms.DateTimePicker();
            this.lblClockOUT = new System.Windows.Forms.Label();
            this.dtClockOUT = new System.Windows.Forms.DateTimePicker();
            this.lblComments = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.pBoxEmployee = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeAttendence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxEmployee)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployeeAttendence
            // 
            this.dgvEmployeeAttendence.AllowUserToAddRows = false;
            this.dgvEmployeeAttendence.AllowUserToDeleteRows = false;
            this.dgvEmployeeAttendence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployeeAttendence.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployeeAttendence.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployeeAttendence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeAttendence.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvEmployeeAttendence.Location = new System.Drawing.Point(2, 297);
            this.dgvEmployeeAttendence.Name = "dgvEmployeeAttendence";
            this.dgvEmployeeAttendence.ReadOnly = true;
            this.dgvEmployeeAttendence.RowHeadersVisible = false;
            this.dgvEmployeeAttendence.RowTemplate.Height = 25;
            this.dgvEmployeeAttendence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeAttendence.Size = new System.Drawing.Size(897, 99);
            this.dgvEmployeeAttendence.TabIndex = 8;
            this.dgvEmployeeAttendence.TabStop = false;
            this.dgvEmployeeAttendence.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvEmployeeAttendence_ColumnAdded);
            this.dgvEmployeeAttendence.SelectionChanged += new System.EventHandler(this.dgvEmployeeAttendence_SelectionChanged);
            this.dgvEmployeeAttendence.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEmployeeAttendence_MouseDoubleClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(279, 399);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 34);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(210, 399);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 34);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(71, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 34);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(141, 399);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 34);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(2, 399);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(64, 34);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Employee Name";
            // 
            // dtDate
            // 
            this.dtDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(152, 46);
            this.dtDate.MinimumSize = new System.Drawing.Size(156, 32);
            this.dtDate.Name = "dtDate";
            this.dtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtDate.Size = new System.Drawing.Size(156, 33);
            this.dtDate.TabIndex = 1;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            this.dtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtDate_KeyDown);
            this.dtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtDate_KeyPress);
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(152, 94);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.ReadOnly = true;
            this.txtEmployeeID.Size = new System.Drawing.Size(156, 20);
            this.txtEmployeeID.TabIndex = 3;
            this.txtEmployeeID.TabStop = false;
            this.txtEmployeeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeID_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "Employee ID\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Status";
            // 
            // radiobtnPresent
            // 
            this.radiobtnPresent.AutoSize = true;
            this.radiobtnPresent.Location = new System.Drawing.Point(156, 158);
            this.radiobtnPresent.Name = "radiobtnPresent";
            this.radiobtnPresent.Size = new System.Drawing.Size(61, 17);
            this.radiobtnPresent.TabIndex = 7;
            this.radiobtnPresent.TabStop = true;
            this.radiobtnPresent.Text = "Present";
            this.radiobtnPresent.UseVisualStyleBackColor = true;
            this.radiobtnPresent.CheckedChanged += new System.EventHandler(this.radiobtnPresent_CheckedChanged);
            // 
            // radiobtnAbsent
            // 
            this.radiobtnAbsent.AutoSize = true;
            this.radiobtnAbsent.Location = new System.Drawing.Point(216, 158);
            this.radiobtnAbsent.Name = "radiobtnAbsent";
            this.radiobtnAbsent.Size = new System.Drawing.Size(58, 17);
            this.radiobtnAbsent.TabIndex = 8;
            this.radiobtnAbsent.TabStop = true;
            this.radiobtnAbsent.Text = "Absent";
            this.radiobtnAbsent.UseVisualStyleBackColor = true;
            this.radiobtnAbsent.CheckedChanged += new System.EventHandler(this.radiobtnAbsent_CheckedChanged);
            // 
            // radiobtnLeave
            // 
            this.radiobtnLeave.AutoSize = true;
            this.radiobtnLeave.Location = new System.Drawing.Point(274, 158);
            this.radiobtnLeave.Name = "radiobtnLeave";
            this.radiobtnLeave.Size = new System.Drawing.Size(55, 17);
            this.radiobtnLeave.TabIndex = 9;
            this.radiobtnLeave.TabStop = true;
            this.radiobtnLeave.Text = "Leave";
            this.radiobtnLeave.UseVisualStyleBackColor = true;
            this.radiobtnLeave.CheckedChanged += new System.EventHandler(this.radiobtnLeave_CheckedChanged);
            // 
            // cmbEmployeeName
            // 
            this.cmbEmployeeName.FormattingEnabled = true;
            this.cmbEmployeeName.Location = new System.Drawing.Point(152, 125);
            this.cmbEmployeeName.Name = "cmbEmployeeName";
            this.cmbEmployeeName.Size = new System.Drawing.Size(191, 21);
            this.cmbEmployeeName.TabIndex = 5;
            this.cmbEmployeeName.SelectionChangeCommitted += new System.EventHandler(this.cmbEmployeeName_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Attendance Date";
            // 
            // lblclockIN
            // 
            this.lblclockIN.AutoSize = true;
            this.lblclockIN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblclockIN.Location = new System.Drawing.Point(394, 84);
            this.lblclockIN.Name = "lblclockIN";
            this.lblclockIN.Size = new System.Drawing.Size(74, 21);
            this.lblclockIN.TabIndex = 10;
            this.lblclockIN.Text = "Clock IN";
            // 
            // dtClockIN
            // 
            this.dtClockIN.CalendarFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtClockIN.CustomFormat = "hh:mm:ss";
            this.dtClockIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtClockIN.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtClockIN.Location = new System.Drawing.Point(474, 79);
            this.dtClockIN.MinimumSize = new System.Drawing.Size(190, 32);
            this.dtClockIN.Name = "dtClockIN";
            this.dtClockIN.ShowCheckBox = true;
            this.dtClockIN.ShowUpDown = true;
            this.dtClockIN.Size = new System.Drawing.Size(190, 32);
            this.dtClockIN.TabIndex = 11;
            this.dtClockIN.ValueChanged += new System.EventHandler(this.dtClockIN_ValueChanged);
            // 
            // lblClockOUT
            // 
            this.lblClockOUT.AutoSize = true;
            this.lblClockOUT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblClockOUT.Location = new System.Drawing.Point(379, 123);
            this.lblClockOUT.Name = "lblClockOUT";
            this.lblClockOUT.Size = new System.Drawing.Size(89, 21);
            this.lblClockOUT.TabIndex = 12;
            this.lblClockOUT.Text = "Clock OUT";
            // 
            // dtClockOUT
            // 
            this.dtClockOUT.CustomFormat = "hh:mm:ss";
            this.dtClockOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtClockOUT.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtClockOUT.Location = new System.Drawing.Point(474, 118);
            this.dtClockOUT.MinimumSize = new System.Drawing.Size(190, 32);
            this.dtClockOUT.Name = "dtClockOUT";
            this.dtClockOUT.ShowCheckBox = true;
            this.dtClockOUT.ShowUpDown = true;
            this.dtClockOUT.Size = new System.Drawing.Size(190, 32);
            this.dtClockOUT.TabIndex = 13;
            this.dtClockOUT.ValueChanged += new System.EventHandler(this.dtClockOUT_ValueChanged);
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComments.Location = new System.Drawing.Point(56, 188);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(86, 21);
            this.lblComments.TabIndex = 14;
            this.lblComments.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(152, 188);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(512, 103);
            this.txtComments.TabIndex = 15;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(770, 33);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(125, 40);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pBoxEmployee
            // 
            this.pBoxEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.pBoxEmployee.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pBoxEmployee.ErrorImage")));
            this.pBoxEmployee.Location = new System.Drawing.Point(670, 79);
            this.pBoxEmployee.Name = "pBoxEmployee";
            this.pBoxEmployee.Size = new System.Drawing.Size(225, 212);
            this.pBoxEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxEmployee.TabIndex = 52;
            this.pBoxEmployee.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(52)))), ((int)(((byte)(212)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(900, 31);
            this.panel3.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(744, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu / Attendance";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Attendance";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmEmployeesAttendence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(151)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(900, 443);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pBoxEmployee);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.dtClockOUT);
            this.Controls.Add(this.lblClockOUT);
            this.Controls.Add(this.dtClockIN);
            this.Controls.Add(this.lblclockIN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbEmployeeName);
            this.Controls.Add(this.radiobtnLeave);
            this.Controls.Add(this.radiobtnAbsent);
            this.Controls.Add(this.radiobtnPresent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvEmployeeAttendence);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployeesAttendence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeeAttendence";
            this.Load += new System.EventHandler(this.frmEmployeesAttendence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeAttendence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxEmployee)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEmployeeAttendence;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radiobtnPresent;
        private System.Windows.Forms.RadioButton radiobtnAbsent;
        private System.Windows.Forms.RadioButton radiobtnLeave;
        private System.Windows.Forms.ComboBox cmbEmployeeName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblclockIN;
        private System.Windows.Forms.DateTimePicker dtClockIN;
        private System.Windows.Forms.Label lblClockOUT;
        private System.Windows.Forms.DateTimePicker dtClockOUT;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox pBoxEmployee;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}