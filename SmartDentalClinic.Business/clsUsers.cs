using SmartDentalClinic.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartDentalClinic.Business
{
    public class clsUsers
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        private string _CurrentPassword { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPeople PersonInfo;
        enMode Mode;
        enum enMode { AddNewUser = 1, UpdateUser = 2 }

        public clsUsers()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            RoleID = -1;
            IsActive = false;
            Mode = enMode.AddNewUser;
        }

        private clsUsers(int userID, int personID, int roleID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            RoleID = roleID;
            UserName = userName;
            _CurrentPassword = password;
            Password = password;
            IsActive = isActive;
            PersonInfo = clsPeople.Find(personID);

            Mode = enMode.UpdateUser;
        }

        private static string GetHashPassowrdValue(string Passowrd)
        {
            return clsBusinessUtil.ComputeHash(Passowrd);
        }

        private async Task<bool> _AddNewUser()
        {
            this.Password = GetHashPassowrdValue(this.Password);
            this.UserID = await clsUsersData.AddNewUserAsync
                (
                this.PersonID,
                this.UserName,
                this.Password,
                this.RoleID,
                this.IsActive
                );

            return (this.UserID != -1);
        }
        private async Task<bool> _UpdateUser()
        {
            string PasswordToSave = this.Password;
            //Check if the password has been changed, if yes then hash it before saving
            if (this.Password != _CurrentPassword)
            {
                PasswordToSave = GetHashPassowrdValue(this.Password);
            }

            bool IsUpdated = await clsUsersData.UpdateUserAsync
                (
                this.UserID,
                this.PersonID,
                this.UserName,
                PasswordToSave,
                this.RoleID,
                this.IsActive
                );

            if (IsUpdated)
            {
                this.Password = PasswordToSave;
                _CurrentPassword = PasswordToSave;
            }
            return IsUpdated;
        }
        private static async Task<clsUsers> _ExecuteFindAsync(Func<Task<UserDTO>> fetchFromDal)
        {
            var userData = await fetchFromDal();

            if (userData != null)
            {
                return new clsUsers(
                    userData.UserID,
                    userData.PersonID,
                    userData.RoleID,
                    userData.UserName,
                    userData.Password,
                    userData.IsActive
                );
            }
            return null;
        }
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNewUser:
                    if (await _AddNewUser())
                    {
                        Mode = enMode.UpdateUser;
                        return true;
                    }
                    return false;
                case enMode.UpdateUser:
                    return await _UpdateUser();
            }
            return false;
        }

        public static async Task<clsUsers> FindByUserIDAsync(int userID)
        {
            return await _ExecuteFindAsync(() => clsUsersData.GetUserInfoByUserIDAsync(userID));
        }

        public static async Task<clsUsers> FindByPersonIDAsync(int personID)
        {
            return await _ExecuteFindAsync(() => clsUsersData.GetUserInfoByPersonIDAsync(personID));
        }

        public static async Task<clsUsers> FindByUserNameAsync(string userName)
        {
            return await _ExecuteFindAsync(() => clsUsersData.GetUserInfoByUserUserNameAsync(userName));
        }

        public static async Task<clsUsers> FindByUsernameAndPasswordAsync(string userName, string password)
        {
            return await _ExecuteFindAsync(() => clsUsersData.GetUserInfoByUserNameAndPasswordAsync(userName, password));
        }

        public static async Task<bool> IsUserExistByPersonIDAsync(int PersonID)
        {
            return await clsUsersData.IsUserExistByPersonIDAsync(PersonID);
        }
        public static async Task<bool> IsUserExistByUserNameAsync(string UserName)
        {
            return await clsUsersData.IsUserExistByUserNameAsync(UserName);
        }
        public static async Task<bool> DeleteUserAsync(int UserID)
        {
            return await clsUsersData.DeleteUserAsync(UserID);
        }

        public async Task<bool> UpdatePasswordAsync (string NewPassword)
        {
            string HashedPassword = GetHashPassowrdValue(NewPassword);

            bool IsUpdated = await clsUsersData.UpdatePasswordAsync(this.UserID, HashedPassword);
            if (IsUpdated)
            {
                this.Password = HashedPassword;
            }

            return IsUpdated;
        }

        public static async Task<bool> ReactivateUserAsync(string UserName)
        {
            return await clsUsersData.ChangeUserStatusAsync(UserName, true);
        }
        public static async Task<bool> DeactivateUserAsync(string UserName)
        {
            return await clsUsersData.ChangeUserStatusAsync(UserName, false);
        }
        public static async Task<DataTable> GetAllUsersListAsync()
        {
            return await clsUsersData.GetAllUsersAsync();
        }
    }
}
