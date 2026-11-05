namespace SmartDentalClinic.Receptionist.DashBoard
{
    partial class frmReceptionistDashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceptionistDashBoard));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flbTodaysAppointments = new System.Windows.Forms.FlowLayoutPanel();
            this.cardNewPatient = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.cardWaiting = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.cardTodaysAppointments = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.ctrlDashboardHeader1 = new SmartDentalClinic.GlobalUserControls.ctrlDashboardHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flbTodaysAppointments);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(13, 358);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(989, 504);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Todays Schedule";
            // 
            // flbTodaysAppointments
            // 
            this.flbTodaysAppointments.AutoScroll = true;
            this.flbTodaysAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flbTodaysAppointments.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flbTodaysAppointments.Location = new System.Drawing.Point(3, 22);
            this.flbTodaysAppointments.Name = "flbTodaysAppointments";
            this.flbTodaysAppointments.Padding = new System.Windows.Forms.Padding(5);
            this.flbTodaysAppointments.Size = new System.Drawing.Size(983, 479);
            this.flbTodaysAppointments.TabIndex = 0;
            this.flbTodaysAppointments.WrapContents = false;
            // 
            // cardNewPatient
            // 
            this.cardNewPatient.Description = "";
            this.cardNewPatient.Icon = global::SmartDentalClinic.Properties.Resources.PatientsDashboard;
            this.cardNewPatient.Location = new System.Drawing.Point(1237, 192);
            this.cardNewPatient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardNewPatient.Name = "cardNewPatient";
            this.cardNewPatient.Size = new System.Drawing.Size(377, 135);
            this.cardNewPatient.TabIndex = 3;
            this.cardNewPatient.Title = "New Patients";
            this.cardNewPatient.Value = "Value";
            // 
            // cardWaiting
            // 
            this.cardWaiting.Description = "";
            this.cardWaiting.Icon = ((System.Drawing.Image)(resources.GetObject("cardWaiting.Icon")));
            this.cardWaiting.Location = new System.Drawing.Point(625, 192);
            this.cardWaiting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardWaiting.Name = "cardWaiting";
            this.cardWaiting.Size = new System.Drawing.Size(377, 135);
            this.cardWaiting.TabIndex = 2;
            this.cardWaiting.Title = "Waiting";
            this.cardWaiting.Value = "Value";
            // 
            // cardTodaysAppointments
            // 
            this.cardTodaysAppointments.Description = "";
            this.cardTodaysAppointments.Icon = global::SmartDentalClinic.Properties.Resources.AppointmentsDashboard;
            this.cardTodaysAppointments.Location = new System.Drawing.Point(13, 192);
            this.cardTodaysAppointments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cardTodaysAppointments.Name = "cardTodaysAppointments";
            this.cardTodaysAppointments.Size = new System.Drawing.Size(377, 135);
            this.cardTodaysAppointments.TabIndex = 1;
            this.cardTodaysAppointments.Title = "Today\'s Appointments";
            this.cardTodaysAppointments.Value = "Value";
            // 
            // ctrlDashboardHeader1
            // 
            this.ctrlDashboardHeader1.DescriptionText = "Here\'s what\'s happening at your clinic today.";
            this.ctrlDashboardHeader1.Location = new System.Drawing.Point(12, 12);
            this.ctrlDashboardHeader1.MotivationText = "Have a great day at the clinic!";
            this.ctrlDashboardHeader1.Name = "ctrlDashboardHeader1";
            this.ctrlDashboardHeader1.Size = new System.Drawing.Size(1603, 150);
            this.ctrlDashboardHeader1.TabIndex = 0;
            // 
            // frmReceptionistDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1632, 874);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cardNewPatient);
            this.Controls.Add(this.cardWaiting);
            this.Controls.Add(this.cardTodaysAppointments);
            this.Controls.Add(this.ctrlDashboardHeader1);
            this.Name = "frmReceptionistDashBoard";
            this.Text = "frmReceptionistDashBoard";
            this.Load += new System.EventHandler(this.frmReceptionistDashBoard_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GlobalUserControls.ctrlDashboardHeader ctrlDashboardHeader1;
        private Admin.DashBoard.Controls.ctrlDashboardCard cardTodaysAppointments;
        private Admin.DashBoard.Controls.ctrlDashboardCard cardWaiting;
        private Admin.DashBoard.Controls.ctrlDashboardCard cardNewPatient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flbTodaysAppointments;
    }
}