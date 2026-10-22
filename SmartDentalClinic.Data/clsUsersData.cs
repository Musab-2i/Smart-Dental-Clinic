using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Data
{
    static public class clsUsersData
    {
        private static void LocalLogError(string FuncName, string ErrorMessage)
        {
            clsDataAccessSettings.ErrorFormating(FuncName, ErrorMessage, "clsUsersData");
        }

        public static async Task<int> AddNewUserAsync(int PersonID, string UserName,
                                     string Password, int RoleID,
                                     bool IsActive)
        {
            int UserID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_AddNewUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    SqlParameter outputIDparam = new SqlParameter("@UserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output,
                    };
                    command.Parameters.Add(outputIDparam);
                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                        UserID = (int)outputIDparam.Value;
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(AddNewUserAsync), ex.Message);
                    }
                }
            }
            return UserID;
        }
        public static async Task<bool> UpdateUserAsync(int UserID, int PersonID,
                                      string UserName, string Password,
                                      int RoleID, bool IsActive)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_UpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        await connection.OpenAsync();
                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(UpdateUserAsync), ex.Message);
                    }
                }
            }
            return (RowsAffected > 0);
        }
        public static async Task<bool> UpdatePasswordAsync(int UserID, string Password)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_UpdatePassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        await connection.OpenAsync();
                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(UpdatePasswordAsync), ex.Message);
                    }
                }
            }
            return (RowsAffected > 0);
        }

        // i'll Remove retrevail Password for security reasons, as it is not a good practice to retrieve passwords from the database.
        public static async Task<UserDTO> GetUserInfoByPersonIDAsync(int PersonID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_GetUserInfoByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new UserDTO
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = PersonID,
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    RoleID = (int)reader["RoleID"],
                                    IsActive = (bool)reader["IsActive"]
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetUserInfoByPersonIDAsync), ex.Message);
                    }
                }
            }
            return null;
        }
        public static async Task<UserDTO> GetUserInfoByUserIDAsync(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_GetUserInfoByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new UserDTO
                                {
                                    UserID = UserID,
                                    PersonID = (int)reader["PersonID"],
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    RoleID = (int)reader["RoleID"],
                                    IsActive = (bool)reader["IsActive"]
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetUserInfoByUserIDAsync), ex.Message);
                    }
                }
            }
            return null;
        }
        public static async Task<UserDTO> GetUserInfoByUserUserNameAsync(string UserName)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_GetUserInfoByUsername", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new UserDTO
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = UserName,
                                    Password = (string)reader["Password"],
                                    RoleID = (int)reader["RoleID"],
                                    IsActive = (bool)reader["IsActive"]
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetUserInfoByUserUserNameAsync), ex.Message);
                    }
                }
            }
            return null;
        }

        //For Login Screen, we will use this method to get the user information by username and password.
        public static async Task<UserDTO> GetUserInfoByUserNameAndPasswordAsync(string UserName, string Password)
        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_GetUserInfoByUsernameAndPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new UserDTO
                                {
                                    UserID = (int)reader["UserID"],
                                    PersonID = (int)reader["PersonID"],
                                    UserName = UserName,
                                    Password = Password,
                                    RoleID = (int)reader["RoleID"],
                                    IsActive = (bool)reader["IsActive"]
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetUserInfoByUserNameAndPasswordAsync), ex.Message);
                    }
                }
            }
            return null;

        }

        public static async Task<bool> IsUserExistByPersonIDAsync(int PersonID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_IsUserExistByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    command.Parameters.Add(returnParameter);

                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                        IsFound = (int)returnParameter.Value == 1;
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(IsUserExistByPersonIDAsync), ex.Message);

                    }
                }
            }
            return IsFound;
        }

        public static async Task<bool> IsUserExistByUserNameAsync(string UserName)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_IsUserExistByUserName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", UserName);

                    SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    command.Parameters.Add(returnParameter);

                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                        IsFound = (int)returnParameter.Value == 1;
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(IsUserExistByUserNameAsync), ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static async Task<bool> DeleteUserAsync(int UserID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_DeleteUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        await connection.OpenAsync();
                        RowsAffected = await command.ExecuteNonQueryAsync();

                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(DeleteUserAsync), ex.Message);
                    }
                }
            }
            return (RowsAffected > 0);
        }

        public static async Task<bool> ChangeUserStatusAsync(string UserName, bool IsActive)
        {
            int RowsAffected = 0;
            string Procedure = IsActive == true ? "SP_Users_ActivateUser" : "SP_Users_DeactivateUser";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        await connection.OpenAsync();
                        RowsAffected = await command.ExecuteNonQueryAsync();

                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(ChangeUserStatusAsync), ex.Message);
                    }
                }
            }
            return (RowsAffected > 0);
        }

        public static async Task<DataTable> GetAllUsersAsync()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM vw_Users_UsersList", connection))
                {
                    command.CommandType = CommandType.Text;

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
                        LocalLogError(nameof(GetAllUsersAsync), ex.Message);
                    }
                }
            }

            return dt;
        }
    }
}