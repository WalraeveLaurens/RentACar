using RentACar.BL.Model;
using System;
using System.Collections.Generic;

namespace RentACar.BL.Interfaces
{
    public interface IReserveringRepository
    {
        void Add(Reservering reservering);
        List<Reservering> GetReserveringen();
        List<Reservering> SearchReserveringen(string searchNaam, DateTime? startDate, DateTime? endDate);


    }
}
