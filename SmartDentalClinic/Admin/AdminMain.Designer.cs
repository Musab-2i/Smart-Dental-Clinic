namespace SmartDentalClinic
{
    partial class AdminMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.asdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treatmentPlansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoicesPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Teal;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdToolStripMenuItem,
            this.patientsToolStripMenuItem,
            this.appointmentsToolStripMenuItem,
            this.visitNotesToolStripMenuItem,
            this.treatmentPlansToolStripMenuItem,
            this.usersRolesToolStripMenuItem,
            this.invoicesPaymentsToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(210, 749);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // asdToolStripMenuItem
            // 
            this.asdToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asdToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.asdToolStripMenuItem.Image = global::SmartDentalClinic.Properties.Resources.home;
            this.asdToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.asdToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.asdToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 175, 0, 20);
            this.asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            this.asdToolStripMenuItem.Size = new System.Drawing.Size(197, 28);
            this.asdToolStripMenuItem.Text = "   Dashboard";
            this.asdToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.asdToolStripMenuItem.Click += new System.EventHandler(this.asdToolStripMenuItem_Click);
            // 
            // patientsToolStripMenuItem
            // 
            this.patientsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.patientsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.patientsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("patientsToolStripMenuItem.Image")));
            this.patientsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patientsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.patientsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            this.patientsToolStripMenuItem.Size = new System.Drawing.Size(197, 28);
            this.patientsToolStripMenuItem.Text = "   Patients";
            this.patientsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.appointmentsToolStripMenuItem.Image = global::SmartDentalClinic.Properties.Resources.calendar;
            this.appointmentsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.appointmentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.appointmentsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(197, 28);
            this.appointmentsToolStripMenuItem.Text = "   Appointments";
            // 
            // visitNotesToolStripMenuItem
            // 
            this.visitNotesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.visitNotesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.visitNotesToolStripMenuItem.Image = global::SmartDentalClinic.Properties.Resources.notepad;
            this.visitNotesToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.visitNotesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.visitNotesToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.visitNotesToolStripMenuItem.Name = "visitNotesToolStripMenuItem";
            this.visitNotesToolStripMenuItem.Size = new System.Drawing.Size(197, 28);
            this.visitNotesToolStripMenuItem.Text = "   Visit Notes";
            // 
            // treatmentPlansToolStripMenuItem
            // 
            this.treatmentPlansToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.treatmentPlansToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.treatmentPlansToolStripMenuItem.Image = global::SmartDentalClinic.Properties.Resources.Treatment_Plans;
            this.treatmentPlansToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.treatmentPlansToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.treatmentPlansToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.treatmentPlansToolStripMenuItem.Name = "treatmentPlansToolStripMenuItem";
            this.treatmentPlansToolStripMenuItem.Size = new System.Drawing.Size(197, 28);
            this.treatmentPlansToolStripMenuItem.Text = "   Treatment Plans";
            // 
            // usersRolesToolStripMenuItem
            // 
            this.usersRolesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usersRolesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.usersRolesToolStripMenuItem.Image = global::SmartDentalClinic.Properties.Resources.profile;
            this.usersRolesToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usersRolesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersRolesToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.usersRolesToolStripMenuItem.Name = "usersRolesToolStripMenuItem";
            this.usersRolesToolStripMenuItem.Size = new System.Drawing.Size(197, 28);
            this.usersRolesToolStripMenuItem.Text = "   Users && Roles";
            this.usersRolesToolStripMenuItem.Click += new System.EventHandler(this.usersRolesToolStripMenuItem_Click);
            // 
            // invoicesPaymentsToolStripMenuItem
            // 
            this.invoicesPaymentsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.invoicesPaymentsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.invoicesPaymentsToolStripMenuItem.Image = global::SmartDentalClinic.Properties.Resources.invoices;
            this.invoicesPaymentsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.invoicesPaymentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.invoicesPaymentsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.invoicesPaymentsToolStripMenuItem.Name = "invoicesPaymentsToolStripMenuItem";
            this.invoicesPaymentsToolStripMenuItem.Size = new System.Drawing.Size(197, 28);
            this.invoicesPaymentsToolStripMenuItem.Text = "   Invoices && Payments";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(210, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1160, 749);
            this.pnlContainer.TabIndex = 2;
            // 
            // AdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treatmentPlansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoicesPaymentsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlContainer;
    }
}

