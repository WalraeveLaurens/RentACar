using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DL.Exceptions
{
    public class ArrangementRepositoryException : Exception
    {
        public ArrangementRepositoryException(string? message) : base(message)
        {
        }

        public ArrangementRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
