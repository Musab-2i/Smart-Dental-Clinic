using SmartDentalClinic.Business.Dashboards;
using SmartDentalClinic.DTOs;
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
        private List<UpcomingAppointmentDTO> GetTestAppointments()
        {
            return new List<UpcomingAppointmentDTO>
            {
                new UpcomingAppointmentDTO
                {
                    AppointmentID = 1,
                    PatientName = "Ahmad Mohammad",
                    StartAt = new TimeSpan(9, 0, 0),
                    DoctorName = "Dr. Omar Khaled",
                    AppointmentStatus = "Confirmed"
                },

                new UpcomingAppointmentDTO
                {
                    AppointmentID = 2,
                    PatientName = "Sara Ahmad",
                    StartAt = new TimeSpan(9, 30, 0),
                    DoctorName = "Dr. Lina Samir",
                    AppointmentStatus = "Pending"
                },

                new UpcomingAppointmentDTO
                {
                    AppointmentID = 3,
                    PatientName = "Mohammad Ali",
                    StartAt = new TimeSpan(10, 0, 0),
                    DoctorName = "Dr. Omar Khaled",
                    AppointmentStatus = "Completed"
                },

                new UpcomingAppointmentDTO
                {
                    AppointmentID = 4,
                    PatientName = "Noor Ibrahim",
                    StartAt = new TimeSpan(10, 30, 0),
                    DoctorName = "Dr. Yazan Ahmad",
                    AppointmentStatus = "Confirmed"
                },

                new UpcomingAppointmentDTO
                {
                    AppointmentID = 5,
                    PatientName = "Khaled Mahmoud",
                    StartAt = new TimeSpan(11, 0, 0),
                    DoctorName = "Dr. Lina Samir",
                    AppointmentStatus = "Cancelled"
                }
            };
        }
        private async Task _FillUserCtrl()
        {
            clsReceptionistDashboard dashboardSummary = await clsReceptionistDashboard.GetStatsAsync();
            if (dashboardSummary != null)
            {
                // 3. تمرير كل رقم للبطاقة الخاصة فيه باستخدام الخاصية Value
                cardTodaysAppointments.Value = dashboardSummary.TodaysAppointments.ToString();
                cardWaiting.Value = dashboardSummary.Waiting.ToString("N0");
                cardNewPatient.Value = dashboardSummary.NewPatients.ToString();
            }
        }
        private async void frmReceptionistDashBoard_Load(object sender, EventArgs e)
        {
            ctrlDashboardHeader1.LoadData();
            await _FillUserCtrl();

            List<UpcomingAppointmentDTO> appointments = GetTestAppointments();// await clsReceptionistDashboard.GetTodaysAppointmentsAsync();

            flbTodaysAppointments.Controls.Clear();

            foreach (var appointment in appointments)
            {
                Panel appointmentCard = CreateAppointmentCard(appointment);
                flbTodaysAppointments.Controls.Add(appointmentCard);
            }
        }
        private Panel CreateAppointmentCard(UpcomingAppointmentDTO appointment)
        {
            Panel pnlCard = new Panel();

            pnlCard.Size = new Size(600, 85);
            pnlCard.BackColor = Color.White;
            pnlCard.Margin = new Padding(5);
            pnlCard.BorderStyle = BorderStyle.FixedSingle;

            // Appointment Time
            Label lblTime = new Label();

            lblTime.Text = appointment.StartAt.ToString(@"hh\:mm");
            lblTime.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTime.ForeColor = Color.Teal;
            lblTime.Location = new Point(10, 25);
            lblTime.Size = new Size(75, 30);
            lblTime.TextAlign = ContentAlignment.MiddleCenter;

            // Patient Name
            Label lblPatient = new Label();

            lblPatient.Text = appointment.PatientName;
            lblPatient.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPatient.ForeColor = Color.FromArgb(45, 55, 72);
            lblPatient.Location = new Point(100, 15);
            lblPatient.Size = new Size(150, 25);
            lblPatient.AutoEllipsis = true;

            // Patient Title
            Label lblPatientTitle = new Label();

            lblPatientTitle.Text = "Patient";
            lblPatientTitle.Font = new Font("Segoe UI", 8);
            lblPatientTitle.ForeColor = Color.Gray;
            lblPatientTitle.Location = new Point(100, 42);
            lblPatientTitle.Size = new Size(150, 20);

            // Doctor Name
            Label lblDoctor = new Label();

            lblDoctor.Text = appointment.DoctorName;
            lblDoctor.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDoctor.ForeColor = Color.FromArgb(45, 55, 72);
            lblDoctor.Location = new Point(280, 15);
            lblDoctor.Size = new Size(150, 25);
            lblDoctor.AutoEllipsis = true;

            // Doctor Title
            Label lblDoctorTitle = new Label();

            lblDoctorTitle.Text = "Doctor";
            lblDoctorTitle.Font = new Font("Segoe UI", 8);
            lblDoctorTitle.ForeColor = Color.Gray;
            lblDoctorTitle.Location = new Point(280, 42);
            lblDoctorTitle.Size = new Size(150, 20);

            // Appointment Status
            // Appointment Status
            Label lblStatus = new Label();

            lblStatus.Text = appointment.AppointmentStatus;
            lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblStatus.Location = new Point(455, 25);
            lblStatus.Size = new Size(125, 30);
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;

            // Set colors based on appointment status
            switch (appointment.AppointmentStatus)
            {
                case "Confirmed":
                    lblStatus.ForeColor = Color.FromArgb(21, 128, 61);
                    lblStatus.BackColor = Color.FromArgb(220, 252, 231);
                    break;

                case "Pending":
                    lblStatus.ForeColor = Color.FromArgb(180, 83, 9);
                    lblStatus.BackColor = Color.FromArgb(254, 243, 199);
                    break;

                case "Completed":
                    lblStatus.ForeColor = Color.FromArgb(29, 78, 216);
                    lblStatus.BackColor = Color.FromArgb(219, 234, 254);
                    break;

                case "Cancelled":
                    lblStatus.ForeColor = Color.FromArgb(185, 28, 28);
                    lblStatus.BackColor = Color.FromArgb(254, 226, 226);
                    break;

                default:
                    lblStatus.ForeColor = Color.Gray;
                    lblStatus.BackColor = Color.FromArgb(243, 244, 246);
                    break;
            }

            // Add Controls
            pnlCard.Controls.Add(lblTime);
            pnlCard.Controls.Add(lblPatient);
            pnlCard.Controls.Add(lblPatientTitle);
            pnlCard.Controls.Add(lblDoctor);
            pnlCard.Controls.Add(lblDoctorTitle);
            pnlCard.Controls.Add(lblStatus);

            return pnlCard;
        }
    }
}
