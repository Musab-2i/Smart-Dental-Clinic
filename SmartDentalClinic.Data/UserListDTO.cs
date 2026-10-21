using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Data
{
    public class UserListDTO
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public string PhoneNo { get; set; }

        public UserListDTO(string name, string userName, string roleName, bool isActive, string status, string phoneNo)
        {
            Name = name;
            UserName = userName;
            RoleName = roleName;
            IsActive = isActive;
            Status = status;
            PhoneNo = phoneNo;
        }
    }
}
