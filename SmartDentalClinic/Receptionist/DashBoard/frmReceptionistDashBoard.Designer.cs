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
            this.ctrlDashboardHeader1 = new SmartDentalClinic.GlobalUserControls.ctrlDashboardHeader();
            this.SuspendLayout();
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
            this.Controls.Add(this.ctrlDashboardHeader1);
            this.Name = "frmReceptionistDashBoard";
            this.Text = "frmReceptionistDashBoard";
            this.Load += new System.EventHandler(this.frmReceptionistDashBoard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GlobalUserControls.ctrlDashboardHeader ctrlDashboardHeader1;
    }
}