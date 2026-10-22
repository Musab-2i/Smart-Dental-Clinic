using SmartDentalClinic.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Business
{
    public class clsDashboard
    {
        public int ActiveUsers { get; set; }
        public int TotalPatients { get; set; }
        public int AppointmentsToday { get; set; }
        public int UnpaidInvoices { get; set; }

        public clsDashboard()
        {
            ActiveUsers = 0;
            TotalPatients = 0;
            AppointmentsToday = 0;
            UnpaidInvoices = 0;
        }

        public static async Task<clsDashboard> GetSummaryAsync()
        {
            DashboardSummaryDTO dto = await clsDashboardData.GetDashboardSummaryAsync();

            if (dto != null)
            {
                return new clsDashboard
                {
                    ActiveUsers = dto.ActiveUsers,
                    TotalPatients = dto.TotalPatients,
                    AppointmentsToday = dto.AppointmentsToday,
                    UnpaidInvoices = dto.UnpaidInvoices
                };
            }
            return null;
        }

        public static async Task<DataTable> GetUsersCountByRoleAsync()
        {
            return await clsDashboardData.GetUsersCountByRoleAsync();
        }
    }
}
