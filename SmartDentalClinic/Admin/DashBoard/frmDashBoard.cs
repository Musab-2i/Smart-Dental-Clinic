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
            clsDashboard dashboardSummary = await clsDashboard.GetSummaryAsync();
            if (dashboardSummary != null)
            {
                // 3. تمرير كل رقم للبطاقة الخاصة فيه باستخدام الخاصية Value

                // بطاقة المستخدمين النشطين
                cardActiveUsers.Value = dashboardSummary.ActiveUsers.ToString();

                // بطاقة المرضى (استخدمنا "N0" عشان يضيف فواصل الآلاف زي 1,284)
                cardPatients.Value = dashboardSummary.TotalPatients.ToString("N0");

                // بطاقة مواعيد اليوم
                cardAppointments.Value = dashboardSummary.AppointmentsToday.ToString();

                // بطاقة الفواتير غير المدفوعة
                cardInvoices.Value = dashboardSummary.UnpaidInvoices.ToString();
            }
        }
        private async Task _FillUsersByRoleGrid()
        {
            DataTable dtUsersByRole = await clsDashboard.GetUsersCountByRoleAsync();

            dgvUsersByRole.DataSource = dtUsersByRole;
            if (dgvUsersByRole.Columns.Count > 0)
            {
                dgvUsersByRole.Columns["Role"].HeaderText = "Role";
                dgvUsersByRole.Columns["Role"].Width = 350;

                dgvUsersByRole.Columns["UserCount"].HeaderText = "User Count";
                dgvUsersByRole.Columns["UserCount"].Width = 155;
            }
        }
        private async void frmDashBoard_Load(object sender, EventArgs e)
        {
            await _FillUserCtrl();
            await _FillUsersByRoleGrid();

        }
    }
}
