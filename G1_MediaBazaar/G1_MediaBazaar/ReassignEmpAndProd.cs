using SharedLibrary;
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

namespace G1_MediaBazaar
{
    public partial class ReassignEmpAndProd : Form
    {
        private Department currentDep;
        private bool isSubmitted;

        public ReassignEmpAndProd(Department current)
        {
            InitializeComponent();
            currentDep = current;
            ReassignedEmps = new Dictionary<Employee, Department>();
            ReassignedProds = new Dictionary<Product, Department>();
            isSubmitted = false;

            lblTitle.Text += currentDep.DepartmentName;
            InitEmployeesLbx();
            InitProductsLbx();

            if (lbxEmpUa.Items.Count == 0 && lbxProdUa.Items.Count == 0)
            {
                this.Close();
                return;
            }

            InitDepartmentsCbx();
        }

        public Dictionary<Employee, Department> ReassignedEmps { get; private set; }

        public Dictionary<Product, Department> ReassignedProds { get; private set; }

        private void InitEmployeesLbx()
        {
            try
            {
                lbxEmpUa.Items.Clear();
                lbxEmpA.Items.Clear();

                foreach (Employee item in MediaBazzar.Instance.UserManager.GetAllUsers())
                {
                    if (item.DepartmentID == currentDep.Id)
                    {
                        lbxEmpUa.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitProductsLbx()
        {
            try
            {
                lbxProdUa.Items.Clear();
                lbxProdA.Items.Clear();

                foreach (Product item in MediaBazzar.Instance.ProductsManager.Products())
                {
                    if (item.DepartmentId == currentDep.Id)
                    {
                        lbxProdUa.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitDepartmentsCbx()
        {
            try
            {
                foreach (Department item in MediaBazzar.Instance.DepartmentsManager.GetDepartments())
                {
                    if (item.Id != currentDep.Id)
                    {
                        cbxDepEmp.Items.Add(item);
                        cbxDepProd.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReassignEmpAndProd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isSubmitted)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAssignEmp_Click(object sender, EventArgs e)
        {
            if (lbxEmpUa.SelectedItem == null)
            {
                return;
            }
            if (cbxDepEmp.SelectedItem == null)
            {
                return;
            }

            Employee emp = lbxEmpUa.SelectedItem as Employee;
            Department chosen = cbxDepEmp.SelectedItem as Department;

            ReassignedEmps.Add(emp, chosen);

            lbxEmpUa.Items.Remove(emp);
            lbxEmpA.Items.Add($"{emp.FirstName} {emp.LastName} - {chosen.DepartmentName}");

            //emp.ChangeManagerAndDep(chosen.ManagerId, chosen.Id);
        }

        private void btnAssignProd_Click(object sender, EventArgs e)
        {
            if (lbxProdUa.SelectedItem == null)
            {
                return;
            }
            if (cbxDepProd.SelectedItem == null)
            {
                return;
            }

            Product prod = lbxProdUa.SelectedItem as Product;
            Department chosen = cbxDepProd.SelectedItem as Department;

            ReassignedProds.Add(prod, chosen);

            lbxProdUa.Items.Remove(prod);
            lbxProdA.Items.Add($"{prod.Name} - {chosen.DepartmentName}");

            //prod.SetDept(chosen);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ReassignedEmps.Clear();
            ReassignedProds.Clear();

            InitEmployeesLbx();
            InitProductsLbx();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lbxEmpUa.Items.Count > 0 || lbxProdUa.Items.Count > 0)
            {
                MessageBox.Show("You must reassign ALL employees and products");

                return;
            }

            isSubmitted = true;

            Close();
        }
    }
}
