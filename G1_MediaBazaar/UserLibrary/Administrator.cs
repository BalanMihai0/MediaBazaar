using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLibrary
{
	public class Administrator : User
	{
		public Administrator() { } //used for model binding

		public Administrator(int id, string firstName, string lastName, string email, string password, DateTime hireDate) : base(id, firstName, lastName, email, password, hireDate)
		{
		}
	}
}