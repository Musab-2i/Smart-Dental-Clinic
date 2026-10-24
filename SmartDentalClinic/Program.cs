using SmartDentalClinic.GlobalClass;
using SmartDentalClinic.Login;
using SmartDentalClinic.Receptionist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AdminMain());

            frmLogin loginForm = new frmLogin();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                switch(clsGlobal.CurrentUser.RoleID)
                {
                    case 1:
                        // Admin role
                        Application.Run(new AdminMain());
                        break;
                        // Not Fully Implemented Yet
                    case 2:
                        // Receptionist role
                        Application.Run(new frmReceptionistMain());
                        break;
                        /*
                    case 3:
                        // Doctor role
                        Application.Run(new DoctorMain());
                        break;
                        */
                    default:
                        // Unknown role, exit application
                        Application.Exit();
                        break;
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
