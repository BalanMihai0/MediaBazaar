using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class InvalidDepartmentException : Exception
    {
        public InvalidDepartmentException(string message):base(message) { }
    }
}
