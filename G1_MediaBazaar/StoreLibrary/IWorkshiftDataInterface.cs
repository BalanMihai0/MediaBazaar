using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary;

namespace StoreLibrary
{
    public interface IWorkshiftDataInterface
    {
        int GenerateNewWorkshiftId();
        void AddWorkshiftToDatabase(Workshift workshift);
        void RemoveWorkshiftFromDatabase(Workshift workshift);
        List<Workshift> EmployeeWorkshifts(DateOnly? date, Employee employee = null, int departmentId = -2);
        List<Workshift> EmployeeWorkshifts(DateOnly date, int departmentId);
        List<Workshift> GetAllWorkshiftsFromDatabase();

        bool RemoveWorkshiftsForEmployee(Employee employee);
	}
}
