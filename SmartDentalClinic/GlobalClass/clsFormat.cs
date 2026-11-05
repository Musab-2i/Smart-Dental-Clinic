using SmartDentalClinic.Admin.DashBoard;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic.GlobalClass
{
    public static class clsFormat
    {
        public static string DateToShort(DateTime Dt1)
        {
            return Dt1.ToString("dd/MMM/yyyy");
        }
        public static string CurrencyFormat(decimal Fees)
        {
            return Fees.ToString("F2");
        }
        public static string GetGreeting()
        {
            int hour = DateTime.Now.Hour;

            if (hour < 12)
                return "Good Morning";

            if (hour < 17)
                return "Good Afternoon";

            return "Good Evening";
        }

        public static void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;

            if (clickedItem == null)
                return;

            // الوصول إلى MenuStrip الذي يحتوي على العنصر
            ToolStrip menu = clickedItem.Owner;

            // إعادة جميع العناصر للوضع الافتراضي
            foreach (ToolStripItem item in menu.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.WhiteSmoke;
            }

            // تمييز العنصر الذي تم الضغط عليه
            //clickedItem.BackColor = ColorTranslator.FromHtml("#E9EEF6");
            clickedItem.BackColor = Color.LightBlue;
            clickedItem.ForeColor = Color.Teal;
        }
    }
}
