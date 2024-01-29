using DataLibrary;
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
using static System.Reflection.Metadata.BlobBuilder;

namespace G1_MediaBazaar
{
    public partial class DepartmentDetails : Form
    {
        private Department department;
        private MenuAdministrator menu;
        private int newManagerID;


        public DepartmentDetails(MenuAdministrator menu, Department department)
        {
            InitializeComponent();

            this.department = department;
            this.menu = menu;
            tbxName.Text = department.DepartmentName;
            InitManagers();
            InitLocations();
        }


        private void InitManagers()
        {
            try
            {
                cbxManager.Items.Clear();
                var managers = MediaBazzar.Instance.UserManager.GetAllManagers();
                if (managers != null)
                    foreach (var manager in managers)
                    {
                        if (manager.DepartmentID == 12345)
                        {
                            cbxManager.Items.Add(manager);
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitLocations()
        {
            try
            {
                cbxLocation.Items.Clear();
                var locations = MediaBazzar.Instance.LocationsManager.GetLocations();
                foreach (var location in locations)
                {
                    cbxLocation.Items.Add(location);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var oldManagerID = department.ManagerId;
                MediaBazzar.Instance.UserManager.UnassignManagerFromDept(oldManagerID);
                newManagerID = ((Manager)cbxManager.SelectedItem).ID;
                var location = (Location)cbxLocation.SelectedItem;
                if (location != null)
                {
                    department.LocationId = location.LocationId;
                }
                menu.UpdateDepartment(department, newManagerID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Update succesful!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
