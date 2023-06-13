using RentACar.BL.Model;
using RentACar.BL.Exceptions;
using RentACar.BL.Interfaces;
using System;
using System.Collections.Generic;

namespace RentACar.BL.Managers
{
    public class KlantManager
    {
        private readonly IKlantRepository klantRepository;

        public KlantManager(IKlantRepository klantRepository)
        {
            this.klantRepository = klantRepository;
        }

        public List<Klant> GetAllKlanten()
        {
            try
            {
                return klantRepository.GetAll();
            }
            catch (Exception ex)
            {
                // Hier kun je naar behoefte omgaan met de exception
                throw new KlantManagerException("Fout bij het ophalen van alle klanten.", ex);
            }
        }

        public void AddKlant(Klant klant)
        {
            try
            {
                klantRepository.Add(klant);
            }
            catch (Exception ex)
            {
                // Hier kun je naar behoefte omgaan met de exception
                throw new KlantManagerException("Fout bij het toevoegen van een klant.", ex);
            }
        }
    }
}
