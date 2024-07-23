using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public partial class frmExpiredProductReport : Form
    {
        public frmExpiredProductReport()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        DataTable dtSearch = new DataTable();
        bool LoadMode = false;
        bool SearchMode = false;

        public void LoadData()
        {
            LoadMode = true;
            SearchMode = false;
            int count = 0;
            DateTime date = new DateTime();
            try
            {
                string Query = "select * from ProductInfo  inner join Category on ProductInfo.CategoryID = Category.CategoryID";
                dt = General.FetchData(Query);
                //
                {
                    dt.Columns.Add("ExpiresOn");
                    //
                    TimeSpan tspan = DateTime.Now.Date.Subtract(DateTime.Now.Date);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        date = DateTime.Parse(dt.Rows[i]["ExpiryDate"].ToString());
                        dt.Rows[i]["ExpiresOn"] = date.Year;
                        //
                        tspan = date.Subtract(DateTime.Now);
                        if (tspan.TotalDays <= 0)
                        {
                            count = count + 1;
                        }

                    }
                    lblCount.Text = count.ToString();
                    //

                    dgvExpiredProduct.DataSource = "";
                    dgvExpiredProduct.DataSource = dt;
                }
                lblStatus.Text = "Overall report";
                AdjustColumnIndex();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void AdjustColumnIndex()
        {
            dgvExpiredProduct.Columns["ProductName"].DisplayIndex = 0;
            dgvExpiredProduct.Columns["CategoryName"].DisplayIndex = 1;
            dgvExpiredProduct.Columns["PurchasePrice"].DisplayIndex = 2;
            dgvExpiredProduct.Columns["RetailPrice"].DisplayIndex = 3;
            dgvExpiredProduct.Columns["AvailableStock"].DisplayIndex = 4;
            dgvExpiredProduct.Columns["ExpiryDate"].DisplayIndex = 5;
        }
        private void frmExpiredProductReport_Load(object sender, EventArgs e)
        {
            LoadData();


        }
       
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            cmbFilter.SelectedIndex = -1;
            chkExpired.Checked = false;
            chkNotExpired.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMode = false;
            SearchMode = true;
            int count = 0;
            DateTime date = new DateTime();
            try
            {
                string Query = "select * from ProductInfo  inner join Category on ProductInfo.CategoryID = Category.CategoryID where ExpiryDate between '"+dtFromDate.Text.ToString()+"' and '"+dtToDate.Text.ToString()+"'";
                dtSearch = General.FetchData(Query);
                //
                {
                    dtSearch.Columns.Add("ExpiresOn");
                    //
                    TimeSpan tspan = DateTime.Now.Date.Subtract(DateTime.Now.Date);
                    for (int i = 0; i < dtSearch.Rows.Count; i++)
                    {
                        date = DateTime.Parse(dtSearch.Rows[i]["ExpiryDate"].ToString());
                        dtSearch.Rows[i]["ExpiresOn"] = date.Year;
                        //
                        tspan = date.Subtract(DateTime.Now);
                        if (tspan.TotalDays <= 0)
                        {
                            count = count + 1;
                        }
                    }
                   
                }
                lblCount.Text = count.ToString();
                //
                dgvExpiredProduct.DataSource = "";
                dgvExpiredProduct.DataSource = dtSearch;
                //
                cmbFilter.SelectedIndex = -1;
                chkExpired.Checked = false;
                chkNotExpired.Checked = false;
                //
                
                lblStatus.Text = "Search report";
                AdjustColumnIndex();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvExpiredProduct_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name.Trim().ToLower().ToString() == "productname" )
            {
                e.Column.HeaderText = "Product";
            }
            else if (e.Column.Name.Trim().ToLower().ToString() == "categoryname")
            {
                e.Column.HeaderText = "Category";
            }
            else if (e.Column.Name.Trim().ToLower().ToString() == "purchaseprice")
            {
                e.Column.HeaderText = "Purchase Price";
            }
            else if (e.Column.Name.Trim().ToLower().ToString() == "retailprice")
            {
                e.Column.HeaderText = "Retail Price";
            }
            else if (e.Column.Name.Trim().ToLower().ToString() == "availablestock")
            {
                e.Column.HeaderText = "Available Stock";
            }
            else if (e.Column.Name.Trim().ToLower().ToString() == "expirydate")
            {
                e.Column.HeaderText = "ExpiryDate";
            }
            else if (e.Column.Name.Trim().ToLower().ToString() == "expireson")
            {
                e.Column.HeaderText = "ExpiresOn";
                e.Column.DefaultCellStyle.BackColor = Color.Black;
                e.Column.DefaultCellStyle.ForeColor = Color.White;
                e.Column.DefaultCellStyle.Font = new Font("SegoeUI",12,FontStyle.Bold);
            }
            else
            {
                e.Column.Visible = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            cmbFilter.SelectedIndex = -1;

        }

        private void chkExpired_Click(object sender, EventArgs e)
        {
            chkExpired.Checked = true;
            chkNotExpired.Checked = false;
            cmbFilter.SelectedIndex = -1;
            //
            DateTime tempdate = new DateTime();
            DataTable dtTemp = new DataTable();
            if (LoadMode == true)
            {
                dtTemp = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempdate = DateTime.Parse(dt.Rows[i]["ExpiryDate"].ToString());
                    if (tempdate.Date <= DateTime.Now.Date)
                    {
                        dtTemp.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                dgvExpiredProduct.DataSource = dtTemp;
            }
            else if (SearchMode == true)
            {
                dtTemp = dtSearch.Clone();
                for (int i = 0; i < dtSearch.Rows.Count; i++)
                {
                    tempdate = DateTime.Parse(dtSearch.Rows[i]["ExpiryDate"].ToString());
                    if (tempdate.Date <= DateTime.Now.Date)
                    {
                        dtTemp.Rows.Add(dtSearch.Rows[i].ItemArray);
                    }
                }
                dgvExpiredProduct.DataSource = dtTemp;
            }
            lblCount.Text = dtTemp.Rows.Count.ToString();
            AdjustColumnIndex();

        }

        private void chkNotExpired_Click(object sender, EventArgs e)
        {
            chkExpired.Checked = false;
            chkNotExpired.Checked = true;
            cmbFilter.SelectedIndex = -1;
            //
            DateTime tempdate = new DateTime();
            DataTable dtTemp = new DataTable();
            if (LoadMode == true)
            {
                dtTemp = dt.Clone();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempdate = DateTime.Parse(dt.Rows[i]["ExpiryDate"].ToString());
                    if (tempdate.Date > DateTime.Now.Date)
                    {
                        dtTemp.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                dgvExpiredProduct.DataSource = dtTemp;

            }
            else if (SearchMode == true)
            {
                dtTemp = dtSearch.Clone();
                for (int i = 0; i < dtSearch.Rows.Count; i++)
                {
                    tempdate = DateTime.Parse(dtSearch.Rows[i]["ExpiryDate"].ToString());
                    if (tempdate.Date > DateTime.Now.Date)
                    {
                        dtTemp.Rows.Add(dtSearch.Rows[i].ItemArray);
                    }
                }
                dgvExpiredProduct.DataSource = dtTemp;
            }
            lblCount.Text = "0";
            AdjustColumnIndex();
        }

        private void cmbFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkExpired.Checked = false;
            chkNotExpired.Checked = false;
            int count = 0;
            if (cmbFilter.SelectedIndex == 0)//{0:DAY}
            {
                try
                {

                    DataView dv = dt.DefaultView;
                    dv.Sort = "ExpiryDate desc";
                    DataTable dtDay = dv.ToTable();
                    //
                    DateTime date = new DateTime();
                    TimeSpan timesp;
                    for (int i = 0; i < dtDay.Rows.Count; i++)
                    {
                        date = DateTime.Parse(dtDay.Rows[i]["ExpiryDate"].ToString());
                        timesp = date.Subtract(DateTime.Now);
                        if (timesp.TotalDays <= 0)
                        {
                            count = count + 1;
                        }
                        if (date > DateTime.Now) //going to expire
                        {
                            dtDay.Rows[i]["ExpiresOn"] = timesp.Days;
                        }
                        else if (date <= DateTime.Now) //already expired
                        {
                            dtDay.Rows[i]["ExpiresOn"] = timesp.Days;
                        }
                    }
                    //
                    dgvExpiredProduct.DataSource = "";
                    dgvExpiredProduct.DataSource = dtDay;
                    //
                    lblCount.Text = count.ToString();
                    lblStatus.Text = "...DAY filter";
                    //
                    AdjustColumnIndex();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else if (cmbFilter.SelectedIndex == 1)//{1:Month}
            {
                count = 0;
                try
                {
                    DataView dv = dt.DefaultView;
                    dv.Sort = "AvailableStock desc";
                    DataTable dtMonth = dv.ToTable();

                    DateTime date = new DateTime();
                    int Months = 0;
                    Dictionary<int, string> IMonths = new Dictionary<int, string>() {
                        {1,"January" },
                        {2,"February" },
                        {3,"March" },
                        {4,"April" },
                        {5,"May" },
                        {6,"June" },
                        {7,"July" },
                        {8,"August" },
                        {9,"September" },
                        {10,"October" },
                        {11,"November" },
                        {12,"December" }

                    };
                    TimeSpan timesp;
                    for (int i = 0; i < dtMonth.Rows.Count; i++)
                    {
                        date = DateTime.Parse(dtMonth.Rows[i]["ExpiryDate"].ToString());
                        // Months = ((date.Year - DateTime.Now.Year) * 12) + (date.Month - DateTime.Now.Month);
                        Months = date.Month;
                        dtMonth.Rows[i]["ExpiresOn"] = IMonths[Months];
                        timesp = date.Subtract(DateTime.Now);
                        if (timesp.TotalDays <= 0)
                        {
                            count = count + 1;
                        }
                    }
                    //
                    dgvExpiredProduct.DataSource = "";
                    dgvExpiredProduct.DataSource = dtMonth;
                    //
                    lblCount.Text = count.ToString();
                    lblStatus.Text = "...Months filter";
                    //
                    AdjustColumnIndex();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else if (cmbFilter.SelectedIndex == 2)//{2:Year}
            {
                count = 0;
                try
                {
                    DataView dv = dt.DefaultView;
                    dv.Sort = "AvailableStock asc";
                    DataTable dtYear = dv.ToTable();
                    //
                    DateTime date = new DateTime();
                    TimeSpan timeSpan;
                    for (int i = 0; i < dtYear.Rows.Count; i++)
                    {
                        date = DateTime.Parse(dtYear.Rows[i]["ExpiryDate"].ToString());
                        dtYear.Rows[i]["ExpiresOn"] = date.Year;
                        timeSpan = date.Subtract(DateTime.Now);
                        if (timeSpan.TotalDays <= 0)
                        {
                            count = count + 1;
                        }
                    }
                    //
                    dgvExpiredProduct.DataSource = "";
                    dgvExpiredProduct.DataSource = dtYear;
                    //
                    lblCount.Text = count.ToString();
                    lblStatus.Text = "...Year filter";
                    //
                    AdjustColumnIndex();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
