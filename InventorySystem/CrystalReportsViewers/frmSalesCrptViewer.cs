using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.CrystalReportsViewers
{
    public partial class frmSalesCrptViewer : Form
    {
        //public frmSalesRegisterViewer()
        //{
        //    InitializeComponent();
        //}

        public frmSalesCrptViewer(DataTable dt,Dictionary<string,string> dates)
        {
            InitializeComponent();
            sourceDT = dt;
            sourceDates = dates;
        }

        DataTable sourceDT = new DataTable();
        Dictionary<string, string> sourceDates;
        private void frmSalesRegisterViewer_Load(object sender, EventArgs e)
        {
            var crptSalesRegister = new CrystalReports.crptSalesRegister();
            crptSalesRegister.SetDataSource(sourceDT);

            var fromDate = DateTime.Parse(sourceDates["fromDate"]);
            var toDate = DateTime.Parse(sourceDates["toDate"]);


            crptSalesRegister.SetParameterValue("fromDate",  fromDate.ToString("dd MMM yyyy"));
            crptSalesRegister.SetParameterValue("toDate", toDate.ToString("dd MMM yyyy"));


            crptViewer.ReportSource = null;
            crptViewer.ReportSource = crptSalesRegister;
        }
    }
}
