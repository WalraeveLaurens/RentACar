using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.BL.Exceptions;

namespace RentACar.BL.Model
{
    public class Arrangement
    {
        public int ArrangementID { get; private set; }
        public string Naam { get; private set; }

        public Arrangement(int arrangementID, string naam)
        {
            ZetArrangementID(arrangementID);
            ZetNaam(naam);
        }

        public Arrangement(string naam)
        {
            ZetNaam(naam);
        }

        public void ZetArrangementID(int arrangementID)
        {
            if (arrangementID < 0) throw new ArrangementException("Ongeldig ArrangementID");
            ArrangementID = arrangementID;
        }

        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam)) throw new ArrangementException("Ongeldige Naam");
            Naam = naam.Trim();
        }

        public override bool Equals(object? obj)
        {
            return obj is Arrangement arrangement &&
                   ArrangementID == arrangement.ArrangementID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ArrangementID);
        }
    }
}
