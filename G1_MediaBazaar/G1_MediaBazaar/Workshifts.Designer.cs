namespace G1_MediaBazaar
{
    partial class Workshifts
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
            btnDelete = new Button();
            lbEmpWTime = new Label();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Salmon;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(360, 26);
            btnDelete.Margin = new Padding(2, 2, 2, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(69, 53);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lbEmpWTime
            // 
            lbEmpWTime.AutoSize = true;
            lbEmpWTime.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbEmpWTime.Location = new Point(23, 38);
            lbEmpWTime.Margin = new Padding(2, 0, 2, 0);
            lbEmpWTime.Name = "lbEmpWTime";
            lbEmpWTime.Size = new Size(62, 24);
            lbEmpWTime.TabIndex = 2;
            lbEmpWTime.Text = "label1";
            // 
            // Workshifts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            Controls.Add(btnDelete);
            Controls.Add(lbEmpWTime);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Workshifts";
            Size = new Size(448, 98);
            Load += Workshifts_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private Label lbEmpWTime;
    }
}
