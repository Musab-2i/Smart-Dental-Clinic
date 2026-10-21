using SmartDentalClinic.Admin.People;
using SmartDentalClinic.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic.Admin.AddNewUser
{
    public partial class frmAddUpdateUser : Form
    {
        private DataTable _dtUsersList = new DataTable();
        public frmAddUpdateUser()
        {
            InitializeComponent();
        }
        private async Task _FillRolesComboBox()
        {
            DataTable Roles = await clsRoles.GetRolesListAsync();
            foreach (DataRow Role in Roles.Rows)
            {
                cbRoles.Items.Add(Role["RoleName"]);
            }
            cbRoles.SelectedIndex = cbRoles.FindString("Administrator");
        }
        private void _CalculatTotalUsers()
        {
            lblDataRecords.Text = dgvUsers.Rows.Count.ToString();
        }
        private async Task _RefreshUsersList()
        {
            _dtUsersList = await clsUsers.GetAllUsersListAsync();

            _dtUsersList = _dtUsersList.DefaultView.ToTable(false, "Name", "UserName", "RoleName", "Status", "PhoneNo");

            dgvUsers.DataSource = _dtUsersList;

            _CalculatTotalUsers();
        }
        private async void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            await _FillRolesComboBox();
            await _RefreshUsersList();

            cbFilterBy.SelectedIndex = 0;

            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["Name"].HeaderText = "Full Name";
                dgvUsers.Columns["UserName"].HeaderText = "Username";
                dgvUsers.Columns["RoleName"].HeaderText = "Role";
                //dgvUsers.Columns["IsActive"].Visible = false; 
                dgvUsers.Columns["Status"].HeaderText = "Status";
                dgvUsers.Columns["PhoneNo"].HeaderText = "Phone Number";
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frmAddUpdateUser = new frmAddUpdatePerson(-1);
            frmAddUpdateUser.OnPersonAdded += (s, args) =>
            {
                txtFullName.Text = args.FullName;
                lblPersonID.Text = args.PersonID.ToString();
            };
            frmAddUpdateUser.ShowDialog();
        }

        private void ctrlFindPersonInfoFilter1_OnPersonSelected(object sender, People.Controls.ctrlFindPersonInfoFilter.DataBackEventArgs e)
        {
            txtFullName.Text = e.FullName;
            lblPersonID.Text = e.PersonID.ToString();
        }

        private async void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsUsers User = new clsUsers();
            User.PersonID = Convert.ToInt32(lblPersonID.Text);
            User.UserName = txtUserName.Text.Trim();
            User.Password = txtPassword.Text.Trim();
            User.RoleID = (int)(await clsRoles.FindAsync(cbRoles.Text)).RoleID;
            // Assume that the user is active by default when created
            User.IsActive = true;

            if (await User.SaveAsync())
            {
                MessageBox.Show("User created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to create user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandlingNullValues(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "This field is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, null);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActiveFilter.Visible = true;
                cbIsActiveFilter.Focus();
                cbIsActiveFilter.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActiveFilter.Visible = false;
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            // Map Selected Filter to real Column name based on View columns
            switch (cbFilterBy.Text)
            {
                case "Full Name":
                    FilterColumn = "Name";
                    break;

                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Role":
                    FilterColumn = "RoleName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;

                case "Phone":
                    FilterColumn = "PhoneNo";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            // Reset the filters in case nothing selected or filter value contains nothing.
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text) || FilterColumn == "None")
            {
                _dtUsersList.DefaultView.RowFilter = "";
                _CalculatTotalUsers();
                return;
            }

            // Apply RowFilter (Since all these columns in the View are text/string types, we use LIKE for flexible searching)
            _dtUsersList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim().Replace("'", "''"));

            _CalculatTotalUsers();
        }
    }
}
