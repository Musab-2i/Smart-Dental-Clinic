using SmartDentalClinic.Business;
using SmartDentalClinic.Data;
using SmartDentalClinic.DTOs;
using System;
using System.Threading.Tasks;

public class clsPatients : clsPeople
{
    public enum enMode
    {
        AddNewPatient,
        UpdatePatient
    }

    public enMode Mode { get; set; }

    // Patient Properties
    public int PatientID { get; set; }
    public bool IsActive { get; set; }

    // Additional Properties
    public int CreatedByUserID { get; set; }
    public DateTime CreatedDate { get; set; }


    // Default Constructor (For Add New)
    public clsPatients()
    {
        PatientID = -1;
        IsActive = true;

        // الخصائص الموروثة من clsPeople يتم تهيئتها افتراضياً عبر الـ Base Constructor لو وجد، أو تبقيها فارغة
        CreatedByUserID = -1;
        CreatedDate = DateTime.Now;

        Mode = enMode.AddNewPatient;
    }


    // Private Constructor (For Update / Find)
    private clsPatients(PatientsDTO patientDTO)
        : base(
            patientDTO.PersonID,
            patientDTO.NationalCountryID,
            patientDTO.NationalID,
            patientDTO.FirstName,
            patientDTO.SecondName,
            patientDTO.ThirdName,
            patientDTO.LastName,
            patientDTO.Address,
            patientDTO.PhoneNo,
            patientDTO.Email,
            patientDTO.ImagePath,
            patientDTO.DateOfBirth,
            patientDTO.Gender
        )
    {
        // تعبئة خصائص المريض الخاصة به فقط
        PatientID = patientDTO.PatientID;
        IsActive = patientDTO.IsActive;
        CreatedByUserID = patientDTO.CreatedByUserID;
        CreatedDate = patientDTO.CreatedDate;

        Mode = enMode.UpdatePatient;
    }


    // Create Patient Object
    private static Task<clsPatients> CreateAsync(PatientsDTO patientDTO)
    {
        if (patientDTO == null)
            return Task.FromResult<clsPatients>(null);

        return Task.FromResult(new clsPatients(patientDTO));
    }


    // Add New Patient
    private async Task<bool> _AddNewPatient()
    {
        PatientsDTO patient = new PatientsDTO
        {
            // استخدام الخصائص الموروثة مباشرة عبر الـ this أو بدونها
            NationalID = this.NationalID,
            FirstName = this.FirstName,
            SecondName = this.SecondName,
            ThirdName = this.ThirdName,
            LastName = this.LastName,
            DateOfBirth = this.DateOfBirth,
            Gender = this.Gender,
            Address = this.Address,
            PhoneNo = this.PhoneNo,
            Email = this.Email,
            NationalCountryID = this.NationalCountryID,
            ImagePath = this.ImagePath,

            CreatedByUserID = this.CreatedByUserID
        };

        this.PatientID = await clsPatientsData.AddNewPatientAsync(patient);

        return (this.PatientID != -1);
    }


    // Update Patient
    private async Task<bool> _UpdatePatient()
    {
        PatientsDTO patient = new PatientsDTO
        {
            PatientID = this.PatientID,

            NationalID = this.NationalID,
            FirstName = this.FirstName,
            SecondName = this.SecondName,
            ThirdName = this.ThirdName,
            LastName = this.LastName,
            DateOfBirth = this.DateOfBirth,
            Gender = this.Gender,
            Address = this.Address,
            PhoneNo = this.PhoneNo,
            Email = this.Email,
            NationalCountryID = this.NationalCountryID,
            ImagePath = this.ImagePath,

            IsActive = this.IsActive
        };

        return await clsPatientsData.UpdatePatientAsync(patient);
    }


    // Save Patient
    public async Task<bool> SaveAsync()
    {
        switch (Mode)
        {
            case enMode.AddNewPatient:

                if (await _AddNewPatient())
                {
                    Mode = enMode.UpdatePatient;
                    return true;
                }

                return false;

            case enMode.UpdatePatient:

                return await _UpdatePatient();
        }

        return false;
    }


    // Find Patient By ID
    public static async Task<clsPatients> FindByPatientIDAsync(int patientID)
    {
        PatientsDTO patientDTO = await clsPatientsData.GetPatientByIDAsync(patientID);

        if (patientDTO == null)
            return null;

        return await CreateAsync(patientDTO);
    }


    // Reactivate Patient
    public static async Task<bool> ReactivatePatientAsync(int patientID)
    {
        return await clsPatientsData.ChangePatientStatusAsync(patientID, true);
    }


    // Deactivate Patient
    public static async Task<bool> DeactivatePatientAsync(int patientID)
    {
        return await clsPatientsData.ChangePatientStatusAsync(patientID, false);
    }
}