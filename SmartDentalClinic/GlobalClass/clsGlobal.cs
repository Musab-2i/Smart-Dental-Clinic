using SmartDentalClinic.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDentalClinic.GlobalClass
{
    public class clsGlobal
    {
        public static clsUsers CurrentUser;

        private static void LocalLogError(string FuncName, string ErrorMessage)
        {
            clsEventLogger.ErrorFormating(FuncName, ErrorMessage, "clsGlobal");
        }

        static public bool SaveUsernameAndPasswordInRegistry(string Username, string Password)
        {
            try
            {
                // If a blank username is passed, it means "clear my data" (cancel remember me).
                if (string.IsNullOrWhiteSpace(Username))
                {
                    if (clsRegistry.GetRegistryValue("Username") != null)
                    {
                        clsRegistry.DeleteRegistryValue("Username");
                        clsRegistry.DeleteRegistryValue("Password");
                    }
                    return true;
                }

                string EncryptedPassword = clsEncryptionDecryption.Encrypt(Password);

                clsRegistry.SetRegistryValue("Username", Username);
                clsRegistry.SetRegistryValue("Password", EncryptedPassword);
                return true;
            }
            catch (Exception ex)
            {
                LocalLogError(nameof(SaveUsernameAndPasswordInRegistry), ex.Message);
                return false;
            }
        }

        static public bool RestoreUsernameAndPasswordFromRegistry(out string Username, out string Password)
        {
            Username = string.Empty;
            Password = string.Empty;
            try
            {
                string storedUsername = clsRegistry.GetRegistryValue("Username");
                if (storedUsername != null)
                {
                    Username = storedUsername;
                    Password = clsEncryptionDecryption.Decrypt(clsRegistry.GetRegistryValue("Password"));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LocalLogError(nameof(RestoreUsernameAndPasswordFromRegistry), ex.Message);
                return false;
            }
        }
    }
}
