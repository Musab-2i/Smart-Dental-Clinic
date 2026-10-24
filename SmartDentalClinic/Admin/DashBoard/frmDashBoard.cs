using SmartDentalClinic.Admin.AddNewUser;
using SmartDentalClinic.Admin.Controls;
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

namespace SmartDentalClinic.Admin.DashBoard
{
    public partial class frmDashBoard : Form
    {
        public frmDashBoard()
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
        private async Task _FillUsersByRoleGrid()
        {
            DataTable dtUsersByRole = await clsAdminDashboard.GetUsersCountByRoleAsync();

            dgvUsersByRole.DataSource = dtUsersByRole;
            if (dgvUsersByRole.Columns.Count > 0)
            {
                dgvUsersByRole.Columns["Role"].HeaderText = "Role";
                dgvUsersByRole.Columns["Role"].Width = 350;

                dgvUsersByRole.Columns["UserCount"].HeaderText = "User Count";
                dgvUsersByRole.Columns["UserCount"].Width = 155;
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
            await _FillUsersByRoleGrid();
            BindCardToForm(cardQuickAccessManageUsers, () => new frmAddUpdateUser());
        }

        //Delete This Method if you don't want to use it, it's just an example of how to use the card click event
        private void cardQuickAccessManageUsers_Click(object sender, EventArgs e)
        {
            //// بطاقة المواعيد (كمثال)
            //cardQuickAccessAppointments.OnCardClicked = () => adminMain.openChildForm(new frmAppointments());

            //// بطاقة الفواتير (كمثال)
            //cardQuickAccessBilling.OnCardClicked = () => adminMain.openChildForm(new frmBilling());
        }
    }
}
