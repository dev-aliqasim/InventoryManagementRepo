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
    public partial class frmProductInfo : Form
    {
        public frmProductInfo()
        {
            InitializeComponent();
            
        }

        DataTable dt = new DataTable();
        DataTable dtCategory = new DataTable();
        string CategoryID = "";
        string ProductID = "";
        bool isValidName = false;

        bool AvailabilityStat = false;

        

        bool NewMode = true;
        bool EditMode = false;

        public void FormControl(string Control)
        {
            if (Control.ToLower() == "enable")
            {
                //textboxes
                cmbCategory.Enabled = true;
                txtProductBarcode.Enabled = true;
                txtProductName.Enabled = true;
                txtRetailPrice.Enabled = true;
                txtPurchasePrice.Enabled = true;
                txtMinimumLimit.Enabled = true;
                txtAvailableStock.Enabled = true;
                

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
                cmbCategory.Enabled = false;
                txtProductBarcode.Enabled = false;
                txtProductName.Enabled = false;
                txtRetailPrice.Enabled = false;
                txtPurchasePrice.Enabled = false;
                txtMinimumLimit.Enabled = false;
                txtAvailableStock.Enabled = false;
                

                //buttons
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
            }
            else if (Control.ToLower() == "clear")
            {
                cmbCategory.SelectedIndex = -1;
                txtProductBarcode.Text = "";
                txtProductName.Text = "";
                txtRetailPrice.Text = "";
                txtPurchasePrice.Text = "";
                txtMinimumLimit.Text = "";
                txtAvailableStock.Text = "";
                

            }

        }
        public void LoadData()
        {
            string Query1 = "select ProductInfo.ProductBarcode,ProductInfo.ProductName,Category.CategoryName,ProductInfo.RetailPrice,ProductInfo.PurchasePrice, ProductInfo.AvailableStock,ProductInfo.MinimumLimit,ProductInfo.ProductID,ProductInfo.CategoryID from ProductInfo inner join Category on Category.CategoryID = ProductInfo.CategoryID order by ProductName";
            dt = General.FetchData(Query1);
            dgvProductInfo.DataSource = dt;
        }
        public void LoadCategory()
        {
            string Query2 = "Select * from Category";
            dtCategory = General.FetchData(Query2);
            cmbCategory.DataSource = dtCategory;
            cmbCategory.DisplayMember = dtCategory.Columns["CategoryName"].ToString();
            cmbCategory.ValueMember = dtCategory.Columns["CategoryID"].ToString();
            cmbCategory.SelectedIndex = -1;
        }
        

        private void ProductInfo_Load(object sender, EventArgs e)
        {
            FormControl("disable");
            LoadCategory();
            LoadData();
            
            
        }

        private bool isValidProductName(string productName)
        {
           return Regex.IsMatch(productName, "/^[A-Za-z0-9 ]+$/");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormControl("enable");
            FormControl("clear");
            NewMode = true;
            EditMode = false;

            cmbCategory.SelectedIndex = -1;
        }

        bool IsUniqueProduct(string CategoryID, string ProductName)
        {
            string query = "select * from ProductInfo where ProductInfo.ProductName='" + ProductName + "'";
            DataTable dtTemp = new DataTable();
            dtTemp = General.FetchData(query);
            if (dtTemp.Rows.Count > 0)
            {
                if (dtTemp.Rows[0]["CategoryID"].ToString() == CategoryID)
                {
                    MessageBox.Show("Duplicate ProductName not allowed!\nPlease Add unique ProductName.", "Duplicate ProductName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        bool IsUniqueProductForUpdate(string ProductID, string CategoryID, string ProductName)
        {
            string query = "select * from ProductInfo where ProductInfo.ProductName='" + ProductName + "' And CategoryID = '"+CategoryID+"'  ";
            DataTable dtTemp = new DataTable();
            dtTemp = General.FetchData(query);
            if (dtTemp.Rows.Count > 0)
            {
                if (dtTemp.Rows[0]["ProductID"].ToString() != ProductID)
                {
                    MessageBox.Show("Duplicate ProductName not allowed!\nPlease Add unique ProductName.", "Duplicate ProductName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private bool validInteger(string value)
        {
            string patterns = @"^(0*[1-9]\d{0,15}|0+)(\.\d\d)?$";
            bool matched = Regex.Match(value, patterns).Success;
            return matched;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Select Category First ");
                cmbCategory.Focus();
                return;                
            }
            else if (txtProductName.Text == "")
            {
                MessageBox.Show("Enter Product Name first");
                txtProductName.Focus();
                return;
            }
            else if (txtRetailPrice.Text == "")
            {
                MessageBox.Show("Enter Retail Price first ");
                txtRetailPrice.Focus();
                return;
            }
            else if(!validInteger(txtRetailPrice.Text))
            {
                MessageBox.Show("Enter Valid Retail Price");
                txtRetailPrice.Focus();
                return;
            }
            else if (txtPurchasePrice.Text == "")
            {
                MessageBox.Show("Enter Purchase Price first ");
                txtPurchasePrice.Focus();
                return;
            }
            else if (!validInteger(txtPurchasePrice.Text))
            {
                MessageBox.Show("Enter Valid Purchase Price");
                txtPurchasePrice.Focus();
                return;
            }
            else if(txtMinimumLimit.Text == "")
            {
                MessageBox.Show("Minimum limit is required");
                txtMinimumLimit.Focus();
                return;
            }
            else if (!validInteger(txtMinimumLimit.Text))
            {
                MessageBox.Show("Enter Valid Minimum Limit");
                txtMinimumLimit.Focus();
                return;
            }
            else if (txtAvailableStock.Text == "")
            {
                MessageBox.Show("Please specify Total Available Stock");
                txtAvailableStock.Focus();
                return;
            }
            else if (!validInteger(txtAvailableStock.Text))
            {
                MessageBox.Show("Enter Valid Available Stock");
                txtAvailableStock.Focus();
                return;
            }
            else
            {
                if (NewMode == true)
                {
                    bool isUniqueProductName = IsUniqueProduct(CategoryID,txtProductName.Text.Trim());
                    if (!isUniqueProductName)
                    {
                        return;
                    }

                    //save Query
                    string Query = "Insert Into ProductInfo(ProductName,RetailPrice,PurchasePrice,ProductBarcode,AvailableStock,ExpiryDate,MinimumLimit,CategoryID) " +
                        "Values( '"+ txtProductName.Text.Trim().ToString()+ "' , '" + txtRetailPrice.Text.Trim().ToString() + "' , '" + txtPurchasePrice.Text.Trim().ToString() + "' ," +
                        "  '" + txtProductBarcode.Text.Trim().ToString() + "' ,'" + txtAvailableStock.Text.Trim().ToString() + "' , '" + "" + "', " +
                        "  '" + txtMinimumLimit.Text.Trim().ToString() + "' , '"+CategoryID.ToString()+"'  )";
                    try
                    {
                        General.ExecuteNonQuery(Query);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error saving record!");
                        return;
                    }
                    MessageBox.Show("Product Inserted Successfully !");
                    
                }
                else if (EditMode == true)
                {
                    bool isUniqueProductName = IsUniqueProductForUpdate(ProductID,CategoryID, txtProductName.Text.Trim());
                    if (!isUniqueProductName)
                    {
                        return;
                    }
                    //edit Query 
                    string Query = "Update ProductInfo set ProductName = '" + txtProductName.Text.Trim().ToString() + "' ,RetailPrice = '" + txtRetailPrice.Text.Trim().ToString() + "' , PurchasePrice = '" + txtPurchasePrice.Text.Trim().ToString() + "' ," +
                        "  ProductBarcode = '" + txtProductBarcode.Text.Trim().ToString() + "' , AvailableStock =  '" + txtAvailableStock.Text.Trim().ToString() + "' , ExpiryDate =  '" + "" + "' , " +
                        "  MinimumLimit =   '" + txtMinimumLimit.Text.Trim().ToString() + "' , CategoryID = '" + CategoryID.ToString() + "'  where ProductID =" + ProductID;

                    General.ExecuteNonQuery(Query);
                    MessageBox.Show("Record Updated");
                    btnSave.Text = "Save";
                }
                LoadData();
            }

            FormControl("disable");
            btnNew.Focus();
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
                if (ProductID != "")
                {

                    try
                    {
                        string Query = "Delete ProductInfo where ProductId =  " + ProductID;
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
            if (dgvProductInfo.SelectedRows.Count > 0)
            {
                int index = dgvProductInfo.SelectedRows[0].Index;

                cmbCategory.SelectedValue = dt.Rows[index]["CategoryID"].ToString();
                CategoryID = dt.Rows[index]["CategoryID"].ToString();
                txtProductBarcode.Text = dt.Rows[index]["ProductBarcode"].ToString();
                txtProductName.Text = dt.Rows[index]["ProductName"].ToString();
                txtRetailPrice.Text = dt.Rows[index]["RetailPrice"].ToString();
                txtPurchasePrice.Text = dt.Rows[index]["PurchasePrice"].ToString();
                txtMinimumLimit.Text = dt.Rows[index]["MinimumLimit"].ToString();
                txtAvailableStock.Text = dt.Rows[index]["AvailableStock"].ToString();
                

                ProductID = dt.Rows[index]["ProductID"].ToString();
            }
        }
        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            GridToTextBox();
        }

        private void dgvProductInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridToTextBox();
        }

        private void radiobtnAvailable_CheckedChanged(object sender, EventArgs e)
        {
            AvailabilityStat = true;
        }

        private void radiobtnNotAvailable_CheckedChanged(object sender, EventArgs e)
        {
            AvailabilityStat = false;
        }

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CategoryID = cmbCategory.SelectedValue.ToString();

        }

        private void dgvProductInfo_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name == "ProductName")
            {
                e.Column.HeaderText = "ProductName";
            }
            else if (e.Column.Name == "RetailPrice")
            {
                e.Column.HeaderText = "Retail Price";
            }
            else if (e.Column.Name == "PurchasePrice")
            {
                e.Column.HeaderText = "Purchase Price";
            }
            else if (e.Column.Name == "ProductBarcode")
            {
                e.Column.HeaderText = "Barcode";
            }
            else if (e.Column.Name == "AvailableStock")
            {
                e.Column.HeaderText = "Available Stock";
            }
            else if (e.Column.Name == "PurchasePrice")
            {
                e.Column.HeaderText = "Purchase Price";
            }
            else if (e.Column.Name == "MinimumLimit")
            {
                e.Column.HeaderText = "Minimum Limit";
            }
            else if (e.Column.Name == "CategoryName")
            {
                e.Column.HeaderText = "Category Name";
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void dgvProductInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            //string validName = @"/^[A-Za-z0-9 ]+$/";
            //isValidName = Regex.IsMatch(txtProductName.Text, validName);
            //if (!isValidName && txtProductName.Text.Length > 1)
            //{
            //    MessageBox.Show("Invalid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtProductName.Focus();
            //}
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
