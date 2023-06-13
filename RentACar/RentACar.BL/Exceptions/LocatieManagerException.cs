using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Exceptions
{
    public class LocatieManagerException : Exception
    {
        public LocatieManagerException(string? message) : base(message)
        {
        }

        public LocatieManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
