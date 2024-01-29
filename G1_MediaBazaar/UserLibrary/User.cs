
using CustomExceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace UserLibrary
{
	public abstract class User
	{

		[Required] private int id;
		[Required] private string? firstName;
		[Required] private string? lastName;
		[Required] private string? email;
		[Required] private string? password;
		[Required] private DateTime hireDate;

		public User() { } //used for model binding

		public User(int id, string firstName, string lastName, string email, string password, DateTime hireDate)
		{
			this.id = id;
			Password = password;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			HireDate = hireDate;
		}

		#region properties + validation
		public int ID { get { return id; } }

		public string FirstName
		{
			get { return firstName; }
			set
			{
				if (IsValidName(value))
					firstName = value;
				else throw new InvalidFirstNameException("Invalid First Name");
			}
		}

		public string LastName
		{
			get { return lastName; }
			set
			{
				if (IsValidName(value))
					lastName = value;
				else throw new InvalidLastNameException("Invalid Last Name");
			}
		}

		public string Email
		{
			get { return email; }
			set
			{
				if (IsValidEmail(value.Trim()))
				{
					email = value;
				}
				else throw new InvalidEmailException("Invalid Email");
			}
		}

		public string Password
		{
			get { return password; }
			set
			{
				if (IsPasswordWeak(value))
				{
					throw new WeakPasswordException("Password is too weak");
				}

				password = value;
			}
		}

		public DateTime HireDate
		{
			get { return hireDate; }
			set
			{
				if (IsHireDateValid(value))
					hireDate = value;
				else throw new InvalidDateException("Invalid Birth Date");
			}
		}

		private bool IsValidEmail(string email)
		{
			Regex regex = new Regex("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$");

			return regex.IsMatch(email);
		}


		private bool IsValidName(string firstName)
		{
			if (string.IsNullOrEmpty(firstName))
			{
				return false;
			}

			foreach (char c in firstName)
			{
				if (!char.IsLetter(c) && c != '-')
				{
					return false;
				}
			}

			if (!char.IsLetter(firstName[0]) || !char.IsLetter(firstName[firstName.Length - 1]))
			{
				return false;
			}

			if (firstName.Length > 50)
			{
				return false;
			}
			return true;
		}

		private bool IsPasswordWeak(string password)
		{
            /// <summary>
            /// passowrd must be 8 characters or longer
            /// password must contain letters and digits and/or special characters
            /// </summary>
            
			Regex regex = new Regex("^(?=.*[A - Za - z])(?=.*\\d)[A - Za - z\\d]{ 8,}$");

            return regex.IsMatch(password);

        }

        private static bool IsHireDateValid(DateTime date)
		{
			if (DateTime.Compare(date, DateTime.Now) > 0) //if date1 later than date2
			{
				return false;
			}

			return true;
		}

		public override string ToString()
		{
			return $"{FirstName} {LastName}, ID: {ID}";
		}
		#endregion
	}
}