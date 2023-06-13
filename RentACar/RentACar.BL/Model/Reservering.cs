using RentACar.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BL.Model
{
    public class Reservering
    {
        public Reservering() { }
        public Reservering(int reserveringID, Klant klant, List<Auto> autos, Arrangement arrangement, DateTime startDatum, TimeSpan startUur, int aantalUren, Locatie startLocatie, Locatie aankomstLocatie)
        {
            ZetReserveringID(reserveringID);
            ZetKlant(klant);
            ZetAutos(autos);
            ZetStartDatum(startDatum);
            ZetStartUur(startUur);
            ZetAantalUren(aantalUren);
            ZetStartLocatie(startLocatie);
            ZetAankomstLocatie(aankomstLocatie);
            ZetSoortUur(startUur);
            ZetArrangement(arrangement, startUur);
            BerekenEenheidsprijs();
            BerekenSubtotaal();
        }
        public Reservering( Klant klant, List<Auto> autos, Arrangement arrangement, DateTime startDatum, TimeSpan startUur, int aantalUren, Locatie startLocatie, Locatie aankomstLocatie)
        {
            ZetKlant(klant);
            ZetAutos(autos);
            
            ZetStartDatum(startDatum);
            ZetStartUur(startUur);
            ZetAantalUren(aantalUren);
            ZetStartLocatie(startLocatie);
            ZetAankomstLocatie(aankomstLocatie);
            ZetSoortUur(startUur);
            ZetArrangement(arrangement, startUur);
            BerekenEenheidsprijs();
            BerekenSubtotaal();
        }

        public Reservering(int reserveringID, Klant klant, List<Auto> autos, Arrangement arrangement, DateTime startDatum, TimeSpan startUur, int aantalUren, string soortUur, decimal eenheidsprijs, decimal subtotaal, Locatie startLocatie, Locatie aankomstLocatie)
        {
            ReserveringID = reserveringID;
            Klant = klant;
            Autos = autos;
            Arrangement = arrangement;
            StartDatum = startDatum;
            StartUur = startUur;
            AantalUren = aantalUren;
            SoortUur = soortUur;
            Eenheidsprijs = eenheidsprijs;
            Subtotaal = subtotaal;
            StartLocatie = startLocatie;
            AankomstLocatie = aankomstLocatie;
        }

        public int ReserveringID { get;  set; }
        public Klant Klant { get;  set; }
        public List<Auto> Autos { get;  set; }
        public Arrangement Arrangement { get;  set; }
        public DateTime StartDatum { get;  set; }
        public TimeSpan StartUur { get;  set; }
        public int AantalUren { get;  set; }
        public string SoortUur { get;  set; }
        public decimal Eenheidsprijs { get;  set; }
        public decimal Subtotaal { get;  set; }
        public Locatie StartLocatie { get;  set; }
        public Locatie AankomstLocatie { get;  set; }

        public void ZetReserveringID(int reserveringID)
        {
            if (reserveringID <0) throw new ReserveringException("Ongeldig ReserveringID");
            ReserveringID = reserveringID;
        }

        public void ZetKlant(Klant klant)
        {
            Klant = klant ?? throw new ReserveringException("Ongeldige Klant");
        }

        public void ZetAutos(List<Auto> autos)
        {
            if (autos == null || autos.Count == 0) throw new ReserveringException("Ongeldige Autos");
            Autos = autos;
        }

        /*public void ZetArrangement(Arrangement arrangement)
        {
            if (arrangement == null)
            {
                throw new ReserveringException("Ongeldig Arrangement");
            }

            if (arrangement.Naam == "Nightlife")
            {
                if (StartUur < new TimeSpan(20, 0, 0) || StartUur > new TimeSpan(23, 59, 59))
                {
                    throw new ReserveringException("Nightlife-arrangement moet starten tussen 20:00 en 24:00");
                }
            }
            else if (arrangement.Naam == "Wedding")
            {
                if (StartUur < new TimeSpan(7, 0, 0) || StartUur > new TimeSpan(14, 59, 59))
                {
                    throw new ReserveringException("Wedding-arrangement moet starten tussen 7:00 en 15:00");
                }
            }

            Arrangement = arrangement;
        }*/

        //test
        public void ZetArrangement(Arrangement arrangement, TimeSpan startUur)
        {
            if (arrangement == null)
            {
                throw new ReserveringException("Ongeldig Arrangement");
            }

            if (arrangement.Naam == "Nightlife")
            {
                if (startUur < new TimeSpan(20, 0, 0) || startUur > new TimeSpan(23, 59, 59))
                {
                    throw new ReserveringException("Nightlife-arrangement moet starten tussen 20:00 en 24:00");
                }
            }
            else if (arrangement.Naam == "Wedding")
            {
                if (startUur < new TimeSpan(7, 0, 0) || startUur > new TimeSpan(14, 59, 59))
                {
                    throw new ReserveringException("Wedding-arrangement moet starten tussen 7:00 en 15:00");
                }
            }

            Arrangement = arrangement;
        }

        public void ZetStartDatum(DateTime startDatum)
        {
            StartDatum = startDatum;
        }

        public void ZetStartUur(TimeSpan startUur)
        {
            StartUur = startUur;
        }

        public void ZetAantalUren(int aantalUren)
        {
            if (aantalUren <= 0 || aantalUren > 11) throw new ReserveringException("Ongeldig AantalUren");
            AantalUren = aantalUren;
        }

        public void ZetStartLocatie(Locatie startLocatie)
        {
            StartLocatie = startLocatie ?? throw new ReserveringException("Ongeldige StartLocatie");
        }

        public void ZetAankomstLocatie(Locatie aankomstLocatie)
        {
            AankomstLocatie = aankomstLocatie ?? throw new ReserveringException("Ongeldige AankomstLocatie");
        }

        public void BerekenEenheidsprijs()
        {
            decimal totalePrijs = 0;

            foreach (var auto in Autos)
            {
                if (Arrangement == null)
                {
                    totalePrijs += auto.EersteUurPrijs;
                }
                else
                {
                    switch (Arrangement.Naam)
                    {
                        case "Nightlife":
                            if (StartUur >= new TimeSpan(20, 0, 0) && StartUur <= new TimeSpan(23, 59, 59))
                            {
                                totalePrijs += auto.NightlifePrijs;
                            }
                            else
                            {
                                throw new ReserveringException("Ongeldig startuur voor het Nightlife arrangement.");
                            }
                            break;
                        case "Wedding":
                            if (StartUur >= new TimeSpan(7, 0, 0) && StartUur <= new TimeSpan(14, 59, 59))
                            {
                                totalePrijs += auto.WeddingPrijs;
                            }
                            else
                            {
                                throw new ReserveringException("Ongeldig startuur voor het Wedding arrangement.");
                            }
                            break;
                        default:
                            totalePrijs += auto.EersteUurPrijs;
                            break;
                    }
                }
            }

            Eenheidsprijs = totalePrijs;
        }

        public void BerekenSubtotaal()
        {
            decimal subtotaal = 0;

            if (Arrangement == null)
            {
                subtotaal = Eenheidsprijs * AantalUren;
            }
            else
            {
                switch (Arrangement.Naam)
                {
                    case "Nightlife":
                    case "Wedding":
                        subtotaal = Eenheidsprijs * 7; // Vaste duur van 7 uur voor Nightlife en Wedding
                        break;
                    default:
                        decimal eersteUurPrijs = Autos.Sum(auto => auto.EersteUurPrijs);
                        decimal prijsPerUur = Math.Round(eersteUurPrijs * 0.6m / 5.0m) * 5.0m; // 60% van de eerste uurprijs
                        subtotaal = eersteUurPrijs + prijsPerUur * (AantalUren - 1);
                        break;
                }
            }

            Subtotaal = subtotaal;
        }

        

        public void ZetSoortUur(TimeSpan startUur)
        {
            if (IsNightUur(startUur))
            {
                SoortUur = "Nachturen";
            }
            else
            {
                SoortUur = "Daguren";
            }
        }
        public bool IsNightUur(TimeSpan uur)
        {
            TimeSpan startNightUur = new TimeSpan(22, 0, 0);
            TimeSpan endNightUur = new TimeSpan(7, 0, 0);
            if (startNightUur <= endNightUur)
            {
                // Nachtperiode valt op één dag, bijv. 22:00 - 07:00
                return uur >= startNightUur && uur < endNightUur;
            }
            else
            {
                // Nachtperiode valt op twee dagen, bijv. 22:00 - 23:59 en 00:00 - 07:00
                return uur >= startNightUur || uur < endNightUur;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Reservering reservering && ReserveringID == reservering.ReserveringID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ReserveringID);
        }


    }
}
