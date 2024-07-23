using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        string EmployeeID = "";
        string location = null;

        bool NewMode = true;
        bool EditMode = false;

        public void FormControl(string Control)
        {
            if (Control.ToLower() == "enable")
            {
                //textboxes
                txtEmployeeName.Enabled = true;
                dtHireDate.Enabled = true;
                txtJobTitle.Enabled = true;
                txtPassword.Enabled = true;
                txtConPassword.Enabled = true;

                //buttons
                btnUpload.Enabled = true;
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
            }
            else if (Control.ToLower() == "disable")
            {
                //textboxes
                txtEmployeeName.Enabled = false;
                dtHireDate.Enabled = false;
                txtJobTitle.Enabled = false;
                txtPassword.Enabled = false;
                txtConPassword.Enabled = false;

                //buttons
                btnUpload.Enabled = false;
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
            }
            else if (Control.ToLower() == "clear")
            {
                txtEmployeeName.Text = "";
                dtHireDate.Value = DateTime.Now;
                txtJobTitle.Text = "";
                txtPassword.Text = "";
                txtConPassword.Text = "";
                pBox.ImageLocation = "";

            }

        }

        public void LoadData()
        {
            string Query = "select * from Employee order by EmployeeName";
            dt = General.FetchData(Query);
            dgvSupplier.DataSource = dt;


        }
        private void frmEmployees_Load(object sender, EventArgs e)
        {
            FormControl("disable");
            LoadData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormControl("enable");
            FormControl("clear");
            NewMode = true;
            EditMode = false;
            txtEmployeeName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployeeName.Text == "")
            {
                MessageBox.Show("Enter Employee Name first ");
                txtEmployeeName.Focus();
                return;

            }
            else if (dtHireDate.Text == "")
            {
                MessageBox.Show("Enter Hire Date first ");
                dtHireDate.Focus();
                return;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show(" Please enter Password. ");
                txtPassword.Focus();
                return;
            }
            else if (txtConPassword.Text == "")
            {
                MessageBox.Show(" Please enter Confirmation Password. ");
                txtConPassword.Focus();
                return;
            }
            else if (txtConPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                MessageBox.Show("Confirmation Password incorrect");
                txtConPassword.Text = "";
                txtConPassword.Focus();
                return;
            }
            else if (txtJobTitle.Text == "")
            {
                MessageBox.Show(" Please enter Job Title ");
                txtJobTitle.Focus();
                return;
            }
            else
            {
                if (NewMode == true)
                {
                    string checkQuery = "select * from Employee where Employee.EmployeeName='" + txtEmployeeName.Text.Trim().ToString() + "' AND Employee.HireDate = '" + dtHireDate.Text.Trim().ToString() + "' AND Employee.JobTitle = '" + txtJobTitle.Text.Trim().ToString() + "'";
                    DataTable dtCheckQuery = new DataTable();
                    dtCheckQuery = General.FetchData(checkQuery);
                    if (dtCheckQuery.Rows.Count > 0)
                    {
                        MessageBox.Show("Duplicate Entries Not Allowed!", "Duplication Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //save Query
                    string Query = "Insert Into Employee(EmployeeName,HireDate,JobTitle,Picture,Password) " +
                        " values('" + txtEmployeeName.Text.Trim().ToString() + "' , '" + dtHireDate.Text.Trim().ToString() + "' , '" + txtJobTitle.Text.Trim().ToString() + "' , '" + location.Trim() + "' , '" + txtPassword.Text.Trim() + "')";
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Inserted Successfully !");

                }
                else if (EditMode == true)
                {
                    //edit Query 
                    string Query = "Update Employee set EmployeeName = '" + txtEmployeeName.Text.Trim().ToString() + "' , HireDate = '" + dtHireDate.Text.Trim().ToString() + "' ,JobTitle = '" + txtJobTitle.Text.Trim().ToString() + "' , Picture = '" + location.Trim() + "' , Password ='" + txtPassword.Text.Trim() + "'   where EmployeeID =" + EmployeeID;
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

            btnSave.Text = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete this record ?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (EmployeeID != "")
                {

                    try
                    {
                        string Query = "Delete Employee where EmployeeID =  " + EmployeeID;
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
            dgvSupplier.DataSource = dt;
        }

        public void GridToTextBox()
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                int index = dgvSupplier.SelectedRows[0].Index;

                txtEmployeeName.Text = dt.Rows[index]["EmployeeName"].ToString();
                dtHireDate.Text = dt.Rows[index]["HireDate"].ToString();
                txtJobTitle.Text = dt.Rows[index]["JobTitle"].ToString();
                txtPassword.Text = dt.Rows[index]["Password"].ToString();
                location = dt.Rows[index]["Picture"].ToString();
                if (location == "" || location == null)
                {
                    location = "";
                    pBox.ImageLocation = "";
                }
                else
                {
                    pBox.ImageLocation = location;
                }


                EmployeeID = dt.Rows[index]["EmployeeID"].ToString();
            }

        }

        private void dgvSupplier_SelectionChanged(object sender, EventArgs e)
        {
            GridToTextBox();
        }

        private void dgvSupplier_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridToTextBox();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            location = fd.FileName;
            pBox.ImageLocation = location;
        }

        private void dgvSupplier_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.ToString().Trim().ToLower() == "employeename")
            {
                e.Column.HeaderText = "Employee Name";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "jobtitle")
            {
                e.Column.HeaderText = "Job Title";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "hiredate")
            {
                e.Column.HeaderText = "Hire Date";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "password")
            {
                e.Column.HeaderText = "Password";
            }
            else
            {
                e.Column.Visible = false;
            }
        }
    }
}
