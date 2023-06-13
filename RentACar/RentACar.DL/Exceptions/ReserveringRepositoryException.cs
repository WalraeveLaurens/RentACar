using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DL.Exceptions
{
    public class ReserveringRepositoryException : Exception
    {
        public ReserveringRepositoryException(string? message) : base(message)
        {
        }

        public ReserveringRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
