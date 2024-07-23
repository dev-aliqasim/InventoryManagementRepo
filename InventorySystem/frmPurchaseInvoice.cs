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
    public partial class frmPurchaseInvoice : Form
    {
        public frmPurchaseInvoice()
        {
            InitializeComponent();

            //Adding Column in MiddelWare dtMiddle
            dtMiddle.Columns.Add("ProductID");
            dtMiddle.Columns.Add("ProductName");
            dtMiddle.Columns.Add("Qty");
            dtMiddle.Columns.Add("Amount");
        }

        DataTable dt = new DataTable();
        DataTable dtSupplier = new DataTable();
        DataTable dtProduct = new DataTable();

        DataTable dtMiddle = new DataTable();

        //string CategoryID = "";
        string SerialNoOnFetchRecord = "";
        string dtDateOnFetchRecord = "";
        string SupplierIdOnFetchRecord = "";
        string PurchaseStatusOnFetchRecord = "";


        string NewSerialNo = "";
        string Barcode = "";
        string ProductID = "";


        bool NewMode = false;
        bool EditMode = false;
        bool NewDisableMix = false;

        public string purchaseStatus = "";
        public string PurchasedID = "";

        public void FormControl(string Control)
        {
            if (Control.ToLower() == "enable")
            {
                //Groupbox-1
                txtSrNo.Enabled = false;
                btnSearch.Enabled = false;
                dtDate.Enabled = true;
                cmbSupplier.Enabled = true;
                radiobtnPurchased.Enabled = true;
                radiobtnPending.Enabled = true;

                //Groupbox-2
                txtBarcode.Enabled = true;
                cmbProduct.Enabled = true;
                txtPrice.Enabled = true;
                txtQuantity.Enabled = true;
                txtAmount.Enabled = true;
                btnAdd.Enabled = true;
                btnClear.Enabled = true;


                //buttons
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                //navigation
                btnFirstRecord.Enabled = false;
                btnPreviousRecord.Enabled = false;
                btnNextRecord.Enabled = false;
                btnLastRecord.Enabled = false;
            }
            else if (Control.ToLower() == "disable")
            {
                //Groupbox-1
                txtSrNo.Enabled = true;
                btnSearch.Enabled = true;
                dtDate.Enabled = false;
                cmbSupplier.Enabled = false;
                radiobtnPurchased.Enabled = false;
                radiobtnPending.Enabled = false;

                //Groupbox-2
                txtBarcode.Enabled = false;
                cmbProduct.Enabled = false;
                txtPrice.Enabled = false;
                txtQuantity.Enabled = false;
                txtAmount.Enabled = false;
                btnAdd.Enabled = false;
                btnClear.Enabled = false;

                //buttons
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
                //navigation
                btnFirstRecord.Enabled = true;
                btnPreviousRecord.Enabled = true;
                btnNextRecord.Enabled = true;
                btnLastRecord.Enabled = true;
            }
            else if (Control.ToLower() == "clear")
            {
                //Groupbox-1
                txtSrNo.Text = "";
                dtDate.Value = DateTime.Now;
                cmbSupplier.SelectedIndex = -1;
                radiobtnPurchased.Checked = false;
                radiobtnPending.Checked = false;

                //Groupbox-2
                txtBarcode.Text = "";
                cmbProduct.SelectedIndex = -1;
                txtPrice.Text = "";
                txtQuantity.Text = "";
                txtAmount.Text = "";

                //datagridview
                dgvPurchaseInvoice.DataSource = "";
                NewDisableMix = true;


            }

        }

        public void LoadSupplier()
        {
            string Query = " Select * from Supplier";
            dtSupplier = General.FetchData(Query);
            cmbSupplier.DataSource = dtSupplier;
            cmbSupplier.DisplayMember = dtSupplier.Columns["SupplierName"].ToString();
            cmbSupplier.ValueMember = dtSupplier.Columns["SupplierID"].ToString();
            cmbSupplier.SelectedIndex = -1;
        }

        public void LoadProduct()
        {
            string Query = " Select * from ProductInfo";
            dtProduct = General.FetchData(Query);
            cmbProduct.DataSource = dtProduct;
            cmbProduct.DisplayMember = dtProduct.Columns["ProductName"].ToString();
            cmbProduct.ValueMember = dtProduct.Columns["ProductID"].ToString();
            cmbProduct.SelectedIndex = -1;
        }
        public void LoadData()
        {
            string query = "Select   * from PurchaseInvoice as PI  Inner Join PurchaseInvoiceDetail as PID  on Pi.PurchaseID = PID.PurchaseID  Inner Join ProductInfo  on PID.ProductID = ProductInfo.ProductID  Where PI.PurchaseID = (select max(PurchaseID) from PurchaseInvoice)";
            dt = General.FetchData(query);
            if (dt.Rows.Count <= 0)
            {
                return;
            }
            dt.Columns.Add("Amount");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Amount"] = float.Parse(dt.Rows[i]["Qty"].ToString()) * float.Parse(dt.Rows[i]["PurchasePrice"].ToString());
            }
            dgvPurchaseInvoice.DataSource = dt;
            ///
            txtSrNo.Text = dt.Rows[0]["SrNo"].ToString();
            cmbSupplier.SelectedValue = dt.Rows[0]["SupplierID"].ToString();
            dtDate.Value = DateTime.Parse(dt.Rows[0]["PurchaseDate"].ToString());
            purchaseStatus = dt.Rows[0]["PurchaseStatus"].ToString();


        }

        private void frmPurchaseInvoice_Load(object sender, EventArgs e)
        {
            FormControl("disable");
            LoadSupplier();
            LoadProduct();
            LoadData();

            NewDisableMix = true;
            GridToTextBox();


        }

        public void autoGenerateSerialNo()
        {
            //Get Last SerialNo
            string query = "select *  from PurchaseInvoice order by PurchaseID desc";
            DataTable tempDT = new DataTable();
            tempDT = General.FetchData(query);
            string LastSerialNo = "";
            if (tempDT.Rows.Count > 0)
            {
                LastSerialNo = tempDT.Rows[0]["SrNo"].ToString();
            }
            else
            {
                NewSerialNo = "S-1";
                txtSrNo.Text = NewSerialNo;
            }


            //set new SerialNo
            int tempSerial = 0;
            if (LastSerialNo == "")
            {
                NewSerialNo = "S-1";
                txtSrNo.Text = NewSerialNo;
            }
            else
            {
                tempSerial = int.Parse(LastSerialNo.Substring(2)); //get 001 part of S-001
                if (tempSerial >= 0)
                {
                    tempSerial = tempSerial + 1; //tempSerial = < 001 > +1
                    NewSerialNo = (LastSerialNo.Substring(0, 2) + tempSerial).ToString(); //concatenate 'S-'  with tempSerial 
                    txtSrNo.Text = NewSerialNo;
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormControl("enable");
            FormControl("clear");

            NewMode = true;
            EditMode = false;
            NewDisableMix = false;

            autoGenerateSerialNo();
            //clearing the Middle datatable for multiple insert
            if (dtMiddle.Rows.Count > 0)
            {
                dtMiddle.Rows.Clear();
            }
            btnSave.Text = "Save";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedIndex == -1)
            {
                MessageBox.Show("Select Supplier  first ");
                cmbSupplier.Focus();
                return;

            }
            else if (purchaseStatus == "")
            {
                MessageBox.Show("Select Purchase Status ");
                radiobtnPurchased.Focus();
                return;
            }
            else
            {
                if (NewMode == true)
                {
                    if (dtMiddle.Rows.Count > 0)
                    {
                        //save Query
                        string Query = "Insert Into PurchaseInvoice(SupplierID,SrNo,PurchaseStatus,PurchaseDate) Output inserted.PurchaseID values ('" + cmbSupplier.SelectedValue.ToString() + "' , '" + txtSrNo.Text.ToString() + "' , '" + purchaseStatus.ToString() + "' , '" + dtDate.Text.ToString() + "' )";
                        DataTable dtNewRecord = new DataTable();
                        dtNewRecord = General.FetchData(Query);

                        string PurchasedID = dtNewRecord.Rows[0]["PurchaseID"].ToString();
                        string insertQuery = "";
                        for (int i = 0; i < dtMiddle.Rows.Count; i++)
                        {
                            insertQuery = insertQuery + "Insert into PurchaseInvoiceDetail(PurchaseID,ProductID,Qty)" +
                              " values('" + PurchasedID + "', '" + dtMiddle.Rows[i]["ProductID"].ToString() + "' ,'" + dtMiddle.Rows[i]["Qty"].ToString() + "'  )";
                        }
                        General.ExecuteNonQuery(insertQuery);
                        //Update Products Quantities accordingly------------//
                        LoadProduct();
                        string queryUpdate = "";
                        float oldQuantity = 0;
                        float newQuantity = 0;
                        float sumQuantity = 0;
                        string PID;
                        for (int i = 0; i < dtMiddle.Rows.Count; i++)
                        {
                            PID = dtMiddle.Rows[i]["ProductID"].ToString().Trim();
                            newQuantity = float.Parse(dtMiddle.Rows[i]["Qty"].ToString());
                            for (int j = 0; j < dtProduct.Rows.Count; j++)
                            {
                                //match productIDs
                                if (dtProduct.Rows[j]["ProductID"].ToString().Trim() == PID)
                                {
                                    //retrieve old quantity
                                    oldQuantity = float.Parse(dtProduct.Rows[j]["AvailableStock"].ToString());
                                    break;
                                }
                            }
                            sumQuantity = oldQuantity + newQuantity;
                            queryUpdate = queryUpdate + "Update ProductInfo set AvailableStock = '" + sumQuantity + "' where ProductID = " + PID;
                        }
                        General.ExecuteNonQuery(queryUpdate);
                        //----------------------------------//
                        MessageBox.Show("Record Inserted Successfully !");
                        FormControl("clear");
                        LoadData();

                    }
                    else
                    {
                        MessageBox.Show("Please select atleast 1 product");
                        txtBarcode.Focus();
                        return;
                    }

                }
                else if (EditMode == true)
                {
                    try
                    {
                        if (dtMiddle.Rows.Count > 0)
                        {
                            //edit Query 
                            string Query = "Update PurchaseInvoice set SupplierID ='" + cmbSupplier.SelectedValue.ToString() + "' ,SrNo = '" + txtSrNo.Text.ToString() + "',PurchaseStatus = '" + purchaseStatus.ToString() + "',PurchaseDate = '" + dtDate.Text.ToString() + "'   where PurchaseID =" + PurchasedID;
                            General.ExecuteNonQuery(Query);

                            //first delete all PurchaseInvoiceDetail record whose PurchaseId = given-above
                            string Query2 = "Delete PurchaseInvoiceDetail where PurchaseID =  " + PurchasedID;
                            General.ExecuteNonQuery(Query2);

                            //insert fresh data
                            string insertQuery = "";
                            for (int i = 0; i < dtMiddle.Rows.Count; i++)
                            {
                                insertQuery = insertQuery + "Insert into PurchaseInvoiceDetail(PurchaseID,ProductID,Qty)" +
                                  " values('" + PurchasedID + "', '" + dtMiddle.Rows[i]["ProductID"].ToString() + "' ,'" + dtMiddle.Rows[i]["Qty"].ToString() + "'  )";
                            }
                            General.ExecuteNonQuery(insertQuery);

                            MessageBox.Show("Record Updated");
                            FormControl("clear");
                            LoadData();

                            NewMode = false;
                            EditMode = false;
                            NewDisableMix = true;
                        }
                        else
                        {
                            MessageBox.Show("Please add 1 Product atleast");
                            return;
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }

                FormControl("disable");


                NewMode = false;
                EditMode = false;
                NewDisableMix = true;

                btnSave.Text = "Save";

            }


        }
        public void CopyTodtMiddle()
        {
            if (dtMiddle.Rows.Count > 0)
            {
                dtMiddle.Rows.Clear();
                dtMiddle.AcceptChanges();
            }
            DataRow dr;
            ///adding record to MiddleDT in EditMode
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dtMiddle.NewRow();
                dr["ProductID"] = dt.Rows[i]["ProductID"].ToString();
                dr["ProductName"] = dt.Rows[i]["ProductName"].ToString();
                dr["Qty"] = dt.Rows[i]["Qty"].ToString();
                dr["Amount"] = float.Parse(dt.Rows[i]["Qty"].ToString()) * float.Parse(dt.Rows[i]["PurchasePrice"].ToString());
                dtMiddle.Rows.Add(dr);
            }
            dgvPurchaseInvoice.DataSource = dtMiddle;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtSrNo.Text.Length <= 0)
            {
                MessageBox.Show("Invalid Sr.No", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            FormControl("enable");

            NewMode = false;
            EditMode = true;
            NewDisableMix = false;



            CopyTodtMiddle();

            btnSave.Text = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete this record ?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (PurchasedID != "")
                {

                    try
                    {
                        string Query1 = "Delete PurchaseInvoiceDetail where PurchaseID =  " + PurchasedID;
                        General.ExecuteNonQuery(Query1);
                        string Query2 = "Delete PurchaseInvoice where PurchaseID =  " + PurchasedID;
                        General.ExecuteNonQuery(Query2);
                        MessageBox.Show("Data successfully Deleted !");
                        LoadData();
                        NewDisableMix = true;
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

            NewMode = false;
            EditMode = false;
            NewDisableMix = true;

            dtMiddle.Clear();
            LoadData();
            btnSave.Text = "Save";
        }
        DataTable dtNavigation = new DataTable();
        private void btnFirstRecord_Click(object sender, EventArgs e)
        {
            string query = "Select Top 1 * from PurchaseInvoice as PI Inner Join PurchaseInvoiceDetail as PID on PI.PurchaseID = PID.PurchaseID Inner Join ProductInfo  on PID.ProductID = ProductInfo.ProductID Order by PI.PurchaseID ASC";
            dt = General.FetchData(query);
            dt.Columns.Add("Amount");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Amount"] = float.Parse(dt.Rows[i]["Qty"].ToString()) * float.Parse(dt.Rows[i]["PurchasePrice"].ToString());
            }
            dgvPurchaseInvoice.DataSource = dt;
        }

        private void btnPreviousRecord_Click(object sender, EventArgs e)
        {

            //if (dgvPurchaseInvoice.Rows.Count != 0)
            if (dgvPurchaseInvoice.Rows.Count > 0)
            {
                if (dt.Rows.Count <= 0) return;
                int id = int.Parse(dt.Rows[0]["PurchaseID"].ToString());
                id = id - 1;
                string query = "select * from PurchaseInvoice as PI  Inner Join PurchaseInvoiceDetail as PID  on Pi.PurchaseID = PID.PurchaseID  Inner Join ProductInfo  on PID.ProductID = ProductInfo.ProductID   where pI.PurchaseID =  ( Select Top 1 Pi.PurchaseID  from PurchaseInvoice as PI  Inner Join PurchaseInvoiceDetail as PID  on Pi.PurchaseID = PID.PurchaseID  Inner Join ProductInfo  on PID.ProductID = ProductInfo.ProductID  Where PI.PurchaseID  Between (select min(PurchaseID) from PurchaseInvoice) AND '" + id + "' order by PI.PurchaseID desc ) ";
                dtNavigation = General.FetchData(query);
                if (dtNavigation.Rows.Count > 0)
                {
                    dt = dtNavigation;
                    dt.Columns.Add("Amount");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Amount"] = float.Parse(dt.Rows[i]["Qty"].ToString()) * float.Parse(dt.Rows[i]["PurchasePrice"].ToString());
                    }
                    dgvPurchaseInvoice.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("This is the last record");
                }


            }
            else
            {
                MessageBox.Show("This is the last record");
            }

        }

        private void btnNextRecord_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseInvoice.Rows.Count != 0)
            {
                if (dt.Rows.Count <= 0) return;
                int id = int.Parse(dt.Rows[0]["PurchaseID"].ToString());
                id = id + 1;
                string query = "select * from PurchaseInvoice as PI  Inner Join PurchaseInvoiceDetail as PID  on Pi.PurchaseID = PID.PurchaseID  Inner Join ProductInfo  on PID.ProductID = ProductInfo.ProductID   where pI.PurchaseID = ( Select Top 1 PurchaseID from PurchaseInvoice Where PurchaseID  Between '" + id + "' AND (select max(PurchaseID) from PurchaseInvoice) order by PurchaseID asc )";
                dtNavigation = General.FetchData(query);
                if (dtNavigation.Rows.Count > 0)
                {
                    dt = dtNavigation;
                    dt.Columns.Add("Amount");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Amount"] = float.Parse(dt.Rows[i]["Qty"].ToString()) * float.Parse(dt.Rows[i]["PurchasePrice"].ToString());
                    }
                    dgvPurchaseInvoice.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("This is the First record");
                }
            }
            else
            {
                MessageBox.Show("This is the First record");
            }
        }

        private void loadLastRecordFromDatabase()
        {
            string query = "Select   * from PurchaseInvoice as PI  Inner Join PurchaseInvoiceDetail as PID  on Pi.PurchaseID = PID.PurchaseID  Inner Join ProductInfo  on PID.ProductID = ProductInfo.ProductID  Where PI.PurchaseID = (select max(PurchaseID) from PurchaseInvoice)";
            dt = General.FetchData(query);
            dt.Columns.Add("Amount");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Amount"] = float.Parse(dt.Rows[i]["Qty"].ToString()) * float.Parse(dt.Rows[i]["PurchasePrice"].ToString());
            }
            dgvPurchaseInvoice.DataSource = dt;
        }

        private void btnLastRecord_Click(object sender, EventArgs e)
        {
            loadLastRecordFromDatabase();
        }




        public void GridToTextBox()
        {
            if (NewMode == true)
            {

            }
            else if (EditMode == true)
            {
                if (dgvPurchaseInvoice.SelectedRows.Count > 0)
                {
                    int index = dgvPurchaseInvoice.Rows[0].Index;
                    ////////////////// Values used in Editing  ///////////////////
                    if (dt.Rows.Count <= 0) return;
                    SerialNoOnFetchRecord = dt.Rows[index]["SrNo"].ToString();
                    dtDateOnFetchRecord = dt.Rows[index]["PurchaseDate"].ToString();
                    SupplierIdOnFetchRecord = dt.Rows[index]["SupplierID"].ToString();
                    PurchaseStatusOnFetchRecord = dt.Rows[index]["PurchaseStatus"].ToString();
                    /////////////////////////////////////////////////////////////

                    txtSrNo.Text = SerialNoOnFetchRecord;
                    dtDate.Text = dtDateOnFetchRecord;
                    cmbSupplier.SelectedValue = SupplierIdOnFetchRecord;
                    purchaseStatus = PurchaseStatusOnFetchRecord;

                    if (purchaseStatus.ToLower().Trim() == "purchased")
                    {
                        radiobtnPurchased.Checked = true;
                        radiobtnPending.Checked = false;
                    }
                    else
                    {
                        radiobtnPurchased.Checked = false;
                        radiobtnPending.Checked = true;
                    }
                    PurchasedID = dt.Rows[index]["PurchaseID"].ToString();
                }
            }

            else if (NewDisableMix == true)
            {
                if (dgvPurchaseInvoice.SelectedRows.Count > 0)
                {
                    int index = dgvPurchaseInvoice.Rows[0].Index;

                    ////////////////// Values used in Editing////////////////////
                    SerialNoOnFetchRecord = dt.Rows[index]["SrNo"].ToString();
                    dtDateOnFetchRecord = dt.Rows[index]["PurchaseDate"].ToString();
                    SupplierIdOnFetchRecord = dt.Rows[index]["SupplierID"].ToString();
                    PurchaseStatusOnFetchRecord = dt.Rows[index]["PurchaseStatus"].ToString();
                    /////////////////////////////////////////////////////////////

                    txtSrNo.Text = SerialNoOnFetchRecord;
                    dtDate.Text = dtDateOnFetchRecord;
                    cmbSupplier.SelectedValue = SupplierIdOnFetchRecord;
                    purchaseStatus = PurchaseStatusOnFetchRecord;

                    if (purchaseStatus.ToLower().Trim() == "purchased")
                    {
                        radiobtnPurchased.Checked = true;
                        radiobtnPending.Checked = false;
                    }
                    else
                    {
                        radiobtnPurchased.Checked = false;
                        radiobtnPending.Checked = true;
                    }
                    PurchasedID = dt.Rows[index]["PurchaseID"].ToString();
                }

            }


        }
        private void dgvPurchaseInvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (NewDisableMix == true)
            {
                GridToTextBox();
            }
            else if (NewMode == true)
            {

            }
            else if (EditMode == true)
            {
                GridToTextBox();
            }


        }

        private void cmbSupplier_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex != -1)
            {
                string tempProductID = cmbProduct.SelectedValue.ToString();
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    if (dtProduct.Rows[i]["ProductID"].ToString().Trim() == tempProductID)
                    {
                        txtBarcode.Text = dtProduct.Rows[i]["ProductBarcode"].ToString();
                        break;
                    }
                }
                string result = LoadProductIntoTextBox(tempProductID).Trim().ToLower();
                if (result == "true")
                {

                }
                else if (result == "false")
                {
                    MessageBox.Show("No such Product ID found ");
                }
                else
                {

                }
            }
            else
            {
                return;
            }
        }
        public string LoadProductIntoTextBox(string tempProductID)
        {
            if (tempProductID != "")
            {
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    if (dtProduct.Rows[i]["ProductID"].ToString() == tempProductID)
                    {
                        ProductID = dtProduct.Rows[i]["ProductID"].ToString();
                        cmbProduct.SelectedValue = dtProduct.Rows[i]["ProductID"].ToString();
                        txtPrice.Text = dtProduct.Rows[i]["PurchasePrice"].ToString();
                        txtQuantity.Text = "1";

                        return "true";
                    }
                }
                return "false";

            }
            else
            {
                return "";
            }
        }
        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tempBarcode = txtBarcode.Text.ToString().ToLower().Trim();
                string tempProductID = null;
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    if (dtProduct.Rows[i]["ProductBarcode"].ToString().Trim().ToLower() == tempBarcode.Trim().ToLower())
                    {
                        tempProductID = dtProduct.Rows[i]["ProductID"].ToString();
                        break;
                    }
                }
                string result = LoadProductIntoTextBox(tempProductID).Trim().ToLower();
                if (result == "true")
                {

                }
                else if (result == "false")
                {
                    MessageBox.Show("No such Product Barcode found ");
                }
                else
                {

                }

            }
        }

        public void CalculateAmount(float quantity)
        {
            float price = 0;
            if (txtPrice.Text == "")
            {
                price = 0;
            }
            else
            {
                price = float.Parse(txtPrice.Text.Trim().ToString());
            }
            float amount = quantity * price;
            txtAmount.Text = amount.ToString();
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Length <= 0)
            {
                return;
            }
            else
            {
                if (!validNumber(txtQuantity.Text))
                {
                    MessageBox.Show("Invalid number entered");
                    txtQuantity.Focus();
                    return;
                }
                float quantity = float.Parse(txtQuantity.Text.Trim().ToString());
                CalculateAmount(quantity);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // We must enforce validations
            if (cmbProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Product First");
                cmbProduct.Focus();
                return;
            }
            else if (txtQuantity.Text == "" || txtQuantity.Text == "0")
            {
                MessageBox.Show("Please select  Quantity ");
                txtQuantity.Focus();
                return;
            }

            //get Product
            DataTable dtTempGetProduct = new DataTable();
            string query = "select ProductID,ProductName from ProductInfo where ProductID = " + cmbProduct.SelectedValue;
            dtTempGetProduct = General.FetchData(query);

            //add new columns as desired
            dtTempGetProduct.Columns.Add("Qty");
            dtTempGetProduct.Columns.Add("Amount");
            //now adding values in these columns
            {
                dtTempGetProduct.Rows[0]["Qty"] = txtQuantity.Text.ToString();
                dtTempGetProduct.Rows[0]["Amount"] = txtAmount.Text.ToString();
            }

            //add record in temporary middle datatable named dtMiddle
            if (dtMiddle.Rows.Count == 0)
            {
                dtMiddle.Rows.Add(dtTempGetProduct.Rows[0].ItemArray);
            }
            else
            {
                bool found = false;
                //product already in the list
                for (int i = 0; i < dtMiddle.Rows.Count; i++)
                {
                    if (dtMiddle.Rows[i]["ProductID"].ToString() == dtTempGetProduct.Rows[0]["ProductID"].ToString())
                    {
                        float oldQuantity = float.Parse(dtMiddle.Rows[i]["Qty"].ToString());
                        float newQuantity = float.Parse(txtQuantity.Text.ToString());

                        float oldAmount = float.Parse(dtMiddle.Rows[i]["Amount"].ToString());
                        float newAmount = float.Parse(txtAmount.Text.ToString());

                        dtMiddle.Rows[i]["Qty"] = oldQuantity + newQuantity; //sum those quantities
                        dtMiddle.Rows[i]["Amount"] = oldAmount + newAmount; //sum those amounts
                        found = true;
                    }
                }
                //if record is unique then add
                if (found != true)
                {
                    dtMiddle.Rows.Add(dtTempGetProduct.Rows[0].ItemArray); //both are new record inserted with unique products id
                }

            }
            //update grid
            dgvPurchaseInvoice.DataSource = dtMiddle.DefaultView;
            Clear();
        }

        public void Clear()
        {
            txtBarcode.Text = "";
            cmbProduct.SelectedIndex = -1;
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtAmount.Text = "";

            txtBarcode.Focus();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void radiobtnPurchased_CheckedChanged(object sender, EventArgs e)
        {
            purchaseStatus = "purchased";
        }

        private void radiobtnPending_CheckedChanged(object sender, EventArgs e)
        {
            purchaseStatus = "pending";
        }
        public string GridToBoxesInEditMode()
        {
            if (dgvPurchaseInvoice.SelectedRows.Count > 0)
            {
                int index = dgvPurchaseInvoice.SelectedRows[0].Index;
                ///////////////////////////////////////////////////////
                txtSrNo.Text = dt.Rows[index]["SrNo"].ToString();
                dtDate.Text = dt.Rows[index]["PurchaseDate"].ToString();
                cmbSupplier.SelectedValue = dt.Rows[index]["SupplierID"].ToString();
                purchaseStatus = dt.Rows[index]["PurchaseStatus"].ToString();

                if (purchaseStatus.ToLower().Trim() == "purchased")
                {
                    radiobtnPurchased.Checked = true;
                    radiobtnPending.Checked = false;
                }
                else
                {
                    radiobtnPurchased.Checked = false;
                    radiobtnPending.Checked = true;
                }
                //////////////////////////////////////////////////////
                string tempProductID = dt.Rows[index]["ProductID"].ToString();
                string tempBarcode = null;
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    if (dtProduct.Rows[i]["ProductID"].ToString().Trim() == tempProductID.Trim())
                    {
                        tempBarcode = dtProduct.Rows[i]["ProductBarcode"].ToString();
                        break;
                    }
                }
                txtBarcode.Text = tempBarcode;
                cmbProduct.SelectedValue = dt.Rows[index]["ProductID"].ToString();
                txtPrice.Text = dt.Rows[index]["RetailPrice"].ToString();
                txtQuantity.Text = dt.Rows[index]["Qty"].ToString();
                //amount auto calculated

                PurchasedID = dt.Rows[index]["PurchaseID"].ToString();

                string retProductID = dt.Rows[index]["ProductID"].ToString();
                return retProductID;
            }
            return "";
        }

        public void RemoveFromDGV(string prodID)
        {
            int rows = dtMiddle.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                if (dtMiddle.Rows[i]["ProductID"].ToString() == prodID)
                {
                    dtMiddle.Rows[i].Delete();
                    dtMiddle.AcceptChanges();
                }
            }
            dgvPurchaseInvoice.DataSource = dtMiddle;
        }
        public string GridToGroupinNewMode()
        {
            if (dgvPurchaseInvoice.SelectedRows.Count > 0)
            {
                int index = dgvPurchaseInvoice.SelectedRows[0].Index;
                ///////////////////////////////////////////////////////
                string tempProductID = dtMiddle.Rows[index]["ProductID"].ToString();
                string tempBarcode = null;
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    if (dtProduct.Rows[i]["ProductID"].ToString().Trim() == tempProductID.Trim())
                    {
                        tempBarcode = dtProduct.Rows[i]["ProductBarcode"].ToString();
                        break;
                    }
                }
                txtBarcode.Text = tempBarcode;
                cmbProduct.SelectedValue = dtMiddle.Rows[index]["ProductID"].ToString();
                txtQuantity.Text = dtMiddle.Rows[index]["Qty"].ToString();
                //amount auto calculated

                string retProductID = dtMiddle.Rows[index]["ProductID"].ToString();
                return retProductID;
            }
            return "";

        }
        private void dgvPurchaseInvoice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //GridToTextBox();
            if (NewMode == true)
            {
                string prodID = GridToGroupinNewMode();
                RemoveFromDGV(prodID);
            }
            else if (EditMode == true)
            {
                string prodID = GridToBoxesInEditMode();
                RemoveFromDGV(prodID);

            }
            else if (NewDisableMix == true)
            {
                string prodID = GridToBoxesInEditMode();
                //RemoveFromDGV(prodID);
            }
        }

        private void dgvPurchaseInvoice_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.Trim().ToLower() == "productid")
            {
                e.Column.DisplayIndex = 0;
                e.Column.HeaderText = "Product ID";
            }
            else if (e.Column.Name.Trim().ToLower() == "productname")
            {
                e.Column.DisplayIndex = 1;
                e.Column.HeaderText = "Product Name";
            }
            else if (e.Column.Name.Trim().ToLower() == "qty")
            {
                e.Column.DisplayIndex = 2;
                e.Column.HeaderText = "Quantity";
            }
            else if (e.Column.Name.Trim().ToLower() == "amount")
            {
                e.Column.DisplayIndex = 3;
                e.Column.HeaderText = "Amount";
            }
            else
            {
                e.Column.Visible = false;
            }
        }
        public void Search()
        {
            if (NewDisableMix == true)
            {
                string query = "Select   * from PurchaseInvoice as PI  Inner Join PurchaseInvoiceDetail as PID  on Pi.PurchaseID = PID.PurchaseID  Inner Join ProductInfo  on PID.ProductID = ProductInfo.ProductID where Pi.SrNo = '" + txtSrNo.Text.ToString().Trim() + "'";
                dt = General.FetchData(query);
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Add("Amount");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Amount"] = float.Parse(dt.Rows[i]["Qty"].ToString()) * float.Parse(dt.Rows[i]["PurchasePrice"].ToString());
                    }

                    dgvPurchaseInvoice.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("SrNo. does not exists");
                    txtSrNo.Text = "";
                    loadLastRecordFromDatabase();
                    return;
                }
            }
        }
        private void txtSrNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void txtSrNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        bool validNumber(string value)
        {
            return Regex.Match(value, @"^(0*[1-9]\d{0,15}|0+)(\.\d\d)?$").Success;
        }
        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Length <= 0)
            {
                return;
            }
            else
            {
                if (!validNumber(txtQuantity.Text))
                {
                    MessageBox.Show("Invalid number entered");
                    txtQuantity.Text = "";
                    txtQuantity.Focus();
                    return;
                }
                float quantity = float.Parse(txtQuantity.Text.Trim().ToString());
                CalculateAmount(quantity);
            }

        }

        private void txtSrNo_Leave(object sender, EventArgs e)
        {
            Search();
        }
    }

}
