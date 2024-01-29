namespace G1_MediaBazaar
{
	partial class DepartmentEntity
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
			lblDepartmentName = new Label();
			lblManagerID = new Label();
			lblLocation = new Label();
			btnRemoveDep = new Button();
			SuspendLayout();
			// 
			// lblDepartmentName
			// 
			lblDepartmentName.AutoSize = true;
			lblDepartmentName.Font = new Font("Bahnschrift", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
			lblDepartmentName.ForeColor = Color.White;
			lblDepartmentName.Location = new Point(34, 27);
			lblDepartmentName.Name = "lblDepartmentName";
			lblDepartmentName.Size = new Size(400, 52);
			lblDepartmentName.TabIndex = 0;
			lblDepartmentName.Text = "[Department Name]";
			lblDepartmentName.Click += ViewDetails;
			// 
			// lblManagerID
			// 
			lblManagerID.AutoSize = true;
			lblManagerID.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point);
			lblManagerID.ForeColor = Color.White;
			lblManagerID.Location = new Point(34, 90);
			lblManagerID.Name = "lblManagerID";
			lblManagerID.Size = new Size(140, 29);
			lblManagerID.TabIndex = 1;
			lblManagerID.Text = "Manager ID:";
			lblManagerID.Click += ViewDetails;
			// 
			// lblLocation
			// 
			lblLocation.AutoSize = true;
			lblLocation.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point);
			lblLocation.ForeColor = Color.White;
			lblLocation.Location = new Point(34, 131);
			lblLocation.Name = "lblLocation";
			lblLocation.Size = new Size(110, 29);
			lblLocation.TabIndex = 2;
			lblLocation.Text = "Location:";
			lblLocation.Click += ViewDetails;
			// 
			// btnRemoveDep
			// 
			btnRemoveDep.BackColor = Color.Red;
			btnRemoveDep.ForeColor = Color.White;
			btnRemoveDep.Location = new Point(608, 24);
			btnRemoveDep.Name = "btnRemoveDep";
			btnRemoveDep.Size = new Size(166, 152);
			btnRemoveDep.TabIndex = 3;
			btnRemoveDep.Text = "Remove Department";
			btnRemoveDep.UseVisualStyleBackColor = false;
			btnRemoveDep.Click += btnRemoveDep_Click;
			// 
			// DepartmentEntity
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.DarkGray;
			Controls.Add(btnRemoveDep);
			Controls.Add(lblLocation);
			Controls.Add(lblManagerID);
			Controls.Add(lblDepartmentName);
			Name = "DepartmentEntity";
			Padding = new Padding(3);
			Size = new Size(800, 200);
			Click += ViewDetails;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblDepartmentName;
		private Label lblManagerID;
		private Label lblLocation;
		private Button btnRemoveDep;
	}
}
