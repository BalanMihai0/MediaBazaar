using CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserLibrary
{
	public class Manager : User
    {
		private int jobId;
		private string? phoneNumber;
		private double salary;
		private int departmentId;

		public Manager() { } //used for model binding

        public Manager(int id, string firstName, string lastName, string email, string password, DateTime hireDate, string phoneNumber, double salary, int jobId, int departmentId) : base(id, firstName, lastName, email, password,  hireDate)
		{
			this.jobId = jobId;
			this.phoneNumber = phoneNumber;
			this.salary = salary;
			this.departmentId = departmentId;
		}

		public int JobID { get { return this.jobId; } }

		public string? PhoneNumber
		{
			get { return this.phoneNumber; }
			set
			{
				if (!IsValidPhoneNumber(value))
				{
					throw new InvalidPhoneNumberException("This phone number is invalid");
				}

				this.phoneNumber = value.Trim();
			}
		}

		public double Salary
		{
			get { return this.salary; }
			set
			{
				if (!IsValidSalary(value))
				{
					throw new Exception("Invalid salary");
				}

				this.salary = value;
			}
		}

		public int DepartmentID
		{
			get { return this.departmentId; }
			set
			{
				this.departmentId = value;
			}
		}

		private bool IsValidPhoneNumber(string phoneNumber)
		{
			Regex rg = new Regex(@"^\+\d{10,13}$|^\b[0]\d{9}$"); // "regular expression": matches only strings that start with either 0 or + and contain only digits

			return rg.IsMatch(phoneNumber.Trim());
		}

		private bool IsValidSalary(double salary)
		{
			return salary >= 0;
		}
	}
}
