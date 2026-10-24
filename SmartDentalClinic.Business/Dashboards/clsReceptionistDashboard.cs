using SmartDentalClinic.Data.Dashboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Business.Dashboards
{
    public class clsReceptionistDashboard
    {
        public int TodaysAppointments { get; private set; }
        public int Waiting { get; private set; }
        public int NewPatients { get; private set; }

        private clsReceptionistDashboard(ReceptionistDashboardDTO dto)
        {
            this.TodaysAppointments = dto.TodaysAppointments;
            this.Waiting = dto.Waiting;
            this.NewPatients = dto.NewPatients;
        }

        public static async Task<clsReceptionistDashboard> GetStatsAsync()
        {
            ReceptionistDashboardDTO dto =
                await clsReceptionistDashboardData.GetDashboardStatsAsync();

            if (dto == null)
                return null;

            return new clsReceptionistDashboard(dto);
        }

    }
}
