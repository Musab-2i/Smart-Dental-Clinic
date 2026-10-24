using SmartDentalClinic.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Business
{
    public class clsAdminDashboard
    {
        public int ActiveUsers { get; set; }
        public int TotalPatients { get; set; }
        public int AppointmentsToday { get; set; }
        public int UnpaidInvoices { get; set; }

        private clsAdminDashboard(DashboardSummaryDTO dto)
        {
            ActiveUsers = dto.ActiveUsers;
            TotalPatients = dto.TotalPatients;
            AppointmentsToday = dto.AppointmentsToday;
            UnpaidInvoices = dto.UnpaidInvoices;
        }

        public static async Task<clsAdminDashboard> GetSummaryAsync()
        {
            DashboardSummaryDTO dto =
                await clsAdminDashboardData.GetDashboardSummaryAsync();

            if (dto == null)
                return null;

            return new clsAdminDashboard(dto);
        }

        public static async Task<DataTable> GetUsersCountByRoleAsync()
        {
            return await clsAdminDashboardData.GetUsersCountByRoleAsync();
        }
    }
}
