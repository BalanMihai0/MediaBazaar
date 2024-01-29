namespace G1_MediaBazaar
{
    partial class Form2
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            tbLoginEmailOrEmployeeId = new TextBox();
            tbLoginPassword = new TextBox();
            button1 = new Button();
            label1 = new Label();
            tbEmail = new TextBox();
            btnSubmit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.mediabazaarlogored;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(112, 14);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tbLoginEmailOrEmployeeId
            // 
            tbLoginEmailOrEmployeeId.Location = new Point(0, 0);
            tbLoginEmailOrEmployeeId.Name = "tbLoginEmailOrEmployeeId";
            tbLoginEmailOrEmployeeId.Size = new Size(100, 23);
            tbLoginEmailOrEmployeeId.TabIndex = 10;
            // 
            // tbLoginPassword
            // 
            tbLoginPassword.Location = new Point(0, 0);
            tbLoginPassword.Name = "tbLoginPassword";
            tbLoginPassword.Size = new Size(100, 23);
            tbLoginPassword.TabIndex = 9;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(1254, -1);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(47, 44);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 22.875F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(560, 270);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(698, 35);
            label1.TabIndex = 11;
            label1.Text = "Please input your email for password recovery:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbEmail
            // 
            tbEmail.BackColor = Color.White;
            tbEmail.BorderStyle = BorderStyle.FixedSingle;
            tbEmail.Font = new Font("Microsoft Sans Serif", 17.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmail.Location = new Point(828, 339);
            tbEmail.Margin = new Padding(4, 5, 4, 5);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(430, 34);
            tbEmail.TabIndex = 12;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.Red;
            btnSubmit.Font = new Font("Microsoft Sans Serif", 17.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(908, 403);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(350, 66);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // Form2
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1300, 700);
            Controls.Add(btnSubmit);
            Controls.Add(tbEmail);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(tbLoginPassword);
            Controls.Add(tbLoginEmailOrEmployeeId);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbLoginEmailOrEmployeeId;
        private System.Windows.Forms.TextBox tbLoginPassword;
        private Button button1;
        private Label label1;
        private TextBox tbEmail;
        private Button btnSubmit;
    }
}