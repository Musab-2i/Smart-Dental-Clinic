using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic.Admin.Controls
{
    public partial class ctrlQuickAccessCard : UserControl
    {
        public Action OnCardClicked { get; set; }



        private Color _defaultColor = Color.Ivory;
        private Color _hoverColor = Color.WhiteSmoke;//ColorTranslator.FromHtml("#F5F8FD");
        public ctrlQuickAccessCard()
        {
            InitializeComponent();
            WireEvents(this);
        }
        [Category("Quick Access Data")]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        [Category("Quick Access Data")]
        public string Description
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        [Category("Quick Access Data")]
        public Image Icon
        {
            get { return pbIcon.Image; }
            set { pbIcon.Image = value; }
        }

        private void WireEvents(Control control)
        {
            control.Click += ctrlQuickAccessCard_Click;
            control.MouseEnter += ctrlQuickAccessCard_MouseEnter;
            control.MouseLeave += ctrlQuickAccessCard_MouseLeave;

            // تطبيق نفس الأحداث على جميع العناصر داخل الـ UserControl (النصوص والصور)
            foreach (Control child in control.Controls)
            {
                WireEvents(child);
            }
        }

        private void ctrlQuickAccessCard_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = _hoverColor;
        }

        private void ctrlQuickAccessCard_MouseLeave(object sender, EventArgs e)
        {
            // التحقق من أن الماوس خرج فعلاً من البطاقة بالكامل
            if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                this.BackColor = _defaultColor;
            }
        }
        private void ctrlQuickAccessCard_Click(object sender, EventArgs e)
        {
            // استدعاء حدث النقر الأساسي للـ UserControl عند الضغط على أي عنصر داخله
            OnCardClicked?.Invoke();
        }
    }
}
