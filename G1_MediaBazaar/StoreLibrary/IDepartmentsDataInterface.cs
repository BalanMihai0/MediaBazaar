using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
    /// <summary>
    /// this interface is implemented by LocationsDataHandler, in DataLibrary
    /// usage: avoid circular dependency, dependency inversion principle. 
    /// manager class uses methods from here
    /// </summary>
    public interface IDepartmentsDataInterface
    {
        int GenerateNewDepartmentId();
        List<Department> GetDepartments();
        void AddDepartmentToDatabase(Department department);
        void RemoveDepartmentFromDatabase(int id);
        void ChangeDepartmentManager(int id, int newManagerId);
        Department GetDepartment(int id);
    }
}
