using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
    public class Product
    {
        private int id;
        private string name;
        private string description;
        private int departmentId;
        public Department? department;
        private int stock;

        public Product(int id, string name, string description, Department? department, int departmentId, int stock)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.department = department;
            this.stock = stock;
            this.departmentId = departmentId;
        }

        public void IncreaseStock(int amount = 0)
        {
            if (amount == 0)
                stock++;
            else
                stock = stock + amount;
        }
        public void DecreaseStock(int amount = 0)
        {
            if (amount == 0)
                stock--;
            else
                stock = stock - amount;
        }
        public int Id { get => id; }
        public string Name { get => name; }
        public string Description { get => description; }
        public int DepartmentId { get => departmentId; }
        public Department? Department { get => department; }
        public void SetDept(Department department)
        {
            this.department = department;
            this.departmentId = department.Id;
        }
        public int Stock { get => stock; }
        public override string ToString()
        {
            return name;
        }
    }
}
