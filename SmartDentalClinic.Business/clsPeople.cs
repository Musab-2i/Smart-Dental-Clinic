using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDentalClinic.Data;

namespace SmartDentalClinic.Business
{
    public class clsPeople
    {
        //-- int
        public int PersonID { get; set; }
        public int NationalCountryID { get; set; }
        //-- string 
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        //-- other
        public clsCountries CountrInfo;
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        private enMode Mode = enMode.AddNewPerson;

        enum enMode
        {
            AddNewPerson = 1,
            UpdatePerson = 2
        }
            
        public clsPeople()
        {
            // int 
            PersonID = -1;
            NationalCountryID = -1;
            // string
            NationalID = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Address = "";
            PhoneNo = "";
            Email = "";
            ImagePath = "";
            // other
            DateOfBirth = DateTime.Now;
            Gender = 0;
            Mode = enMode.AddNewPerson;
        }
        private clsPeople(int personID, int nationalCountryID, string nationalID, string firstName, string secondName, string thirdName, string lastName, string address, string phoneNo, string email, string imagePath, DateTime dateOfBirth, byte gender)
        {
            this.PersonID = personID;
            this.NationalCountryID = nationalCountryID;
            this.NationalID = nationalID;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNo = phoneNo;
            this.Email = email;
            this.ImagePath = imagePath;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.CountrInfo = clsCountries.Find(nationalCountryID);
            Mode = enMode.UpdatePerson;
        }
        public string FullName
        {
            get { return $"{FirstName} {SecondName} {ThirdName} {LastName}"; }
        }

        private async Task<bool> _AddNewPersonAsync()
        {
            this.PersonID = await clsPeopleData.AddNewPersonAsync(
                this.NationalCountryID,
                this.NationalID,
                this.FirstName,
                this.SecondName,
                this.ThirdName,
                this.LastName,
                this.Address,
                this.PhoneNo,
                this.Email,
                this.ImagePath,
                this.DateOfBirth,
                this.Gender
            );
            return (this.PersonID != -1);
        }
        private async Task<bool> _UpdatePersonAsync()
        {
            return await clsPeopleData.UpdatePersonAsync(
                this.PersonID,
                this.NationalCountryID,
                this.NationalID,
                this.FirstName,
                this.SecondName,
                this.ThirdName,
                this.LastName,
                this.Address,
                this.PhoneNo,
                this.Email,
                this.ImagePath,
                this.DateOfBirth,
                this.Gender
                );
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNewPerson:
                    if (await _AddNewPersonAsync())
                    {
                        Mode = enMode.UpdatePerson;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdatePerson:
                    return await _UpdatePersonAsync();
            }
            return false;
        }
        static public clsPeople Find(int PersonID)
        {
            string NationalID = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", PhoneNo = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int NationalCountryID = -1;
            if (clsPeopleData.GetPersonInfoByPersonID(PersonID, ref NationalCountryID, ref NationalID, ref FirstName,
                         ref SecondName, ref ThirdName, ref LastName, ref Address,
                         ref PhoneNo, ref Email, ref ImagePath, ref DateOfBirth,
                         ref Gender))
            {
                return new clsPeople(PersonID, NationalCountryID, NationalID, FirstName,
                          SecondName, ThirdName, LastName, Address,
                          PhoneNo, Email, ImagePath, DateOfBirth,
                          Gender);
            }
            else
            {
                return null;
            }
        }
        static public clsPeople Find(string NationalID)
        {
            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", PhoneNo = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int NationalCountryID = -1;
            if (clsPeopleData.GetPersonInfoByNationalID(NationalID, ref NationalCountryID, ref PersonID, ref FirstName,
                         ref SecondName, ref ThirdName, ref LastName, ref Address,
                         ref PhoneNo, ref Email, ref ImagePath, ref DateOfBirth,
                         ref Gender))
            {
                return new clsPeople(PersonID, NationalCountryID, NationalID, FirstName,
                          SecondName, ThirdName, LastName, Address,
                          PhoneNo, Email, ImagePath, DateOfBirth,
                          Gender);
            }
            else
            {
                return null;
            }
        }

        static public async Task <bool> CheckPersonExistByPersonIDAsync(int PersonID)
        {
            return await clsPeopleData.CheckPersonExistByPersonIDAsync(PersonID);
        }
        static public async Task<bool> CheckPersonExistByNationalIDAsync(string NationalID)
        {
            return await clsPeopleData.CheckPersonExistByNationalIDAsync(NationalID);
        }
        static public async Task<bool> DeletePersonAsync(int PersonID)
        {
            return await clsPeopleData.DeletePersonAsync(PersonID);
        }

    }
}
