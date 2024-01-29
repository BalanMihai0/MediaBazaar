using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary
{
    public class Availability
    {
        private Employee _employee;
        private DateOnly _date;
        private Tuple<Weekday, AvailabilityTimeEnum> _availability;
        public Availability(Employee employee, Weekday weekday, AvailabilityTimeEnum availabilityTimeEnum, DateOnly date)
        {
            _employee = employee;
            Tuple<Weekday, AvailabilityTimeEnum> newTuple = Tuple.Create(weekday, availabilityTimeEnum);
            _availability = newTuple;
            _date = date;
        }
        public Employee Employee { get { return _employee; } }
        public Tuple<Weekday, AvailabilityTimeEnum> ShiftAvailibility { get { return _availability; } }
        public DateOnly Date { get { return _date; } }

     
    }
}
