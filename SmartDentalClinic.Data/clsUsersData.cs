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
        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName,
                                                 ref string Password, ref int RoleID,
                                                 ref bool IsActive)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_GetUserInfoByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                UserID = (int)reader["UserID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                RoleID = (int)reader["RoleID"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetUserInfoByPersonID), ex.Message);
                    }
                }
            }
            return IsFound;
        }
        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName,
                                         ref string Password, ref int RoleID,
                                         ref bool IsActive)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_GetUserInfoByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                PersonID = (int)reader["PersonID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                RoleID = (int)reader["RoleID"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetUserInfoByUserID), ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static bool GetUserInfoByUserUserName(string UserName, ref int PersonID, ref int UserID,
                                         ref string Password, ref int RoleID,
                                         ref bool IsActive)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_GetUserInfoByUsername", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                Password = (string)reader["Password"];
                                RoleID = (int)reader["RoleID"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetUserInfoByUserUserName), ex.Message);
                    }
                }
            }
            return IsFound;
        }

        //For Login Screen, we will use this method to get the user information by username and password.
        public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password,
                                                            ref int PersonID, ref int UserID,
                                                            ref int RoleID, ref bool IsActive)
        {

            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Users_GetUserInfoByUsernameAndPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                RoleID = (int)reader["RoleID"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetUserInfoByUserNameAndPassword), ex.Message);
                    }
                }
            }
            return IsFound;

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

        public static async Task<bool> ChangeUserStatusAsync(int UserID, bool IsActive)
        {
            int RowsAffected = 0;
            string Procedure = IsActive == true ? "SP_Users_ActivateUser" : "SP_Users_DeactivateUser";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Procedure, connection))
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
                        LocalLogError(nameof(ChangeUserStatusAsync), ex.Message);
                    }
                }
            }
            return (RowsAffected > 0);
        }
    }
}