using CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
    public class DepartmentsManager
    {

        private readonly IDepartmentsDataInterface _deptDataStorage;

        public DepartmentsManager(IDepartmentsDataInterface dataInterface) 
        { 
            _deptDataStorage= dataInterface;
        }

        public List<Department> GetDepartments()
        {
            return _deptDataStorage.GetDepartments();
        }

        public Department AddDepartment(string departmentName, int managerId, int locationId )
        {
            Department department = new Department(_deptDataStorage.GenerateNewDepartmentId(), departmentName, managerId, locationId);

            try
            {
                _deptDataStorage.AddDepartmentToDatabase(department);
            }
			catch(InvalidDepartmentException ide) 
            { 
                throw new InvalidDepartmentException(ide.Message);
                //exception is sent to Form
            }

            return department;
        }

        public void RemoveDepartment(int id)
        {
            _deptDataStorage.RemoveDepartmentFromDatabase(id);
        }

        public void ChangeDepartmentManager(int departmentId,int newManagerId)
        {
            _deptDataStorage.ChangeDepartmentManager(departmentId,newManagerId);
        }

        public Department GetDepartment(int id)
        {
            return _deptDataStorage.GetDepartment(id);
        }
    }
}
