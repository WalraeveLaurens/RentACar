using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Exceptions
{
    public class ArrangementManagerException : Exception
    {
        public ArrangementManagerException(string? message) : base(message)
        {
        }

        public ArrangementManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
