using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmManageLogins : Form
    {
        public frmManageLogins()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        string LoginID = null;
        string TypeID = null;
        string location = null;

        bool NewMode = true;
        bool EditMode = false;

        public void FormControl(string Control)
        {
            if (Control.ToLower() == "enable")
            {
                //textboxes
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
                txtConPassword.Enabled = true;
                cmbUserType.Enabled = true;
                picBox.Enabled = true;

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
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                txtConPassword.Enabled = false;
                cmbUserType.Enabled = false;
                picBox.Enabled = false;

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
                picBox.ImageLocation = "";
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtConPassword.Text = "";
                cmbUserType.SelectedIndex = -1;
                dgvLogins.DataSource = "";

            }

        }
        public void LoadData()
        {
            string Query = "select * from Login inner join LoginType on Login.TypeID = LoginType.TypeID";
            dt = General.FetchData(Query);
            dgvLogins.DataSource = dt;

        }
        private void frmDashboard_ManageLogins_Load(object sender, EventArgs e)
        {
            FormControl("disable");
            LoadData();
        }

        public void GridToTextBox()
        {
            if (dgvLogins.SelectedRows.Count > 0)
            {
                int index = dgvLogins.SelectedRows[0].Index;

                txtUserName.Text = dt.Rows[index]["UserName"].ToString();
                txtPassword.Text = dt.Rows[index]["Password"].ToString();
                txtConPassword.Text = "";
                TypeID = dt.Rows[index]["TypeID"].ToString();
                cmbUserType.SelectedIndex = int.Parse(TypeID) - 1;
                location = dt.Rows[index]["Picture"].ToString();
                if (location == "" || location == null)
                {
                    location = "";
                    picBox.ImageLocation = "";
                }
                else
                {
                    picBox.ImageLocation = location;
                }
               

                LoginID = dt.Rows[index]["LoginID"].ToString();
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormControl("enable");
            FormControl("clear");
            NewMode = true;
            EditMode = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Enter User Name first ");
                txtUserName.Focus();
                return;

            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter password ");
                txtPassword.Focus();
                return;
            }
            else if (txtConPassword.Text == "")
            {
                MessageBox.Show("Enter Confirmation Password.");
                txtConPassword.Focus();
                return;
            }
            else if (txtConPassword.Text.Trim() != txtPassword.Text.Trim() )
            {
                MessageBox.Show("Password does not match");
                txtConPassword.Text = "";
                txtConPassword.Focus();
                return;
            }
            else if (cmbUserType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a User Type");
                cmbUserType.Focus();
                return;
            }
            else if (location == "" || location == null)
            {
                location = @"C:\Users\Ali\source\repos\InventorySystem\InventorySystem\Resources\employee_account_business_time_clock_icon_124657.ico";
            }
            else
            {
                

                if (NewMode == true)
                {
                    //save Query
                    string Query = "insert into Login(UserName,TypeID,Password,Picture)" +
                        " values('"+txtUserName.Text.Trim()+"' ,'"+TypeID.Trim()+"' , '"+txtPassword.Text.Trim()+"' , '"+location.Trim()+"' )";
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Inserted Successfully !");

                }
                else if (EditMode == true)
                {
                    //checking accidental lockdown of admin account
                    string checkQuery = "Select count(TypeID) as Admins from Login where TypeID = '1' ";
                    DataTable dtCheck = new DataTable();
                    dtCheck = General.FetchData(checkQuery);
                    //
                    var currentTypeID = "";
                    if (dgvLogins.SelectedRows.Count > 0)
                    {
                        int index = dgvLogins.SelectedRows[0].Index;
                        currentTypeID = dt.Rows[index]["TypeID"].ToString();

                    }
                    //

                    if (dtCheck.Rows[0]["Admins"].ToString().Trim() == "1" && currentTypeID == "1" )
                    {
                        MessageBox.Show("Operation Failed!\nThere must be atleast `2` Admin Account","Warning" , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //edit Query 
                    string Query = "Update Login set UserName = '" + txtUserName.Text.Trim() + "' , TypeID = '" + TypeID.Trim() + "' ,Password = '" + txtPassword.Text.Trim() + "' , Picture = '" + location.Trim() + "'  where LoginID =" + LoginID;
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Updated");

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
                if (LoginID != "")
                {

                    try
                    {
                        //checking accidental deletion of all admin account
                        string checkQuery = "Select count(TypeID) as Admins from Login where TypeID = '1' ";
                        DataTable dtCheck = new DataTable();
                        dtCheck = General.FetchData(checkQuery);
                        //
                        var currentTypeID = "";
                        if (dgvLogins.SelectedRows.Count > 0)
                        {
                            int index = dgvLogins.SelectedRows[0].Index;
                            currentTypeID = dt.Rows[index]["TypeID"].ToString();

                        }
                        //

                        if (dtCheck.Rows[0]["Admins"].ToString().Trim() == "1" && currentTypeID == "1")
                        {
                            MessageBox.Show("Operation Failed!\nThere must me atleast `1` Admin Account", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        string Query = "Delete Login where LoginID =  " + LoginID;
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
            LoadData();
            btnSave.Text = "Save";
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            location = fd.FileName;
            picBox.ImageLocation = location;
        }

        private void cmbUserType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbUserType.SelectedIndex == 0)
            {
               TypeID = "1";
            }
            else if (cmbUserType.SelectedIndex == 1)
            {
                TypeID = "2";
            }
            else if (cmbUserType.SelectedIndex == 2)
            {
                TypeID = "3";
            }
            else
            {
                return;
            }
        }

        private void dgvLogins_SelectionChanged(object sender, EventArgs e)
        {
            GridToTextBox();
        }
    }
}
