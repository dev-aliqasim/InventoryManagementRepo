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
    public partial class frmDashboard_Setting : Form
    {
        public frmDashboard_Setting()
        {
            InitializeComponent();
            LoadForm(new frmManageLogins());
        }
        public void LoadForm(object sourceForm)
        {
            if (this.panelSettingBody.Controls.Count >0)
            {
                this.panelSettingBody.Controls.RemoveAt(0);
            }
            Form f = sourceForm as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panelSettingBody.Controls.Add(f);
            this.panelSettingBody.Tag = f;
            f.Show();
        }
        private void lblEmployee_Click(object sender, EventArgs e)
        {
            LoadForm(new frmEmployees() );
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            LoadForm(new frmManageLogins());
        }
    }
}
