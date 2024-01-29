namespace G1_MediaBazaar
{
    partial class DepartmentDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentDetails));
            panel1 = new Panel();
            lblDepartmentName = new Label();
            label1 = new Label();
            tbxName = new TextBox();
            cbxManager = new ComboBox();
            cbxLocation = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            btnSubmit = new Button();
            btnCancel = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(lblDepartmentName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(374, 71);
            panel1.TabIndex = 0;
            // 
            // lblDepartmentName
            // 
            lblDepartmentName.AutoSize = true;
            lblDepartmentName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDepartmentName.ForeColor = Color.White;
            lblDepartmentName.Location = new Point(26, 25);
            lblDepartmentName.Margin = new Padding(2, 0, 2, 0);
            lblDepartmentName.Name = "lblDepartmentName";
            lblDepartmentName.Size = new Size(198, 28);
            lblDepartmentName.TabIndex = 0;
            lblDepartmentName.Text = "Update department";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 86);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 1;
            label1.Text = "Change name:";
            // 
            // tbxName
            // 
            tbxName.Location = new Point(26, 108);
            tbxName.Margin = new Padding(2, 2, 2, 2);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(329, 27);
            tbxName.TabIndex = 2;
            // 
            // cbxManager
            // 
            cbxManager.FormattingEnabled = true;
            cbxManager.Location = new Point(26, 174);
            cbxManager.Margin = new Padding(2, 2, 2, 2);
            cbxManager.Name = "cbxManager";
            cbxManager.Size = new Size(329, 28);
            cbxManager.TabIndex = 3;
            // 
            // cbxLocation
            // 
            cbxLocation.FormattingEnabled = true;
            cbxLocation.Location = new Point(26, 243);
            cbxLocation.Margin = new Padding(2, 2, 2, 2);
            cbxLocation.Name = "cbxLocation";
            cbxLocation.Size = new Size(329, 28);
            cbxLocation.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 152);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(122, 20);
            label2.TabIndex = 5;
            label2.Text = "Change manager";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 221);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 6;
            label3.Text = "Change location";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = SystemColors.AppWorkspace;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(26, 294);
            btnSubmit.Margin = new Padding(2, 2, 2, 2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(154, 48);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(199, 294);
            btnCancel.Margin = new Padding(2, 2, 2, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(154, 48);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // DepartmentDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 366);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbxLocation);
            Controls.Add(cbxManager);
            Controls.Add(tbxName);
            Controls.Add(label1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "DepartmentDetails";
            Text = "DepartmentDetails";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblDepartmentName;
        private Label label1;
        private TextBox tbxName;
        private ComboBox cbxManager;
        private ComboBox cbxLocation;
        private Label label2;
        private Label label3;
        private Button btnSubmit;
        private Button btnCancel;
    }
}