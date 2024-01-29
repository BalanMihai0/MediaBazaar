using SharedLibrary;
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
    public partial class Schedule : Form
    {
        Manager loggedIn;
        MenuDepartmentManager manager;
        public Schedule(Manager loggedIn, MenuDepartmentManager dept)
        {
            this.loggedIn = loggedIn;
            manager = dept;
            InitializeComponent();
            UpdateFLP();
        }
        public void UpdateFLP()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (var item in MediaBazzar.Instance.WorkshiftsManager.EmployeeWorkshifts(DateOnly.FromDateTime(monthCalendar1.SelectionStart), loggedIn.DepartmentID))
                {
                    Workshifts workS = new Workshifts(item, this, manager);
                    flowLayoutPanel1.Controls.Add(workS);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateFLP();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {

        }
    }
}
