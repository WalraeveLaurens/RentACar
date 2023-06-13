using RentACar.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.BL.Interfaces;
using RentACar.BL.Exceptions;



namespace RentACar.BL.Managers
{
    public class ArrangementManager
    {
        private readonly IArrangementRepository repository;

        public ArrangementManager(IArrangementRepository repository)
        {
            this.repository = repository;
        }

        public List<Arrangement> GetAllArrangements()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                // Hier kun je naar behoefte omgaan met de exception
                throw new ArrangementManagerException("Error occurred while retrieving arrangements.", ex);
            }
        }

        public void AddArrangement(string naam)
        {
            try
            {
                Arrangement arrangement = new Arrangement( naam); // arrangementID zal automatisch gegenereerd worden in de database
                repository.Add(arrangement);
            }
            catch (Exception ex)
            {
                // Hier kun je naar behoefte omgaan met de exception
                throw new ArrangementManagerException("Error occurred while adding an arrangement.", ex);
            }
        }
    }
}
