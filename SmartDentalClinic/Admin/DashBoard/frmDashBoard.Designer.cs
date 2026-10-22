namespace SmartDentalClinic.Admin.DashBoard
{
    partial class frmDashBoard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cardInvoices = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.cardAppointments = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.cardPatients = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.cardActiveUsers = new SmartDentalClinic.Admin.DashBoard.Controls.ctrlDashboardCard();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUsersByRole = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersByRole)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome, Admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Here\'s what\'s happening at your clinic today.";
            // 
            // cardInvoices
            // 
            this.cardInvoices.Description = "Awaiting payment";
            this.cardInvoices.Icon = global::SmartDentalClinic.Properties.Resources.UnpaidInvoicesDashboard;
            this.cardInvoices.Location = new System.Drawing.Point(861, 117);
            this.cardInvoices.Name = "cardInvoices";
            this.cardInvoices.Size = new System.Drawing.Size(283, 110);
            this.cardInvoices.TabIndex = 5;
            this.cardInvoices.Title = "Unpaid Invoices";
            this.cardInvoices.Value = "Value";
            // 
            // cardAppointments
            // 
            this.cardAppointments.Description = "Scheduled for today";
            this.cardAppointments.Icon = global::SmartDentalClinic.Properties.Resources.AppointmentsDashboard;
            this.cardAppointments.Location = new System.Drawing.Point(578, 117);
            this.cardAppointments.Name = "cardAppointments";
            this.cardAppointments.Size = new System.Drawing.Size(283, 110);
            this.cardAppointments.TabIndex = 4;
            this.cardAppointments.Title = "Appointments Today";
            this.cardAppointments.Value = "Value";
            // 
            // cardPatients
            // 
            this.cardPatients.Description = "Total registered patients   ";
            this.cardPatients.Icon = global::SmartDentalClinic.Properties.Resources.PatientsDashboard;
            this.cardPatients.Location = new System.Drawing.Point(295, 117);
            this.cardPatients.Name = "cardPatients";
            this.cardPatients.Size = new System.Drawing.Size(283, 110);
            this.cardPatients.TabIndex = 3;
            this.cardPatients.Title = "Patients";
            this.cardPatients.Value = "Value";
            // 
            // cardActiveUsers
            // 
            this.cardActiveUsers.Description = "System Users";
            this.cardActiveUsers.Icon = global::SmartDentalClinic.Properties.Resources.ActiveUsersDashboard;
            this.cardActiveUsers.Location = new System.Drawing.Point(12, 117);
            this.cardActiveUsers.Name = "cardActiveUsers";
            this.cardActiveUsers.Size = new System.Drawing.Size(283, 110);
            this.cardActiveUsers.TabIndex = 2;
            this.cardActiveUsers.Title = "Active Users";
            this.cardActiveUsers.Value = "Value";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUsersByRole);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(18, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 317);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users By Role";
            // 
            // dgvUsersByRole
            // 
            this.dgvUsersByRole.AllowUserToAddRows = false;
            this.dgvUsersByRole.AllowUserToDeleteRows = false;
            this.dgvUsersByRole.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvUsersByRole.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsersByRole.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvUsersByRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsersByRole.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsersByRole.Location = new System.Drawing.Point(6, 43);
            this.dgvUsersByRole.Name = "dgvUsersByRole";
            this.dgvUsersByRole.ReadOnly = true;
            this.dgvUsersByRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsersByRole.Size = new System.Drawing.Size(548, 254);
            this.dgvUsersByRole.TabIndex = 1;
            // 
            // frmDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1144, 710);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cardInvoices);
            this.Controls.Add(this.cardAppointments);
            this.Controls.Add(this.cardPatients);
            this.Controls.Add(this.cardActiveUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDashBoard";
            this.Text = "frmDashBoard";
            this.Load += new System.EventHandler(this.frmDashBoard_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersByRole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controls.ctrlDashboardCard cardActiveUsers;
        private Controls.ctrlDashboardCard cardPatients;
        private Controls.ctrlDashboardCard cardAppointments;
        private Controls.ctrlDashboardCard cardInvoices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUsersByRole;
    }
}