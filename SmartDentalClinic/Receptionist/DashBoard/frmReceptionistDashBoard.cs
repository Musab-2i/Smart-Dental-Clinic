using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDentalClinic.Receptionist.DashBoard
{
    public partial class frmReceptionistDashBoard : Form
    {
        public frmReceptionistDashBoard()
        {
            InitializeComponent();
        }

        private void frmReceptionistDashBoard_Load(object sender, EventArgs e)
        {
            ctrlDashboardHeader1.LoadData();

        }
    }
}
