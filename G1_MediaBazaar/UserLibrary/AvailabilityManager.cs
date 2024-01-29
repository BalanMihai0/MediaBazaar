using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary
{
    public class AvailabilityManager
    {
        private IAvailability availabilityData;

        public AvailabilityManager(IAvailability availabilityData)
        {
            this.availabilityData = availabilityData;
        }

        public void AddAvailability(Availability availability)
        {
            availabilityData.AddAvailability(availability);
        }

        public void DeleteAvailability(Availability availability)
        {
            availabilityData.DeleteAvailability(availability);
        }

        public List<Availability> AvailaibilityOfEmployee(Employee employee)
        {
            return availabilityData.AvailaibilityOfEmployee(employee);
        }
	}
}
