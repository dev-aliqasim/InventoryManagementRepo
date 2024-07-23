using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmAttendenceReport : Form
    {
        public frmAttendenceReport()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        DataTable dtTemp = new DataTable();
     
        public void OrderDGVColumns()
        {
            dgvAttendence.Columns["Date"].DisplayIndex = 0;
            dgvAttendence.Columns["EmployeeName"].DisplayIndex = 1;
            dgvAttendence.Columns["AttendenceStatus"].DisplayIndex = 2;
            dgvAttendence.Columns["ClockIN"].DisplayIndex = 3;
            dgvAttendence.Columns["ClockOUT"].DisplayIndex = 4;
            dgvAttendence.Columns["Comments"].DisplayIndex = 5;
        }
        public void LoadData()
        {
            string query = "select * from EmployeeAttendence inner join Employee on EmployeeAttendence.EmployeeID = Employee.EmployeeID where EmployeeAttendence.Date ='" + DateTime.Now + "' ";
            dt = General.FetchData(query);
            dgvAttendence.DataSource = dt;
            OrderDGVColumns();

        }
        private void LoadEmployee()
        {
            string query = "select * from Employee";
            DataTable dtEmployee = new DataTable();
            dtEmployee = General.FetchData(query);
            cmbEmployee.DataSource = dtEmployee;
            cmbEmployee.DisplayMember = dtEmployee.Columns["EmployeeName"].ToString();
            cmbEmployee.ValueMember = dtEmployee.Columns["EmployeeID"].ToString();
            cmbEmployee.SelectedIndex = -1;
        }
        private void frmAttendenceReport_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadEmployee();
        }

        private void cmbMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //int month = int.Parse(cmbMonth.SelectedIndex.ToString()) + 1;
            //int year = DateTime.Now.Year;
            //int daysinmonth = DateTime.DaysInMonth(year,month);
            //string fromDate = "  "+year+ "  -  " + month + " - 01     ";
            //string toDate = "  " + year + "  -  " + month + " - "+daysinmonth+"  ";

            //try
            //{
            //    string query = "select * from Attendence inner join Employee on Attendence.EmployeeID = Employee.EmployeeID where Attendence.DateTime between '" + fromDate + "' AND '" + toDate + "' ";
            //    dt = General.FetchData(query);
            //    dgvAttendence.DataSource = dt;
            //    OrderDGVColumns();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}

            ////
            //chkBoxPresent.Checked = false;
            //chkBoxAbsent.Checked = false;
            //chkBoxLeave.Checked = false;

        }

        private void chkBoxPresent_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkBoxAbsent_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkBoxLeave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkBoxLeave_Click(object sender, EventArgs e)
        {
            chkBoxPresent.Checked = false;
            chkBoxAbsent.Checked = false;
            chkBoxLeave.Checked = true;
            FilterBy("leave");
        }

        private void chkBoxAbsent_Click(object sender, EventArgs e)
        {
            chkBoxPresent.Checked = false;
            chkBoxAbsent.Checked = true;
            chkBoxLeave.Checked = false;
            FilterBy("absent");
        }

        private void chkBoxPresent_Click(object sender, EventArgs e)
        {
            chkBoxPresent.Checked = true;
            chkBoxAbsent.Checked = false;
            chkBoxLeave.Checked = false;
            FilterBy("present");

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //LoadData();
            //cmbMonth.SelectedIndex = -1;
            //chkBoxPresent.Checked = false;
            //chkBoxAbsent.Checked = false;
            //chkBoxLeave.Checked = false;
        }

        private void dgvAttendence_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.ToString().Trim().ToLower() == "date")
            {
                e.Column.HeaderText = "Date";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "employeename")
            {
                e.Column.HeaderText = "Employee Name";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "attendencestatus")
            {
                e.Column.HeaderText = "Status";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "clockin")
            {
                e.Column.HeaderText = "Clock IN";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "clockout")
            {
                e.Column.HeaderText = "Clock OUT";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "comments")
            {
                e.Column.HeaderText = "Remarks";
            }
            else
            {
                e.Column.Visible = false;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = "select * from EmployeeAttendence inner join Employee on EmployeeAttendence.EmployeeID = Employee.EmployeeID where EmployeeAttendence.Date between '" + dtFromDate.Value.ToString() + "' and '" + dtToDate.Value.ToString() + "' ";
            dt = General.FetchData(query);
            dgvAttendence.DataSource = dt;
            OrderDGVColumns();

            chkBoxPresent.Checked = false;
            chkBoxAbsent.Checked = false;
            chkBoxLeave.Checked = false;


            dtpYear.Value = DateTime.Now;
            dtpMonth.Value = DateTime.Now;
            cmbEmployee.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvAttendence.DataSource = "";
            LoadData();
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            dtpYear.Value = DateTime.Now;
            dtpMonth.Value = DateTime.Now;
            cmbEmployee.SelectedIndex = -1;
            chkBoxPresent.Checked = false;
            chkBoxAbsent.Checked = false;
            chkBoxLeave.Checked = false;


        }

        private void applyFilter()
        {
            int year = dtpYear.Value.Year;
            int month = dtpMonth.Value.Month;
            int daysinmonth = DateTime.DaysInMonth(year, month);
            string fromDate = "  " + year + "  -  " + month + " - 01     ";
            string toDate = "  " + year + "  -  " + month + " - " + daysinmonth + "  ";
            if (cmbEmployee.SelectedIndex == -1)
            {
                try
                {
                    string query = "select * from EmployeeAttendence inner join Employee on EmployeeAttendence.EmployeeID = Employee.EmployeeID where EmployeeAttendence.Date between '" + fromDate + "' AND '" + toDate + "' ";
                    dt = General.FetchData(query);
                    dgvAttendence.DataSource = dt;
                    OrderDGVColumns();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                try
                {
                    string query = "select * from EmployeeAttendence inner join Employee on EmployeeAttendence.EmployeeID = Employee.EmployeeID where EmployeeAttendence.Date between '" + fromDate + "' AND '" + toDate + "' AND Employee.EmployeeID = " + cmbEmployee.SelectedValue.ToString();
                    dt = General.FetchData(query);
                    dgvAttendence.DataSource = dt;
                    OrderDGVColumns();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            applyFilter();
        }

        private void btnEmployeeReset_Click(object sender, EventArgs e)
        {
            cmbEmployee.SelectedIndex = -1;
            applyFilter();

        }

        private void FilterBy(string status)
        {
            dtTemp = dt.Clone();
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["AttendenceStatus"].ToString().ToLower() == status)
                {
                    dtTemp.Rows.Add(dt.Rows[i].ItemArray);
                }
            }
            dgvAttendence.DataSource = "";
            dgvAttendence.DataSource = dtTemp;
            OrderDGVColumns();
        }

        private void chkBoxPresent_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void chkBoxAbsent_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void chkBoxLeave_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
