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
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        string CategoryID = "";

        bool isInvalidName = false;

        bool NewMode = true;
        bool EditMode = false;
        public  void FormControl(string Control)
        {
            if (Control.ToLower() == "enable")
            {
                //textboxes
                txtCategoryName.Enabled = true;
                txtDescription.Enabled = true;

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
                txtCategoryName.Enabled = false;
                txtDescription.Enabled = false;

                //buttons
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
            }
            else if (Control.ToLower() == "clear")
            {
                txtCategoryName.Text = "";
                txtDescription.Text = "";

            }

        }
        public void LoadData()
        {
            string Query = "select * from Category order by CategoryName";
            dt = General.FetchData(Query);
            dgvCategory.DataSource = dt;

        }
        private void Category_Load(object sender, EventArgs e)
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
            txtCategoryName.Focus();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormControl("clear");
            FormControl("disable");
            NewMode = true;
            EditMode = false;

            btnSave.Text = "Save";

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormControl("enable");
            NewMode = false;
            EditMode = true;

            btnSave.Text = "Update";

        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvCategory_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count >0)
            {
                int index = dgvCategory.SelectedRows[0].Index;

                txtCategoryName.Text = dt.Rows[index]["CategoryName"].ToString();
                txtDescription.Text = dt.Rows[index]["Description"].ToString();

                CategoryID = dt.Rows[index]["CategoryID"].ToString();
            }
        }

        bool IsUniqueCategory(string CategoryName)
        {
            string query = "select COUNT(*) as count from Category where Category.CategoryName ='"+CategoryName+"'";
            DataTable dtTemp = new DataTable();
            dtTemp = General.FetchData(query);
            if (int.Parse(dtTemp.Rows[0]["count"].ToString()) >0 )
            {
                MessageBox.Show("Duplicate Category not allowed!\nPlease Add unique category.","Duplicate Category",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        bool IsUniqueCategoryForUpdate(string CategoryID ,string CategoryName)
        {
            string query = "select Category.CategoryID from Category where Category.CategoryName ='"+CategoryName+"'";
            DataTable dtTemp = new DataTable();
            dtTemp = General.FetchData(query);
            if (dtTemp.Rows.Count > 0)
            {
                if (dtTemp.Rows[0]["CategoryID"].ToString() != CategoryID)
                {
                    MessageBox.Show("Duplicate Category not allowed!\nPlease Add unique category.", "Duplicate Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "" || isInvalidName == true || txtCategoryName.Text.Length < 2)
            {
                MessageBox.Show("Enter Valid Category Name first ");
                txtCategoryName.Focus();
                return;

            }
            else if ( txtDescription.Text == "")
            {
                MessageBox.Show("Enter Description first ");
                txtDescription.Focus();
                return;
            }
            else
            {
                if (NewMode == true)
                {
                    bool isUniqueCategory = IsUniqueCategory(txtCategoryName.Text.Trim());
                    if (!isUniqueCategory)
                    {
                        return;
                    }
                    //save Query
                    string Query = "Insert Into Category(CategoryName,Description) values('" + txtCategoryName.Text.Trim() + "' , '" + txtDescription.Text.Trim() + "' )";
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Category Inserted Successfully !");
                    LoadData();
                }
                else if (EditMode == true)
                {
                    bool isUniqueCategoryForUpdate = IsUniqueCategoryForUpdate(CategoryID,txtCategoryName.Text.Trim());
                    if (!isUniqueCategoryForUpdate)
                    {
                        return;
                    }
                    //edit Query 
                    string Query = "Update Category set CategoryName =  '" + txtCategoryName.Text.Trim() + "' , Description = '" + txtDescription.Text.Trim() + "' where CategoryID = '" + CategoryID + "' ";
                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Updated");
                    LoadData();
                    btnSave.Text = "Save";
                }

            }
            FormControl("disable");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Fetching Product against a particular category
            string query = "select count(*) as count from ProductInfo where ProductInfo.CategoryID ="+CategoryID;
            DataTable dtTemp = new DataTable();
            dtTemp = General.FetchData(query);
            //
            string countOfCascadeDeleteProduct = "0";
            if (dtTemp.Rows.Count >0)
            {
                countOfCascadeDeleteProduct = dtTemp.Rows[0]["count"].ToString();
            }

            if (MessageBox.Show("Are you sure you want to Delete this record ?\n "+countOfCascadeDeleteProduct+" - Products will be deleted in this Category!!" , "Confirm Dialog"  , MessageBoxButtons.YesNo ,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (CategoryID != "")
                {

                    try
                    {
                        string Query = "Delete Category where CategoryId =  " + CategoryID + "Delete ProductInfo where ProductInfo.CategoryID = "+CategoryID;
                        General.ExecuteNonQuery(Query);
                        MessageBox.Show("Record Deleted from Category(Cascade Delete)");
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

        private void dgvCategory_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                int index = dgvCategory.SelectedRows[0].Index;

                txtCategoryName.Text = dt.Rows[index]["CategoryName"].ToString();
                txtDescription.Text = dt.Rows[index]["Description"].ToString();

                CategoryID = dt.Rows[index]["CategoryID"].ToString();
            }
        }

        private void dgvCategory_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name =="CategoryName")
            {
                e.Column.HeaderText = "Category Name";
            }
            else if (e.Column.Name == "Description")
            {
                e.Column.HeaderText = "Description";
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void txtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            string invalidName = @"^[1-9]\d*$";
            isInvalidName = Regex.IsMatch(txtCategoryName.Text.Trim(), invalidName);
            if(isInvalidName)
            {
                MessageBox.Show("Invalid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoryName.Focus();
            }
            
        }
    }
}
