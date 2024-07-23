using System;
using System.Data;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmEmployeesAttendence : Form
    {
        public frmEmployeesAttendence()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        DataTable dtEmployee = new DataTable();

        string attendenceStatus = "";
        string attendenceID = "";

        string clockIN = "";
        string clockOUT = "";
        string defaultEmployeePic = AppDomain.CurrentDomain.BaseDirectory + @"\Resources\worker-64.ico";

        bool NewMode = true;
        bool EditMode = false;
        bool disableMode = false;
        public void FormControl(string Control)
        {
            if (Control.ToLower() == "enable")
            {
                disableMode = false;
                //textboxes
                txtEmployeeID.Enabled = true;
                cmbEmployeeName.Enabled = true;
                dtDate.Enabled = true;
                dtClockIN.Enabled = true;
                dtClockOUT.Enabled = true;
                txtComments.Enabled = true;
                {
                    radiobtnPresent.Enabled = true;
                    radiobtnAbsent.Enabled = true;
                    radiobtnLeave.Enabled = true;
                }
                pBoxEmployee.Enabled = true;
                //implicit present if not selected
                radiobtnPresent.Checked = true;

                //buttons
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
            }
            else if (Control.ToLower() == "disable")
            {
                disableMode = true;
                //textboxes
                txtEmployeeID.Enabled = false;
                cmbEmployeeName.Enabled = false;
                dtDate.Enabled = true;
                dtClockIN.Enabled = false;
                dtClockOUT.Enabled = false;
                txtComments.Enabled = false;
                {
                    radiobtnPresent.Enabled = false;
                    radiobtnAbsent.Enabled = false;
                    radiobtnLeave.Enabled = false;
                }
                pBoxEmployee.Enabled = false;
                //buttons
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
            }
            else if (Control.ToLower() == "clear")
            {
                disableMode = false;
                //
                txtEmployeeID.Text = "";
                cmbEmployeeName.SelectedIndex = -1;
                dtDate.Value = DateTime.Now;
                dtClockIN.Value = DateTime.Now;
                dtClockOUT.Value = DateTime.Now;
                txtComments.Text = "";
                {
                    radiobtnPresent.Checked = false;
                    radiobtnAbsent.Checked = false;
                    radiobtnLeave.Checked = false;
                }
                pBoxEmployee.ImageLocation = defaultEmployeePic;
            }

        }

        public void LoadEmployee()
        {
            string query = "Select * from Employee";
            dtEmployee = General.FetchData(query);
            cmbEmployeeName.DataSource = dtEmployee;
            cmbEmployeeName.DisplayMember = dtEmployee.Columns["EmployeeName"].ToString();
            cmbEmployeeName.ValueMember = dtEmployee.Columns["EmployeeID"].ToString();
            cmbEmployeeName.SelectedIndex = -1;
        }
        public void LoadData()
        {
            string Query = "select EmployeeAttendence.EmployeeID,EmployeeAttendence.AttendenceID,Employee.Picture,Date,EmployeeName,AttendenceStatus,ClockIN,ClockOUT,Comments from EmployeeAttendence inner join Employee on Employee.EmployeeID = EmployeeAttendence.EmployeeID where EmployeeAttendence.Date = '" + DateTime.Now.Date + "' order by AttendenceID desc";
            dt = General.FetchData(Query);
            dgvEmployeeAttendence.DataSource = "";
            dgvEmployeeAttendence.DataSource = dt;

        }
        public void LoadDataWithSpecificDate(DateTime date)
        {
            string Query = "select EmployeeAttendence.EmployeeID,EmployeeAttendence.AttendenceID,Employee.Picture,Date,EmployeeName,AttendenceStatus,ClockIN,ClockOUT,Comments from EmployeeAttendence inner join Employee on Employee.EmployeeID = EmployeeAttendence.EmployeeID where EmployeeAttendence.Date = '" + date + "' order by AttendenceID desc";
            dt = General.FetchData(Query);
            if (dt.Rows.Count > 0)
            {
                dgvEmployeeAttendence.DataSource = "";
                dgvEmployeeAttendence.DataSource = dt;
            }
            else
            {
                dgvEmployeeAttendence.DataSource = "";
                disableMode = true;
            }


        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormControl("clear");
            FormControl("enable");

            NewMode = true;
            EditMode = false;
            cmbEmployeeName.Focus();
        }

        public bool CheckSingleAttendance(string EmployeeID, string Date)
        {

            string query = "select * from EmployeeAttendence where EmployeeAttendence.EmployeeID = '" + EmployeeID + "' and EmployeeAttendence.Date = '" + Date + "'";
            DataTable dt = new DataTable();
            dt = General.FetchData(query);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Duplicate entry is not allowed", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        public bool CheckSingleAttendanceForUpdate(string AttendanceID, string EmployeeID, string Date)
        {

            string query = "select * from EmployeeAttendence where EmployeeAttendence.EmployeeID = '" + EmployeeID + "' and EmployeeAttendence.Date = '" + Date + "' ";
            DataTable dt = new DataTable();
            dt = General.FetchData(query);
            if (dt.Rows.Count != 1)
            {
                MessageBox.Show("Duplicate entry is not allowed.Please update an existing record.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["AttendenceID"].ToString() == AttendanceID)
                {
                    return true;
                }

            }
            MessageBox.Show("Duplicate entry is not allowed.Please update an existing record.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cmbEmployeeName.SelectedIndex == -1)
            {
                MessageBox.Show("Select Employee Name first ");
                cmbEmployeeName.Focus();
                return;

            }
            else if (attendenceStatus == "")
            {
                MessageBox.Show("Please Choose Attendence Status ");
                radiobtnPresent.Focus();
                return;
            }
            else
            {
                if (NewMode == true)
                {
                    if (radiobtnPresent.Checked != true)
                    {
                        clockIN = "";
                        clockOUT = "";

                    }
                    bool singleEntry = CheckSingleAttendance(txtEmployeeID.Text.ToString().Trim(), dtDate.Text.ToString().Trim());
                    if (singleEntry != true)
                    {
                        cmbEmployeeName.Focus();
                        return;
                    }
                    //save Query
                    string Query = "Insert into EmployeeAttendence(EmployeeID,Date,AttendenceStatus,ClockIN,ClockOUT,Comments) " +
                        "values( '" + txtEmployeeID.Text.ToString().Trim() + "' , '" + dtDate.Text.ToString().Trim() + "' , '" + attendenceStatus.Trim().ToString() + "','" + clockIN + "','" + clockOUT + "','" + txtComments.Text.Trim().ToString() + "' ) ";
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Inserted Successfully !");

                }
                else if (EditMode == true)
                {
                    if (radiobtnPresent.Checked != true)
                    {
                        clockIN = "";
                        clockOUT = "";

                    }
                    bool singleEntryForUpdate = CheckSingleAttendanceForUpdate(attendenceID, txtEmployeeID.Text.ToString().Trim(), dtDate.Text.ToString().Trim());
                    if (singleEntryForUpdate != true)
                    {
                        return;
                    }
                    ////Update Query 
                    string Query = "Update EmployeeAttendence set EmployeeID = '" + txtEmployeeID.Text.ToString().Trim() + "' , Date = '" + dtDate.Text.ToString().Trim() + "' , AttendenceStatus = '" + attendenceStatus.Trim().ToString() + "', ClockIN='" + clockIN + "',ClockOUT='" + clockOUT + "',Comments='" + txtComments.Text.Trim().ToString() + "'   where AttendenceID = " + attendenceID;
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Updated");
                    btnSave.Text = "Save";

                }
                LoadData();
                FormControl("disable");
                btnNew.Focus();
            }
        }

        private void frmEmployeesAttendence_Load(object sender, EventArgs e)
        {
            FormControl("disable");
            disableMode = true;
            LoadEmployee();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormControl("enable");
            //
            if (radiobtnPresent.Checked != true)
            {
                dtClockIN.Enabled = false;
                dtClockOUT.Enabled = false;
            }
            else
            {
                dtClockIN.Enabled = true;
                dtClockOUT.Enabled = true;
            }
            //


            NewMode = false;
            EditMode = true;

            btnSave.Text = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete this record ?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (txtEmployeeID.Text.Trim().ToString() != "")
                {

                    try
                    {
                        string Query = "Delete EmployeeAttendence where AttendenceID = " + attendenceID;
                        General.ExecuteNonQuery(Query);
                        MessageBox.Show("Record Deleted");
                        FormControl("clear");
                        LoadData();
                    }
                    catch (Exception)
                    {

                        throw new Exception("Exception in Deleting Data");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a record");
                    return;
                }

            }
            else
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormControl("clear");
            FormControl("disable");
            NewMode = true;
            EditMode = false;

            btnSave.Text = "Save";
        }

        public void GridToTextBox()
        {
            if (dgvEmployeeAttendence.SelectedRows.Count > 0)
            {
                int index = dgvEmployeeAttendence.SelectedRows[0].Index;

                dtDate.Value = DateTime.Parse(dt.Rows[index]["Date"].ToString());
                txtEmployeeID.Text = dt.Rows[index]["EmployeeID"].ToString();
                cmbEmployeeName.SelectedValue = dt.Rows[index]["EmployeeID"].ToString();
                attendenceStatus = dt.Rows[index]["AttendenceStatus"].ToString().ToLower().Trim();

                if (string.IsNullOrEmpty(dt.Rows[index]["Picture"].ToString()))
                {
                    pBoxEmployee.ImageLocation = defaultEmployeePic;
                }
                else
                {
                    pBoxEmployee.ImageLocation = dt.Rows[index]["Picture"].ToString();

                }

                if (attendenceStatus == "present")
                {
                    radiobtnPresent.Checked = true;
                    radiobtnAbsent.Checked = false;
                    radiobtnLeave.Checked = false;
                    //
                    if (disableMode == true)
                    {

                        dtClockIN.Enabled = false;
                        dtClockOUT.Enabled = false;
                        dtClockIN.Checked = false;
                        dtClockOUT.Checked = false;
                    }
                    else
                    {
                        dtClockIN.Enabled = true;
                        dtClockOUT.Enabled = true;
                        dtClockIN.Checked = true;
                        dtClockOUT.Checked = true;
                    }

                }
                else if (attendenceStatus == "absent")
                {
                    radiobtnPresent.Checked = false;
                    radiobtnAbsent.Checked = true;
                    radiobtnLeave.Checked = false;
                    //
                    dtClockIN.Enabled = false;
                    dtClockOUT.Enabled = false;
                    dtClockIN.Checked = false;
                    dtClockOUT.Checked = false;
                }
                else if (attendenceStatus == "leave")
                {
                    radiobtnPresent.Checked = false;
                    radiobtnAbsent.Checked = false;
                    radiobtnLeave.Checked = true;
                    //
                    dtClockIN.Enabled = false;
                    dtClockOUT.Enabled = false;
                    dtClockIN.Checked = false;
                    dtClockOUT.Checked = false;
                }
                if (string.IsNullOrEmpty(dt.Rows[index]["ClockIN"].ToString()))
                {
                    dtClockIN.Value = DateTime.Now;
                }
                else
                {
                    dtClockIN.Value = DateTime.Parse(dt.Rows[index]["ClockIN"].ToString());

                }
                if (string.IsNullOrEmpty(dt.Rows[index]["ClockOUT"].ToString()))
                {
                    dtClockOUT.Value = DateTime.Now;
                }
                else
                {
                    dtClockOUT.Value = DateTime.Parse(dt.Rows[index]["ClockOUT"].ToString());

                }
                txtComments.Text = dt.Rows[index]["Comments"].ToString().Trim();


                attendenceID = dt.Rows[index]["AttendenceID"].ToString().ToLower().Trim();
            }

        }
        private void dgvEmployeeAttendence_SelectionChanged(object sender, EventArgs e)
        {
            GridToTextBox();
        }

        private void dgvEmployeeAttendence_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridToTextBox();
        }

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtEmployeeID.Text = cmbEmployeeName.SelectedValue.ToString();
            if (string.IsNullOrEmpty(dtEmployee.Rows[cmbEmployeeName.SelectedIndex]["Picture"].ToString()))
            {
                pBoxEmployee.ImageLocation = defaultEmployeePic;
            }
            else
            {
                pBoxEmployee.ImageLocation = dtEmployee.Rows[cmbEmployeeName.SelectedIndex]["Picture"].ToString();

            }
        }

        private void radiobtnPresent_CheckedChanged(object sender, EventArgs e)
        {
            attendenceStatus = "present";
            //
            dtClockIN.Checked = true;
            dtClockOUT.Checked = true;
            //
            dtClockIN.Enabled = true;
            dtClockOUT.Enabled = true;
            //

            //
            clockIN = dtClockIN.Value.ToShortTimeString();
            clockOUT = dtClockOUT.Value.ToShortTimeString();
        }

        private void radiobtnAbsent_CheckedChanged(object sender, EventArgs e)
        {
            attendenceStatus = "absent";
            //
            dtClockIN.Checked = false;
            dtClockOUT.Checked = false;
            //
            dtClockIN.Enabled = false;
            dtClockOUT.Enabled = false;
            //
            clockIN = "";
            clockOUT = "";
        }

        private void radiobtnLeave_CheckedChanged(object sender, EventArgs e)
        {
            attendenceStatus = "leave";
            dtClockIN.Checked = false;
            dtClockOUT.Checked = false;
            dtClockIN.Enabled = false;
            dtClockOUT.Enabled = false;
            //
            clockIN = "";
            clockOUT = "";
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string employeeID = txtEmployeeID.Text.Trim().ToString();
                for (int i = 0; i < dtEmployee.Rows.Count; i++)
                {
                    if (dtEmployee.Rows[i]["EmployeeID"].ToString().Trim() == employeeID)
                    {
                        cmbEmployeeName.SelectedValue = employeeID;
                        pBoxEmployee.ImageLocation = dtEmployee.Rows[i]["Picture"].ToString().Trim();
                        return;
                    }
                }


            }
        }

        private void dtClockIN_ValueChanged(object sender, EventArgs e)
        {
            clockIN = dtClockIN.Value.ToShortTimeString();
        }

        private void dtClockOUT_ValueChanged(object sender, EventArgs e)
        {
            clockOUT = dtClockOUT.Value.ToShortTimeString();
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {

            if (disableMode)
            {
                LoadDataWithSpecificDate(dtDate.Value.Date);
            }

        }

        private void dtDate_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            //{
            //    if (disableMode)
            //    {
            //        LoadDataWithSpecificDate(dtDate.Value.Date);
            //    }
            //}
        }

        private void dgvEmployeeAttendence_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name == "Date")
            {
                e.Column.HeaderText = "Attendance Date";
            }
            else if (e.Column.Name == "EmployeeName")
            {
                e.Column.HeaderText = "Employee Name";
            }
            else if (e.Column.Name == "AttendenceStatus")
            {
                e.Column.HeaderText = "Attendance Status";
            }
            else if (e.Column.Name == "ClockIN")
            {
                e.Column.HeaderText = "Clock IN";
            }
            else if (e.Column.Name == "ClockOUT")
            {
                e.Column.HeaderText = "Clock OUT";
            }
            else if (e.Column.Name == "Comments")
            {
                e.Column.HeaderText = "Comments";
            }
            else
            {
                e.Column.Visible = false;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FormControl("Clear");
            FormControl("Disable");

            LoadData();
            txtEmployeeID.Focus();

        }

        private void dtDate_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
