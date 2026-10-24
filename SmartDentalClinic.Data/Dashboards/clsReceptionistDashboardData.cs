using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Data.Dashboards
{
    public class ReceptionistDashboardDTO
    {
        public int TodaysAppointments { get; set; }
        public int Waiting { get; set; }
        public int NewPatients { get; set; }
    }
    public static class clsReceptionistDashboardData
    {
        private static void LocalLogError(string FuncName, string ErrorMessage)
        {
            clsDataAccessSettings.ErrorFormating(FuncName, ErrorMessage, "clsReceptionistDashboardData");
        }

        public static async Task<ReceptionistDashboardDTO> GetDashboardStatsAsync()
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Dashboard_Receptionist_GetReceptionistDashboardStats", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new ReceptionistDashboardDTO
                                {
                                    TodaysAppointments = (int)reader["TodaysAppointments"],
                                    Waiting = (int)reader["Waiting"],
                                    NewPatients = (int)reader["NewPatients"]
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetDashboardStatsAsync), ex.Message);
                    }
                }
            }
            return null;
        }

    }
}
