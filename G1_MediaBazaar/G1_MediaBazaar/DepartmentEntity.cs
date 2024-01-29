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

namespace G1_MediaBazaar
{
	public partial class DepartmentEntity : UserControl
	{
		MenuAdministrator menuAdministrator;

		public DepartmentEntity(MenuAdministrator menuAdministrator, Department department)
		{
			InitializeComponent();
			this.menuAdministrator = menuAdministrator;
			Department = department;
			lblDepartmentName.Text = department.DepartmentName;
			lblManagerID.Text += department.ManagerId;
			lblLocation.Text += department.LocationId;
		}

		public Department Department { get; set; }

		private void btnRemoveDep_Click(object sender, EventArgs e)
		{
			menuAdministrator.RemoveDepartment(this);
		}

		private void ViewDetails(object sender, EventArgs e)
		{
			DepartmentDetails details = new DepartmentDetails(menuAdministrator, Department);
			details.Show();
		}
	}
}
