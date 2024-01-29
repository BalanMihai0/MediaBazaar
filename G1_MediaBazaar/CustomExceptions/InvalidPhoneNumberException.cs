using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
	public class InvalidPhoneNumberException : Exception
	{
		public InvalidPhoneNumberException(string message) : base (message)
		{
		}
	}
}
