using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Exceptions
{
    public class AutoManagerException : Exception
    {
        public AutoManagerException(string? message) : base(message)
        {
        }

        public AutoManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
