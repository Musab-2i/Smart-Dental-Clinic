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
using static SmartDentalClinic.Admin.People.frmAddUpdatePerson;

namespace SmartDentalClinic.Admin.AddNewUser
{
    public partial class frmAddUpdateUser : Form
    {
        private DataTable _dtUsersList = new DataTable();
        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // التأكد من أن التلوين يطبق فقط على عمود "Status" وأن الخلية تحتوي على قيمة
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string statusValue = e.Value.ToString().Trim();

                // إذا كانت الحالة Active
                if (statusValue.Equals("Active", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.CellStyle.SelectionForeColor = Color.DarkGreen; // لون النص عند تحديد الصف
                }
                // إذا كانت الحالة Inactive
                else if (statusValue.Equals("Inactive", StringComparison.OrdinalIgnoreCase) || statusValue.Equals("In Active", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red; // لون النص عند تحديد الصف
                }
            }
        }
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
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;
            await _FillRolesComboBox();
            await _RefreshUsersList();

            cbFilterBy.SelectedIndex = 0;

            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["Name"].HeaderText = "Full Name";
                dgvUsers.Columns["Name"].Width = 170;

                dgvUsers.Columns["UserName"].HeaderText = "Username";
                dgvUsers.Columns["UserName"].Width = 100;

                dgvUsers.Columns["RoleName"].HeaderText = "Role";
                dgvUsers.Columns["RoleName"].Width = 120; 

                //dgvUsers.Columns["IsActive"].Visible = false; 
                dgvUsers.Columns["Status"].HeaderText = "Status";
                dgvUsers.Columns["Status"].Width = 80;

                dgvUsers.Columns["PhoneNo"].HeaderText = "Phone Number";
                dgvUsers.Columns["PhoneNo"].Width = 150;

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
        private async Task<bool> _CreateUserAsync()
        {
            if (!int.TryParse(lblPersonID.Text, out int personID))
            {
                MessageBox.Show("Please select a valid person first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            clsUsers User = new clsUsers();
            User.PersonID = Convert.ToInt32(lblPersonID.Text);
            User.UserName = txtUserName.Text.Trim();
            User.Password = txtPassword.Text.Trim();
            User.RoleID = (int)(await clsRoles.FindAsync(cbRoles.Text)).RoleID;
            // Assume that the user is active by default when created
            User.IsActive = true;

            return await User.SaveAsync();
        }
        private void _ClearInputFields()
        {
            txtFullName.Clear();
            lblPersonID.Text = "N/A";
            txtUserName.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            cbRoles.SelectedIndex = cbRoles.FindString("Administrator");
            ctrlFindPersonInfoFilter1.ClearInput();
        }
        private async void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (await _CreateUserAsync())
            {
                MessageBox.Show("User created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await _RefreshUsersList();
                // Clear the input fields after successful creation
                _ClearInputFields();
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
            if (cbFilterBy.Text == "Status")
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
        private bool _ValidateEmptyTextBox(TextBox txt, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "This field is required!");
                return true; // أي أنه فارغ وفيه خطأ
            }
            return false; // ليس فارغاً
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_ValidateEmptyTextBox(txtConfirmPassword, e)) return;

            else if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "The password does not match!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private async void btnReactivateUser_Click(object sender, EventArgs e)
        {
            if(await clsUsers.ReactivateUserAsync(dgvUsers.CurrentRow.Cells["UserName"].Value.ToString()))
            {
                MessageBox.Show("User reactivated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await _RefreshUsersList();
            }
            else
            {
                MessageBox.Show("Failed to reactivate user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeactivateUser_Click(object sender, EventArgs e)
        {
            if (await clsUsers.DeactivateUserAsync(dgvUsers.CurrentRow.Cells["UserName"].Value.ToString()))
            {
                MessageBox.Show("User Deactivated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await _RefreshUsersList();
            }
            else
            {
                MessageBox.Show("Failed to Deactivate user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterColumn = "Status";

            switch (cbIsActiveFilter.Text)
            {
                case "Active":
                    // تصفية السجلات للحالة النشطة فقط
                    _dtUsersList.DefaultView.RowFilter = string.Format("[{0}] = 'Active'", filterColumn);
                    break;

                case "InActive":
                case "Inactive":
                    // تصفية السجلات للحالة غير النشطة
                    _dtUsersList.DefaultView.RowFilter = string.Format("[{0}] = 'InActive'", filterColumn);
                    break;

                default:
                    // عند اختيار "All" يتم إلغاء الفلتر وعرض الكل
                    _dtUsersList.DefaultView.RowFilter = "";
                    break;
            }

            _CalculatTotalUsers();
        }
    }
}
