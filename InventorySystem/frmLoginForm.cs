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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtID.Focus();
        }

        private void performLogin()
        {
            if (txtID.Text.Length <= 0)
            {
                MessageBox.Show("Please Enter Login ID");
                txtID.Focus();
                return;
            }
            else if (txtPassword.Text.Length <= 0)
            {
                MessageBox.Show("Please Enter Password ");
                txtPassword.Focus();
                return;
            }
            else
            {
                DataTable dt = new DataTable();
                string Query = "Select * from Login where username = '" + txtID.Text.Trim().ToLower() + "' and password = '" + txtPassword.Text.Trim().ToLower() + "'  ";
                dt = General.FetchData(Query);
                if (dt.Rows.Count == 1)
                {
                    string LoginID = dt.Rows[0]["LoginID"].ToString();
                    frmLOADER loader = new frmLOADER(LoginID);
                    loader.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User Name or Password is Incorrect !");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }
            }

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            performLogin();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact Administrator\nTel. #  0315-6665512","Help",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                performLogin();

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
