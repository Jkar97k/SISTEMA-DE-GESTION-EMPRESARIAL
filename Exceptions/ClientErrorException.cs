using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ClientErrorException : Exception
    {
        public ClientErrorException(string message) : base(message)
        {
        }
    }
}
