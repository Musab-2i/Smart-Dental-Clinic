using SmartDentalClinic.Admin.AddNewUser;
using SmartDentalClinic.Admin.DashBoard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic
{
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();
            openChildForm(new frmDashBoard());
            asdToolStripMenuItem.PerformClick();
        }
        private void ResetMenuColors()
        {
            // إعادة الألوان للوضع الافتراضي
            asdToolStripMenuItem.BackColor = Color.Transparent;
            asdToolStripMenuItem.ForeColor = Color.White;
            usersRolesToolStripMenuItem.BackColor = Color.Transparent;
            usersRolesToolStripMenuItem.ForeColor = Color.White;
        }
        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            asdToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#E9EEF6");
            asdToolStripMenuItem.ForeColor = Color.Teal;
            openChildForm(new frmDashBoard());
        }

        private void usersRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            usersRolesToolStripMenuItem.BackColor = ColorTranslator.FromHtml("#E9EEF6");
            usersRolesToolStripMenuItem.ForeColor = Color.Teal;

            openChildForm(new frmAddUpdateUser());
        }
        private Form activeForm = null;

        private void openChildForm(Form childForm)
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
        //private void usersRolesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new frmAddUpdateUser());
        //}

        //private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new frmDashBoard());
        //}
    }
}
