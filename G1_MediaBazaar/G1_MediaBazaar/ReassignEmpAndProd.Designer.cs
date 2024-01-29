namespace G1_MediaBazaar
{
	partial class ReassignEmpAndProd
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
			lbxEmpUa = new ListBox();
			panel1 = new Panel();
			lblTitle = new Label();
			gbxEmp = new GroupBox();
			btnAssignEmp = new Button();
			lblDep1 = new Label();
			cbxDepEmp = new ComboBox();
			lblNewEmp = new Label();
			lblOldEmp = new Label();
			lbxEmpA = new ListBox();
			groupBox1 = new GroupBox();
			btnAssignProd = new Button();
			lblDep2 = new Label();
			cbxDepProd = new ComboBox();
			lblNewProd = new Label();
			lblOldProd = new Label();
			lbxProdUa = new ListBox();
			lbxProdA = new ListBox();
			btnReset = new Button();
			btnSubmit = new Button();
			panel1.SuspendLayout();
			gbxEmp.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// lbxEmpUa
			// 
			lbxEmpUa.FormattingEnabled = true;
			lbxEmpUa.ItemHeight = 32;
			lbxEmpUa.Location = new Point(46, 124);
			lbxEmpUa.Name = "lbxEmpUa";
			lbxEmpUa.Size = new Size(240, 260);
			lbxEmpUa.TabIndex = 0;
			// 
			// panel1
			// 
			panel1.BackColor = Color.Red;
			panel1.Controls.Add(lblTitle);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(1198, 142);
			panel1.TabIndex = 4;
			// 
			// lblTitle
			// 
			lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			lblTitle.ForeColor = Color.White;
			lblTitle.Location = new Point(246, 0);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(612, 142);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "Reassign Employees and Products from ";
			lblTitle.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// gbxEmp
			// 
			gbxEmp.Controls.Add(btnAssignEmp);
			gbxEmp.Controls.Add(lblDep1);
			gbxEmp.Controls.Add(cbxDepEmp);
			gbxEmp.Controls.Add(lblNewEmp);
			gbxEmp.Controls.Add(lblOldEmp);
			gbxEmp.Controls.Add(lbxEmpUa);
			gbxEmp.Controls.Add(lbxEmpA);
			gbxEmp.Location = new Point(47, 164);
			gbxEmp.Name = "gbxEmp";
			gbxEmp.Size = new Size(1117, 411);
			gbxEmp.TabIndex = 5;
			gbxEmp.TabStop = false;
			gbxEmp.Text = "Reassign employees";
			// 
			// btnAssignEmp
			// 
			btnAssignEmp.BackColor = Color.Gray;
			btnAssignEmp.FlatAppearance.BorderSize = 0;
			btnAssignEmp.FlatAppearance.MouseOverBackColor = Color.Brown;
			btnAssignEmp.FlatStyle = FlatStyle.Flat;
			btnAssignEmp.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point);
			btnAssignEmp.ForeColor = Color.White;
			btnAssignEmp.Location = new Point(417, 283);
			btnAssignEmp.Name = "btnAssignEmp";
			btnAssignEmp.Size = new Size(242, 101);
			btnAssignEmp.TabIndex = 7;
			btnAssignEmp.Text = "Assign";
			btnAssignEmp.UseVisualStyleBackColor = false;
			btnAssignEmp.Click += btnAssignEmp_Click;
			// 
			// lblDep1
			// 
			lblDep1.AutoSize = true;
			lblDep1.Location = new Point(325, 89);
			lblDep1.Name = "lblDep1";
			lblDep1.Size = new Size(226, 32);
			lblDep1.TabIndex = 6;
			lblDep1.Text = "Choose department";
			// 
			// cbxDepEmp
			// 
			cbxDepEmp.FormattingEnabled = true;
			cbxDepEmp.Location = new Point(325, 124);
			cbxDepEmp.Name = "cbxDepEmp";
			cbxDepEmp.Size = new Size(405, 40);
			cbxDepEmp.TabIndex = 5;
			// 
			// lblNewEmp
			// 
			lblNewEmp.AutoSize = true;
			lblNewEmp.Location = new Point(835, 89);
			lblNewEmp.Name = "lblNewEmp";
			lblNewEmp.Size = new Size(110, 32);
			lblNewEmp.TabIndex = 4;
			lblNewEmp.Text = "Assigned";
			// 
			// lblOldEmp
			// 
			lblOldEmp.AutoSize = true;
			lblOldEmp.Location = new Point(46, 89);
			lblOldEmp.Name = "lblOldEmp";
			lblOldEmp.Size = new Size(137, 32);
			lblOldEmp.TabIndex = 3;
			lblOldEmp.Text = "Unassigned";
			// 
			// lbxEmpA
			// 
			lbxEmpA.FormattingEnabled = true;
			lbxEmpA.HorizontalScrollbar = true;
			lbxEmpA.ItemHeight = 32;
			lbxEmpA.Location = new Point(779, 124);
			lbxEmpA.Name = "lbxEmpA";
			lbxEmpA.Size = new Size(332, 260);
			lbxEmpA.TabIndex = 1;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnAssignProd);
			groupBox1.Controls.Add(lblDep2);
			groupBox1.Controls.Add(cbxDepProd);
			groupBox1.Controls.Add(lblNewProd);
			groupBox1.Controls.Add(lblOldProd);
			groupBox1.Controls.Add(lbxProdUa);
			groupBox1.Controls.Add(lbxProdA);
			groupBox1.Location = new Point(47, 605);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(1117, 411);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "Reassign products";
			// 
			// btnAssignProd
			// 
			btnAssignProd.BackColor = Color.Gray;
			btnAssignProd.FlatAppearance.BorderSize = 0;
			btnAssignProd.FlatAppearance.MouseOverBackColor = Color.Brown;
			btnAssignProd.FlatStyle = FlatStyle.Flat;
			btnAssignProd.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point);
			btnAssignProd.ForeColor = Color.White;
			btnAssignProd.Location = new Point(417, 283);
			btnAssignProd.Name = "btnAssignProd";
			btnAssignProd.Size = new Size(242, 101);
			btnAssignProd.TabIndex = 9;
			btnAssignProd.Text = "Assign";
			btnAssignProd.UseVisualStyleBackColor = false;
			btnAssignProd.Click += btnAssignProd_Click;
			// 
			// lblDep2
			// 
			lblDep2.AutoSize = true;
			lblDep2.Location = new Point(325, 89);
			lblDep2.Name = "lblDep2";
			lblDep2.Size = new Size(226, 32);
			lblDep2.TabIndex = 8;
			lblDep2.Text = "Choose department";
			// 
			// cbxDepProd
			// 
			cbxDepProd.FormattingEnabled = true;
			cbxDepProd.Location = new Point(325, 124);
			cbxDepProd.Name = "cbxDepProd";
			cbxDepProd.Size = new Size(405, 40);
			cbxDepProd.TabIndex = 7;
			// 
			// lblNewProd
			// 
			lblNewProd.AutoSize = true;
			lblNewProd.Location = new Point(835, 89);
			lblNewProd.Name = "lblNewProd";
			lblNewProd.Size = new Size(110, 32);
			lblNewProd.TabIndex = 4;
			lblNewProd.Text = "Assigned";
			// 
			// lblOldProd
			// 
			lblOldProd.AutoSize = true;
			lblOldProd.Location = new Point(46, 89);
			lblOldProd.Name = "lblOldProd";
			lblOldProd.Size = new Size(137, 32);
			lblOldProd.TabIndex = 3;
			lblOldProd.Text = "Unassigned";
			// 
			// lbxProdUa
			// 
			lbxProdUa.FormattingEnabled = true;
			lbxProdUa.ItemHeight = 32;
			lbxProdUa.Location = new Point(46, 124);
			lbxProdUa.Name = "lbxProdUa";
			lbxProdUa.Size = new Size(240, 260);
			lbxProdUa.TabIndex = 0;
			// 
			// lbxProdA
			// 
			lbxProdA.FormattingEnabled = true;
			lbxProdA.HorizontalScrollbar = true;
			lbxProdA.ItemHeight = 32;
			lbxProdA.Location = new Point(779, 124);
			lbxProdA.Name = "lbxProdA";
			lbxProdA.Size = new Size(332, 260);
			lbxProdA.TabIndex = 1;
			// 
			// btnReset
			// 
			btnReset.BackColor = Color.Red;
			btnReset.FlatAppearance.BorderSize = 0;
			btnReset.FlatStyle = FlatStyle.Flat;
			btnReset.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point);
			btnReset.ForeColor = Color.White;
			btnReset.Location = new Point(629, 1083);
			btnReset.Name = "btnReset";
			btnReset.Size = new Size(250, 77);
			btnReset.TabIndex = 10;
			btnReset.Text = "Reset";
			btnReset.UseVisualStyleBackColor = false;
			btnReset.Click += btnReset_Click;
			// 
			// btnSubmit
			// 
			btnSubmit.BackColor = SystemColors.AppWorkspace;
			btnSubmit.FlatAppearance.BorderSize = 0;
			btnSubmit.FlatStyle = FlatStyle.Flat;
			btnSubmit.Font = new Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point);
			btnSubmit.ForeColor = Color.White;
			btnSubmit.Location = new Point(348, 1083);
			btnSubmit.Name = "btnSubmit";
			btnSubmit.Size = new Size(250, 77);
			btnSubmit.TabIndex = 9;
			btnSubmit.Text = "Submit";
			btnSubmit.UseVisualStyleBackColor = false;
			btnSubmit.Click += btnSubmit_Click;
			// 
			// ReassignEmpAndProd
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1198, 1233);
			Controls.Add(btnReset);
			Controls.Add(btnSubmit);
			Controls.Add(groupBox1);
			Controls.Add(gbxEmp);
			Controls.Add(panel1);
			Name = "ReassignEmpAndProd";
			Text = "ReassignEmpAndProd";
			FormClosed += ReassignEmpAndProd_FormClosed;
			panel1.ResumeLayout(false);
			gbxEmp.ResumeLayout(false);
			gbxEmp.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private ListBox lbxEmpUa;
		private Panel panel1;
		private Label lblTitle;
		private GroupBox gbxEmp;
		private Label lblOldEmp;
		private Button btnAssignEmp;
		private Label lblDep1;
		private ComboBox cbxDepEmp;
		private Label lblNewEmp;
		private ListBox lbxEmpA;
		private GroupBox groupBox1;
		private Button btnAssignProd;
		private Label lblDep2;
		private ComboBox cbxDepProd;
		private Label lblNewProd;
		private Label lblOldProd;
		private ListBox lbxProdUa;
		private ListBox lbxProdA;
		private Button btnReset;
		private Button btnSubmit;
	}
}