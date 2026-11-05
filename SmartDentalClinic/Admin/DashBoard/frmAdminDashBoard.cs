using SmartDentalClinic.Admin.AddNewUser;
using SmartDentalClinic.Admin.Controls;
using SmartDentalClinic.Business;
using SmartDentalClinic.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic.Admin.DashBoard
{
    public partial class frmAdminDashBoard : Form
    {
        public frmAdminDashBoard()
        {
            InitializeComponent();
        }
        private async Task _FillUserCtrl()
        {
            clsAdminDashboard dashboardSummary = await clsAdminDashboard.GetSummaryAsync();
            if (dashboardSummary != null)
            {
                // 3. تمرير كل رقم للبطاقة الخاصة فيه باستخدام الخاصية Value

                cardActiveUsers.Value = dashboardSummary.ActiveUsers.ToString();

                cardPatients.Value = dashboardSummary.TotalPatients.ToString("N0");

                cardAppointments.Value = dashboardSummary.AppointmentsToday.ToString();

                cardInvoices.Value = dashboardSummary.UnpaidInvoices.ToString();
            }
        }
        private void BindCardToForm(ctrlQuickAccessCard card, Func<Form> formFactory)
        {
            card.OnCardClicked = () =>
            {
                // 1. جلب الشاشة الرئيسية (الأب) المفتوحة حالياً
                AdminMain mainForm = (AdminMain)this.ParentForm;

                // 2. أمر الشاشة الرئيسية بفتح الشاشة المُمررة بداخلها
                if (mainForm != null)
                {
                    // formFactory() ستقوم بإنشاء الفورم "فقط" لحظة النقر
                    mainForm.openChildForm(formFactory());
                }
            };
        }
        private async void frmDashBoard_Load(object sender, EventArgs e)
        {
            await _FillUserCtrl();
            BindCardToForm(cardQuickAccessManageUsers, () => new frmAddUpdateUser());
            ctrlDashboardHeader1.LoadData();

            flpUsersByRole.Controls.Clear();

            List<RoleUserCountDTO> roles = await clsAdminDashboard.GetUsersCountByRoleAsync();

            foreach(RoleUserCountDTO roleUser in roles)
            {
                flpUsersByRole.Controls.Add(
                    CreateRoleCard(roleUser.RoleName, roleUser.UserCount)
                );
            }

        }

        //Delete This Method if you don't want to use it, it's just an example of how to use the card click event
        private void cardQuickAccessManageUsers_Click(object sender, EventArgs e)
        {
            //// بطاقة المواعيد (كمثال)
            //cardQuickAccessAppointments.OnCardClicked = () => adminMain.openChildForm(new frmAppointments());

            //// بطاقة الفواتير (كمثال)
            //cardQuickAccessBilling.OnCardClicked = () => adminMain.openChildForm(new frmBilling());
        }

        private Panel CreateRoleCard(string roleName, int userCount)
        {
            // Create Card
            Panel pnlCard = new Panel();

            pnlCard.Size = new Size(500, 110);
            pnlCard.BackColor = Color.White;
            pnlCard.Margin = new Padding(7);
            pnlCard.BorderStyle = BorderStyle.FixedSingle;

            // Accent Bar
            Panel pnlAccent = new Panel();

            pnlAccent.Size = new Size(5, 108);
            pnlAccent.Location = new Point(0, 0);
            pnlAccent.BackColor = Color.Teal;

            // Role Name
            Label lblRoleName = new Label();

            lblRoleName.Text = roleName;
            lblRoleName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblRoleName.ForeColor = Color.FromArgb(45, 55, 72);
            lblRoleName.Location = new Point(15, 8);
            lblRoleName.Size = new Size(475, 25);
            lblRoleName.TextAlign = ContentAlignment.MiddleCenter;
            lblRoleName.AutoEllipsis = true;

            // User Count
            Label lblUserCount = new Label();

            lblUserCount.Text = userCount.ToString();
            lblUserCount.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblUserCount.ForeColor = Color.Teal;
            lblUserCount.Location = new Point(15, 32);
            lblUserCount.Size = new Size(475, 45);
            lblUserCount.TextAlign = ContentAlignment.MiddleCenter;

            // Description
            Label lblDescription = new Label();

            lblDescription.Text = "Total Users";
            lblDescription.Font = new Font("Segoe UI", 9);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.Location = new Point(15, 78);
            lblDescription.Size = new Size(475, 20);
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;

            // Add Controls
            pnlCard.Controls.Add(pnlAccent);
            pnlCard.Controls.Add(lblRoleName);
            pnlCard.Controls.Add(lblUserCount);
            pnlCard.Controls.Add(lblDescription);

            return pnlCard;
        }
    }
}
