using DataLibrary;
using SharedLibrary;
using StoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserLibrary;

namespace G1_MediaBazaar
{
    public partial class MenuEmployee : Form
    {
        Employee loggedIn;

        public MenuEmployee(Employee employee)
        {
            InitializeComponent();
            loggedIn = employee;
        }

        private void buttonToEmployeeControl_Click(object sender, EventArgs e)
        {
            panelStockControl.Hide();
            panelEmployeeInfo.Show();

        }
        private void MenuEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in MediaBazzar.Instance.ProductsManager.Products())
                {
                    if (item.department.Id == loggedIn.DepartmentID)
                    {
                        listItemsName.Items.Add(item);
                    }

                }
                //lbxEmployeeShifts.DataSource = MediaBazzar.Instance.WorkshiftsManager.EmployeeWorkshifts(loggedIn);
                foreach (var workshift in MediaBazzar.Instance.WorkshiftsManager.EmployeeWorkshifts(null, loggedIn))
                {
                    flowLayoutPanel1.Controls.Add(new ShiftEntity(workshift));
                }
                lbLoggedIn.Text = $"Logged in as {loggedIn.FirstName} {loggedIn.LastName}";
                FillInEmployeeInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillInEmployeeInfo()
        {
            try
            {
                User manager = MediaBazzar.Instance.UserManager.GetUser(loggedIn.ManagerID);
                tbNewFirstName.Text = loggedIn.FirstName;
                tbNewLastName.Text = loggedIn.LastName;
                tbNewEmail.Text = loggedIn.Email;
                tbNewPhone.Text = loggedIn.PhoneNumber;
                tbDepartmentName.Text = MediaBazzar.Instance.DepartmentsManager.GetDepartment(loggedIn.DepartmentID).DepartmentName;
                tbManagerName.Text = $"{manager.FirstName} {manager.LastName}";
                nUdID.Value = loggedIn.ID;
                dTPHireDate.Value = loggedIn.HireDate;
                nUDSalary.Value = (decimal)loggedIn.Salary;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // save the changed amount of stock on the chosen item in listItemsName
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            Product tempProduct = (Product)listItemsName.SelectedItem;
            tempProduct.DecreaseStock();
            tbStockChange.Text = tempProduct.Stock.ToString();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            Product tempProduct = (Product)listItemsName.SelectedItem;
            tempProduct.IncreaseStock();
            tbStockChange.Text = tempProduct.Stock.ToString();
        }

        private void btnToStock_Click(object sender, EventArgs e)
        {
            panelStockControl.Visible = true;
            panelEmployeeInfo.Visible = false;
        }

        private void buttonToEmployeeInfo_Click_1(object sender, EventArgs e)
        {

            panelStockControl.Visible = false;
            panelEmployeeInfo.Visible = true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                Product tempProduct = (Product)listItemsName.SelectedItem;
                MediaBazzar.Instance.ProductsManager.UpdateProductStock(tempProduct);

                MessageBox.Show(tempProduct.Name + " stock has changed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCheck_Click_1(object sender, EventArgs e)
        {
            // Display an mbox with item name and current amount in stock
        }

        private void listItemsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(listItemsName.SelectedItem == null))
                {
                    Product tempProduct = (Product)listItemsName.SelectedItem;
                    tempProduct = MediaBazzar.Instance.ProductsManager.CheckProductFromDB(tempProduct);
                    tbStockChange.Text = tempProduct.Stock.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnToStock_Click_1(object sender, EventArgs e)
        {
            panelStockControl.Visible = true;
            panelEmployeeInfo.Visible = false;
        }

        private void buttonToEmployeeInfo_Click_2(object sender, EventArgs e)
        {
            panelStockControl.Visible = false;
            panelEmployeeInfo.Visible = true;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnSaveEmpChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNewEmail.Text) ||
                string.IsNullOrEmpty(tbNewFirstName.Text) ||
                string.IsNullOrEmpty(tbNewLastName.Text) ||
                string.IsNullOrEmpty(tbNewPhone.Text) ||
                !IsValidEmail(tbNewEmail.Text) ||
                !IsValidPhoneNumber(tbNewPhone.Text))
            {
                MessageBox.Show("The changes are invalid");

                return;
            }

            try
            {
                loggedIn.Email = tbNewEmail.Text;
                loggedIn.FirstName = tbNewFirstName.Text;
                loggedIn.LastName = tbNewLastName.Text;
                loggedIn.PhoneNumber = tbNewPhone.Text;

                MediaBazzar.Instance.UserManager.UpdateUser(loggedIn.ID, loggedIn);

                btnChangeData.Visible = true;
                btnCancel.Visible = false;
                btnSaveEmpChanges.Visible = false;
                tbNewFirstName.Enabled = false;
                tbNewLastName.Enabled = false;
                tbNewEmail.Enabled = false;
                tbNewPhone.Enabled = false;
                FillInEmployeeInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            Regex regex = new Regex("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$");

            return regex.IsMatch(email);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex rg = new(@"^\+\d{10,13}$|^\b[0]\d{9}$"); // matches only strings that start with either 0 or + and contain only digits

            return rg.IsMatch(phoneNumber.Trim());
        }

        private void btnChangeData_Click(object sender, EventArgs e)
        {
            btnChangeData.Visible = false;
            btnCancel.Visible = true;
            btnSaveEmpChanges.Visible = true;
            tbNewFirstName.Enabled = true;
            tbNewLastName.Enabled = true;
            tbNewEmail.Enabled = true;
            tbNewPhone.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnChangeData.Visible = true;
            btnCancel.Visible = false;
            btnSaveEmpChanges.Visible = false;
            tbNewFirstName.Enabled = false;
            tbNewLastName.Enabled = false;
            tbNewEmail.Enabled = false;
            tbNewPhone.Enabled = false;
            FillInEmployeeInfo();
        }
    }
}
