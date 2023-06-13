using RentACar.BL.Interfaces;
using RentACar.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.BL.Exceptions;

namespace RentACar.BL.Managers
{
    public class LocatieManager
    {
        private readonly ILocatieRepository locatieRepository;

        public LocatieManager(ILocatieRepository locatieRepository)
        {
            this.locatieRepository = locatieRepository;
        }

        public List<Locatie> GetAllLocaties()
        {
            try
            {
                return locatieRepository.GetAll();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new LocatieManagerException("Failed to retrieve locations.", ex);
            }
        }

        public void AddLocatie(Locatie locatie)
        {
            try
            {
                locatieRepository.Add(locatie);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new LocatieManagerException("Failed to add location.", ex);
            }
        }
    }
}
