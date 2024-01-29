namespace G1_MediaBazaar
{
    partial class ShiftEntity
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
            this.labelShiftData = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelShiftData
            // 
            this.labelShiftData.AutoSize = true;
            this.labelShiftData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelShiftData.ForeColor = System.Drawing.Color.White;
            this.labelShiftData.Location = new System.Drawing.Point(22, 21);
            this.labelShiftData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelShiftData.Name = "labelShiftData";
            this.labelShiftData.Size = new System.Drawing.Size(76, 32);
            this.labelShiftData.TabIndex = 0;
            this.labelShiftData.Text = "Date: ";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(22, 53);
            this.lbTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(72, 32);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "Time:";
            // 
            // ShiftEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.labelShiftData);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ShiftEntity";
            this.Size = new System.Drawing.Size(375, 107);
            this.Load += new System.EventHandler(this.ShiftEntity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelShiftData;
        private Label lbTime;
    }
}
