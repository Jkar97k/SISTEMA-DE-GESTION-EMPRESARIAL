using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Services.Base.Exceptions
{
    public class EmpleadoErrorException : Exception
    {
        EmpleadoErrorException(string message) : base(message) { }
    }
}
