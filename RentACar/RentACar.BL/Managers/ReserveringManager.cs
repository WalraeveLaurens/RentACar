using RentACar.BL.Exceptions;
using RentACar.BL.Interfaces;
using RentACar.BL.Model;
using System;
using System.Collections.Generic;

namespace RentACar.BL.Managers
{
    public class ReserveringManager
    {
        private readonly IReserveringRepository reserveringRepository;

        public ReserveringManager(IReserveringRepository reserveringRepository)
        {
            this.reserveringRepository = reserveringRepository;
        }

        public void AddReservering(Reservering reservering)
        {
            try
            {
                ValidateReservering(reservering);
                reserveringRepository.Add(reservering);
            }
            catch (Exception ex)
            {
                // Hier kun je naar behoefte omgaan met de exception
                throw new ReserveringManagerException("Fout bij het toevoegen van een reservering.", ex);
            }
        }

        public List<Reservering> GetReserveringen()
        {
            try
            {
                return reserveringRepository.GetReserveringen();
            }
            catch (Exception ex)
            {
                // Hier kun je naar behoefte omgaan met de exception
                throw new ReserveringManagerException("Fout bij het ophalen van reserveringen.", ex);
            }
        }

        public List<Reservering> SearchReserveringen(string searchNaam, DateTime? startDate, DateTime? endDate)
        {
            
            try
            {
                return reserveringRepository.SearchReserveringen(searchNaam, startDate, endDate);
            }
            catch (Exception ex)
            {
                // Hier kun je naar behoefte omgaan met de exception
                throw new ReserveringManagerException("Fout bij het zoeken van reserveringen.", ex);
            }
        }


        // Voer eventuele validaties uit op de reservering voordat deze wordt toegevoegd
        private void ValidateReservering(Reservering reservering)
        {
            if (reservering == null)
            {
                throw new ReserveringManagerException("Ongeldige reservering");
            }

            // Voer hier aanvullende validaties uit op de reservering, indien nodig
        }
    }
}
