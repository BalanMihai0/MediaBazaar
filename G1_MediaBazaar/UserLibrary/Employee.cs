using CustomExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace UserLibrary
{
    public class Employee : User
    {
        private int jobId;
        private string phoneNumber;
        private double salary;
        private int managerId;
        private int departmentId;

        public Employee() { } //used for model binding

        public Employee(int id, string firstName, string lastName, string email, string password, int jobId, DateTime hireDate, string phoneNumber, double salary, int managerId, int departmentId) : base(id, firstName, lastName, email, password, hireDate)
        {
            PhoneNumber = phoneNumber;
            Salary = salary;
            ManagerID = managerId;
            DepartmentID = departmentId;
            JobID = jobId;
        }

        #region properties & validation
        public int JobID
        {
            get { return jobId; }
            private set
            {
                jobId = value;
            }
        }

        public string? PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (!IsValidPhoneNumber(value))
                    throw new InvalidPhoneNumberException("This phone number is invalid");

                phoneNumber = value.Trim();
            }
        }
        public double Salary
        {
            get { return salary; }
            private set
            {
                if (!IsValidSalary(value))
                {
                    throw new Exception("Invalid salary");
                }

                salary = value;
            }
        }

        public int ManagerID
        {
            get { return managerId; }
            private set
            {
                managerId = value;
            }
        }

        public int DepartmentID
        {
            get { return departmentId; }
            private set
            {
                departmentId = value;
            }
        }
        public void ChangeManagerAndDep(Manager manager, bool delManager = false)
        {
            if (delManager)
            {
                managerId = 0;
                departmentId = 12345;
            }
            else
            {
                managerId = manager.ID;
                departmentId = manager.DepartmentID;
            }

        }

        public void ChangeManagerAndDep(int managerId, int departmentId)
        {
            this.managerId = managerId;
            this.departmentId = departmentId;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex rg = new(@"^\+\d{10,13}$|^\b[0]\d{9}$"); // matches only strings that start with either 0 or + and contain only digits

            return rg.IsMatch(phoneNumber.Trim());
        }

        private bool IsValidSalary(double salary)
        {
            return salary >= 0;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        #endregion


    }
}