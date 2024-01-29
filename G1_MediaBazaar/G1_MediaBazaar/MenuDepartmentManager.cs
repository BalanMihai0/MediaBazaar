using DataLibrary;
using SharedLibrary;
using StoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserLibrary;

namespace G1_MediaBazaar
{
    public partial class MenuDepartmentManager : Form
    {
        private Manager loggedIn;

        public MenuDepartmentManager(Manager loggedIn)
        {
            try
            {
                InitializeComponent();
                this.loggedIn = loggedIn;
                label1.Text += " " + (MediaBazzar.Instance.DepartmentsManager.GetDepartment(loggedIn.DepartmentID)).DepartmentName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Employee SelectedEmp { get => (Employee)lbxEmployeesShifts.SelectedItem; }
        private void UpdateDeptEmployees()
        {
            try
            {
                listCurrentEmployees.Items.Clear();
                listFreeEmployees.Items.Clear();
                List<Employee> employees = MediaBazzar.Instance.UserManager.GetAllUsers().Cast<Employee>().ToList();
                foreach (Employee item in employees)
                {
                    if (item.ManagerID == 0)
                    {
                        listFreeEmployees.Items.Add(item);
                    }
                    if (item.ManagerID == loggedIn.ID)
                    {
                        listCurrentEmployees.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //This is for lbx with employees in shift panel
        private void UpdateLBXEmpShifts()
        {
            try
            {
                lbxEmployeesShifts.Items.Clear();
                foreach (Employee item in MediaBazzar.Instance.UserManager.GetAllUsers())
                {
                    if (item.ManagerID == loggedIn.ID)
                        lbxEmployeesShifts.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //This is for lbx with shifts of selected employee
        public void UpdateLBXShifts(Employee employee)
        {
            try
            {
                listWorkingDays.Items.Clear();
                foreach (var item in MediaBazzar.Instance.WorkshiftsManager.EmployeeWorkshifts(DateOnly.FromDateTime(dTpEmployeeSchedule.Value), employee))
                {
                    listWorkingDays.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnCloseForm_Click(object sender, EventArgs e)
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }

        private void buttonToEmployeeControl_Click(object sender, EventArgs e)
        {
            panelEmployee.Visible = true;
            panelStatistics.Visible = false;
            panelSchedule.Visible = false;
        }

        private void buttonToSchedule_Click(object sender, EventArgs e)
        {
            panelEmployee.Visible = false;
            panelStatistics.Visible = false;
            panelSchedule.Visible = true;
        }

        private void buttonToStatisticControl_Click(object sender, EventArgs e)
        {
            panelEmployee.Visible = false;
            panelStatistics.Visible = true;
            panelSchedule.Visible = false;
        }

        private void btnAddDay_Click(object sender, EventArgs e)
        {
            try
            {
                Employee tempEmployee = (Employee)lbxEmployeesShifts.SelectedItem;
                Tuple<int, Employee?> tempTuple = new Tuple<int, Employee?>(tempEmployee.ID, tempEmployee);
                Workshift shift = new Workshift(MediaBazzar.Instance.WorkshiftsManager.GenerateId(), tempTuple, DateOnly.FromDateTime(dTpEmployeeSchedule.Value), (ShiftTimeEnum)cbbTimeOfShift.SelectedItem, loggedIn.DepartmentID);
                MediaBazzar.Instance.WorkshiftsManager.AddWorkshift(shift);
                UpdateLBXShifts(tempEmployee);
                string message = $"You have been assigned to a {shift.ShiftTime} shift on {shift.Date}.";
                MediaBazzar.Instance.UserManager.SendEmail(tempEmployee.Email, message, "New shift");

                MessageBox.Show("Shift added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveDay_Click(object sender, EventArgs e)
        {
            try
            {
                Employee tempEmployee = (Employee)lbxEmployeesShifts.SelectedItem;
                Tuple<int, Employee?> tempTuple = new Tuple<int, Employee?>(tempEmployee.ID, tempEmployee);
                Workshift shift = (Workshift)listWorkingDays.SelectedItem;
                MediaBazzar.Instance.WorkshiftsManager.RemoveWorkshift(shift);
                UpdateLBXShifts(tempEmployee);
                string message = $"Your {shift.ShiftTime} shift on " + shift.Date + " has been removed.";
                MediaBazzar.Instance.UserManager.SendEmail(tempEmployee.Email, message, "Removed shift");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuDepartmentManager_Load(object sender, EventArgs e)
        {
            UpdateLBXEmpShifts();
            UpdateDeptEmployees();
            foreach (var item in Enum.GetValues(typeof(ShiftTimeEnum)))
            {
                cbbTimeOfShift.Items.Add(item);
            }
        }

        private void lbxEmployeesShifts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Employee tempEmployee = (Employee)lbxEmployeesShifts.SelectedItem;
                UpdateLBXShifts(tempEmployee);
                cbbTimeOfShift.SelectedItem = null;
            }
            catch (Exception)
            {
                return;
            }

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Employee tempEmployee = (Employee)listFreeEmployees.SelectedItem;
                tempEmployee.ChangeManagerAndDep(loggedIn);
                MediaBazzar.Instance.UserManager.UpdateUser(tempEmployee.ID, tempEmployee);
                UpdateDeptEmployees();
                UpdateLBXEmpShifts();

                MessageBox.Show(tempEmployee.FirstName + " " + tempEmployee.LastName + " successfully added to this department");
            }
            catch (Exception)
            {
                return;
            }

        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Employee tempEmployee = (Employee)listCurrentEmployees.SelectedItem;
                tempEmployee.ChangeManagerAndDep(loggedIn, true);
                MediaBazzar.Instance.UserManager.UpdateUser(tempEmployee.ID, tempEmployee);
                UpdateDeptEmployees();
                UpdateLBXEmpShifts();

                MessageBox.Show(tempEmployee.FirstName + " " + tempEmployee.LastName + " successfully removed from this department");
            }
            catch (Exception)
            {
                return;
            }

        }

        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            Schedule schedForm = new Schedule(loggedIn, this);
            schedForm.ShowDialog();
        }

        private void dTpEmployeeSchedule_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateLBXShifts((Employee)lbxEmployeesShifts.SelectedItem);
            }
            catch
            {
            }
        }

        private void btnAutoSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                Department d = MediaBazzar.Instance.DepartmentsManager.GetDepartment(loggedIn.DepartmentID);
                AutoScheduler.Schedule(d);
                MessageBox.Show("Operation succesful");
            }
            catch(Exception) { MessageBox.Show("Something went wrong, please try again later!"); }
        }
    }
}
