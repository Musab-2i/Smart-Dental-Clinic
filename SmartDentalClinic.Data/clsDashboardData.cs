using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Data
{
    public class DashboardSummaryDTO
    {
        public int ActiveUsers { get; set; }
        public int TotalPatients { get; set; }
        public int AppointmentsToday { get; set; }
        public int UnpaidInvoices { get; set; }
    }
    public static class clsDashboardData
    {
        public static async Task<DashboardSummaryDTO> GetDashboardSummaryAsync()
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Dashboard_GetSummary", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            // استخدام ReadAsync بدلاً من Read
                            if (await reader.ReadAsync())
                            {
                                return new DashboardSummaryDTO
                                {
                                    ActiveUsers = (int)reader["ActiveUsers"],
                                    TotalPatients = (int)reader["TotalPatients"],
                                    AppointmentsToday = (int)reader["AppointmentsToday"],
                                    UnpaidInvoices = (int)reader["UnpaidInvoices"]
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // تسجيل الخطأ إن لزم الأمر
                    }
                }
            }
            return null; // نرجع Null في حال عدم العثور على بيانات أو حدوث خطأ
        }

        public static async Task<DataTable> GetUsersCountByRoleAsync()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Dashboard_GetUsersCountByRole", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // تسجيل الخطأ
                    }
                }
            }
            return dt;
        }
    }
}
