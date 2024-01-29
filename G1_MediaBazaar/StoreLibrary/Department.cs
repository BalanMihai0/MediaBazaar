using System.Text.RegularExpressions;
using CustomExceptions;

namespace StoreLibrary
{
    public class Department
    {
        private int id;
        private string departmentName;
        private int managerId;
        private int locationId;

        public Department(int id, string departmentName, int managerId, int locationId)
        {
            Id = id;
            DepartmentName = departmentName;
            ManagerId = managerId;
            LocationId = locationId;
        }

        #region properties & validation
        public int Id
        {
            get { return id; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidDepartmentException("Id cannot be negative");
                }
                id = value;
            }
        }

        public string DepartmentName
        {
            get { return departmentName; }
            private set
            {
                Regex departmentNameValid = new Regex(@"^[a-zA-Z0-9\s]{3,50}$");
                if (string.IsNullOrEmpty(value) || !departmentNameValid.IsMatch(value))
                {
                    throw new InvalidDepartmentException("Department name cannot be null or empty");
                }
                departmentName = value;
            }
        }

        public int ManagerId
        {
            get { return managerId; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidDepartmentException("Manager id cannot be negative");
                }
                managerId = value;
            }
        }

        public int LocationId
        {
            get { return locationId; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidDepartmentException("Location id cannot be negative");
                }
                locationId = value;
            }
        }
        #endregion

        public override string ToString()
        {
            return $"Department {this.id}, {this.departmentName}, managed by {this.managerId}, situated in {this.locationId}" ;
        }
    }
}