using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Data
{

    public class RoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }

    public class clsRolesData
    {
        private static void LocalLogError(string FuncName, string ErrorMessage)
        {
            clsDataAccessSettings.ErrorFormating(FuncName, ErrorMessage, "clsRolesData");
        }

        public static async Task<RoleDTO> GetRoleInfoByIDAsync(int RoleID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Roles_GetRoleInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new RoleDTO
                                {
                                    RoleID = (int)reader["RoleID"],
                                    RoleName = (string)reader["RoleName"],
                                    Description = (string)reader["Description"]
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetRoleInfoByIDAsync), ex.Message);
                    }
                }
            }
            return null;
        }

        public static async Task<RoleDTO> GetRoleInfoByNameAsync(string RoleName)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Roles_GetRoleInfoByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", RoleName);

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new RoleDTO
                                {
                                    RoleID = (int)reader["RoleID"],
                                    RoleName = (string)reader["RoleName"],
                                    Description = (string)reader["Description"]
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetRoleInfoByNameAsync), ex.Message);
                    }
                }
            }
            return null;
        }

        public static async Task<DataTable> GetAllRolesAsync()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Roles_GetAllRoles", connection))
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
                        LocalLogError(nameof(GetAllRolesAsync), ex.Message);
                    }
                }
            }

            return dt;
        }
    }
}
