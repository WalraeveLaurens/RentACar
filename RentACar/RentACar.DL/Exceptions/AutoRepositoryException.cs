using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DL.Exceptions
{
    public class AutoRepositoryException : Exception
    {
        public AutoRepositoryException(string? message) : base(message)
        {
        }

        public AutoRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
