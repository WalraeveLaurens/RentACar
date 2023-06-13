using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Exceptions
{
    public class ReserveringManagerException : Exception
    {
        public ReserveringManagerException(string? message) : base(message)
        {
        }

        public ReserveringManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
