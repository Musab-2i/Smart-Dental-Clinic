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
    public static class clsAppointmentsData
    {
        private static void LocalLogError(string FuncName, string ErrorMessage)
        {
            clsDataAccessSettings.ErrorFormating(FuncName, ErrorMessage, "clsAppointmentsData");
        }

        public static async Task<List<UpcomingAppointmentDTO>> GetUpcomingAppointmentsAsync()
        {
            List<UpcomingAppointmentDTO> upcomingAppointments = new List<UpcomingAppointmentDTO>();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_Dashboard_Receptionist_GetTodaysAppointments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                UpcomingAppointmentDTO appointment = new UpcomingAppointmentDTO
                                {
                                    AppointmentID = reader.GetInt32(reader.GetOrdinal("AppointmentID")),
                                    PatientName = reader.GetString(reader.GetOrdinal("PatientName")),
                                    StartAt = reader.GetTimeSpan(reader.GetOrdinal("StartAt")),
                                    DoctorName = reader.GetString(reader.GetOrdinal("DoctorName")),
                                    AppointmentStatus = reader.GetString(reader.GetOrdinal("AppointmentStatus"))

                                };
                                upcomingAppointments.Add(appointment);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LocalLogError(nameof(GetUpcomingAppointmentsAsync), ex.Message);
                        throw;
                    }
                }
            }
            return upcomingAppointments;
        }
    }
}
