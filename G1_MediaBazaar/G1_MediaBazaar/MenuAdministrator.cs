using DataLibrary;
using StoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserLibrary;
using SharedLibrary;
using CustomExceptions;

namespace G1_MediaBazaar
{
    public partial class MenuAdministrator : Form
    {
        public MenuAdministrator()
        {

            InitializeComponent();
            InitCbxJobs();
            InitCbxAssignManager();
            InitCbxAssignLocation();
            InitDepartments();
        }

        #region design functions

        private void EmployeeAdedSuccesfully()
        {
            tbEmployeeEmail.Text = string.Empty;
            tbEmployeeFirstName.Text = string.Empty;
            tbEmployeeLastName.Text = string.Empty;
            tbEmployeePassword.Text = string.Empty;
            tbEmployeePhoneNumber.Text = string.Empty;
            tbSalary.Text = string.Empty;
            cbJobs.SelectedItem = -1;
            MessageBox.Show("Succesfully added employee");
        }
        private void InitCbxJobs()
        {
            try
            {
                cbJobs.Items.Clear();
                var jobs = MediaBazzar.Instance.JobsManager.GetAllJobs();
                foreach (var j in jobs)
                {
                    cbJobs.Items.Add(j);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitCbxAssignManager()
        {
            try
            {
                cbxAssignManager.Items.Clear();
                var managers = MediaBazzar.Instance.UserManager.GetAllManagers();
                if (managers != null)
                    foreach (var manager in managers)
                    {
                        if (manager.DepartmentID == 12345)
                        {
                            cbxAssignManager.Items.Add(manager);
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitCbxAssignLocation()
        {
            try
            {
                cbxAssignLocation.Items.Clear();
                var locations = MediaBazzar.Instance.LocationsManager.GetLocations();
                foreach (var location in locations)
                {
                    cbxAssignLocation.Items.Add(location);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateDepartment(Department department, int newManagerID)
        {
            try
            { MediaBazzar.Instance.DepartmentsManager.ChangeDepartmentManager(department.Id, newManagerID); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitDepartments()
        {
            try
            {
                var departments = MediaBazzar.Instance.DepartmentsManager.GetDepartments();

                foreach (var dep in departments)
                {
                    DepartmentEntity depEntity = new DepartmentEntity(this, dep);

                    flowLayoutPanel.Controls.Add(depEntity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonToStatisticControl_Click_1(object sender, EventArgs e)
        {
            panelEmployeeAndItems.Visible = false;
            panelAnnouncements.Visible = true;
            panelDepartments.Visible = false;
        }

        private void buttonToEmployeeControl_Click_1(object sender, EventArgs e)
        {
            panelEmployeeAndItems.Visible = true;
            panelAnnouncements.Visible = false;
            panelDepartments.Visible = false;
        }

        private void buttonToDepartmentControl_Click_1(object sender, EventArgs e)
        {
            panelEmployeeAndItems.Visible = false;
            panelAnnouncements.Visible = false;
            panelDepartments.Visible = true;
        }
        #endregion

        private void UpdateDepartmentsCBBInProducts()
        {
            try
            {
                cbDepartmentName.Items.Clear();
                foreach (var item in MediaBazzar.Instance.DepartmentsManager.GetDepartments())
                {
                    cbDepartmentName.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void comboBox1_TextChanged(object sender, EventArgs e)
        //{
        //	string inputText = comboBox1.Text;
        //	var filteredItems = comboBox1.Items.Cast<string>()
        //						.Where(item => item.StartsWith(inputText));
        //	comboBox1.DataSource = filteredItems.ToList();
        //}

        private void btnCreateDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                string assignedName = tbxAddName.Text;
                Manager assignedManager = (Manager)cbxAssignManager.SelectedItem;
                Location assignedLocation = (Location)cbxAssignLocation.SelectedItem;

                if (assignedName == "" || assignedManager == null || assignedLocation == null)
                {
                    MessageBox.Show("Please enter all input fields before adding a department");

                    return;
                }
                Department dep = MediaBazzar.Instance.DepartmentsManager.AddDepartment(assignedName, assignedManager.ID, assignedLocation.LocationId);
                DepartmentEntity depEntity = new DepartmentEntity(this, dep);

                flowLayoutPanel.Controls.Add(depEntity);
            }
            catch (InvalidDepartmentException ex) { MessageBox.Show(ex.Message); }
        }

        public void RemoveDepartment(DepartmentEntity depEntity)
        {
            //Open form to reassign products and employees
            try
            {
                using ReassignEmpAndProd form = new ReassignEmpAndProd(depEntity.Department);

                form.ShowDialog();

                if (form.DialogResult == DialogResult.Cancel)
                {
                    MessageBox.Show("Deletion canceled");
                }

                else if (form.DialogResult == DialogResult.OK)
                {
                    //Call reassign employees function
                    var reassignedEmpsDict = form.ReassignedEmps;
                    List<Employee> reassignedEmpsList = new List<Employee>();
                    foreach (var emp in reassignedEmpsDict.Keys)
                    {
                        emp.ChangeManagerAndDep(reassignedEmpsDict[emp].ManagerId, reassignedEmpsDict[emp].Id);
                        reassignedEmpsList.Add(emp);
                    }

                    MediaBazzar.Instance.UserManager.ReassignEmployeesToDept(reassignedEmpsList);

                    //Delete workshifts
                    foreach (var emp in reassignedEmpsList)
                    {
                        MediaBazzar.Instance.WorkshiftsManager.RemoveWorkshiftsForEmployee(emp);
                    }

                    //Call reassign products function
                    var reassignedProdsDict = form.ReassignedProds;
                    List<Product> reassignedProdsList = new List<Product>();
                    foreach (var prod in reassignedProdsDict.Keys)
                    {
                        prod.SetDept(reassignedProdsDict[prod]);
                        reassignedProdsList.Add(prod);
                    }

                    MediaBazzar.Instance.ProductsManager.ReassignProdsToDept(reassignedProdsList);

                    //Unassigning manager from the department
                    MediaBazzar.Instance.UserManager.UnassignManagerFromDept(depEntity.Department.ManagerId);

                    //Remove department
                    flowLayoutPanel.Controls.Remove(depEntity);
                    Department department = depEntity.Department;

                    MediaBazzar.Instance.DepartmentsManager.RemoveDepartment(department.Id);
                }
            }
            catch (Exception) // There are already no employees and products in the department
            {
                //Unassigning manager from the department
                MediaBazzar.Instance.UserManager.UnassignManagerFromDept(depEntity.Department.ManagerId);

                //Remove department
                flowLayoutPanel.Controls.Remove(depEntity);
                Department department = depEntity.Department;

                MediaBazzar.Instance.DepartmentsManager.RemoveDepartment(department.Id);
            }
        }

        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = tbEmployeeFirstName.Text;
                string lastName = tbEmployeeLastName.Text;
                string email = tbEmployeeEmail.Text;
                string phoneNumber = tbEmployeePhoneNumber.Text;
                string password = tbEmployeePassword.Text;
                DateTime dateTime = DateTime.Now;


                //to be added to design
                int jobId = ((Job)cbJobs.SelectedItem).Id;
                int departmentId = 12345; // 12345 on adding, department is assigned later
                double salary = Double.Parse(tbSalary.Text);
                if (rbManager.Checked == true)
                {
                    int generalDepartmentID = 12345;
                    MediaBazzar.Instance.UserManager.AddEmployee(new Manager(MediaBazzar.Instance.UserManager.GenerateId(), firstName, lastName, email, password, dateTime, phoneNumber, salary, jobId, generalDepartmentID));
                }
                else
                {
                    MediaBazzar.Instance.UserManager.AddEmployee(new Employee(MediaBazzar.Instance.UserManager.GenerateId(), firstName, lastName, email, password, jobId, dateTime, phoneNumber, salary, 0, departmentId));
                }
                EmployeeAdedSuccesfully();
                cbbEmployeeForDelete.DataSource = MediaBazzar.Instance.UserManager.GetAllUsers();
            }
            catch (FormatException ex) { MessageBox.Show(ex.Message); }
            catch (InvalidEmailException ex) { MessageBox.Show(ex.Message); }
            catch (InvalidFirstNameException ex) { MessageBox.Show(ex.Message); }
            catch (InvalidLastNameException ex) { MessageBox.Show(ex.Message); }
            catch (WeakPasswordException ex) { MessageBox.Show(ex.Message); }
            catch (InvalidDateException ex) { MessageBox.Show(ex.Message); }
            catch (InvalidPhoneNumberException ex) { MessageBox.Show(ex.Message); }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            List<Form> formsToClose = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                formsToClose.Add(form);
            }
            foreach (Form form in formsToClose)
            {
                form.Close();
            }
        }

        private void buttonToStatisticControl_Click(object sender, EventArgs e)
        {
            panelEmployeeAndItems.Visible = false;
            panelAnnouncements.Visible = true;
            panelDepartments.Visible = false;
        }

        private void buttonToDepartmentControl_Click(object sender, EventArgs e)
        {
            panelEmployeeAndItems.Visible = false;
            panelAnnouncements.Visible = false;
            panelDepartments.Visible = true;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                Department tempDepartment = (Department)cbDepartmentName.SelectedItem;
                MediaBazzar.Instance.ProductsManager.AddProduct(new Product(MediaBazzar.Instance.ProductsManager.GenerateId(), tbItemName.Text, rTbProductDescription.Text, tempDepartment, tempDepartment.Id, (int)nUdProductStock.Value));
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonToEmployeeControl_Click(object sender, EventArgs e)
        {
            panelEmployeeAndItems.Visible = true;
            panelAnnouncements.Visible = false;
            panelDepartments.Visible = false;
        }

        private void MenuAdministrator_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateDepartmentsCBBInProducts();
                cbbEmployeeForDelete.DataSource = MediaBazzar.Instance.UserManager.GetAllUsers();
                cbDepartment.DataSource = MediaBazzar.Instance.DepartmentsManager.GetDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbDepartmentName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbManager_CheckedChanged(object sender, EventArgs e)
        {
            if (rbManager.Checked == true)
            {
                labelDepartment.Visible = true;
                cbDepartment.Visible = true;
            }
            else if (rbEmployee.Checked == true)
            {
                labelDepartment.Visible = false;
                cbDepartment.Visible = false;

            }
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Employee tempEmployee = (Employee)cbbEmployeeForDelete.SelectedItem;
                MediaBazzar.Instance.UserManager.RemoveUser(tempEmployee);
                cbbEmployeeForDelete.DataSource = MediaBazzar.Instance.UserManager.GetAllUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbManager_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbManager.Checked == true)
                cbDepartment.Visible = true;
            else
                cbDepartment.Visible = false;
        }

        private void btnPostAnnouncement_Click(object sender, EventArgs e)
        {
            try
            {
                Announcement a = new Announcement();
                a.Title = tbxAnnouncementTitle.Text;
                a.Description = tbxAnnouncementDescription.Text != "" ? tbxAnnouncementDescription.Text : null;
                a.PosterID = 10000;

                MediaBazzar.Instance.AnnouncementManager.AddAnouncement(a);

                tbxAnnouncementTitle.Text = "";
                tbxAnnouncementDescription.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
