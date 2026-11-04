using SmartDentalClinic.Business;
using SmartDentalClinic.GlobalClass;
using SmartDentalClinic.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic.GlobalUserControls
{
    public partial class ctrlDashboardHeader : UserControl
    {
        public ctrlDashboardHeader()
        {
            InitializeComponent();
        }
        private string _descriptionText = "Here's what's happening at your clinic today.";
        private string _motivationText = "Have a great day at the clinic!";
        
        [Category("Dashboard Content")]
        [Description("Gets or sets the dashboard description text.")]
        public string DescriptionText
        {
            get { return _descriptionText; }
            set
            {
                _descriptionText = value;
                lblDescription.Text = _descriptionText;
            }
        }
        [Category("Dashboard Content")]
        [Description("Gets or sets the motivational message.")]
        public string MotivationText
        {
            get { return _motivationText; }
            set
            {
                _motivationText = value;
                lblMotivation.Text = _motivationText;
            }
        }
        private void LoadPersonImage()
        {
            pbUserImage.Image =
                clsGlobal.CurrentUser.PersonInfo.Gender == 0
                ? Resources.manSmallUserCard
                : Resources.womanSmallUserCard;
        }
        private void LoadPersonRole()
        {
            switch(clsGlobal.CurrentUser.RoleID)
            {
                case (int)clsRoles.enRolesIDs.Administrator:
                    lblUserRole.Text = "Administrator";
                    break;
                case (int)clsRoles.enRolesIDs.Doctor:
                    lblUserRole.Text = "Doctor";
                    break;
                case (int)clsRoles.enRolesIDs.Receptionist:
                    lblUserRole.Text = "Receptionist";
                    break;
                default:
                    lblUserRole.Text = "Unknown Role";
                    break;
            }
        }
        public void LoadData()
        {
            lblDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblGreeting.Text = clsFormat.GetGreeting() + ", ";
            string personName = clsGlobal.CurrentUser.PersonInfo.FirstName;
            lblUserName.Text = personName;
            lblUsername2.Text = personName;
            LoadPersonImage();
            LoadPersonRole();
        }
    }
}
