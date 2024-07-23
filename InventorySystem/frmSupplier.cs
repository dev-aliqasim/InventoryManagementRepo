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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        string SupplierID = "";

        bool NewMode = true;
        bool EditMode = false;

        public void FormControl(string Control)
        {
            if (Control.ToLower() == "enable")
            {
                //textboxes
                txtSupplierName.Enabled = true;
                txtPhoneNo.Enabled = true;
                txtCompanyName.Enabled = true;
                txtSupplierEmail.Enabled = true;
                txtSupplierAddress.Enabled = true;


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
                txtSupplierName.Enabled = false;
                txtPhoneNo.Enabled = false;
                txtCompanyName.Enabled = false;
                txtSupplierEmail.Enabled = false;
                txtSupplierAddress.Enabled = false;

                //buttons
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
            }
            else if (Control.ToLower() == "clear")
            {
                txtSupplierName.Text = "";
                txtPhoneNo.Text = "";
                txtCompanyName.Text = "";
                txtSupplierEmail.Text = "";
                txtSupplierAddress.Text = "";
                dgvSupplier.DataSource = "";

            }

        }

        public void LoadData()
        {
            string Query = "select * from Supplier order by SupplierName";
            dt = General.FetchData(Query);
            dgvSupplier.DataSource = dt;

        }
        private void frmSupplier_Load(object sender, EventArgs e)
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
        }

        bool validPhoneNo(string phoneNo)
        {
            return Regex.Match(phoneNo, @"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$").Success;
        }

        bool validEmail(string email)
        {
            return Regex.Match(email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").Success;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ( txtCompanyName.Text == "")
            {
                MessageBox.Show("Enter Company Name first ");
                txtCompanyName.Focus();
                return;

            }
            else if (txtSupplierName.Text == "")
            {
                MessageBox.Show("Enter Supplier Name first ");
                txtSupplierName.Focus();
                return;
            }
            else if (txtPhoneNo.Text == "")
            {
                MessageBox.Show("Enter Phone No. please ");
                txtPhoneNo.Focus();
                return;
            }
            else if(!validPhoneNo(txtPhoneNo.Text))
            {
                MessageBox.Show("Enter Valid Phone No. ");
                txtPhoneNo.Focus();
                return;
            }
            else if (txtSupplierEmail.Text == "")
            {
                MessageBox.Show("Enter valid Email Address ");
                txtSupplierEmail.Focus();
                return;
            }
            else if (!validEmail(txtSupplierEmail.Text))
            {
                MessageBox.Show("Enter Valid email address ");
                txtSupplierEmail.Focus();
                return;
            }
            else
            {
                if (NewMode == true)
                {
                    //save Query
                    string Query = " Insert Into Supplier(SupplierName,SupplierAddress,SupplierPhoneNo,SupplierCompanyName,SupplierEmail) " +
                        " Values( '"+ txtSupplierName.Text.Trim().ToString()+ "' , '" + txtSupplierAddress.Text.Trim().ToString() + "'  , '" + txtPhoneNo.Text.Trim().ToString() + "' , '" + txtCompanyName.Text.Trim().ToString() + "' , '" + txtSupplierEmail.Text.Trim().ToString() + "')";
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Inserted Successfully !");
                    
                }
                else if (EditMode == true)
                {
                    //edit Query 
                    string Query = "Update Supplier set SupplierName ='" + txtSupplierName.Text.Trim().ToString() + "' , SupplierAddress ='" + txtSupplierAddress.Text.Trim().ToString() + "' ,SupplierPhoneNo ='" + txtPhoneNo.Text.Trim().ToString() + "' ,SupplierCompanyName ='" + txtCompanyName.Text.Trim().ToString() + "', SupplierEmail ='" + txtSupplierEmail.Text.Trim().ToString() + "' where SupplierId =" + SupplierID;
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
                if (SupplierID != "")
                {

                    try
                    {
                        string Query = "Delete Supplier where SupplierId =  " + SupplierID;
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
            LoadData();
        }

        public void GridToTextBox()
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                int index = dgvSupplier.SelectedRows[0].Index;

                txtSupplierName.Text = dt.Rows[index]["SupplierName"].ToString();
                txtPhoneNo.Text = dt.Rows[index]["SupplierPhoneNo"].ToString();
                txtCompanyName.Text = dt.Rows[index]["SupplierCompanyName"].ToString();
                txtSupplierEmail.Text = dt.Rows[index]["SupplierEmail"].ToString();
                txtSupplierAddress.Text = dt.Rows[index]["SupplierAddress"].ToString();

                SupplierID = dt.Rows[index]["SupplierID"].ToString();
            }

        }
        private void dgvSupplier_SelectionChanged(object sender, EventArgs e)
        {
            GridToTextBox();
        }

        private void dgvSupplier_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridToTextBox();
        }

        private void dgvSupplier_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name == "SupplierName")
            {
                e.Column.HeaderText = "Supplier Name";
            }
            else if (e.Column.Name == "SupplierEmail")
            {
                e.Column.HeaderText = "Email";
            }
            else if (e.Column.Name == "SupplierPhoneNo")
            {
                e.Column.HeaderText = "Phone No.";
            }
            else if (e.Column.Name == "SupplierCompanyName")
            {
                e.Column.HeaderText = "Company Name";
            }
            else if (e.Column.Name == "SupplierAddress")
            {
                e.Column.HeaderText = "Address";
            }
            else
            {
                e.Column.Visible = false;
            }
        }
    }
}
