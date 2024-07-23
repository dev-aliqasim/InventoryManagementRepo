using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmEmployeesSalary : Form
    {
        public frmEmployeesSalary()
        {
            InitializeComponent();
        }

        DataTable dtEmployee = new DataTable();
        DataTable dt = new DataTable();

        string SalaryID = "";
        string EmployeeID = "";

        bool NewMode = true;
        bool EditMode = false;
        string SalaryPaidStatus = "";

        Dictionary<int, string> monthList = new Dictionary<int, string> { { 1, "January" }, { 2, "February" }, { 3, "March" }, { 4, "April" }, { 5, "May" }, { 6, "June" }, { 7, "July" }, { 8, "August" }, { 9, "September" }, { 10, "October" }, { 11, "November" }, { 12, "December" } };
        

        public void FormControl(string Control)
        {
            if (Control.ToLower() == "enable")
            {
                //textboxes
                txtEmployeeID.Enabled = false;
                dtDate.Enabled = true;
                cmbEmployeeName.Enabled = true;
                txtEmployeeSalary.Enabled = true;
                {
                    radiobtnPaid.Enabled = true;
                    radiobtnPending.Enabled = true;
                }
                txtTotalAbsentees.Enabled = true;
                txtCalculatedSalary.Enabled = true;
                //group-box
                txtAbsenteesGreaterThan.Enabled = true;
                txtAmountToDeduct.Enabled = true;

                //buttons
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
            }
            else if (Control.ToLower() == "disable")
            {
                //textboxes
                txtEmployeeID.Enabled = false;
                dtDate.Enabled = false;
                cmbEmployeeName.Enabled = false;
                txtEmployeeSalary.Enabled = false;
                {
                    radiobtnPaid.Enabled = false;
                    radiobtnPending.Enabled = false;
                }
                txtTotalAbsentees.Enabled = false;
                txtCalculatedSalary.Enabled = false;
                //group-box
                txtAbsenteesGreaterThan.Enabled = false;
                txtAmountToDeduct.Enabled = false;

                //buttons
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
            }
            else if (Control.ToLower() == "clear")
            {
                txtEmployeeID.Text = "";
                dtDate.Value = DateTime.Now;
                cmbEmployeeName.SelectedIndex = -1;
                txtEmployeeSalary.Text = "";
                {
                    radiobtnPaid.Checked = false;
                    radiobtnPending.Checked = false;
                }
                txtTotalAbsentees.Text = "";
                txtCalculatedSalary.Text = "";
                //
                txtAbsenteesGreaterThan.Text = "";
                txtAmountToDeduct.Text = "";

            }

        }

        public void LoadEmployee()
        {
            string Query = "select * from Employee ";
            dtEmployee = General.FetchData(Query);
            cmbEmployeeName.DataSource = dtEmployee;
            cmbEmployeeName.DisplayMember = dtEmployee.Columns["EmployeeName"].ToString();
            cmbEmployeeName.ValueMember = dtEmployee.Columns["EmployeeID"].ToString();
            cmbEmployeeName.SelectedIndex = -1; 
        }
        public void LoadData()
        {
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
                dt.Rows[i]["Month"] = monthList[tempMonth] ;
            }
            dgvEmployeeSalary.DataSource = dt;

        }


        private void frmEmployeesSalary_Load(object sender, EventArgs e)
        {
            FormControl("disable");
            LoadEmployee();
            LoadData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormControl("enable");
            FormControl("clear");
            NewMode = true;
            EditMode = false;
        }

        bool validNumber(string value)
        {
            return Regex.Match(value, @"^(0*[1-9]\d{0,15}|0+)(\.\d\d)?$").Success;
        }

        bool validInt(string value)
        {
            return Regex.Match(value, @"^\d+$").Success;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbEmployeeName.SelectedIndex == -1)
            {
                MessageBox.Show("Select Employee Name first ");
                cmbEmployeeName.Focus();
                return;

            }
            else if (txtEmployeeSalary.Text == "")
            {
                MessageBox.Show("Enter Employee Salary first ");
                txtEmployeeSalary.Focus();
                return;
            }
            else if(!validNumber(txtEmployeeSalary.Text))
            {
                MessageBox.Show("Enter valid Salary amount ");
                txtEmployeeSalary.Focus();
                return;
            }
            else if (SalaryPaidStatus == "")
            {
                MessageBox.Show(" Please Select Salary Paid Status ");
                radiobtnPaid.Focus();
                return;
            }
            else if (txtTotalAbsentees.Text == "")
            {
                MessageBox.Show("Enter Absentees first");
                txtTotalAbsentees.Focus();
                return;
            }
            else if (!validNumber(txtTotalAbsentees.Text))
            {
                MessageBox.Show("Enter valid absentees number");
                txtTotalAbsentees.Focus();
                return;
            }
            else
            {
                if (NewMode == true)
                {
                    //save Query
                    string Query = "Insert into EmployeeSalary(EmployeeID,Date,Salary,TotalAbsentees,CalculatedSalary,SalaryPaidStatus) " +
                        "  values('"+EmployeeID.ToString() +"' , '"+ dtDate.Text.Trim().ToString()+ "' , '" + txtEmployeeSalary.Text.Trim().ToString() + "' , " +
                        " '" + txtTotalAbsentees.Text.Trim().ToString() + "' , '" + txtCalculatedSalary.Text.Trim().ToString() + "' , '"+SalaryPaidStatus.ToString()+"'  ) ";
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Inserted Successfully !");

                }
                else if (EditMode == true)
                {
                    //edit Query 
                    string Query = "Update EmployeeSalary set EmployeeID = '" + EmployeeID.ToString() + "' , Date =  '" + dtDate.Text.Trim().ToString() + "' , Salary = '" + txtEmployeeSalary.Text.Trim().ToString() + "' " +
                        "  , TotalAbsentees = '" + txtTotalAbsentees.Text.Trim().ToString() + "' , CalculatedSalary =  '" + txtCalculatedSalary.Text.Trim().ToString() + "' ,  SalaryPaidStatus = '" + SalaryPaidStatus.ToString() + "' where SalaryID =" + SalaryID;
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Updated");
                    btnSave.Text = "Save";
                }
                LoadData();
                FormControl("disable");
                btnNew.Focus();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormControl("enable");
            NewMode = false;
            EditMode = true;

            txtAbsenteesGreaterThan.Text = "";
            txtAmountToDeduct.Text = "";

            btnSave.Text = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete this record ?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (SalaryID != "")
                {

                    try
                    {
                        string Query = "Delete EmployeeSalary where SalaryID =  " + SalaryID;
                        General.ExecuteNonQuery(Query);
                        MessageBox.Show("Record Deleted");
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
           
                if (dgvEmployeeSalary.SelectedRows.Count > 0)
                {
                    int index = dgvEmployeeSalary.SelectedRows[0].Index;
                    
                    EmployeeID = dt.Rows[index]["EmployeeID"].ToString();
                    txtEmployeeID.Text = dt.Rows[index]["EmployeeID"].ToString();
                    dtDate.Text = dt.Rows[index]["Date"].ToString(); 
                    cmbEmployeeName.SelectedValue = dt.Rows[index]["EmployeeID"].ToString();
                    txtEmployeeSalary.Text = dt.Rows[index]["Salary"].ToString();
                    if (dt.Rows[index]["SalaryPaidStatus"].ToString().ToLower() == "paid")
                    {
                        radiobtnPaid.Checked = true;
                        radiobtnPending.Checked = false;
                    }
                    else
                    {
                        radiobtnPaid.Checked = false;
                        radiobtnPending.Checked = true;
                    }
                    txtTotalAbsentees.Text = dt.Rows[index]["TotalAbsentees"].ToString();
                    txtCalculatedSalary.Text = dt.Rows[index]["CalculatedSalary"].ToString();

                     SalaryID = dt.Rows[index]["SalaryID"].ToString();
                }

            

        }
        private void dgvEmployeeSalary_SelectionChanged(object sender, EventArgs e)
        {
            GridToTextBox();
        }

        private void dgvEmployeeSalary_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridToTextBox();
        }

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EmployeeID = cmbEmployeeName.SelectedValue.ToString();
            txtEmployeeID.Text = EmployeeID.ToString();
        }

        private void radiobtnPaid_CheckedChanged(object sender, EventArgs e)
        {
            SalaryPaidStatus = "Paid";
        }

        private void radiobtnPending_CheckedChanged(object sender, EventArgs e)
        {
            SalaryPaidStatus = "Pending";
        }

        public void CalculateSalary()
        {
            if (txtTotalAbsentees.Text.ToString() != "")
            {
                int absentees = int.Parse(txtTotalAbsentees.Text.ToString());
                float salary = 0;
                int AbsenteesInFormulaOfGroupBox = 0;
                float deduct = 0;

                if (txtEmployeeSalary.Text.ToString() != "") //not equal to empty
                {
                    salary = float.Parse(txtEmployeeSalary.Text.ToString());
                }
                //getting valid absentees
                if (txtAbsenteesGreaterThan.Text.ToString().Trim() == "" || txtAbsenteesGreaterThan.Text.ToString().Trim() == null)
                {
                    AbsenteesInFormulaOfGroupBox = 0;
                }
                else
                {
                    AbsenteesInFormulaOfGroupBox = int.Parse(txtAbsenteesGreaterThan.Text.ToString().Trim());

                }
                //getting valid deduct amount
                if (txtAmountToDeduct.Text.ToString().Trim() == "" || txtAmountToDeduct.Text.ToString().Trim() == null)
                {
                    deduct = 0;
                }
                else
                {
                    deduct = int.Parse(txtAmountToDeduct.Text.ToString().Trim());

                }
                
                if (absentees > AbsenteesInFormulaOfGroupBox)
                {
                    float newSalary = salary - ((absentees - AbsenteesInFormulaOfGroupBox) * deduct);
                    if (newSalary >= 0)
                    {
                        txtCalculatedSalary.Text = (newSalary).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Calculated Salary is less than Zero.");
                        txtTotalAbsentees.Text = "";
                        return;
                    }
                }
                else
                {
                    txtCalculatedSalary.Text = txtEmployeeSalary.Text;
                    return;
                }
            }
            else
            {
                txtCalculatedSalary.Text = txtEmployeeSalary.Text;
                return;
            }
        }
        private void txtTotalAbsentees_TextChanged(object sender, EventArgs e)
        {
            //if(txtTotalAbsentees.Text.Length <=0)
            //{
            //    return;
            //}
            //else
            //{
            //    if (!validInt(txtTotalAbsentees.Text))
            //    {
            //        MessageBox.Show("Invalid number entered");
            //        txtTotalAbsentees.Focus();
            //        return;
            //    }
            //    CalculateSalary();
            //}
        }

        private void txtEmployeeSalary_TextChanged(object sender, EventArgs e)
        {
            //if (txtEmployeeSalary.Text.Length <= 0)
            //{
            //    return;
            //}
            //else
            //{
            //    if (!validNumber(txtEmployeeSalary.Text))
            //    {
            //        MessageBox.Show("Invalid number entered");
            //        txtEmployeeSalary.Focus();
            //        return;
            //    }
            //    CalculateSalary();
            //}
        }

        private void txtAbsenteesGreaterThan_TextChanged(object sender, EventArgs e)
        {
            //if (txtAbsenteesGreaterThan.Text.Length <= 0)
            //{
            //    return;
            //}
            //else
            //{
            //    if (!validNumber(txtAbsenteesGreaterThan.Text))
            //    {
            //        MessageBox.Show("Invalid number entered");
            //        txtAbsenteesGreaterThan.Focus();
            //        return;
            //    }
            //    CalculateSalary();
            //}
        }

        private void txtAmountToDeduct_TextChanged(object sender, EventArgs e)
        {
            //if (txtAmountToDeduct.Text.Length <= 0)
            //{
            //    return;
            //}
            //else
            //{
            //    if (!validNumber(txtAmountToDeduct.Text))
            //    {
            //        MessageBox.Show("Invalid number entered");
            //        txtAmountToDeduct.Focus();
            //        return;
            //    }
            //    CalculateSalary();
            //}
        }

        private void dgvEmployeeSalary_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
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

        private void txtEmployeeSalary_Leave(object sender, EventArgs e)
        {
            if (txtEmployeeSalary.Text.Length <= 0)
            {
                return;
            }
            else
            {
                if (!validNumber(txtEmployeeSalary.Text))
                {
                    MessageBox.Show("Invalid number entered");
                    txtEmployeeSalary.Text = "";
                    txtEmployeeSalary.Focus();
                    return;
                }
                CalculateSalary();
            }
        }

        private void txtTotalAbsentees_Leave(object sender, EventArgs e)
        {
            if (txtTotalAbsentees.Text.Length <= 0)
            {
                return;
            }
            else
            {
                if (!validInt(txtTotalAbsentees.Text))
                {
                    MessageBox.Show("Invalid number entered");
                    txtTotalAbsentees.Text = "";
                    txtTotalAbsentees.Focus();
                    return;
                }
                CalculateSalary();
            }
        }

        private void txtAbsenteesGreaterThan_Leave(object sender, EventArgs e)
        {
            if (txtAbsenteesGreaterThan.Text.Length <= 0)
            {
                return;
            }
            else
            {
                if (!validInt(txtAbsenteesGreaterThan.Text))
                {
                    MessageBox.Show("Invalid number entered");
                    txtAbsenteesGreaterThan.Text = "";
                    txtAbsenteesGreaterThan.Focus();
                    return;
                }
                CalculateSalary();
            }
        }

        private void txtAmountToDeduct_Leave(object sender, EventArgs e)
        {
            if (txtAmountToDeduct.Text.Length <= 0)
            {
                return;
            }
            else
            {
                if (!validNumber(txtAmountToDeduct.Text))
                {
                    MessageBox.Show("Invalid number entered");
                    txtAmountToDeduct.Text = "";
                    txtAmountToDeduct.Focus();
                    return;
                }
                CalculateSalary();
            }
        }
    }
}
