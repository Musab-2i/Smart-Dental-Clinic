using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.DTOs
{
    public class PatientsDTO
    {
        // Patient Information
        public int PatientID { get; set; }
        public bool IsActive { get; set; }

        // Person Information
        public int PersonID { get; set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int NationalCountryID { get; set; }
        public string ImagePath { get; set; }

        // Audit Information
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
