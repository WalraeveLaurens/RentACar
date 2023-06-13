using RentACar.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Model
{
    public class Auto
    {
        public int AutoID { get; private set; }
        public string Naam { get; private set; }
        public decimal EersteUurPrijs { get; private set; }
        public decimal NightlifePrijs { get; private set; }
        public decimal WeddingPrijs { get; private set; }
        public int Bouwjaar { get; private set; }

        public Auto(int autoID, string naam, decimal eersteUurPrijs, decimal nightlifePrijs, decimal weddingPrijs, int bouwjaar)
        {
            ZetAutoID(autoID);
            ZetNaam(naam);
            ZetEersteUurPrijs(eersteUurPrijs);
            ZetNightlifePrijs(nightlifePrijs);
            ZetWeddingPrijs(weddingPrijs);
            ZetBouwjaar(bouwjaar);
        }

        public Auto(string naam, decimal eersteUurPrijs, decimal nightlifePrijs, decimal weddingPrijs, int bouwjaar)
        {
            ZetNaam(naam);
            ZetEersteUurPrijs(eersteUurPrijs);
            ZetNightlifePrijs(nightlifePrijs);
            ZetWeddingPrijs(weddingPrijs);
            ZetBouwjaar(bouwjaar);
        }

        public void ZetAutoID(int autoID)
        {
            if (autoID < 0) throw new AutoException("Ongeldige AutoID");
            AutoID = autoID;
        }

        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam)) throw new AutoException("Ongeldige Naam");
            Naam = naam.Trim();
        }

        public void ZetEersteUurPrijs(decimal eersteUurPrijs)
        {
            if (eersteUurPrijs < 0) throw new AutoException("Ongeldige EersteUurPrijs");
            EersteUurPrijs = eersteUurPrijs;
        }

        public void ZetNightlifePrijs(decimal nightlifePrijs)
        {
            if (nightlifePrijs < 0) throw new AutoException("Ongeldige NightlifePrijs");
            NightlifePrijs = nightlifePrijs;
        }

        public void ZetWeddingPrijs(decimal weddingPrijs)
        {
            if (weddingPrijs < 0) throw new AutoException("Ongeldige WeddingPrijs");
            WeddingPrijs = weddingPrijs;
        }

        public void ZetBouwjaar(int bouwjaar)
        {
            if (bouwjaar <= 0) throw new AutoException("Ongeldig Bouwjaar");
            Bouwjaar = bouwjaar;
        }

        public override bool Equals(object? obj)
        {
            return obj is Auto auto &&
                   AutoID == auto.AutoID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AutoID);
        }
    }
}
