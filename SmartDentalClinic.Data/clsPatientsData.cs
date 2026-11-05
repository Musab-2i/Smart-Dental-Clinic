using SmartDentalClinic.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Data
{
    public static class clsPatientsData
    {
        private static void LocalLogError(string FuncName, string ErrorMessage)
        {
            clsDataAccessSettings.ErrorFormating(FuncName, ErrorMessage, "clsPatientsData");
        }
        public static async Task<int> AddNewPatientAsync(PatientsDTO patient)
        {
            int PatientID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Patients_AddNewPatient", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NationalID", patient.NationalID);
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@SecondName", patient.SecondName);
                    command.Parameters.AddWithValue("@ThirdName", (object)patient.ThirdName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", patient.Gender);
                    command.Parameters.AddWithValue("@Address", patient.Address);
                    command.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);
                    command.Parameters.AddWithValue("@Email", (object)patient.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NationalCountryID", patient.NationalCountryID);
                    command.Parameters.AddWithValue("@ImagePath", (object)patient.ImagePath ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedByUserID", patient.CreatedByUserID);

                    SqlParameter outputIDparam = new SqlParameter("@PatientID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output,
                    };

                    command.Parameters.Add(outputIDparam);

                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        PatientID = (int)outputIDparam.Value;
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(AddNewPatientAsync), ex.Message);
                    }
                }
            }
            return PatientID;
        }

        public static async Task<bool> UpdatePatientAsync(PatientsDTO patient)
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Patients_UpdatePatient", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PatientID", patient.PatientID);
                    command.Parameters.AddWithValue("@NationalID", patient.NationalID);
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@SecondName", patient.SecondName);
                    command.Parameters.AddWithValue("@ThirdName", (object)patient.ThirdName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", patient.Gender);
                    command.Parameters.AddWithValue("@Address", patient.Address);
                    command.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);
                    command.Parameters.AddWithValue("@Email", (object)patient.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NationalCountryID", patient.NationalCountryID);
                    command.Parameters.AddWithValue("@ImagePath", (object)patient.ImagePath ?? DBNull.Value);

                    try
                    {
                        await connection.OpenAsync();
                        RowsAffected = await command.ExecuteNonQueryAsync();

                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(UpdatePatientAsync), ex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static async Task<bool> ChangePatientStatusAsync(int patientID, bool IsActive)
        {
            int RowsAffected = 0;
            string Procedure = IsActive == true ? "SP_Patients_ActivatePatient" : "SP_Patients_DeactivatePatient";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PatientID", patientID);

                    try
                    {
                        await connection.OpenAsync();
                        RowsAffected = await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(ChangePatientStatusAsync), ex.Message);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static async Task<PatientsDTO> GetPatientByIDAsync(int patientID)
        {
            PatientsDTO patient = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Patients_GetPatientByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PatientID", patientID);
                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                patient = new PatientsDTO
                                {
                                    PatientID = reader.GetInt32(reader.GetOrdinal("PatientID")),
                                    PersonID = reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    NationalID = reader.GetString(reader.GetOrdinal("NationalID")),
                                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                    SecondName = reader.GetString(reader.GetOrdinal("SecondName")),
                                    ThirdName = reader.IsDBNull(reader.GetOrdinal("ThirdName")) ? null : reader.GetString(reader.GetOrdinal("ThirdName")),
                                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                    Gender = reader.GetByte(reader.GetOrdinal("Gender")),
                                    Address = reader.GetString(reader.GetOrdinal("Address")),
                                    PhoneNo = reader.GetString(reader.GetOrdinal("PhoneNo")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    NationalCountryID = reader.GetInt32(reader.GetOrdinal("NationalCountryID")),
                                    ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetPatientByIDAsync), ex.Message);
                    }
                }
            }
            return patient;
        }
    }
}