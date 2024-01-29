using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UserLibrary;

namespace StoreLibrary
{
    public class WorkshiftManager
    {
        private readonly IWorkshiftDataInterface _workshiftDataInterface;

        public WorkshiftManager(IWorkshiftDataInterface dataInterface)
        {
            this._workshiftDataInterface = dataInterface;
        }
        public int GenerateId()
        {
            return _workshiftDataInterface.GenerateNewWorkshiftId();
        }
        public void AddWorkshift(Workshift workshift)
        {
            List<Workshift> shiftsOfEmp = EmployeeWorkshifts(workshift.Date, workshift.Employee.Item2);
            if (shiftsOfEmp.Count > 1)
            {
                throw new Exception("Employee already has 2 workshifts!");
            }
            else
            {
                foreach (var item in shiftsOfEmp)
                {
                    if (item.ShiftTime == workshift.ShiftTime)
                    {
                        throw new Exception("Employee already has been assigned to this time!");
                    }
                }
            }
            _workshiftDataInterface.AddWorkshiftToDatabase(workshift);
        }
        public void RemoveWorkshift(Workshift workshift)
        {
            _workshiftDataInterface.RemoveWorkshiftFromDatabase(workshift);
        }
        public List<Workshift> EmployeeWorkshifts(DateOnly? date,Employee employee = null, int departmentId = -2)
        {
            return _workshiftDataInterface.EmployeeWorkshifts(date, employee, departmentId);
        }
        public List<Workshift> EmployeeWorkshifts(DateOnly date, int departmentId)
        {
            return _workshiftDataInterface.EmployeeWorkshifts(date, departmentId);
        }

        public List<Workshift> GetWorkshiftsInRange(DateOnly start, DateOnly end)
        {
            List<Workshift> temp = _workshiftDataInterface.GetAllWorkshiftsFromDatabase();
            List<Workshift> filteredWorkshifts = new List<Workshift>();

            foreach (Workshift workshift in temp)
            {
                if (workshift.Date >= start && workshift.Date <= end)
                {
                    filteredWorkshifts.Add(workshift);
                }
            }

            return filteredWorkshifts;

        }

        public bool RemoveWorkshiftsForEmployee(Employee employee)
        {
            return _workshiftDataInterface.RemoveWorkshiftsForEmployee(employee);
        }
    }
}
