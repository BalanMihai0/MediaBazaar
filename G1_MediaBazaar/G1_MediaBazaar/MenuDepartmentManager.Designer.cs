namespace G1_MediaBazaar
{
    partial class MenuDepartmentManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuDepartmentManager));
            panelTop = new Panel();
            btnRefresh = new Button();
            btnLogOut = new Button();
            btnCloseForm = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panelMenu = new Panel();
            tableLayoutPanelMenu = new TableLayoutPanel();
            panelToStatistics = new Panel();
            buttonToStatisticControl = new Button();
            panelToSchedule = new Panel();
            buttonToSchedule = new Button();
            panelToEmployeeControl = new Panel();
            buttonToEmployeeControl = new Button();
            panelSchedule = new Panel();
            btnAutoSchedule = new Button();
            panelStatistics = new Panel();
            listEmployees = new ListBox();
            labelItems = new Label();
            listItemsName = new ListBox();
            labelManagerAmountOfItems = new Label();
            labelEmployeeTotalHoursWorked = new Label();
            labelEmployeeDepartment = new Label();
            labelEmployeeId = new Label();
            labelEmployeeSalary = new Label();
            labelEmployeeHireDate = new Label();
            labelFilterByEmployee = new Label();
            labelEmployeeAmount = new Label();
            btnViewSchedule = new Button();
            cbbTimeOfShift = new ComboBox();
            dTpEmployeeSchedule = new DateTimePicker();
            btnRemoveDay = new Button();
            btnAddDay = new Button();
            listWorkingDays = new ListBox();
            labelSchedule = new Label();
            lbxEmployeesShifts = new ListBox();
            label4 = new Label();
            label3 = new Label();
            panelHome = new Panel();
            label2 = new Label();
            panelEmployee = new Panel();
            btnRemoveEmployee = new Button();
            labelCurrentEmployees = new Label();
            listCurrentEmployees = new ListBox();
            btnAddEmployee = new Button();
            labelAvailableEmployees = new Label();
            listFreeEmployees = new ListBox();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelMenu.SuspendLayout();
            tableLayoutPanelMenu.SuspendLayout();
            panelToStatistics.SuspendLayout();
            panelToSchedule.SuspendLayout();
            panelToEmployeeControl.SuspendLayout();
            panelSchedule.SuspendLayout();
            panelStatistics.SuspendLayout();
            panelEmployee.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.Red;
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(btnLogOut);
            panelTop.Controls.Add(btnCloseForm);
            panelTop.Controls.Add(label1);
            panelTop.Controls.Add(pictureBox1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1140, 85);
            panelTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.BackgroundImage = Properties.Resources.refresh;
            btnRefresh.BackgroundImageLayout = ImageLayout.Stretch;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(1011, 0);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(40, 33);
            btnRefresh.TabIndex = 4;
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.Red;
            btnLogOut.BackgroundImage = Properties.Resources.logout__1_;
            btnLogOut.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Location = new Point(1055, 0);
            btnLogOut.Margin = new Padding(0);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(40, 33);
            btnLogOut.TabIndex = 3;
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnCloseForm
            // 
            btnCloseForm.BackColor = Color.Red;
            btnCloseForm.BackgroundImage = Properties.Resources.Transparent_X;
            btnCloseForm.BackgroundImageLayout = ImageLayout.Stretch;
            btnCloseForm.FlatAppearance.BorderSize = 0;
            btnCloseForm.FlatStyle = FlatStyle.Flat;
            btnCloseForm.Location = new Point(1096, 0);
            btnCloseForm.Margin = new Padding(0);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(40, 33);
            btnCloseForm.TabIndex = 2;
            btnCloseForm.UseVisualStyleBackColor = false;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(312, 30);
            label1.Name = "label1";
            label1.Size = new Size(418, 32);
            label1.TabIndex = 1;
            label1.Text = "Welcome, Department Manager of ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.mediabazaarlogoblack;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(9, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(165, 78);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.Red;
            panelMenu.Controls.Add(tableLayoutPanelMenu);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 85);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(201, 431);
            panelMenu.TabIndex = 1;
            // 
            // tableLayoutPanelMenu
            // 
            tableLayoutPanelMenu.ColumnCount = 1;
            tableLayoutPanelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.Controls.Add(panelToStatistics, 0, 2);
            tableLayoutPanelMenu.Controls.Add(panelToSchedule, 0, 0);
            tableLayoutPanelMenu.Controls.Add(panelToEmployeeControl, 0, 1);
            tableLayoutPanelMenu.Location = new Point(4, 2);
            tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            tableLayoutPanelMenu.RowCount = 3;
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMenu.Size = new Size(194, 435);
            tableLayoutPanelMenu.TabIndex = 0;
            // 
            // panelToStatistics
            // 
            panelToStatistics.Controls.Add(buttonToStatisticControl);
            panelToStatistics.Dock = DockStyle.Fill;
            panelToStatistics.Location = new Point(3, 293);
            panelToStatistics.Name = "panelToStatistics";
            panelToStatistics.Size = new Size(188, 139);
            panelToStatistics.TabIndex = 0;
            // 
            // buttonToStatisticControl
            // 
            buttonToStatisticControl.BackColor = Color.Red;
            buttonToStatisticControl.Cursor = Cursors.Hand;
            buttonToStatisticControl.FlatAppearance.BorderSize = 0;
            buttonToStatisticControl.FlatStyle = FlatStyle.Popup;
            buttonToStatisticControl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonToStatisticControl.Location = new Point(3, 5);
            buttonToStatisticControl.Name = "buttonToStatisticControl";
            buttonToStatisticControl.Size = new Size(184, 130);
            buttonToStatisticControl.TabIndex = 1;
            buttonToStatisticControl.Text = "Statistics";
            buttonToStatisticControl.UseVisualStyleBackColor = false;
            buttonToStatisticControl.Click += buttonToStatisticControl_Click;
            // 
            // panelToSchedule
            // 
            panelToSchedule.Controls.Add(buttonToSchedule);
            panelToSchedule.Dock = DockStyle.Fill;
            panelToSchedule.Location = new Point(3, 3);
            panelToSchedule.Name = "panelToSchedule";
            panelToSchedule.Size = new Size(188, 139);
            panelToSchedule.TabIndex = 0;
            // 
            // buttonToSchedule
            // 
            buttonToSchedule.BackColor = Color.Red;
            buttonToSchedule.BackgroundImageLayout = ImageLayout.None;
            buttonToSchedule.Cursor = Cursors.Hand;
            buttonToSchedule.FlatAppearance.BorderSize = 0;
            buttonToSchedule.FlatStyle = FlatStyle.Popup;
            buttonToSchedule.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonToSchedule.Location = new Point(2, 3);
            buttonToSchedule.Name = "buttonToSchedule";
            buttonToSchedule.Size = new Size(185, 133);
            buttonToSchedule.TabIndex = 0;
            buttonToSchedule.Text = "Schedule";
            buttonToSchedule.UseVisualStyleBackColor = false;
            buttonToSchedule.Click += buttonToSchedule_Click;
            // 
            // panelToEmployeeControl
            // 
            panelToEmployeeControl.Controls.Add(buttonToEmployeeControl);
            panelToEmployeeControl.Dock = DockStyle.Fill;
            panelToEmployeeControl.Location = new Point(3, 148);
            panelToEmployeeControl.Name = "panelToEmployeeControl";
            panelToEmployeeControl.Size = new Size(188, 139);
            panelToEmployeeControl.TabIndex = 1;
            // 
            // buttonToEmployeeControl
            // 
            buttonToEmployeeControl.BackColor = Color.Red;
            buttonToEmployeeControl.Cursor = Cursors.Hand;
            buttonToEmployeeControl.FlatAppearance.BorderSize = 0;
            buttonToEmployeeControl.FlatStyle = FlatStyle.Popup;
            buttonToEmployeeControl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonToEmployeeControl.Location = new Point(3, 5);
            buttonToEmployeeControl.Name = "buttonToEmployeeControl";
            buttonToEmployeeControl.Size = new Size(184, 130);
            buttonToEmployeeControl.TabIndex = 1;
            buttonToEmployeeControl.Text = "Employees";
            buttonToEmployeeControl.UseVisualStyleBackColor = false;
            buttonToEmployeeControl.Click += buttonToEmployeeControl_Click;
            // 
            // panelSchedule
            // 
            panelSchedule.Controls.Add(btnAutoSchedule);
            panelSchedule.Controls.Add(panelStatistics);
            panelSchedule.Controls.Add(btnViewSchedule);
            panelSchedule.Controls.Add(cbbTimeOfShift);
            panelSchedule.Controls.Add(dTpEmployeeSchedule);
            panelSchedule.Controls.Add(btnRemoveDay);
            panelSchedule.Controls.Add(btnAddDay);
            panelSchedule.Controls.Add(listWorkingDays);
            panelSchedule.Controls.Add(labelSchedule);
            panelSchedule.Controls.Add(lbxEmployeesShifts);
            panelSchedule.Controls.Add(label4);
            panelSchedule.Dock = DockStyle.Fill;
            panelSchedule.Location = new Point(201, 85);
            panelSchedule.Margin = new Padding(3, 2, 3, 2);
            panelSchedule.Name = "panelSchedule";
            panelSchedule.Size = new Size(939, 431);
            panelSchedule.TabIndex = 2;
            panelSchedule.Visible = false;
            // 
            // btnAutoSchedule
            // 
            btnAutoSchedule.Location = new Point(488, 253);
            btnAutoSchedule.Margin = new Padding(3, 2, 3, 2);
            btnAutoSchedule.Name = "btnAutoSchedule";
            btnAutoSchedule.Size = new Size(395, 32);
            btnAutoSchedule.TabIndex = 25;
            btnAutoSchedule.Text = "Auto Schedule All";
            btnAutoSchedule.UseVisualStyleBackColor = true;
            btnAutoSchedule.Click += btnAutoSchedule_Click;
            // 
            // panelStatistics
            // 
            panelStatistics.Controls.Add(listEmployees);
            panelStatistics.Controls.Add(labelItems);
            panelStatistics.Controls.Add(listItemsName);
            panelStatistics.Controls.Add(labelManagerAmountOfItems);
            panelStatistics.Controls.Add(labelEmployeeTotalHoursWorked);
            panelStatistics.Controls.Add(labelEmployeeDepartment);
            panelStatistics.Controls.Add(labelEmployeeId);
            panelStatistics.Controls.Add(labelEmployeeSalary);
            panelStatistics.Controls.Add(labelEmployeeHireDate);
            panelStatistics.Controls.Add(labelFilterByEmployee);
            panelStatistics.Controls.Add(labelEmployeeAmount);
            panelStatistics.Location = new Point(2, 1);
            panelStatistics.Margin = new Padding(2, 1, 2, 1);
            panelStatistics.Name = "panelStatistics";
            panelStatistics.Size = new Size(939, 440);
            panelStatistics.TabIndex = 2;
            panelStatistics.Visible = false;
            // 
            // listEmployees
            // 
            listEmployees.FormattingEnabled = true;
            listEmployees.ItemHeight = 15;
            listEmployees.Location = new Point(208, 76);
            listEmployees.Margin = new Padding(3, 2, 3, 2);
            listEmployees.Name = "listEmployees";
            listEmployees.Size = new Size(253, 349);
            listEmployees.TabIndex = 14;
            // 
            // labelItems
            // 
            labelItems.AutoSize = true;
            labelItems.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelItems.Location = new Point(485, 98);
            labelItems.Name = "labelItems";
            labelItems.Size = new Size(121, 25);
            labelItems.TabIndex = 13;
            labelItems.Text = "Choose item:";
            // 
            // listItemsName
            // 
            listItemsName.FormattingEnabled = true;
            listItemsName.ItemHeight = 15;
            listItemsName.Location = new Point(628, 76);
            listItemsName.Margin = new Padding(3, 2, 3, 2);
            listItemsName.Name = "listItemsName";
            listItemsName.Size = new Size(281, 349);
            listItemsName.TabIndex = 12;
            // 
            // labelManagerAmountOfItems
            // 
            labelManagerAmountOfItems.AutoSize = true;
            labelManagerAmountOfItems.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelManagerAmountOfItems.Location = new Point(485, 26);
            labelManagerAmountOfItems.Margin = new Padding(2, 0, 2, 0);
            labelManagerAmountOfItems.Name = "labelManagerAmountOfItems";
            labelManagerAmountOfItems.Size = new Size(280, 32);
            labelManagerAmountOfItems.TabIndex = 11;
            labelManagerAmountOfItems.Text = "Total amount of items: ";
            // 
            // labelEmployeeTotalHoursWorked
            // 
            labelEmployeeTotalHoursWorked.AutoSize = true;
            labelEmployeeTotalHoursWorked.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmployeeTotalHoursWorked.Location = new Point(11, 299);
            labelEmployeeTotalHoursWorked.Margin = new Padding(2, 0, 2, 0);
            labelEmployeeTotalHoursWorked.Name = "labelEmployeeTotalHoursWorked";
            labelEmployeeTotalHoursWorked.Size = new Size(142, 20);
            labelEmployeeTotalHoursWorked.TabIndex = 10;
            labelEmployeeTotalHoursWorked.Text = "Total hours worked: ";
            // 
            // labelEmployeeDepartment
            // 
            labelEmployeeDepartment.AutoSize = true;
            labelEmployeeDepartment.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmployeeDepartment.Location = new Point(11, 262);
            labelEmployeeDepartment.Margin = new Padding(2, 0, 2, 0);
            labelEmployeeDepartment.Name = "labelEmployeeDepartment";
            labelEmployeeDepartment.Size = new Size(96, 20);
            labelEmployeeDepartment.TabIndex = 9;
            labelEmployeeDepartment.Text = "Department: ";
            // 
            // labelEmployeeId
            // 
            labelEmployeeId.AutoSize = true;
            labelEmployeeId.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmployeeId.Location = new Point(11, 136);
            labelEmployeeId.Margin = new Padding(2, 0, 2, 0);
            labelEmployeeId.Name = "labelEmployeeId";
            labelEmployeeId.Size = new Size(29, 20);
            labelEmployeeId.TabIndex = 8;
            labelEmployeeId.Text = "Id: ";
            // 
            // labelEmployeeSalary
            // 
            labelEmployeeSalary.AutoSize = true;
            labelEmployeeSalary.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmployeeSalary.Location = new Point(11, 218);
            labelEmployeeSalary.Margin = new Padding(2, 0, 2, 0);
            labelEmployeeSalary.Name = "labelEmployeeSalary";
            labelEmployeeSalary.Size = new Size(56, 20);
            labelEmployeeSalary.TabIndex = 7;
            labelEmployeeSalary.Text = "Salary: ";
            // 
            // labelEmployeeHireDate
            // 
            labelEmployeeHireDate.AutoSize = true;
            labelEmployeeHireDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmployeeHireDate.Location = new Point(11, 176);
            labelEmployeeHireDate.Margin = new Padding(2, 0, 2, 0);
            labelEmployeeHireDate.Name = "labelEmployeeHireDate";
            labelEmployeeHireDate.Size = new Size(78, 20);
            labelEmployeeHireDate.TabIndex = 6;
            labelEmployeeHireDate.Text = "Hire date: ";
            // 
            // labelFilterByEmployee
            // 
            labelFilterByEmployee.AutoSize = true;
            labelFilterByEmployee.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelFilterByEmployee.Location = new Point(11, 97);
            labelFilterByEmployee.Margin = new Padding(2, 0, 2, 0);
            labelFilterByEmployee.Name = "labelFilterByEmployee";
            labelFilterByEmployee.Size = new Size(171, 25);
            labelFilterByEmployee.TabIndex = 3;
            labelFilterByEmployee.Text = "Choose employee: ";
            // 
            // labelEmployeeAmount
            // 
            labelEmployeeAmount.AutoSize = true;
            labelEmployeeAmount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelEmployeeAmount.Location = new Point(11, 25);
            labelEmployeeAmount.Margin = new Padding(2, 0, 2, 0);
            labelEmployeeAmount.Name = "labelEmployeeAmount";
            labelEmployeeAmount.Size = new Size(340, 32);
            labelEmployeeAmount.TabIndex = 0;
            labelEmployeeAmount.Text = "Total amount of employees: ";
            // 
            // btnViewSchedule
            // 
            btnViewSchedule.Location = new Point(488, 367);
            btnViewSchedule.Margin = new Padding(3, 2, 3, 2);
            btnViewSchedule.Name = "btnViewSchedule";
            btnViewSchedule.Size = new Size(407, 32);
            btnViewSchedule.TabIndex = 24;
            btnViewSchedule.Text = "View schedule";
            btnViewSchedule.UseVisualStyleBackColor = true;
            btnViewSchedule.Click += btnViewSchedule_Click;
            // 
            // cbbTimeOfShift
            // 
            cbbTimeOfShift.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTimeOfShift.FormattingEnabled = true;
            cbbTimeOfShift.Location = new Point(488, 83);
            cbbTimeOfShift.Margin = new Padding(2, 1, 2, 1);
            cbbTimeOfShift.Name = "cbbTimeOfShift";
            cbbTimeOfShift.Size = new Size(407, 23);
            cbbTimeOfShift.TabIndex = 23;
            // 
            // dTpEmployeeSchedule
            // 
            dTpEmployeeSchedule.Location = new Point(488, 55);
            dTpEmployeeSchedule.Margin = new Padding(3, 2, 3, 2);
            dTpEmployeeSchedule.MinDate = new DateTime(2023, 3, 16, 0, 0, 0, 0);
            dTpEmployeeSchedule.Name = "dTpEmployeeSchedule";
            dTpEmployeeSchedule.Size = new Size(394, 23);
            dTpEmployeeSchedule.TabIndex = 22;
            dTpEmployeeSchedule.ValueChanged += dTpEmployeeSchedule_ValueChanged;
            // 
            // btnRemoveDay
            // 
            btnRemoveDay.Location = new Point(690, 117);
            btnRemoveDay.Margin = new Padding(3, 2, 3, 2);
            btnRemoveDay.Name = "btnRemoveDay";
            btnRemoveDay.Size = new Size(193, 32);
            btnRemoveDay.TabIndex = 21;
            btnRemoveDay.Text = "Remove workshift";
            btnRemoveDay.UseVisualStyleBackColor = true;
            btnRemoveDay.Click += btnRemoveDay_Click;
            // 
            // btnAddDay
            // 
            btnAddDay.Location = new Point(488, 117);
            btnAddDay.Margin = new Padding(3, 2, 3, 2);
            btnAddDay.Name = "btnAddDay";
            btnAddDay.Size = new Size(193, 32);
            btnAddDay.TabIndex = 20;
            btnAddDay.Text = "Add workshift";
            btnAddDay.UseVisualStyleBackColor = true;
            btnAddDay.Click += btnAddDay_Click;
            // 
            // listWorkingDays
            // 
            listWorkingDays.FormattingEnabled = true;
            listWorkingDays.ItemHeight = 15;
            listWorkingDays.Location = new Point(488, 155);
            listWorkingDays.Margin = new Padding(3, 2, 3, 2);
            listWorkingDays.Name = "listWorkingDays";
            listWorkingDays.Size = new Size(394, 79);
            listWorkingDays.TabIndex = 19;
            // 
            // labelSchedule
            // 
            labelSchedule.AutoSize = true;
            labelSchedule.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelSchedule.Location = new Point(604, 24);
            labelSchedule.Name = "labelSchedule";
            labelSchedule.Size = new Size(139, 25);
            labelSchedule.TabIndex = 17;
            labelSchedule.Text = "Schedule work:";
            // 
            // lbxEmployeesShifts
            // 
            lbxEmployeesShifts.FormattingEnabled = true;
            lbxEmployeesShifts.ItemHeight = 15;
            lbxEmployeesShifts.Location = new Point(30, 52);
            lbxEmployeesShifts.Margin = new Padding(3, 2, 3, 2);
            lbxEmployeesShifts.Name = "lbxEmployeesShifts";
            lbxEmployeesShifts.Size = new Size(328, 349);
            lbxEmployeesShifts.TabIndex = 16;
            lbxEmployeesShifts.SelectedIndexChanged += lbxEmployeesShifts_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(82, 26);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(171, 25);
            label4.TabIndex = 15;
            label4.Text = "Choose employee: ";
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 0;
            // 
            // panelHome
            // 
            panelHome.Location = new Point(0, 0);
            panelHome.Name = "panelHome";
            panelHome.Size = new Size(200, 100);
            panelHome.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(93, 255);
            label2.Name = "label2";
            label2.Size = new Size(893, 62);
            label2.TabIndex = 0;
            label2.Text = "Hello, please choose one of the options";
            // 
            // panelEmployee
            // 
            panelEmployee.Controls.Add(btnRemoveEmployee);
            panelEmployee.Controls.Add(labelCurrentEmployees);
            panelEmployee.Controls.Add(listCurrentEmployees);
            panelEmployee.Controls.Add(btnAddEmployee);
            panelEmployee.Controls.Add(labelAvailableEmployees);
            panelEmployee.Controls.Add(listFreeEmployees);
            panelEmployee.Dock = DockStyle.Fill;
            panelEmployee.Location = new Point(201, 85);
            panelEmployee.Margin = new Padding(2, 1, 2, 1);
            panelEmployee.Name = "panelEmployee";
            panelEmployee.Size = new Size(939, 431);
            panelEmployee.TabIndex = 2;
            panelEmployee.Visible = false;
            // 
            // btnRemoveEmployee
            // 
            btnRemoveEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoveEmployee.Location = new Point(534, 377);
            btnRemoveEmployee.Margin = new Padding(3, 2, 3, 2);
            btnRemoveEmployee.Name = "btnRemoveEmployee";
            btnRemoveEmployee.Size = new Size(298, 47);
            btnRemoveEmployee.TabIndex = 5;
            btnRemoveEmployee.Text = "Remove employee from department";
            btnRemoveEmployee.UseVisualStyleBackColor = true;
            btnRemoveEmployee.Click += btnRemoveEmployee_Click;
            // 
            // labelCurrentEmployees
            // 
            labelCurrentEmployees.AutoSize = true;
            labelCurrentEmployees.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelCurrentEmployees.Location = new Point(572, 52);
            labelCurrentEmployees.Name = "labelCurrentEmployees";
            labelCurrentEmployees.Size = new Size(175, 25);
            labelCurrentEmployees.TabIndex = 4;
            labelCurrentEmployees.Text = "Current employees:";
            // 
            // listCurrentEmployees
            // 
            listCurrentEmployees.FormattingEnabled = true;
            listCurrentEmployees.ItemHeight = 15;
            listCurrentEmployees.Location = new Point(534, 77);
            listCurrentEmployees.Margin = new Padding(3, 2, 3, 2);
            listCurrentEmployees.Name = "listCurrentEmployees";
            listCurrentEmployees.Size = new Size(300, 289);
            listCurrentEmployees.TabIndex = 3;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddEmployee.Location = new Point(49, 377);
            btnAddEmployee.Margin = new Padding(3, 2, 3, 2);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(318, 47);
            btnAddEmployee.TabIndex = 2;
            btnAddEmployee.Text = "Add employee to department";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // labelAvailableEmployees
            // 
            labelAvailableEmployees.AutoSize = true;
            labelAvailableEmployees.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelAvailableEmployees.Location = new Point(79, 52);
            labelAvailableEmployees.Name = "labelAvailableEmployees";
            labelAvailableEmployees.Size = new Size(188, 25);
            labelAvailableEmployees.TabIndex = 1;
            labelAvailableEmployees.Text = "Available employees:";
            // 
            // listFreeEmployees
            // 
            listFreeEmployees.FormattingEnabled = true;
            listFreeEmployees.ItemHeight = 15;
            listFreeEmployees.Location = new Point(49, 77);
            listFreeEmployees.Margin = new Padding(3, 2, 3, 2);
            listFreeEmployees.Name = "listFreeEmployees";
            listFreeEmployees.Size = new Size(317, 289);
            listFreeEmployees.TabIndex = 0;
            // 
            // MenuDepartmentManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1140, 516);
            ControlBox = false;
            Controls.Add(panelSchedule);
            Controls.Add(panelEmployee);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MenuDepartmentManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuAdministrator";
            Load += MenuDepartmentManager_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelMenu.ResumeLayout(false);
            tableLayoutPanelMenu.ResumeLayout(false);
            panelToStatistics.ResumeLayout(false);
            panelToSchedule.ResumeLayout(false);
            panelToEmployeeControl.ResumeLayout(false);
            panelSchedule.ResumeLayout(false);
            panelSchedule.PerformLayout();
            panelStatistics.ResumeLayout(false);
            panelStatistics.PerformLayout();
            panelEmployee.ResumeLayout(false);
            panelEmployee.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Panel panelMenu;
        private TableLayoutPanel tableLayoutPanelMenu;
        private Panel panelToStatistics;
        private Panel panelToSchedule;
        private Panel panelToEmployeeControl;
        private Button buttonToStatisticControl;
        private Button buttonToSchedule;
        private Button buttonToEmployeeControl;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btnCloseForm;
        private Button btnLogOut;
        private Panel panelHome;
        private Label label2;
        private Label label3;
        private Panel panelStatistics;
        private Label labelEmployeeTotalHoursWorked;
        private Label labelEmployeeDepartment;
        private Label labelEmployeeId;
        private Label labelEmployeeSalary;
        private Label labelEmployeeHireDate;
        private Label labelFilterByEmployee;
        private Label labelEmployeeAmount;
        private Panel panelEmployee;
        private Panel panelSchedule;
        private ListBox listEmployees;
        private Label labelItems;
        private ListBox listItemsName;
        private Label labelManagerAmountOfItems;
        private Button btnRemoveDay;
        private Button btnAddDay;
        private ListBox listWorkingDays;
        private Label labelSchedule;
        private ListBox lbxEmployeesShifts;
        private Label label4;
        private Button btnRemoveEmployee;
        private Label labelCurrentEmployees;
        private ListBox listCurrentEmployees;
        private Button btnAddEmployee;
        private Label labelAvailableEmployees;
        private ListBox listFreeEmployees;
        private DateTimePicker dTpEmployeeSchedule;
        private Button btnRefresh;
        private Button btnViewSchedule;
        private ComboBox cbbTimeOfShift;
        private Button btnAutoSchedule;
    }
}