using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDentalClinic.DTOs;

namespace SmartDentalClinic.Data
{
    public class DashboardSummaryDTO
    {
        public int ActiveUsers { get; set; }
        public int TotalPatients { get; set; }
        public int AppointmentsToday { get; set; }
        public int UnpaidInvoices { get; set; }
    }
    public static class clsAdminDashboardData
    {
        private static void LocalLogError(string FuncName, string ErrorMessage)
        {
            clsDataAccessSettings.ErrorFormating(FuncName, ErrorMessage, "clsAdminDashboardData");
        }

        public static async Task<DashboardSummaryDTO> GetDashboardSummaryAsync()
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Dashboard_Admin_GetSummary", connection))
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
                        LocalLogError(nameof(GetDashboardSummaryAsync), ex.Message);
                    }
                }
            }
            return null; // نرجع Null في حال عدم العثور على بيانات أو حدوث خطأ
        }

        public static async Task<List<RoleUserCountDTO>> GetUsersCountByRoleAsync()
        {
            List<RoleUserCountDTO> roles = new List<RoleUserCountDTO>();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Dashboard_Admin_GetUsersCountByRole", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                RoleUserCountDTO role = new RoleUserCountDTO
                                {
                                    RoleName = reader["Role"].ToString(),
                                    UserCount = Convert.ToInt32(reader["UserCount"])
                                };
                                roles.Add(role);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetUsersCountByRoleAsync), ex.Message);
                    }
                }
            }
            return roles;
        }
    }
}
