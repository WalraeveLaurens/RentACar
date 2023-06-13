using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.BL.Exceptions;

namespace RentACar.BL.Model
{
    public class Klant
    {
        public Klant() { }
        public Klant(int klantID, string klantnummer, string voornaam, string naam, string straat, string straatnummer, string busnummer, string plaats, string postcode, string btwNummer)
        {
            ZetKlantID(klantID);
            ZetKlantnummer(klantnummer);
            ZetVoornaam(voornaam);
            ZetNaam(naam);
            ZetStraat(straat);
            ZetStraatnummer(straatnummer);
            ZetBusnummer(busnummer);
            ZetPlaats(plaats);
            ZetPostcode(postcode);
            ZetBTWNummer(btwNummer);
        }
        public Klant(string klantnummer, string voornaam, string naam, string straat, string straatnummer, string busnummer, string plaats, string postcode, string btwNummer)
        {
            ZetKlantnummer(klantnummer);
            ZetVoornaam(voornaam);
            ZetNaam(naam);
            ZetStraat(straat);
            ZetStraatnummer(straatnummer);
            ZetBusnummer(busnummer);
            ZetPlaats(plaats);
            ZetPostcode(postcode);
            ZetBTWNummer(btwNummer);
        }

        public int KlantID { get;  set; }
        public string Klantnummer { get;  set; }
        public string Voornaam { get;  set; }
        public string Naam { get;  set; }
        public string Straat { get;  set; }
        public string Straatnummer { get;  set; }
        public string? Busnummer { get;  set; }
        public string Plaats { get;  set; }
        public string Postcode { get;  set; }
        public string? BTWNummer { get;  set; }

        public void ZetKlantID(int klantID)
        {
            if (klantID < 0) throw new KlantException("Ongeldig KlantID");
            KlantID = klantID;
        }

        public void ZetKlantnummer(string klantnummer)
        {
            if (string.IsNullOrWhiteSpace(klantnummer)) throw new KlantException("Ongeldig Klantnummer");
            Klantnummer = klantnummer.Trim();
        }

        public void ZetVoornaam(string voornaam)
        {
            if (string.IsNullOrWhiteSpace(voornaam)) throw new KlantException("Ongeldige Voornaam");
            Voornaam = voornaam.Trim();
        }

        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam)) throw new KlantException("Ongeldige Naam");
            Naam = naam.Trim();
        }

        public void ZetStraat(string straat)
        {
            if (string.IsNullOrWhiteSpace(straat)) throw new KlantException("Ongeldige Straat");
            Straat = straat.Trim();
        }

        public void ZetStraatnummer(string straatnummer)
        {
            if (string.IsNullOrWhiteSpace(straatnummer)) throw new KlantException("Ongeldig Straatnummer");
            Straatnummer = straatnummer.Trim();
        }

        public void ZetBusnummer(string busnummer)
        {
            Busnummer = busnummer?.Trim();
        }

        public void ZetPlaats(string plaats)
        {
            if (string.IsNullOrWhiteSpace(plaats)) throw new KlantException("Ongeldige Plaats");
            Plaats = plaats.Trim();
        }

        public void ZetPostcode(string postcode)
        {
            if (string.IsNullOrWhiteSpace(postcode)) throw new KlantException("Ongeldige Postcode");
            Postcode = postcode.Trim();
        }

        public void ZetBTWNummer(string btwNummer)
        {
            BTWNummer = btwNummer?.Trim();
        }

        public override bool Equals(object obj)
        {
            return obj is Klant klant && KlantID == klant.KlantID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(KlantID);
        }
    }
}
