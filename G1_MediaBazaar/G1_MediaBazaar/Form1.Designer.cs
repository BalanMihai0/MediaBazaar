using Microsoft.VisualBasic.Logging;

namespace G1_MediaBazaar
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            tbLoginEmailOrEmployeeId = new TextBox();
            tbLoginPassword = new TextBox();
            label1 = new Label();
            btnLogin = new Button();
            button1 = new Button();
            label2 = new Label();
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
            tbLoginEmailOrEmployeeId.BackColor = Color.White;
            tbLoginEmailOrEmployeeId.BorderStyle = BorderStyle.FixedSingle;
            tbLoginEmailOrEmployeeId.Font = new Font("Microsoft Sans Serif", 17.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbLoginEmailOrEmployeeId.Location = new Point(826, 315);
            tbLoginEmailOrEmployeeId.Margin = new Padding(4, 5, 4, 5);
            tbLoginEmailOrEmployeeId.Name = "tbLoginEmailOrEmployeeId";
            tbLoginEmailOrEmployeeId.Size = new Size(350, 34);
            tbLoginEmailOrEmployeeId.TabIndex = 1;
            tbLoginEmailOrEmployeeId.Text = "Email/EmployeeID";
            tbLoginEmailOrEmployeeId.TextChanged += tbLoginEmailOrEmployeeId_TextChanged;
            tbLoginEmailOrEmployeeId.Enter += tbLoginEmailOrEmployeeId_Enter;
            // 
            // tbLoginPassword
            // 
            tbLoginPassword.BackColor = Color.White;
            tbLoginPassword.BorderStyle = BorderStyle.FixedSingle;
            tbLoginPassword.Font = new Font("Microsoft Sans Serif", 17.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbLoginPassword.Location = new Point(826, 379);
            tbLoginPassword.Margin = new Padding(4, 5, 4, 5);
            tbLoginPassword.Name = "tbLoginPassword";
            tbLoginPassword.PasswordChar = '*';
            tbLoginPassword.Size = new Size(350, 34);
            tbLoginPassword.TabIndex = 2;
            tbLoginPassword.Text = "Password";
            tbLoginPassword.Enter += tbLoginPassword_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 22.875F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(826, 119);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(367, 105);
            label1.TabIndex = 3;
            label1.Text = "Welcome ,Please log in \r\nbefore continuing\r\n\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Red;
            btnLogin.Font = new Font("Microsoft Sans Serif", 17.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(826, 444);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(350, 66);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
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
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(907, 547);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(178, 24);
            label2.TabIndex = 6;
            label2.Text = "Forgot Password?";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1300, 700);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Controls.Add(tbLoginPassword);
            Controls.Add(tbLoginEmailOrEmployeeId);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbLoginEmailOrEmployeeId;
        private System.Windows.Forms.TextBox tbLoginPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private Button button1;
        private Label label2;
    }
}