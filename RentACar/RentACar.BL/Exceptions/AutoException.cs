using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Exceptions
{
    public class AutoException : Exception
    {
        public AutoException(string? message) : base(message)
        {
        }

        public AutoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
