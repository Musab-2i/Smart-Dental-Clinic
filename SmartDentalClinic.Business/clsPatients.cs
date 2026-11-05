using SmartDentalClinic.Business;
using SmartDentalClinic.Data;
using SmartDentalClinic.DTOs;
using System;
using System.Threading.Tasks;

public class clsPatients
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

    // Person Information
    public clsPeople PersonInfo { get; set; }

    // Additional Properties
    public int CreatedByUserID { get; set; }
    public DateTime CreatedDate { get; set; }


    // Default Constructor
    public clsPatients()
    {
        PatientID = -1;
        IsActive = true;

        PersonInfo = new clsPeople();

        CreatedByUserID = -1;
        CreatedDate = DateTime.Now;

        Mode = enMode.AddNewPatient;
    }


    // Private Constructor
    private clsPatients(PatientsDTO patientDTO, clsPeople personInfo)
    {
        PatientID = patientDTO.PatientID;
        IsActive = patientDTO.IsActive;

        PersonInfo = personInfo;

        CreatedByUserID = patientDTO.CreatedByUserID;
        CreatedDate = patientDTO.CreatedDate;

        Mode = enMode.UpdatePatient;
    }


    // Create Patient Object
    private static async Task<clsPatients> CreateAsync(PatientsDTO patientDTO)
    {
        clsPeople personInfo = await clsPeople.FindAsync(patientDTO.PersonID);

        if (personInfo == null)
            return null;

        return new clsPatients(patientDTO, personInfo);
    }


    // Add New Patient
    private async Task<bool> _AddNewPatient()
    {
        PatientsDTO patient = new PatientsDTO
        {
            NationalID = PersonInfo.NationalID,
            FirstName = PersonInfo.FirstName,
            SecondName = PersonInfo.SecondName,
            ThirdName = PersonInfo.ThirdName,
            LastName = PersonInfo.LastName,
            DateOfBirth = PersonInfo.DateOfBirth,
            Gender = PersonInfo.Gender,
            Address = PersonInfo.Address,
            PhoneNo = PersonInfo.PhoneNo,
            Email = PersonInfo.Email,
            NationalCountryID = PersonInfo.NationalCountryID,
            ImagePath = PersonInfo.ImagePath,

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

            NationalID = PersonInfo.NationalID,
            FirstName = PersonInfo.FirstName,
            SecondName = PersonInfo.SecondName,
            ThirdName = PersonInfo.ThirdName,
            LastName = PersonInfo.LastName,
            DateOfBirth = PersonInfo.DateOfBirth,
            Gender = PersonInfo.Gender,
            Address = PersonInfo.Address,
            PhoneNo = PersonInfo.PhoneNo,
            Email = PersonInfo.Email,
            NationalCountryID = PersonInfo.NationalCountryID,
            ImagePath = PersonInfo.ImagePath,

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