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
    public partial class ShiftEntity : UserControl
    {
        Workshift workshift;

        public ShiftEntity(Workshift workshift)
        {
            InitializeComponent();

            this.workshift = workshift;

            labelShiftData.Text += $" {workshift.Date}";
            lbTime.Text += $" {workshift.TimeOfShift}";
        }

        private void ShiftEntity_Load(object sender, EventArgs e)
        {

        }
    }
}
