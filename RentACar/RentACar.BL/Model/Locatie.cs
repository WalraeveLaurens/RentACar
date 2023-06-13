using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.BL.Exceptions;

namespace RentACar.BL.Model
{
    public class Locatie
    {
        public int LocatieID { get; private set; }
        public string Stad { get; private set; }

        public Locatie(int locatieID, string stad)
        {
            ZetLocatieID(locatieID);
            ZetStad(stad);
        }

        public Locatie(string stad)
        {
            ZetStad(stad);
        }

        public void ZetLocatieID(int locatieID)
        {
            if (locatieID < 0) throw new LocatieException("Ongeldige LocatieID");
            LocatieID = locatieID;
        }

        public void ZetStad(string stad)
        {
            if (string.IsNullOrWhiteSpace(stad)) throw new LocatieException("Ongeldige Stad");
            Stad = stad.Trim();
        }

        public override bool Equals(object? obj)
        {
            return obj is Locatie locatie &&
                   LocatieID == locatie.LocatieID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LocatieID);
        }
    }
}
