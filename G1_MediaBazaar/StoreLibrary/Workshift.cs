using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary;

namespace StoreLibrary
{
    public class Workshift
    {
        private int id;
        private Tuple<int,Employee?> employee;
        private DateOnly date;
        private ShiftTimeEnum shiftTime;
        private int departmentId;
        private Dictionary<ShiftTimeEnum, string> timeOfShift = new Dictionary<ShiftTimeEnum, string>()
        {
            { ShiftTimeEnum.Morning, "8:00 - 12:00"},
            { ShiftTimeEnum.Afternoon, "12:00 - 16:00" },
            { ShiftTimeEnum.Evening, "16:00 - 20:00" }
        };

        public Workshift(int id, Tuple<int,Employee?> employee, DateOnly date, ShiftTimeEnum shiftTime, int departmentId)
        {
            this.id = id;
            this.employee = employee;
            this.date = date;
            this.shiftTime = shiftTime;
            this.departmentId = departmentId;
        }

        public int Id { get => id; }
        public Tuple<int,Employee?> Employee { get => employee; }
        public void SetEmployee(Tuple<int, Employee?> emp)
        {
            employee = emp;
        }
        public DateOnly Date { get => date; }
        public ShiftTimeEnum ShiftTime { get => shiftTime; }
        public string TimeOfShift { get => timeOfShift[shiftTime]; }
        public int DepartmentId { get => departmentId; }
        public string Color
        {
            get
            {
                // Replace these colors with your desired colors for each ShiftTimeEnum
                return shiftTime switch
                {
                    ShiftTimeEnum.Morning => "red",
                    ShiftTimeEnum.Afternoon => "green",
                    ShiftTimeEnum.Evening => "blue",
                    _ => "gray"
                };
            }
        }

        public DateTime StartTime
        {
            get
            {
                string startTimeString = timeOfShift[shiftTime].Split('-')[0].Trim();
                DateTime startTime = DateTime.ParseExact(startTimeString, "H:mm", CultureInfo.InvariantCulture);
                TimeOnly startTimeOnly = TimeOnly.FromDateTime(startTime);
                return date.ToDateTime(startTimeOnly);
            }
        }

        public DateTime EndTime
        {
            get
            {
                string endTimeString = timeOfShift[shiftTime].Split('-')[1].Trim();
                DateTime endTime = DateTime.ParseExact(endTimeString, "H:mm", CultureInfo.InvariantCulture);
                TimeOnly endTimeOnly = TimeOnly.FromDateTime(endTime);
                return date.ToDateTime(endTimeOnly);
            }
        }
        public override string ToString()
        {
            return $"{Date} - {timeOfShift[shiftTime]}";
        }
    }
}
