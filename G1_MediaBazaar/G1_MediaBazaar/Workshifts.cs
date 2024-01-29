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
using SharedLibrary;

namespace G1_MediaBazaar
{
    public partial class Workshifts : UserControl
    {
        Workshift workShift;
        Schedule schedule;
        MenuDepartmentManager manager;
        public Workshifts(Workshift workshift, Schedule sched, MenuDepartmentManager dept)
        {
            this.workShift = workshift;
            schedule = sched;
            manager = dept;
            InitializeComponent();
        }

        private void Workshifts_Load(object sender, EventArgs e)
        {
            lbEmpWTime.Text = $"{workShift.Employee} - {workShift.TimeOfShift}";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MediaBazzar.Instance.WorkshiftsManager.RemoveWorkshift(workShift);
                if (manager.SelectedEmp.ID == workShift.Employee.Item2.ID)
                    manager.UpdateLBXShifts(workShift.Employee.Item2);
                schedule.UpdateFLP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
