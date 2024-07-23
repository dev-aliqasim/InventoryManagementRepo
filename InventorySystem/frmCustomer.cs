using PickAndChooseGroceryStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        string CustomerID = "";

        bool NewMode = true;
        bool EditMode = false;

        public void FormControl(string Control)
        {
            if (Control.ToLower() == "enable")
            {
                //textboxes
                txtName.Enabled = true;
                txtPhoneNo.Enabled = true;
                txtName.Enabled = true;
                txtEmail.Enabled = true;
                txtCNIC.Enabled = true;
                txtAddress.Enabled = true;


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
                txtName.Enabled = false;
                txtPhoneNo.Enabled = false;
                txtName.Enabled = false;
                txtEmail.Enabled = false;
                txtCNIC.Enabled = false;
                txtAddress.Enabled = false;

                //buttons
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
            }
            else if (Control.ToLower() == "clear")
            {
                txtName.Text = "";
                txtPhoneNo.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";
                txtCNIC.Text = "";
                txtAddress.Text = "";
                dgvCustomer.DataSource = "";

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            string Query = "select * from Customer order by CustomerName";
            dt = General.FetchData(Query);
            dgvCustomer.DataSource = dt;

        }

        private void frmCustomer_Load(object sender, EventArgs e)
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
            txtName.Focus();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormControl("enable");
            NewMode = false;
            EditMode = true;

            btnSave.Text = "Update";
        }

        bool validPhoneNo(string phoneNo)
        {
            return Regex.Match(phoneNo, @"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$").Success;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Enter Name first ");
                txtName.Focus();
                return;

            }
            else if (txtPhoneNo.Text == "")
            {
                MessageBox.Show("Enter Phone No. please ");
                txtPhoneNo.Focus();
                return;
            }
            else if (!validPhoneNo(txtPhoneNo.Text))
            {
                MessageBox.Show("Enter Valid Phone No. ");
                txtPhoneNo.Focus();
                return;
            }
            else if (txtCNIC.Text == "")
            {
                MessageBox.Show("Enter CNIC please ");
                txtCNIC.Focus();
                return;
            }
            else
            {
                if (NewMode == true)
                {
                    //save Query
                    string Query = " Insert Into Customer(CustomerName,CustomerPhoneNo,CustomerEmail,CustomerCNIC,CustomerAddress) " +
                        " Values( '" + txtName.Text.Trim().ToString() + "' , '" + txtPhoneNo.Text.Trim().ToString() + "'  , '" + txtEmail.Text.Trim().ToString() + "' , '" + txtCNIC.Text.Trim().ToString() + "' , '" + txtAddress.Text.Trim().ToString() + "')";
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Inserted Successfully !");

                }
                else if (EditMode == true)
                {
                    //edit Query 
                    string Query = "Update Customer set CustomerName ='" + txtName.Text.Trim().ToString() + "' , CustomerPhoneNo ='" + txtPhoneNo.Text.Trim().ToString() + "' ,CustomerEmail ='" + txtEmail.Text.Trim().ToString() + "' ,CustomerCNIC ='" + txtCNIC.Text.Trim().ToString() + "', CustomerAddress ='" + txtAddress.Text.Trim().ToString() + "' where CustomerID =" + CustomerID;
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Updated");
                    btnSave.Text = "Save";

                }
                LoadData();
                FormControl("disable");
                btnNew.Focus();
            }
        }

        public void GridToTextBox()
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                int index = dgvCustomer.SelectedRows[0].Index;

                txtName.Text = dt.Rows[index]["CustomerName"].ToString();
                txtEmail.Text = dt.Rows[index]["CustomerEmail"].ToString();
                txtPhoneNo.Text = dt.Rows[index]["CustomerPhoneNo"].ToString();
                txtCNIC.Text = dt.Rows[index]["CustomerCNIC"].ToString();
                txtAddress.Text = dt.Rows[index]["CustomerAddress"].ToString();

                CustomerID = dt.Rows[index]["CustomerID"].ToString();
            }

        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            GridToTextBox();
        }

        private void dgvCustomer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridToTextBox();
        }

        private void dgvCustomer_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name == "CustomerName")
            {
                e.Column.HeaderText = "Name";
            }
            else if (e.Column.Name == "CustomerEmail")
            {
                e.Column.HeaderText = "Email";
            }
            else if (e.Column.Name == "CustomerPhoneNo")
            {
                e.Column.HeaderText = "Phone No.";
            }
            else if (e.Column.Name == "CustomerCNIC")
            {
                e.Column.HeaderText = "CNIC";
            }
            else if (e.Column.Name == "CustomerAddress")
            {
                e.Column.HeaderText = "Address";
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete this record ?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CustomerID != "")
                {

                    try
                    {
                        string Query = "Delete Customer where CustomerID =  " + CustomerID;
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
    }
}
