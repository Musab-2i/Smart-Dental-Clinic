using SmartDentalClinic.Business;
using SmartDentalClinic.GlobalClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if(clsGlobal.RestoreUsernameAndPasswordFromRegistry(out string username, out string password))
            {
                txtUsername.Text = username;
                txtPassword.Text = password;
                chkRememberMe.Checked = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxes_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(txt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "This field is required!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, null);
            }
        }

        private void _ShowErrorMessage(string message)
        {
            lblErrorType.Visible = true;
            lblErrorType.Text = message;
        }
        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            lblErrorType.Visible = false;

            clsGlobal.CurrentUser = await clsUsers.FindByUsernameAndPasswordAsync(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (clsGlobal.CurrentUser == null)
            {
                //MessageBox.Show("Invalid Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ShowErrorMessage("Invalid Username or Password!");
                return;
            }
            else if (clsGlobal.CurrentUser.IsActive == false)
            {
                //MessageBox.Show("Your account is Inactive, Contact your Admin.", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _ShowErrorMessage("Your account is Inactive, Contact your Admin");
                return;
            }
            else
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobal.SaveUsernameAndPasswordInRegistry(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.SaveUsernameAndPasswordInRegistry("", "");
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
