using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.DTOs
{
    public class UpcomingAppointmentDTO
    {
        public int AppointmentID { get; set; }

        public string PatientName { get; set; }

        public TimeSpan StartAt { get; set; }

        public string DoctorName { get; set; }

        public string AppointmentStatus { get; set; }
    }
}
