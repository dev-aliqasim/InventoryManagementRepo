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
    public partial class frmSalesInvoice : Form
    {
        public frmSalesInvoice()
        {
            InitializeComponent();
            dtMiddle.Columns.Add("ProductID");
            dtMiddle.Columns.Add("ProductBarcode");
            dtMiddle.Columns.Add("ProductName");
            dtMiddle.Columns.Add("Qty");
            dtMiddle.Columns.Add("RetailPrice");
            dtMiddle.Columns.Add("Discount");
            dtMiddle.Columns.Add("Amount");
        }


        DataTable dt = new DataTable();
        DataTable dtCustomer = new DataTable();
        DataTable dtProduct = new DataTable();
        DataTable dtMiddle = new DataTable();

        string NewSerialNo = "";
        string ProductID = "";

        bool NewMode = false;
        bool EditMode = false;

        int PurchaseStatus = 0; //[type:int {0:not_selected , 1:Success , 2:Pending} ]
        string pStatus = "";
        int BillID;
        float grandTotal = 0;
        float stock = 0;
        //for adjustment of quantity only
        //string adjustProductID = "";
        //float adjustQuantity = 0;
        //


        public void FormControl(string Control)
        {
            if (Control.ToLower() == "enable")
            {
                //Groupbox-1
                txtSrNo.Enabled = false;
                btnSearch.Enabled = false;
                dtDate.Enabled = true;
                cmbCustomer.Enabled = true;
                radiobtnSuccess.Enabled = true;
                radiobtnPending.Enabled = true;
                txtRemarks.Enabled = true;

                //Groupbox-2
                txtBarcode.Enabled = true;
                cmbProduct.Enabled = true;
                txtPrice.Enabled = true;
                txtQuantity.Enabled = true;
                txtDiscount.Enabled = true;
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
                cmbCustomer.Enabled = false;
                radiobtnSuccess.Enabled = false;
                radiobtnPending.Enabled = false;
                txtRemarks.Enabled = false;

                //Groupbox-2
                txtBarcode.Enabled = false;
                cmbProduct.Enabled = false;
                txtPrice.Enabled = false;
                txtQuantity.Enabled = false;
                txtDiscount.Enabled = false;
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
                cmbCustomer.SelectedIndex = -1;
                radiobtnSuccess.Checked = false;
                radiobtnPending.Checked = false;
                txtRemarks.Text = "";
                //\\\\\\\
                PurchaseStatus = 0;
                pStatus = "";
                //\\\\\\\\\

                //Groupbox-2
                txtBarcode.Text = "";
                cmbProduct.SelectedIndex = -1;
                txtPrice.Text = "";
                txtQuantity.Text = "";
                txtDiscount.Text = "";
                txtAmount.Text = "";

                //datagridview
                if (dtMiddle.Rows.Count > 0)
                {
                    dtMiddle.Rows.Clear();
                    dtMiddle.AcceptChanges();
                }
                lblGrandTotal.Text = "";
                dgvSalesInvoice.DataSource = "";
                BillID = 0;


            }

        }

        public void LoadCustomer()
        {
            string Query = " Select * from Customer";
            dtCustomer = General.FetchData(Query);
            cmbCustomer.DataSource = dtCustomer;
            cmbCustomer.DisplayMember = dtCustomer.Columns["CustomerName"].ToString();
            cmbCustomer.ValueMember = dtCustomer.Columns["CustomerID"].ToString();
            cmbCustomer.SelectedIndex = -1;
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
        public void OrderColumnsDGV()
        {
            dgvSalesInvoice.Columns["ProductBarcode"].DisplayIndex = 0;
            dgvSalesInvoice.Columns["ProductName"].DisplayIndex = 1;
            dgvSalesInvoice.Columns["Qty"].DisplayIndex = 2;
            dgvSalesInvoice.Columns["RetailPrice"].DisplayIndex = 3;
            dgvSalesInvoice.Columns["Discount"].DisplayIndex = 4;
            dgvSalesInvoice.Columns["Amount"].DisplayIndex = 5;
        }

        public void LoadData()
        {
            string Query = "select * from SalesInvoice as SalInvo inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID  Where SalInvo.BillID = (select max(BillID) from SalesInvoice)";
            dt = General.FetchData(Query);
            if (dt.Rows.Count > 0)
            {
                //adding extra column
                dt.Columns.Add("Amount");
                float totalAmount = 0;
                float retailprice = 0;
                float discount = 0;
                int quantity = 0;
                float initialTotal = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    retailprice = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
                    quantity = int.Parse(dt.Rows[i]["Qty"].ToString());
                    initialTotal = retailprice * quantity;
                    discount = float.Parse(dt.Rows[i]["Discount"].ToString());
                    totalAmount = initialTotal - ((initialTotal * discount) / 100);
                    dt.Rows[i]["Amount"] = totalAmount.ToString();
                }
                ////////
                dgvSalesInvoice.DataSource = "";
                dgvSalesInvoice.DataSource = dt;
                //OrderColumnsDGV();
            }
            else
            {
                FormControl("clear");
                return;
            }
        }

        private void frmSalesInvoice_Load(object sender, EventArgs e)
        {
            FormControl("disable");
            NewMode = false;
            EditMode = false;

            LoadCustomer();
            LoadProduct();
            LoadData();
            
        }

        public void autoGenerateSerialNo()
        {
            //Get Last SerialNo
            string query = "select *  from SalesInvoice order by BillID desc";
            DataTable serialDT = new DataTable();
            serialDT = General.FetchData(query);
            string LastSerialNo = "";
            if (serialDT.Rows.Count > 0)
            {
                LastSerialNo = serialDT.Rows[0]["SrNo"].ToString();
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

            autoGenerateSerialNo();

            btnSave.Text = "Save";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PurchaseStatus == 1)
            {
                pStatus = "Success";
            }
            else if (PurchaseStatus == 2)
            {
                pStatus = "Pending";
            }
            //validations
            if (txtSrNo.Text.ToString() == "" || txtSrNo.Text.ToString() == null)
            {
                MessageBox.Show("Invalid SrNo. ");
                txtSrNo.Focus();
                return;

            }
            else if (PurchaseStatus == 0)
            {
                MessageBox.Show("Select Payment Status ");
                radiobtnSuccess.Focus();
                return;
            }
            else if (dtMiddle.Rows.Count <= 0)
            {
                MessageBox.Show("Select atleast 1 Product.Invalid Entry ");
                cmbProduct.Focus();
                return;

            }
            //saving / updating data
            else
            {
                // for default customer
                if (cmbCustomer.SelectedIndex == -1)
                {
                    for (int i = 0; i < dtCustomer.Rows.Count; i++)
                    {
                        if (dtCustomer.Rows[i]["CustomerName"].ToString().Trim().ToLower() == "default")
                        {
                            cmbCustomer.SelectedValue = int.Parse(dtCustomer.Rows[i]["CustomerID"].ToString().Trim());
                            cmbCustomer.DisplayMember = dtCustomer.Columns["CustomerName"].ToString();
                            break;
                        }
                    }
                }
                //

                if (NewMode == true)
                {
                    if (dtMiddle.Rows.Count > 0)
                    {
                        //save Query
                        //insert into  SalesInvoice  Table
                        string Query = "Insert Into SalesInvoice(SrNo,Date,CustomerID,PaymentStatus,Remarks) Output inserted.BillId " +
                            "values( '" + txtSrNo.Text.Trim().ToString() + "' , '" + dtDate.Text.Trim().ToString() + "' , '" + cmbCustomer.SelectedValue.ToString() + "' , '" + pStatus + "' , '" + txtRemarks.Text.ToString() + "'  )";
                        DataTable dtNewRecord = new DataTable();
                        try
                        {
                            dtNewRecord = General.FetchData(Query);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }

                        string tempBillID = dtNewRecord.Rows[0]["BillId"].ToString();

                        //insert into  SalesInvoiceDetail  Table
                        string insertQuery = "";
                        for (int i = 0; i < dtMiddle.Rows.Count; i++)
                        {
                            insertQuery = insertQuery + "Insert into SalesInvoiceDetail(BillID,ProductID,Qty,Discount)" +
                              " values('" + tempBillID + "', '" + dtMiddle.Rows[i]["ProductID"].ToString() + "' ,'" + dtMiddle.Rows[i]["Qty"].ToString() + "','" + dtMiddle.Rows[i]["Discount"].ToString() + "'  )";
                        }
                        try
                        {
                            General.ExecuteNonQuery(insertQuery);

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                        float updatedStock = 0;
                        float oldQuantity = 0;
                        string queryRemove = "";
                        /// removing qty from stock in the database
                        for (int i = 0; i < dtMiddle.Rows.Count; i++)
                        {
                            //get old quantity from dtProduct against this Product quantity in dtMiddle
                            for (int j = 0; j < dtProduct.Rows.Count; j++)
                            {
                                if (dtProduct.Rows[j]["ProductID"].ToString().Trim() == dtMiddle.Rows[i]["ProductID"].ToString().Trim())
                                {
                                    oldQuantity = float.Parse(dtProduct.Rows[j]["AvailableStock"].ToString().Trim());
                                    break;
                                }
                            }
                            updatedStock = oldQuantity - float.Parse(dtMiddle.Rows[i]["Qty"].ToString().Trim());
                            queryRemove = queryRemove + "Update ProductInfo set AvailableStock= '" + updatedStock.ToString() + "' where ProductID = " + dtMiddle.Rows[i]["ProductID"].ToString().Trim();

                        }
                        try
                        {
                            General.ExecuteNonQuery(queryRemove);

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                        MessageBox.Show("Record Inserted Successfully !");
                        FormControl("clear");
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
                            string Query = "Update SalesInvoice set CustomerID ='" + cmbCustomer.SelectedValue.ToString() + "' ,SrNo = '" + txtSrNo.Text.ToString() + "',PaymentStatus = '" + pStatus.ToString() + "',Date = '" + dtDate.Text.ToString() + "' , Remarks = '" + txtRemarks.Text.ToString() + "'   where BillID =" + BillID;
                            General.ExecuteNonQuery(Query);

                            //first delete all PurchaseInvoiceDetail record whose PurchaseId = given-above
                            string Query2 = "Delete SalesInvoiceDetail where BillID =  " + BillID;
                            General.ExecuteNonQuery(Query2);

                            //insert fresh data
                            string insertQuery = "";
                            for (int i = 0; i < dtMiddle.Rows.Count; i++)
                            {
                                insertQuery = insertQuery + "Insert into SalesInvoiceDetail(BillID,ProductID,Qty,Discount)" +
                                    " values('" + BillID + "', '" + dtMiddle.Rows[i]["ProductID"].ToString() + "' ,'" + dtMiddle.Rows[i]["Qty"].ToString() + "' , '" + dtMiddle.Rows[i]["Discount"].ToString() + "'  )";
                            }
                            General.ExecuteNonQuery(insertQuery);
                            ////////////////-------------------updating stock in the database--------------------
                            //float updatedStock = 0;
                            //float oldQuantity = 0;
                            //string queryRemove = "";
                            ///// removing qty from stock in the database
                            //for (int i = 0; i < dtMiddle.Rows.Count; i++)
                            //{
                            //    //get old quantity from dtProduct against this Product quantity in dtMiddle
                            //    for (int j = 0; j < dtProduct.Rows.Count; j++)
                            //    {
                            //        if (dtProduct.Rows[j]["ProductID"].ToString().Trim() == dtMiddle.Rows[i]["ProductID"].ToString().Trim())
                            //        {
                            //            oldQuantity = float.Parse(dtProduct.Rows[j]["AvailableStock"].ToString().Trim());
                            //            break;
                            //        }
                            //    }
                            //    updatedStock = oldQuantity - float.Parse(dtMiddle.Rows[i]["Qty"].ToString().Trim());
                            //    queryRemove = queryRemove + "Update ProductInfo set AvailableStock= '" + updatedStock.ToString() + "' where ProductID = " + dtMiddle.Rows[i]["ProductID"].ToString().Trim();

                            //}
                            //try
                            //{
                            //    General.ExecuteNonQuery(queryRemove);

                            //}
                            //catch (Exception ex)
                            //{

                            //    MessageBox.Show(ex.Message);
                            //}


                            /////////////---------------------------------------

                            MessageBox.Show("Record Updated Successfully!");
                            FormControl("clear");

                            NewMode = false;
                            EditMode = false;

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
                //always set Mode to false before Loading Data
                NewMode = false;
                EditMode = false;
                ///////////////////////////////////////////
                LoadData();
                LoadProduct();
                FormControl("disable");
                btnSave.Text = "Save";



            }
        }
        public void FromdgvTodtMiddle()
        {
            if (dtMiddle.Rows.Count > 0)
            {
                dtMiddle.Rows.Clear();
                dtMiddle.AcceptChanges();
            }

            if (dgvSalesInvoice.SelectedRows.Count > 0)
            {
                bool found = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    float amount = float.Parse(dt.Rows[i]["Qty"].ToString()) * float.Parse(dt.Rows[i]["RetailPrice"].ToString());
                    float discount = float.Parse(dt.Rows[i]["Discount"].ToString());
                    float tempTotalAmount = amount - ((amount * discount) / 100);
                    //group box 1
                    txtSrNo.Text = dt.Rows[i]["SrNo"].ToString();
                    dtDate.Text = dt.Rows[i]["Date"].ToString();
                    cmbCustomer.SelectedValue = dt.Rows[i]["CustomerID"].ToString();
                    pStatus = dt.Rows[i]["PaymentStatus"].ToString();
                    //
                    PurchaseStatus = 0;
                    if (pStatus.ToLower().Trim() == "success")
                    {
                        PurchaseStatus = 1;
                        radiobtnSuccess.Checked = true;
                        radiobtnPending.Checked = false;
                    }
                    else
                    {
                        PurchaseStatus = 2;
                        radiobtnSuccess.Checked = false;
                        radiobtnPending.Checked = true;
                    }

                    ///making a datarow according to MS Documentation
                    DataRow dr;
                    dr = dtMiddle.NewRow();
                    dr["ProductID"] = dt.Rows[i]["ProductID"].ToString();
                    dr["ProductBarcode"] = dt.Rows[i]["ProductBarcode"].ToString();
                    dr["ProductName"] = dt.Rows[i]["ProductName"].ToString();
                    dr["Qty"] = dt.Rows[i]["Qty"].ToString();
                    dr["RetailPrice"] = dt.Rows[i]["RetailPrice"].ToString();
                    dr["Discount"] = dt.Rows[i]["Discount"].ToString();
                    dr["Amount"] = tempTotalAmount.ToString();

                    //check if product is already existing in dtMiddle
                    for (int j = 0; j < dtMiddle.Rows.Count; j++)
                    {
                        //just for comparison declaring strings
                        string dtProductName = dt.Rows[i]["ProductName"].ToString().ToLower().Trim();
                        string dtMiddleProductName = dtMiddle.Rows[j]["ProductName"].ToString().ToLower().Trim();

                        float dtDiscount = float.Parse(dt.Rows[i]["Discount"].ToString().Trim());
                        float dtMiddleDiscount = float.Parse(dtMiddle.Rows[j]["Discount"].ToString().Trim());

                        //if product already in the list
                        if (dtMiddleProductName == dtProductName)
                        {
                            if (dtDiscount == dtMiddleDiscount)
                            {
                                dtMiddle.Rows[j]["Qty"] = float.Parse(dtMiddle.Rows[j]["Qty"].ToString()) + float.Parse(dt.Rows[i]["Qty"].ToString());
                                dtMiddle.Rows[j]["Discount"] = float.Parse(dtMiddle.Rows[j]["Discount"].ToString());
                                dtMiddle.Rows[j]["Amount"] = float.Parse(dtMiddle.Rows[j]["Amount"].ToString()) + float.Parse(tempTotalAmount.ToString());
                                found = true;
                            }
                        }


                    }


                    if (found == false)
                    {
                        dtMiddle.Rows.Add(dr);
                    }

                    BillID = int.Parse(dt.Rows[i]["BillID"].ToString());
                }

                dgvSalesInvoice.DataSource = dtMiddle;
                OrderColumnsDGV();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Cannot Edit Empty Records!");
                btnNew.Focus();
                return;
            }
            FormControl("enable");

            NewMode = false;
            EditMode = true;

            FromdgvTodtMiddle();

            btnSave.Text = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete this record ?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (BillID > 0)
                {

                    try
                    {
                        string Query1 = "Delete SalesInvoiceDetail where BillId =  " + BillID;
                        General.ExecuteNonQuery(Query1);
                        string Query2 = "Delete SalesInvoice where BillId =  " + BillID;
                        General.ExecuteNonQuery(Query2);
                        MessageBox.Show("Data successfully Deleted !");
                        lblGrandTotal.Text = "";
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

            NewMode = false;
            EditMode = false;

            LoadData();

            btnSave.Text = "Save";
        }

        private void dgvSalesInvoice_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.ToString().Trim().ToLower() == "productbarcode")
            {
                e.Column.HeaderText = "Barcode";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "productname")
            {
                e.Column.HeaderText = "Product Name";

            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "qty")
            {
                e.Column.HeaderText = "Quantity";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "retailprice")
            {
                e.Column.HeaderText = "Price";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "discount")
            {
                e.Column.HeaderText = "Discount";
            }
            else if (e.Column.Name.ToString().Trim().ToLower() == "amount")
            {
                e.Column.HeaderText = " Final Price";
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void dgvSalesInvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (NewMode == true)
            {

            }
            else if (EditMode == true)
            {

            }
            else
            {
                if (dgvSalesInvoice.SelectedRows.Count > 0)
                {
                    grandTotal = 0;
                    int index = dgvSalesInvoice.SelectedRows[0].Index;

                    txtSrNo.Text = dt.Rows[index]["SrNo"].ToString();
                    dtDate.Text = dt.Rows[index]["Date"].ToString();
                    cmbCustomer.SelectedValue = dt.Rows[index]["CustomerID"].ToString();
                    pStatus = dt.Rows[index]["PaymentStatus"].ToString().ToLower().Trim();
                    if (pStatus == "success")
                    {
                        radiobtnSuccess.Checked = true;
                        radiobtnPending.Checked = false;

                    }
                    else if (pStatus == "pending")
                    {

                        radiobtnSuccess.Checked = false;
                        radiobtnPending.Checked = true;
                    }
                    txtRemarks.Text = dt.Rows[index]["Remarks"].ToString();

                    BillID = int.Parse(dt.Rows[index]["BillID"].ToString());
                    ///////for grand total
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        grandTotal = grandTotal + float.Parse(dt.Rows[i]["Amount"].ToString());
                    }
                    lblGrandTotal.Text = grandTotal.ToString();
                    OrderColumnsDGV();
                }
            }

        }

        private void btnLastRecord_Click(object sender, EventArgs e)
        {
            string query = "select * from SalesInvoice as SalInvo inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID  Where SalInvo.BillID = (select max(BillID) from SalesInvoice)";
            dt = General.FetchData(query);
            //adding extra column
            dt.Columns.Add("Amount");
            float amount = 0;
            float retailprice = 0;
            float discount = 0;
            float quantity = 0;
            float totalamount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                quantity = float.Parse(dt.Rows[i]["Qty"].ToString());
                retailprice = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
                discount = float.Parse(dt.Rows[i]["Discount"].ToString());
                amount = retailprice - ((retailprice * discount) / 100);
                totalamount = amount * quantity;
                dt.Rows[i]["Amount"] = totalamount.ToString();
            }
            //dt.Columns.Add("Amount");
            //float amount = 0;
            //float retailprice = 0;
            //float discount = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    retailprice = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
            //    discount = float.Parse(dt.Rows[i]["Discount"].ToString());
            //    amount = retailprice - ((retailprice * discount) / 100);
            //    dt.Rows[i]["Amount"] = amount.ToString();
            //}
            dgvSalesInvoice.DataSource = dt;
            OrderColumnsDGV();
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
                        //calculate Amount
                        float quantity = float.Parse(txtQuantity.Text.Trim().ToString());
                        float discount;
                        if (txtDiscount.Text != "")
                        {
                            discount = float.Parse(txtDiscount.Text.Trim().ToString());

                        }
                        else
                        {
                            txtDiscount.Text = "0";
                            discount = 0;
                        }
                        CalculateAmount(quantity, discount);
                        //


                        return "found";
                    }
                }
                return "notfound";
            }
            else
            {
                return "";
            }
        }
        private void cmbProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex != -1)
            {
                string tempProductID = cmbProduct.SelectedValue.ToString();
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    if (dtProduct.Rows[i]["ProductID"].ToString() == tempProductID)
                    {
                        txtBarcode.Text = dtProduct.Rows[i]["ProductBarcode"].ToString();
                    }
                }

                string result = LoadProductIntoTextBox(tempProductID).Trim().ToLower();
                if (result == "found")
                {
                    ////---------- GET Stock--------------

                    //for (int i = 0; i < dtProduct.Rows.Count; i++)
                    //{
                    //    if (dtProduct.Rows[i]["ProductID"].ToString().Trim() == tempProductID.ToString())
                    //    {
                    //        stock = float.Parse(dtProduct.Rows[i]["AvailableStock"].ToString().Trim());
                    //        break;
                    //    }
                    //}
                    //if (stock == 0)
                    //{
                    //    MessageBox.Show("Out Of Stock Product");
                    //    txtQuantity.Text = "0";
                    //    cmbProduct.Focus();
                    //    return;
                    //}
                }
                else if (result == "notfound")
                {
                    MessageBox.Show("No such Product found! ");
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
        public void CalculateAmount(float quantity, float discount)
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
            float TotalAmount = amount - ((amount * discount) / 100);
            txtAmount.Text = TotalAmount.ToString();
        }

        bool validNumber(string value)
        {
            return Regex.Match(value, @"^(0*[1-9]\d{0,15}|0+)(\.\d\d)?$").Success;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (NewMode == true)
            {
                if (txtQuantity.Text != "" && cmbProduct.SelectedIndex.ToString() != "-1")
                {
                    if (!validNumber(txtQuantity.Text))
                    {
                        MessageBox.Show("Invalid number entered");
                        txtQuantity.Focus();
                        return;
                    }
                    float quantity = float.Parse(txtQuantity.Text.Trim().ToString());
                    float tempProductID = float.Parse(cmbProduct.SelectedValue.ToString());
                    ////---------- GET Stock--------------

                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        if (dtProduct.Rows[i]["ProductID"].ToString().Trim() == tempProductID.ToString())
                        {
                            stock = float.Parse(dtProduct.Rows[i]["AvailableStock"].ToString().Trim());
                            break;
                        }
                    }

                    //--------------------//----------//
                    float TotalQuantity = quantity;
                    if (dtMiddle.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtMiddle.Rows.Count; i++)
                        {
                            if (dtMiddle.Rows[i]["ProductID"].ToString().Trim() == tempProductID.ToString())
                            {
                                TotalQuantity = TotalQuantity + float.Parse(dtMiddle.Rows[i]["Qty"].ToString());
                            }
                        }
                    }

                    if (TotalQuantity <= stock)
                    {
                        float discount;
                        if (txtDiscount.Text != "")
                        {
                            discount = float.Parse(txtDiscount.Text.Trim().ToString());
                        }
                        else
                        {
                            discount = 0;
                        }
                        CalculateAmount(TotalQuantity, discount);
                    }
                    else if (TotalQuantity > stock)
                    {
                        MessageBox.Show("Quantity : '" + TotalQuantity + "'   greater than stock : '" + stock + "'  available");
                        txtQuantity.Text = "0";
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else if (EditMode == true)
            {
                if (txtQuantity.Text != "" && cmbProduct.SelectedIndex.ToString() != "-1")
                {
                    if (!validNumber(txtQuantity.Text))
                    {
                        MessageBox.Show("Invalid number entered");
                        txtQuantity.Focus();
                        return;
                    }
                    float quantity = float.Parse(txtQuantity.Text.Trim().ToString());
                    //float tempProductID = float.Parse(cmbProduct.SelectedValue.ToString());
                    //////---------- GET Stock--------------

                    //for (int i = 0; i < dtProduct.Rows.Count; i++)
                    //{
                    //    if (dtProduct.Rows[i]["ProductID"].ToString().Trim() == tempProductID.ToString())
                    //    {
                    //        stock = float.Parse(dtProduct.Rows[i]["AvailableStock"].ToString().Trim());
                    //        break;
                    //    }
                    //}

                    ////--------------------//----------//
                    //float TotalQuantity = quantity;
                    //if (dtMiddle.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dtMiddle.Rows.Count; i++)
                    //    {
                    //        if (dtMiddle.Rows[i]["ProductID"].ToString().Trim() == tempProductID.ToString())
                    //        {
                    //            TotalQuantity = TotalQuantity + float.Parse(dtMiddle.Rows[i]["Qty"].ToString());
                    //        }
                    //    }
                    //}

                    float discount;
                    if (txtDiscount.Text != "")
                    {
                        discount = float.Parse(txtDiscount.Text.Trim().ToString());
                    }
                    else
                    {
                        discount = 0;
                    }
                    CalculateAmount(quantity, discount);

                }
                else
                {
                    return;
                }
                //if (txtQuantity.Text != "" && cmbProduct.SelectedIndex.ToString() != "-1")
                //{
                //    float quantity = float.Parse(txtQuantity.Text.ToString().Trim());
                //    string productID = cmbProduct.SelectedValue.ToString();
                //    float stock = 0;
                //    for (int i = 0; i < dtProduct.Rows.Count; i++)
                //    {
                //        if (dtProduct.Rows[i]["ProductID"].ToString().Trim() == productID)
                //        {
                //            stock = float.Parse(dtProduct.Rows[i]["AvailableStock"].ToString().Trim());
                //            break;
                //        }
                //    }
                //    ///checking conditions
                //    if (quantity <)
                //    {

                //    }

                //}
                //else
                //{
                //    return;
                //}


            }





        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "")
            {

                float quantity = float.Parse(txtQuantity.Text.Trim().ToString());
                float discount;
                if (txtDiscount.Text != "")
                {
                    if (!validNumber(txtDiscount.Text))
                    {
                        MessageBox.Show("Invalid number entered");
                        txtDiscount.Focus();
                        return;
                    }
                    discount = float.Parse(txtDiscount.Text.Trim().ToString());

                }
                else
                {
                    discount = 0;
                }
                CalculateAmount(quantity, discount);

            }
            else
            {
                return;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //validations
            if (txtBarcode.Text.Trim().ToString() == null || txtBarcode.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Please enter product BARCODE first!");
                txtBarcode.Text = "0";
                txtBarcode.Focus();
                return;
            }
            else if (cmbProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Product first!");
                cmbProduct.Focus();
                return;
            }
            else if (txtPrice.Text.Trim().ToString() == "" || txtPrice.Text.Trim().ToString() == null)
            {
                MessageBox.Show("Product Price invalid!");
                return;
            }
            else if (txtQuantity.Text.Trim().ToString() == "" || txtQuantity.Text.Trim().ToString() == null || float.Parse(txtQuantity.Text.Trim().ToString()) <= 0)
            {
                MessageBox.Show("Product Quantity invalid!");
                txtQuantity.Focus();
                return;
            }
            else
            {
                //check discount %
                if (txtDiscount.Text.Trim().ToString() == "" || txtDiscount.Text.Trim().ToString() == null || txtDiscount.Text.Trim().ToString() == "0")
                {
                    txtDiscount.Text = "0";
                }
                int tempProductID = int.Parse(cmbProduct.SelectedValue.ToString());
                string tempBarcode = txtBarcode.Text.Trim().ToString();
                string tempProductName = cmbProduct.Text;
                float tempPrice = float.Parse(txtPrice.Text.Trim().ToString());
                float tempQuantity = float.Parse(txtQuantity.Text.Trim().ToString());
                float tempDiscount = float.Parse(txtDiscount.Text.Trim().ToString());
                float tempAmount = float.Parse(txtAmount.Text.Trim().ToString());
                bool found = false;

                
                DataRow dr;
                dr = dtMiddle.NewRow();
                dr["ProductID"] = tempProductID;
                dr["ProductBarcode"] = tempBarcode;
                dr["ProductName"] = tempProductName;
                dr["Qty"] = tempQuantity;
                dr["RetailPrice"] = tempPrice;
                dr["Discount"] = tempDiscount;
                dr["Amount"] = tempAmount;


                for (int i = 0; i < dtMiddle.Rows.Count; i++)
                {
                    //if product already in the list
                    if (dtMiddle.Rows[i]["ProductID"].ToString().ToLower().Trim() == cmbProduct.SelectedValue.ToString().ToLower().Trim())
                    {
                        if (dtMiddle.Rows[i]["Discount"].ToString().ToLower().Trim() == txtDiscount.Text.Trim().ToString())
                        {
                            dtMiddle.Rows[i]["Qty"] = float.Parse(dtMiddle.Rows[i]["Qty"].ToString()) + float.Parse(txtQuantity.Text.Trim().ToString());
                            //////----------------------- still Working on Discount ---------------------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\
                            //dtMiddle.Rows[i]["Discount"] = float.Parse(dtMiddle.Rows[i]["Discount"].ToString()) + float.Parse(txtDiscount.Text.Trim().ToString());
                            dtMiddle.Rows[i]["Amount"] = float.Parse(dtMiddle.Rows[i]["Amount"].ToString()) + float.Parse(txtAmount.Text.Trim().ToString());
                            found = true;
                            break;
                        }

                    }
                }
                if (found == false)
                {
                    dtMiddle.Rows.Add(dr);
                }
                dgvSalesInvoice.DataSource = "";
                dgvSalesInvoice.DataSource = dtMiddle;
                OrderColumnsDGV();

                //for grandtotal
                grandTotal = 0;
                for (int i = 0; i < dtMiddle.Rows.Count; i++)
                {
                    grandTotal = grandTotal + float.Parse(dtMiddle.Rows[i]["Amount"].ToString());
                }
                lblGrandTotal.Text = grandTotal.ToString();
            }

            clear();
            txtBarcode.Focus();



        }
        public void clear()
        {
            txtBarcode.Text = "";
            cmbProduct.SelectedIndex = -1;
            txtPrice.Text = "0";
            txtQuantity.Text = "0";
            txtDiscount.Text = "0";
            txtAmount.Text = "0";

            txtBarcode.Focus();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void radiobtnSuccess_CheckedChanged(object sender, EventArgs e)
        {
            PurchaseStatus = 1; //[type:int {0:not_selected , 1:Success , 2:Pending} ]
        }

        private void radiobtnPending_CheckedChanged(object sender, EventArgs e)
        {
            PurchaseStatus = 2; //[type:int {0:not_selected , 1:Success , 2:Pending} ]
        }

        DataTable dtNavigation = new DataTable();
        private void btnNextRecord_Click(object sender, EventArgs e)
        {
            if (dgvSalesInvoice.Rows.Count != 0)
            {
                if (dt.Rows.Count <= 0) return;
                int id = int.Parse(dt.Rows[0]["BillID"].ToString());
                id = id + 1;
                string query = "select * from SalesInvoice as SalInvo inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID  " +
                    " Where SalInvo.BillID = ( Select Top 1  BillID from SalesInvoice  Where BillID  Between '" + id + "' AND (select max(BillID) from SalesInvoice) order by BillID asc ) ";
                dtNavigation = General.FetchData(query);
                if (dtNavigation.Rows.Count > 0)
                {
                    dt = dtNavigation;
                    //adding extra column
                    dt.Columns.Add("Amount");
                    float amount = 0;
                    float retailprice = 0;
                    float discount = 0;
                    float quantity = 0;
                    float totalamount = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        quantity = float.Parse(dt.Rows[i]["Qty"].ToString());
                        retailprice = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
                        discount = float.Parse(dt.Rows[i]["Discount"].ToString());
                        amount = retailprice - ((retailprice * discount) / 100);
                        totalamount = amount * quantity;
                        dt.Rows[i]["Amount"] = totalamount.ToString();
                    }

                    dgvSalesInvoice.DataSource = dt;
                    OrderColumnsDGV();
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

        private void btnFirstRecord_Click(object sender, EventArgs e)
        {
            string query = "select Top 1 * from SalesInvoice as SalInvo inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID  Order by SalInvo.BillID ASC ";
            dt = General.FetchData(query);
            //adding extra column
            dt.Columns.Add("Amount");
            float amount = 0;
            float retailprice = 0;
            float discount = 0;
            float quantity = 0;
            float totalamount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                quantity = float.Parse(dt.Rows[i]["Qty"].ToString());
                retailprice = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
                discount = float.Parse(dt.Rows[i]["Discount"].ToString());
                amount = retailprice - ((retailprice * discount) / 100);
                totalamount = amount * quantity;
                dt.Rows[i]["Amount"] = totalamount.ToString();
            }
            //dt.Columns.Add("Amount");
            //float amount = 0;
            //float retailprice = 0;
            //float discount = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    retailprice = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
            //    discount = float.Parse(dt.Rows[i]["Discount"].ToString());
            //    amount = retailprice - ((retailprice * discount) / 100);
            //    dt.Rows[i]["Amount"] = amount.ToString();
            //}

            dgvSalesInvoice.DataSource = dt;
            OrderColumnsDGV();
        }

        private void btnPreviousRecord_Click(object sender, EventArgs e)
        {
            if (dgvSalesInvoice.Rows.Count != 0)
            {
                if (dt.Rows.Count <= 0) return;
                int id = int.Parse(dt.Rows[0]["BillID"].ToString());
                id = id - 1;
                string query = "select * from SalesInvoice as SalInvo inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID Where SalInvo.BillID = ( Select Top 1  BillID from SalesInvoice  Where BillID  Between (select min(BillID) from SalesInvoice) AND '" + id + "'  order by BillID desc ) ";
                dtNavigation = General.FetchData(query);
                if (dtNavigation.Rows.Count > 0)
                {
                    dt = dtNavigation;
                    //adding extra column
                    dt.Columns.Add("Amount");
                    float amount = 0;
                    float retailprice = 0;
                    float discount = 0;
                    float quantity = 0;
                    float totalamount = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        quantity = float.Parse(dt.Rows[i]["Qty"].ToString());
                        retailprice = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
                        discount = float.Parse(dt.Rows[i]["Discount"].ToString());
                        amount = retailprice - ((retailprice * discount) / 100);
                        totalamount = amount * quantity;
                        dt.Rows[i]["Amount"] = totalamount.ToString();
                    }

                    dgvSalesInvoice.DataSource = dt;
                    OrderColumnsDGV();
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

        private void dgvSalesInvoice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (NewMode == true || EditMode == true)
            {
                if (dgvSalesInvoice.SelectedRows.Count > 0)
                {
                    int index = dgvSalesInvoice.SelectedRows[0].Index;
                    ////for adjustments only
                    //adjustProductID = dtMiddle.Rows[index]["ProductID"].ToString();
                    //adjustQuantity = float.Parse(dtMiddle.Rows[index]["Qty"].ToString());

                    //
                    txtBarcode.Text = dtMiddle.Rows[index]["ProductBarcode"].ToString();
                    cmbProduct.SelectedValue = dtMiddle.Rows[index]["ProductID"].ToString();
                    {
                        for (int i = 0; i < dtProduct.Rows.Count; i++)
                        {
                            if (dtProduct.Rows[i]["ProductID"].ToString().Trim() == dtMiddle.Rows[index]["ProductID"].ToString().Trim())
                            {
                                txtPrice.Text = dtProduct.Rows[i]["RetailPrice"].ToString().Trim();
                                break;
                            }
                        }

                    }
                    float delayQuantityToPreventProblem = float.Parse(dtMiddle.Rows[index]["Qty"].ToString());

                    txtDiscount.Text = dtMiddle.Rows[index]["Discount"].ToString();
                    txtAmount.Text = dtMiddle.Rows[index]["Amount"].ToString();

                    dtMiddle.Rows.RemoveAt(index);
                    dtMiddle.AcceptChanges();
                    //
                    txtQuantity.Text = delayQuantityToPreventProblem.ToString();
                    //calculating grand total
                    if (dtMiddle.Rows.Count > 0)
                    {
                        grandTotal = 0;
                        for (int i = 0; i < dtMiddle.Rows.Count; i++)
                        {
                            grandTotal = grandTotal + float.Parse(dtMiddle.Rows[i]["Amount"].ToString());
                        }
                        lblGrandTotal.Text = grandTotal.ToString();
                    }
                    else
                    {
                        lblGrandTotal.Text = "0";
                    }


                }

            }

        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tempProductBarcode = txtBarcode.Text.Trim().ToString();
                string tempProductID = "";
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    if (dtProduct.Rows[i]["ProductBarcode"].ToString() == tempProductBarcode)
                    {
                        tempProductID = dtProduct.Rows[i]["ProductID"].ToString();
                        cmbProduct.SelectedValue = tempProductID;

                    }
                }

                string result = LoadProductIntoTextBox(tempProductID).Trim().ToLower();
                if (result == "found")
                {

                }
                else if (result == "notfound")
                {
                    MessageBox.Show("No such Product found! ");
                }
                else
                {

                }

                txtQuantity.Focus();

            }
        }

        private void txtSrNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string query = "select * from SalesInvoice as SalInvo inner join SalesInvoiceDetail as SalDet on SalInvo.BillId = SalDet.BillID inner join ProductInfo as PI on SalDet.ProductID = PI.ProductID  Where SalInvo.SrNo = '" + txtSrNo.Text.ToString().Trim().ToLower() + "'";
                    dt = General.FetchData(query);
                    //adding extra column
                    dt.Columns.Add("Amount");
                    float amount = 0;
                    float retailprice = 0;
                    float discount = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        retailprice = float.Parse(dt.Rows[i]["RetailPrice"].ToString());
                        discount = float.Parse(dt.Rows[i]["Discount"].ToString());
                        amount = retailprice - ((retailprice * discount) / 100);
                        dt.Rows[i]["Amount"] = amount.ToString();
                    }
                    ////////

                    if (dt.Rows.Count > 0)
                    {
                        dgvSalesInvoice.DataSource = dt;
                        OrderColumnsDGV();
                    }
                    else
                    {
                        MessageBox.Show("Serial No. doesn't exists");
                        LoadData();
                        FormControl("clear");
                        txtSrNo.Text = "";
                        // To prevent anonymous delete behaviour setting billId to default 0
                        BillID = 0;

                        return;
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (NewMode == true)
            {
                if (txtQuantity.Text != "" && cmbProduct.SelectedIndex.ToString() != "-1")
                {
                    if (!validNumber(txtQuantity.Text))
                    {
                        MessageBox.Show("Invalid number entered");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                        return;
                    }
                    float quantity = float.Parse(txtQuantity.Text.Trim().ToString());
                    float tempProductID = float.Parse(cmbProduct.SelectedValue.ToString());
                    ////---------- GET Stock--------------

                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        if (dtProduct.Rows[i]["ProductID"].ToString().Trim() == tempProductID.ToString())
                        {
                            stock = float.Parse(dtProduct.Rows[i]["AvailableStock"].ToString().Trim());
                            break;
                        }
                    }

                    //--------------------//----------//
                    float TotalQuantity = quantity;
                    if (dtMiddle.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtMiddle.Rows.Count; i++)
                        {
                            if (dtMiddle.Rows[i]["ProductID"].ToString().Trim() == tempProductID.ToString())
                            {
                                TotalQuantity = TotalQuantity + float.Parse(dtMiddle.Rows[i]["Qty"].ToString());
                            }
                        }
                    }

                    if (TotalQuantity <= stock)
                    {
                        float discount;
                        if (txtDiscount.Text != "")
                        {
                            discount = float.Parse(txtDiscount.Text.Trim().ToString());
                        }
                        else
                        {
                            discount = 0;
                        }
                        CalculateAmount(TotalQuantity, discount);
                    }
                    else if (TotalQuantity > stock)
                    {
                        MessageBox.Show("Quantity : '" + TotalQuantity + "'   greater than stock : '" + stock + "'  available");
                        txtQuantity.Text = "0";
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else if (EditMode == true)
            {
                if (txtQuantity.Text != "" && cmbProduct.SelectedIndex.ToString() != "-1")
                {
                    if (!validNumber(txtQuantity.Text))
                    {
                        MessageBox.Show("Invalid number entered");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                        return;
                    }
                }
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (!validNumber(txtDiscount.Text))
            {
                MessageBox.Show("Invalid number entered");
                txtDiscount.Text = "0";
                txtDiscount.Focus();
                return;
            }
        }
    }
}
