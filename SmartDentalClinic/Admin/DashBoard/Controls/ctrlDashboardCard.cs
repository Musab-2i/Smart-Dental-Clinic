using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic.Admin.DashBoard.Controls
{
    public partial class ctrlDashboardCard : UserControl
    {
        public ctrlDashboardCard()
        {
            InitializeComponent();
        }
        [Category("Card Settings")]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        [Category("Card Settings")]
        public string Value
        {
            get { return lblValue.Text; }
            set { lblValue.Text = value; }
        }

        [Category("Card Settings")]
        public string Description
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        [Category("Card Settings")]
        public Image Icon
        {
            get { return pbIcon.Image; }
            set { pbIcon.Image = value; }
        }
    }
}
