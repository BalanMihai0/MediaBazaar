using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class WeakPasswordException : Exception
    {
        public WeakPasswordException(string message) : base(message) { }
    }
}
