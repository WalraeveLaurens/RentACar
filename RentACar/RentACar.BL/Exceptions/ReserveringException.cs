using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Exceptions
{
    public class ReserveringException : Exception
    {
        public ReserveringException(string? message) : base(message)
        {
        }

        public ReserveringException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
