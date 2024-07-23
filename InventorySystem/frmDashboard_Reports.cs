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
    public partial class frmDashboard_Reports : Form
    {
        public frmDashboard_Reports()
        {
            InitializeComponent();
        }
        public void LoadForm(Form frm)
        {
            Form f1 = frmDashboard_Reports.ActiveForm;
            f1.ActiveMdiChild.Close();
            Form newfrm = frm as Form;
            newfrm.MdiParent = f1;
            newfrm.Show();
        }
        private void lblAttendenceReport_Click(object sender, EventArgs e)
        {
            LoadForm(new frmAttendenceReport());
        }

        private void lblSalaryReport_Click(object sender, EventArgs e)
        {
            LoadForm(new frmEmployeeSalaryReport());

        }

        private void lblStockReport_Click(object sender, EventArgs e)
        {
            LoadForm(new frmProductStockReport());

        }

        private void lblExpiredProductReport_Click(object sender, EventArgs e)
        {
            LoadForm(new Reports.frmSalesInvoiceReport());

        }

        private void lblPurchaseInvoiceReport_Click(object sender, EventArgs e)
        {
            LoadForm(new Reports.frmPurchaseInvoiceReport());
        }

        private void lblSalesInvoiceReport_Click(object sender, EventArgs e)
        {
            LoadForm(new frmSalesReport());
        }

        private void lblOverAllSalesReport_Click(object sender, EventArgs e)
        {
            //LoadForm(new Reports.frmSalesInvoiceReport());

        }

        private void lblOverAllPurchaseReport_Click(object sender, EventArgs e)
        {
            //LoadForm(new Reports.frmPurchaseInvoiceReport());

        }
    }
}
