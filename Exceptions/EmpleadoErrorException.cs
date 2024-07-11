using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Exceptions
{
    public class EmpleadoErrorException : Exception
    {
        public EmpleadoErrorException(string message) : base(message)
        {
        }
    }
}
