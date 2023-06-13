using RentACar.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.BL.Exceptions;
using RentACar.BL.Interfaces;

namespace RentACar.BL.Managers
{
    public class AutoManager
    {
        private readonly IAutoRepository autoRepository;

        public AutoManager(IAutoRepository autoRepository)
        {
            this.autoRepository = autoRepository;
        }

        public List<Auto> GetAllAutos()
        {
            try
            {
                return autoRepository.GetAll();
            }
            catch (Exception ex)
            {
                // Hier kun je naar behoefte omgaan met de exception
                throw new AutoManagerException("Fout bij het ophalen van alle auto's.", ex);
            }
        }

        public Auto GetAutoById(int id)
        {
            try
            {
                return autoRepository.GetById(id);
            }
            catch (Exception ex)
            {
                // Hier kun je naar behoefte omgaan met de exception
                throw new AutoManagerException($"Fout bij het ophalen van auto met ID {id}.", ex);
            }
        }

        public void AddAuto(Auto auto)
        {
            try
            {
                autoRepository.Add(auto);
            }
            catch (Exception ex)
            {
                // Hier kun je naar behoefte omgaan met de exception
                throw new AutoManagerException("Fout bij het toevoegen van een auto.", ex);
            }
        }
    }
}
