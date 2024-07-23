using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmEmployeeSalaryReport : Form
    {
        public frmEmployeeSalaryReport()
        {
            InitializeComponent();
        }

        //
       bool dtMode = false;
       bool tempDTMode = false;
        //
        DataTable dt = new DataTable();
        DataTable tempDT = new DataTable();
        DataTable month = new DataTable();
        //
        DataTable tempStatus = new DataTable();
        //
        Dictionary<int, string> monthList = new Dictionary<int, string> { { 1, "January" }, { 2, "February" }, { 3, "March" },
                                                                        { 4, "April" }, { 5, "May" }, { 6, "June" }, { 7, "July" },
                                                                        { 8, "August" }, { 9, "September" }, { 10, "October" },
                                                                        { 11, "November" }, { 12, "December" } };
        public void LoadData()
        {
            dtMode = true;
            tempDTMode = false;
            //
            string Query = "select * from EmployeeSalary inner join Employee on EmployeeSalary.EmployeeID = Employee.EmployeeID";
            dt = General.FetchData(Query);
            ////////////////////////////////
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Month";
            dt.Columns.Add(dc);
            int tempMonth = 0;
            DateTime tempobj = new DateTime();

            ////////////////////////////////
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tempobj = Convert.ToDateTime(dt.Rows[i]["Date"].ToString());
                tempMonth = tempobj.Month;
                dt.Rows[i]["Month"] = monthList[tempMonth];
            }
            dgvSalary.DataSource = dt;
        }
        private void frmEmployeeSalaryReport_Load(object sender, EventArgs e)
        {

            LoadData();
        }

        private void cmbMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            int index = cmbMonth.SelectedIndex;
            if (dtMode == true)
            {
                month = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Month"].ToString().Trim().ToLower() == monthList[index + 1].ToString().Trim().ToLower())
                    {
                        month.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                dgvSalary.DataSource = month;
            }
            else if (tempDTMode == true)
            {
                month = tempDT.Clone();
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    if (tempDT.Rows[i]["Month"].ToString().Trim().ToLower() == monthList[index + 1].ToString().Trim().ToLower())
                    {
                        month.Rows.Add(tempDT.Rows[i].ItemArray);
                    }
                }
                dgvSalary.DataSource = month;
            }
            
            chkBoxPAID.Checked = false;
            chkBoxPending.Checked = false;
        }

        private void dgvSalary_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.ToString().Trim().ToLower() == "employeename")
            {
                e.Column.HeaderText = "Employee Name";
                e.Column.DisplayIndex = 0;
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "date")
            {
                e.Column.HeaderText = "Date";
                e.Column.DisplayIndex = 1;
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "month")
            {
                e.Column.HeaderText = "Month";
                e.Column.DisplayIndex = 2;
                
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "salary")
            {
                e.Column.HeaderText = "Salary";
                e.Column.DisplayIndex = 3;
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "totalabsentees")
            {
                e.Column.HeaderText = "Total Absentees";
                e.Column.DisplayIndex = 4;
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "calculatedsalary")
            {
                e.Column.HeaderText = "Calculated Salary";
                e.Column.DisplayIndex = 5;
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "salarypaidstatus")
            {
                e.Column.HeaderText = "Salary Paid Status";
                e.Column.DisplayIndex = 6;
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void lblTodaysReport_Click(object sender, EventArgs e)
        {
            LoadData();
            cmbMonth.SelectedIndex = -1;
            chkBoxPAID.Checked = false;
            chkBoxPending.Checked = false;

        }

        private void chkBoxPAID_Click(object sender, EventArgs e)
        {
            chkBoxPAID.Checked = true;
            chkBoxPending.Checked = false;
            if (cmbMonth.SelectedIndex != -1)
            {
                tempStatus = month.Clone();
                //compare with dt from search
                for (int i = 0; i < month.Rows.Count; i++)
                {
                    if (month.Rows[i]["SalaryPaidStatus"].ToString().Trim().ToLower() == "paid")
                    {
                        tempStatus.Rows.Add(month.Rows[i].ItemArray);
                    }
                }
                dgvSalary.DataSource = tempStatus;
            }
            else if (dtMode == true)
            {
                tempStatus = dt.Clone();
                //compare with tempDT from combobox selected
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["SalaryPaidStatus"].ToString().Trim().ToLower() == "paid")
                    {
                        tempStatus.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                dgvSalary.DataSource = tempStatus;
            }
            else if(tempDTMode == true)
            {
                tempStatus = tempDT.Clone();
                //compare with dt from search
                for (int i = 0; i < tempDT.Rows.Count; i++)
                    {
                        if (tempDT.Rows[i]["SalaryPaidStatus"].ToString().Trim().ToLower() == "paid")
                        {
                             tempStatus.Rows.Add(tempDT.Rows[i].ItemArray);
                        }
                    }
                    dgvSalary.DataSource = tempStatus;  
            }
            
        }

        private void chkBoxPending_Click(object sender, EventArgs e)
        {
            //
            chkBoxPAID.Checked = false;
            chkBoxPending.Checked = true;
            //
            if (cmbMonth.SelectedIndex != -1)
            {
                tempStatus = month.Clone();
                //compare with tempDT from combobox selected
                for (int i = 0; i < month.Rows.Count; i++)
                {
                    if (month.Rows[i]["SalaryPaidStatus"].ToString().Trim().ToLower() == "pending")
                    {
                        tempStatus.Rows.Add(month.Rows[i].ItemArray);
                    }
                }
                dgvSalary.DataSource = tempStatus;
            }
            else if (dtMode == true)   
            {
                tempStatus = dt.Clone();
                //compare with dt from loadevent
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["SalaryPaidStatus"].ToString().Trim().ToLower() == "pending")
                    {
                        tempStatus.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                dgvSalary.DataSource = tempStatus;
            }
            else if (tempDTMode == true)
            {
                tempStatus = tempDT.Clone();
                //compare with dt from loadevent
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    if (tempDT.Rows[i]["SalaryPaidStatus"].ToString().Trim().ToLower() == "pending")
                    {
                        tempStatus.Rows.Add(tempDT.Rows[i].ItemArray);
                    }
                }
                dgvSalary.DataSource = tempStatus;

            }

        }
        public void LoadDataBetweenDates()
        {
            tempDTMode = true;
            dtMode = false;
            try
            {
                string Query = "select * from EmployeeSalary inner join Employee on EmployeeSalary.EmployeeID = Employee.EmployeeID where EmployeeSalary.Date between" +
               "   '" + dtFromDate.Text.ToString().Trim() + "' and '" + dtToDate.Text.ToString().Trim() + "' ";
                tempDT = General.FetchData(Query);
                ////////////////////////////////
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Month";
                tempDT.Columns.Add(dc);
                int tempMonth = 0;
                DateTime tempobj = new DateTime();

                ////////////////////////////////
                for (int i = 0; i < tempDT.Rows.Count; i++)
                {
                    tempobj = Convert.ToDateTime(tempDT.Rows[i]["Date"].ToString());
                    tempMonth = tempobj.Month;
                    tempDT.Rows[i]["Month"] = monthList[tempMonth];
                }
                cmbMonth.SelectedIndex = -1;
                dgvSalary.DataSource = tempDT;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataBetweenDates();
            cmbMonth.SelectedIndex = -1;
            chkBoxPAID.Checked = false;
            chkBoxPending.Checked = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //LoadData();
            dgvSalary.DataSource = "";
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            cmbMonth.SelectedIndex = -1;
            chkBoxPAID.Checked = false;
            chkBoxPending.Checked = false;
        }
    }
}
