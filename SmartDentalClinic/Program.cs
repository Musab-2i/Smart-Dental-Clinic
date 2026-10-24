using SmartDentalClinic.Login;
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

            // 2. نختبر: هل رجعت الشاشة بإشارة "OK" (نجاح الدخول)؟
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // إذا نجح الدخول، نجعل الشاشة الرئيسية هي الأساسية للبرنامج
                Application.Run(new AdminMain());
            }
            else
            {
                // إذا قام المستخدم بالضغط على زر (X) لإغلاق شاشة الدخول، ننهي البرنامج تماماً
                Application.Exit();
            }
        }
    }
}
