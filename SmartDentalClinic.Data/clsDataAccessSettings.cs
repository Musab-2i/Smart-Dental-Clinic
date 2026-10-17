using System;
using System.Configuration;
using System.Diagnostics;


namespace SmartDentalClinic.Data
{
    internal class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["SmartDentalClinic_Connection"].ConnectionString;

        public static void LogError(string ErrorMessage, string sourceName)
        {
            sourceName = "SmartDentalClinic";
            try
            {
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                EventLog.WriteEntry(sourceName, ErrorMessage, EventLogEntryType.Error);

            }
            catch
            {
                // لا نفعل شيئاً هنا حتى لا ينهار البرنامج إذا فشل تسجيل الخطأ
            }
        }
    }
}
