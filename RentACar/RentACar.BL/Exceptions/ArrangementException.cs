using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Exceptions
{
    public class ArrangementException : Exception
    {
        public ArrangementException(string? message) : base(message)
        {
        }

        public ArrangementException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
