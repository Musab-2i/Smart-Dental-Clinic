using SmartDentalClinic.Admin.DashBoard;
using SmartDentalClinic.Receptionist.DashBoard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic.Receptionist
{
    public partial class frmReceptionistMain : Form
    {
        public frmReceptionistMain()
        {
            InitializeComponent();
            openChildForm(new frmReceptionistDashBoard());
            asdToolStripMenuItem.PerformClick();
        }
        private Form activeForm = null;

        public void openChildForm(Form childForm)
        {
            // 1. إذا كان في شاشة مفتوحة أصلاً، سكرها
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            // 2. هذه أهم خطوة: نخبر الويندوز أن هذا الفورم لم يعد نافذة مستقلة
            childForm.TopLevel = false;

            // 3. إخفاء الإطار الخارجي وشريط العنوان وزر الإغلاق X للفورم الجديد
            childForm.FormBorderStyle = FormBorderStyle.None;

            // 4. جعل الفورم الجديد يملأ البانل بالكامل
            childForm.Dock = DockStyle.Fill;

            // 5. إضافة الفورم إلى البانل وإظهاره
            pnlContainer.Controls.Add(childForm);
            pnlContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

    }
}
