namespace SmartDentalClinic.Admin.DashBoard
{
    partial class frmAdminDashBoard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUsersByRole = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlDashboardHeader1 = new SmartDentalClinic.GlobalUserControls.ctrlDashboardHeader();
            this.cardQuickAccessBilling = new SmartDentalClinic.Admin.Controls.ctrlQuickAccessCard();
            this.cardQuickAccessAppointments = new SmartDentalClinic.Admin.Controls.ctrlQuickAccessCard();
            this.cardQuickAccessManageUsers = new SmartDentalClinic.Admin.Controls.ctrlQuickAccessCard();
            this.cardInvoices = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.cardAppointments = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.cardPatients = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.cardActiveUsers = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersByRole)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUsersByRole);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(24, 354);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(747, 495);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users By Role";
            // 
            // dgvUsersByRole
            // 
            this.dgvUsersByRole.AllowUserToAddRows = false;
            this.dgvUsersByRole.AllowUserToDeleteRows = false;
            this.dgvUsersByRole.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvUsersByRole.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUsersByRole.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvUsersByRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsersByRole.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUsersByRole.Location = new System.Drawing.Point(8, 53);
            this.dgvUsersByRole.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUsersByRole.Name = "dgvUsersByRole";
            this.dgvUsersByRole.ReadOnly = true;
            this.dgvUsersByRole.RowHeadersWidth = 51;
            this.dgvUsersByRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsersByRole.Size = new System.Drawing.Size(731, 417);
            this.dgvUsersByRole.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cardQuickAccessBilling);
            this.groupBox2.Controls.Add(this.cardQuickAccessAppointments);
            this.groupBox2.Controls.Add(this.cardQuickAccessManageUsers);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(920, 354);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(715, 495);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quick Access";
            // 
            // ctrlDashboardHeader1
            // 
            this.ctrlDashboardHeader1.DescriptionText = "Here\'s what\'s happening at your clinic today.";
            this.ctrlDashboardHeader1.Location = new System.Drawing.Point(32, 12);
            this.ctrlDashboardHeader1.MotivationText = "Have a great day at the clinic!";
            this.ctrlDashboardHeader1.Name = "ctrlDashboardHeader1";
            this.ctrlDashboardHeader1.Size = new System.Drawing.Size(1603, 150);
            this.ctrlDashboardHeader1.TabIndex = 8;
            // 
            // cardQuickAccessBilling
            // 
            this.cardQuickAccessBilling.Description = "View Invoices and Process Payment";
            this.cardQuickAccessBilling.Icon = global::SmartDentalClinic.Properties.Resources.BlueInvoicesDashboard;
            this.cardQuickAccessBilling.Location = new System.Drawing.Point(9, 332);
            this.cardQuickAccessBilling.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.cardQuickAccessBilling.Name = "cardQuickAccessBilling";
            this.cardQuickAccessBilling.OnCardClicked = null;
            this.cardQuickAccessBilling.Size = new System.Drawing.Size(673, 137);
            this.cardQuickAccessBilling.TabIndex = 3;
            this.cardQuickAccessBilling.Title = "Open Billing";
            this.cardQuickAccessBilling.Click += new System.EventHandler(this.cardQuickAccessManageUsers_Click);
            // 
            // cardQuickAccessAppointments
            // 
            this.cardQuickAccessAppointments.Description = "Check and Manage Appointments";
            this.cardQuickAccessAppointments.Icon = global::SmartDentalClinic.Properties.Resources.AppointmentsDashboard;
            this.cardQuickAccessAppointments.Location = new System.Drawing.Point(9, 180);
            this.cardQuickAccessAppointments.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.cardQuickAccessAppointments.Name = "cardQuickAccessAppointments";
            this.cardQuickAccessAppointments.OnCardClicked = null;
            this.cardQuickAccessAppointments.Size = new System.Drawing.Size(673, 137);
            this.cardQuickAccessAppointments.TabIndex = 2;
            this.cardQuickAccessAppointments.Title = "View Appointments";
            this.cardQuickAccessAppointments.Click += new System.EventHandler(this.cardQuickAccessManageUsers_Click);
            // 
            // cardQuickAccessManageUsers
            // 
            this.cardQuickAccessManageUsers.Description = "Add, Edit or Activate/Deactivate Users";
            this.cardQuickAccessManageUsers.Icon = global::SmartDentalClinic.Properties.Resources.ActiveUsersDashboard;
            this.cardQuickAccessManageUsers.Location = new System.Drawing.Point(9, 27);
            this.cardQuickAccessManageUsers.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cardQuickAccessManageUsers.Name = "cardQuickAccessManageUsers";
            this.cardQuickAccessManageUsers.OnCardClicked = null;
            this.cardQuickAccessManageUsers.Size = new System.Drawing.Size(673, 137);
            this.cardQuickAccessManageUsers.TabIndex = 1;
            this.cardQuickAccessManageUsers.Title = "Manage Users";
            this.cardQuickAccessManageUsers.Click += new System.EventHandler(this.cardQuickAccessManageUsers_Click);
            // 
            // cardInvoices
            // 
            this.cardInvoices.Description = "Awaiting payment";
            this.cardInvoices.Icon = global::SmartDentalClinic.Properties.Resources.UnpaidInvoicesDashboard;
            this.cardInvoices.Location = new System.Drawing.Point(1258, 179);
            this.cardInvoices.Margin = new System.Windows.Forms.Padding(5);
            this.cardInvoices.Name = "cardInvoices";
            this.cardInvoices.Size = new System.Drawing.Size(377, 135);
            this.cardInvoices.TabIndex = 5;
            this.cardInvoices.Title = "Unpaid Invoices";
            this.cardInvoices.Value = "Value";
            // 
            // cardAppointments
            // 
            this.cardAppointments.Description = "Scheduled for today";
            this.cardAppointments.Icon = global::SmartDentalClinic.Properties.Resources.AppointmentsDashboard;
            this.cardAppointments.Location = new System.Drawing.Point(844, 179);
            this.cardAppointments.Margin = new System.Windows.Forms.Padding(5);
            this.cardAppointments.Name = "cardAppointments";
            this.cardAppointments.Size = new System.Drawing.Size(377, 135);
            this.cardAppointments.TabIndex = 4;
            this.cardAppointments.Title = "Appointments Today";
            this.cardAppointments.Value = "Value";
            // 
            // cardPatients
            // 
            this.cardPatients.Description = "Total registered patients   ";
            this.cardPatients.Icon = global::SmartDentalClinic.Properties.Resources.PatientsDashboard;
            this.cardPatients.Location = new System.Drawing.Point(430, 179);
            this.cardPatients.Margin = new System.Windows.Forms.Padding(5);
            this.cardPatients.Name = "cardPatients";
            this.cardPatients.Size = new System.Drawing.Size(377, 135);
            this.cardPatients.TabIndex = 3;
            this.cardPatients.Title = "Patients";
            this.cardPatients.Value = "Value";
            // 
            // cardActiveUsers
            // 
            this.cardActiveUsers.Description = "System Users";
            this.cardActiveUsers.Icon = global::SmartDentalClinic.Properties.Resources.ActiveUsersDashboard;
            this.cardActiveUsers.Location = new System.Drawing.Point(16, 179);
            this.cardActiveUsers.Margin = new System.Windows.Forms.Padding(5);
            this.cardActiveUsers.Name = "cardActiveUsers";
            this.cardActiveUsers.Size = new System.Drawing.Size(377, 135);
            this.cardActiveUsers.TabIndex = 2;
            this.cardActiveUsers.Title = "Active Users";
            this.cardActiveUsers.Value = "Value";
            // 
            // frmAdminDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1691, 874);
            this.Controls.Add(this.ctrlDashboardHeader1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cardInvoices);
            this.Controls.Add(this.cardAppointments);
            this.Controls.Add(this.cardPatients);
            this.Controls.Add(this.cardActiveUsers);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAdminDashBoard";
            this.Text = "frmDashBoard";
            this.Load += new System.EventHandler(this.frmDashBoard_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersByRole)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.ctrlDashboardCard cardActiveUsers;
        private Controls.ctrlDashboardCard cardPatients;
        private Controls.ctrlDashboardCard cardAppointments;
        private Controls.ctrlDashboardCard cardInvoices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUsersByRole;
        private System.Windows.Forms.GroupBox groupBox2;
        private Admin.Controls.ctrlQuickAccessCard cardQuickAccessManageUsers;
        private Admin.Controls.ctrlQuickAccessCard cardQuickAccessBilling;
        private Admin.Controls.ctrlQuickAccessCard cardQuickAccessAppointments;
        private GlobalUserControls.ctrlDashboardHeader ctrlDashboardHeader1;
    }
}