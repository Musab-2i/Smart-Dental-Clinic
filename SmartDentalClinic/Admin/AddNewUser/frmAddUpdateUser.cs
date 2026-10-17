using SmartDentalClinic.Admin.People;
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
        public frmAddUpdateUser()
        {
            InitializeComponent();
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
    }
}
