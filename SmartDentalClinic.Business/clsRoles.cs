using SmartDentalClinic.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.Business
{
    public class clsRoles
    {
        public enum enRolesIDs { Administrator = 1, Receptionist = 2, Doctor = 3 }

        public clsRoles.enRolesIDs RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public clsRoles()
        {
            RoleID = clsRoles.enRolesIDs.Receptionist;
            RoleName = "";
            Description = "";
        }

        private clsRoles(clsRoles.enRolesIDs roleID, string roleName, string description)
        {
            RoleID = roleID;
            RoleName = roleName;
            Description = description;
        }

        public static async Task<clsRoles> FindAsync(int roleID)
        {
            if (roleID > 0)
            {
                RoleDTO roleDto = await clsRolesData.GetRoleInfoByIDAsync(roleID);
                if (roleDto != null)
                {
                    return new clsRoles((clsRoles.enRolesIDs)roleDto.RoleID, roleDto.RoleName, roleDto.Description);
                }
            }
            return null;
        }

        public static async Task<clsRoles> FindAsync(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                RoleDTO roleDto = await clsRolesData.GetRoleInfoByNameAsync(roleName);
                if (roleDto != null)
                {
                    return new clsRoles((clsRoles.enRolesIDs)roleDto.RoleID, roleDto.RoleName, roleDto.Description);
                }
            }
            return null;
        }

        public static async Task<DataTable> GetRolesListAsync()
        {
            return await clsRolesData.GetAllRolesAsync();
        }
    }
}
