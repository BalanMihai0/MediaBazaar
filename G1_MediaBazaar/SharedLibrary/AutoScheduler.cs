using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary;
using StoreLibrary;
using Org.BouncyCastle.Crypto.Signers;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using Org.BouncyCastle.Asn1.Esf;

namespace SharedLibrary
{
    /// <summary>
    /// pretty self explanatory, just pray it works
    ///
    /// </summary>
    public static class AutoScheduler
    {
        private static List<User> allEmployees = MediaBazzar.Instance.UserManager.GetAllEmployees(); //all employees

        private static bool AreAllWorkshiftsFull(DateOnly start, DateOnly end)
        {
            int total = 7 * 3;
            return (MediaBazzar.Instance.WorkshiftsManager.GetWorkshiftsInRange(start, end)).Count() >= total;
        }

        public static void Schedule(Department d)
        {
            Random random = new Random();
            //get target week
            DateOnly weekstart = DateOnly.FromDateTime(DateTime.Now); //first monday going back in time
            while (weekstart.DayOfWeek != DayOfWeek.Monday)
            {
                weekstart = weekstart.AddDays(-1);
            }
            DateOnly weekend = weekstart.AddDays(6); //first sunday going forward in time

            //remove existing workshifts from target week
            List<Workshift> notGood = MediaBazzar.Instance.WorkshiftsManager.GetWorkshiftsInRange(weekstart, weekend);
            List<Workshift> workshiftsToRemove = new List<Workshift>();

            foreach (Workshift workshift in notGood)
            {
                workshiftsToRemove.Add(workshift);
            }

            foreach (Workshift workshift in workshiftsToRemove)
            {
                MediaBazzar.Instance.WorkshiftsManager.RemoveWorkshift(workshift);
            }

            //first assign availability on a first come first served basis

            //get all availabilities
            List<User> allUsers = MediaBazzar.Instance.UserManager.GetAllEmployees();
            List<Employee> allEmployees = allUsers.OfType<Employee>().ToList();
            List<Employee> meh = allUsers.OfType<Employee>().ToList();
            //make sure we re only touching employees from that department
            foreach(Employee e in meh)
            {
                if(e.DepartmentID != d.Id)
                {
                    allEmployees.Remove(e);
                }
            }
            meh = null; //no longer needed
            List<Availability> availabilities = new List<Availability>(); 
            foreach (Employee emp in allEmployees) 
            { 
                List<Availability> temp = MediaBazzar.Instance.AvailabilityManager.AvailaibilityOfEmployee(emp);
                foreach (Availability temp2 in temp)
                {
                    if(temp2.Date>=weekstart && temp2.Date <= weekend)
                        availabilities.Add(temp2);
                }
            }

            //assign availabilities in order
            foreach (Availability av in availabilities)
            {
                int id = random.Next(1000, 9999);
                AvailabilityTimeEnum availabilityTime = av.ShiftAvailibility.Item2;
                ShiftTimeEnum shiftTime = (ShiftTimeEnum)Enum.Parse(typeof(ShiftTimeEnum), availabilityTime.ToString());

                Workshift wok = new Workshift(id, new Tuple<int, Employee>(id, av.Employee), av.Date, shiftTime, av.Employee.DepartmentID);

                if(!CheckAlreadyAssignedWorkshift(wok, weekstart, weekend) ) { MediaBazzar.Instance.WorkshiftsManager.AddWorkshift(wok); }
                
            }
            //assign remaining workshifts to employees randomly?
            if(!AreAllWorkshiftsFull(weekstart, weekend))
            {
                //get remaining workshifts dates

                List<Tuple<DateOnly, ShiftTimeEnum>> freeSpots = new List<Tuple<DateOnly, ShiftTimeEnum>>();
                //all workshifts
                for(DateOnly date = weekstart; date<=weekend; date= date.AddDays(1))
                {
                    freeSpots.Add(new Tuple<DateOnly, ShiftTimeEnum>(date, ShiftTimeEnum.Morning));
                    freeSpots.Add(new Tuple<DateOnly, ShiftTimeEnum>(date, ShiftTimeEnum.Evening));
                    freeSpots.Add(new Tuple<DateOnly, ShiftTimeEnum>(date, ShiftTimeEnum.Afternoon));
                }
                //remove occupied workshifts
                List<Workshift> workshifts = MediaBazzar.Instance.WorkshiftsManager.GetWorkshiftsInRange(weekstart, weekend);
                foreach(Workshift wks in workshifts)
                {
                    Tuple<DateOnly, ShiftTimeEnum> toCheck = new Tuple<DateOnly, ShiftTimeEnum>(wks.Date, wks.ShiftTime);
                    if(freeSpots.Contains(toCheck))
                    {
                        freeSpots.Remove(toCheck);
                    }
                }
                //freespots actually contains what it should now
                int minIterations = Math.Min(allEmployees.Count(), freeSpots.Count());

                for( int i=0; i < minIterations; i++)
                {
                    int id = random.Next(1000, 9999);
                    Tuple<DateOnly, ShiftTimeEnum> freeSpot = freeSpots[i];
                    Employee employee = allEmployees[i];
                    int departmentId = employee.DepartmentID;

                    MediaBazzar.Instance.WorkshiftsManager.AddWorkshift(new Workshift(id, new Tuple<int, Employee?>(employee.ID, employee), freeSpot.Item1, freeSpot.Item2, departmentId));
                }
            }

            
        }

        private static bool CheckAlreadyAssignedWorkshift(Workshift wok,DateOnly weekstart, DateOnly weekend)
        {
            List<Workshift> workshifts = MediaBazzar.Instance.WorkshiftsManager.GetWorkshiftsInRange(weekstart, weekend);
            foreach(Workshift wks in workshifts)
            {
                if(wok.Date == wks.Date && wok.ShiftTime.ToString() == wks.ShiftTime.ToString()) 
                {
                    //workshift was already assigned
                    return true;
                }
            }
            return false;
        }
    }
}
