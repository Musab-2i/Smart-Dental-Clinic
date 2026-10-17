namespace SmartDentalClinic.Admin.People.Controls
{
    partial class ctrlFindPersonInfoFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbSearchPerson = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtFilterValue);
            this.groupBox1.Controls.Add(this.cbSearchPerson);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.txtFilterValue.Location = new System.Drawing.Point(230, 34);
            this.txtFilterValue.MaxLength = 10;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(139, 23);
            this.txtFilterValue.TabIndex = 8;
            // 
            // cbSearchPerson
            // 
            this.cbSearchPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchPerson.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.cbSearchPerson.FormattingEnabled = true;
            this.cbSearchPerson.Items.AddRange(new object[] {
            "National ID",
            "Person ID"});
            this.cbSearchPerson.Location = new System.Drawing.Point(66, 34);
            this.cbSearchPerson.Name = "cbSearchPerson";
            this.cbSearchPerson.Size = new System.Drawing.Size(158, 23);
            this.cbSearchPerson.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.label1.Location = new System.Drawing.Point(-1, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Find By :";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::SmartDentalClinic.Properties.Resources.SearchPerson;
            this.button1.Location = new System.Drawing.Point(375, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ctrlFindPersonInfoFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlFindPersonInfoFilter";
            this.Size = new System.Drawing.Size(430, 90);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbSearchPerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
