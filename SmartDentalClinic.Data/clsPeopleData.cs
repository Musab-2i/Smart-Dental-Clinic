using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Data
{
    public class PersonDTO
    {
        public int PersonID { get; set; }
        public int NationalCountryID { get; set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
    }
    public class clsPeopleData
    {
        private static void LocalLogError(string FuncName, string ErrorMessage)
        {
            clsDataAccessSettings.ErrorFormating(FuncName, ErrorMessage, "clsPersonData");
        }
        public static async Task<int> AddNewPersonAsync(int NationalCountryID, string NationalID,
                               string FirstName, string SecondName, string ThirdName,
                               string LastName, string Address, string PhoneNo,
                               string Email, string ImagePath, DateTime DateOfBirth,
                               byte Gender)
        {
            int PersonID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_People_AddNewPerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NationalID", NationalID);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                    command.Parameters.AddWithValue("@NationalCountryID", NationalCountryID);

                    // الحقول التي تسمح بـ NULL
                    command.Parameters.AddWithValue("@ThirdName", (string.IsNullOrEmpty(ThirdName)) ? (object)DBNull.Value : ThirdName);
                    command.Parameters.AddWithValue("@Email", (string.IsNullOrEmpty(Email)) ? (object)DBNull.Value : Email);
                    command.Parameters.AddWithValue("@ImagePath", (string.IsNullOrEmpty(ImagePath)) ? (object)DBNull.Value : ImagePath);

                    SqlParameter outputIdParam = new SqlParameter("@PersonID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                        PersonID = (int)outputIdParam.Value;
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(AddNewPersonAsync), ex.Message);
                    }
                }
            }
            return PersonID;
        }

        public static async Task<bool> UpdatePersonAsync(int PersonID, int NationalCountryID,
                               string NationalID, string FirstName, string SecondName, string ThirdName,
                               string LastName, string Address, string PhoneNo,
                               string Email, string ImagePath, DateTime DateOfBirth,
                               byte Gender)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_People_UpdatePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@NationalID", NationalID);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                    command.Parameters.AddWithValue("@NationalCountryID", NationalCountryID);

                    // التعامل مع الحقول التي تسمح بـ NULL
                    command.Parameters.AddWithValue("@ThirdName", (string.IsNullOrEmpty(ThirdName)) ? (object)DBNull.Value : ThirdName);
                    command.Parameters.AddWithValue("@Email", (string.IsNullOrEmpty(Email)) ? (object)DBNull.Value : Email);
                    command.Parameters.AddWithValue("@ImagePath", (string.IsNullOrEmpty(ImagePath)) ? (object)DBNull.Value : ImagePath);

                    try
                    {
                        await connection.OpenAsync();
                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(UpdatePersonAsync), ex.Message);
                    }
                }
            }
            return (RowsAffected > 0);
        }

        public static Task<PersonDTO> GetPersonInfoByPersonIDAsync(int personID)
        {
            return GetPersonInfoAsync(
                "SP_People_GetPersonInfoByPersonID",
                "@PersonID",
                personID);
        }

        public static Task<PersonDTO> GetPersonInfoByNationalIDAsync(string nationalID)
        {
            return GetPersonInfoAsync(
                "SP_People_GetPersonInfoByNationalID",
                "@NationalID",
                nationalID);
        }
        private static async Task<PersonDTO> GetPersonInfoAsync(string storedProcedure, string parameterName,
                                                                object parameterValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue(parameterName, parameterValue ?? DBNull.Value);

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (!await reader.ReadAsync()) return null;

                        return new PersonDTO
                        {
                            PersonID = Convert.ToInt32(reader["PersonID"]),
                            NationalCountryID = Convert.ToInt32(reader["NationalCountryID"]),

                            NationalID = Convert.ToString(reader["NationalID"]),
                            FirstName = Convert.ToString(reader["FirstName"]),
                            SecondName = Convert.ToString(reader["SecondName"]),
                            ThirdName = reader["ThirdName"] == DBNull.Value ? "" : Convert.ToString(reader["ThirdName"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            Address = Convert.ToString(reader["Address"]),
                            PhoneNo = Convert.ToString(reader["PhoneNo"]),

                            Email = reader["Email"] == DBNull.Value ? "" : Convert.ToString(reader["Email"]),
                            ImagePath = reader["ImagePath"] == DBNull.Value ? "" : Convert.ToString(reader["ImagePath"]),

                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Gender = Convert.ToByte(reader["Gender"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                LocalLogError(
                    nameof(GetPersonInfoAsync), $"{storedProcedure}: {ex}");

                return null;
            }
        }
        public static async Task<bool> DeletePersonAsync(int PersonID)
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_People_DeletePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        await connection.OpenAsync();
                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(DeletePersonAsync), ex.Message);
                    }
                }
            }
            return (RowsAffected > 0);
        }

        public static async Task<bool> CheckPersonExistByPersonIDAsync(int PersonID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_People_CheckPersonExistByPersonID", connection))
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
                        LocalLogError(nameof(CheckPersonExistByPersonIDAsync), ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static async Task<bool> CheckPersonExistByNationalIDAsync(string NationalID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_People_CheckPersonExistByNationalID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalID", NationalID);

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
                        LocalLogError(nameof(CheckPersonExistByNationalIDAsync), ex.Message);
                    }
                }
            }
            return IsFound;
        }
    }
}
