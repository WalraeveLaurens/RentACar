using RentACar.DL.Exceptions;
using RentACar.BL.Exceptions;
using RentACar.BL.Interfaces;
using RentACar.BL.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RentACar.DL.Repositories
{
    public class ReserveringRepositoryADO : IReserveringRepository
    {
        private readonly string connectionString;

        public ReserveringRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Reservering reservering)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            int reserveringID = AddReservering(reservering, connection, transaction);
                            AddReserveringAutos(reserveringID, reservering.Autos, connection, transaction);

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new ReserveringRepositoryException("Failed to add reservation.", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ReserveringRepositoryException("Failed to add reservation.", ex);
            }
        }

        private int AddReservering(Reservering reservering, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"INSERT INTO Reservering (KlantID, ArrangementID, StartDatum, StartUur, AantalUren, SoortUur, Eenheidsprijs, Subtotaal, StartLocatieID, AankomstLocatieID)
                     VALUES (@KlantID, @ArrangementID, @StartDatum, @StartUur, @AantalUren, @SoortUur, @Eenheidsprijs, @Subtotaal, @StartLocatieID, @AankomstLocatieID);
                     SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@KlantID", reservering.Klant.KlantID);
                command.Parameters.AddWithValue("@ArrangementID", reservering.Arrangement.ArrangementID);
                command.Parameters.AddWithValue("@StartDatum", reservering.StartDatum);
                command.Parameters.AddWithValue("@StartUur", reservering.StartUur);
                command.Parameters.AddWithValue("@AantalUren", reservering.AantalUren);
                command.Parameters.AddWithValue("@SoortUur", reservering.SoortUur);
                command.Parameters.AddWithValue("@Eenheidsprijs", reservering.Eenheidsprijs);
                command.Parameters.AddWithValue("@Subtotaal", reservering.Subtotaal);
                command.Parameters.AddWithValue("@StartLocatieID", reservering.StartLocatie.LocatieID);
                command.Parameters.AddWithValue("@AankomstLocatieID", reservering.AankomstLocatie.LocatieID);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }

                throw new ReserveringRepositoryException("Failed to add reservation.");
            }
        }

        private void AddReserveringAutos(int reserveringID, List<Auto> autos, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"INSERT INTO ReserveringAuto (ReserveringID, AutoID)
                     VALUES (@ReserveringID, @AutoID);";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                foreach (Auto auto in autos)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ReserveringID", reserveringID);
                    command.Parameters.AddWithValue("@AutoID", auto.AutoID);
                    command.ExecuteNonQuery();
                }
            }
        }


        // Andere methoden van IReserveringRepository...


        public List<Reservering> GetReserveringen()
        {
            List<Reservering> reserveringen = new List<Reservering>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT R.ReserveringID, R.StartDatum, R.StartUur, R.AantalUren, R.SoortUur, R.Eenheidsprijs, R.Subtotaal,
                                K.KlantID, K.Klantnummer, K.Voornaam, K.Naam, K.Straat, K.Straatnummer, K.Busnummer, K.Plaats, K.Postcode, K.BTWNummer,
                                L1.LocatieID AS StartLocatieID, L1.Stad AS StartLocatieStad,
                                L2.LocatieID AS AankomstLocatieID, L2.Stad AS AankomstLocatieStad,
                                A.ArrangementID, A.Naam AS ArrangementNaam,
                                RA.AutoID, AU.Naam AS AutoNaam, AU.EersteUurPrijs, AU.NightlifePrijs, AU.WeddingPrijs, AU.Bouwjaar
                         FROM Reservering AS R
                         INNER JOIN Klant AS K ON R.KlantID = K.KlantID
                         INNER JOIN Locatie AS L1 ON R.StartLocatieID = L1.LocatieID
                         INNER JOIN Locatie AS L2 ON R.AankomstLocatieID = L2.LocatieID
                         INNER JOIN Arrangement AS A ON R.ArrangementID = A.ArrangementID
                         INNER JOIN ReserveringAuto AS RA ON R.ReserveringID = RA.ReserveringID
                         INNER JOIN Auto AS AU ON RA.AutoID = AU.AutoID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int reserveringID = reader.GetInt32(0);
                                DateTime startDatum = reader.GetDateTime(1);
                                TimeSpan startUur = reader.GetTimeSpan(2);
                                int aantalUren = reader.GetInt32(3);
                                string soortUur = reader.GetString(4);
                                decimal eenheidsprijs = reader.GetDecimal(5);
                                decimal subtotaal = reader.GetDecimal(6);

                                int klantID = reader.GetInt32(7);
                                string klantnummer = reader.GetString(8);
                                string voornaam = reader.GetString(9);
                                string naam = reader.GetString(10);
                                string straat = reader.GetString(11);
                                string straatnummer = reader.GetString(12);
                                string busnummer = reader.IsDBNull(13) ? null : reader.GetString(13);
                                string plaats = reader.GetString(14);
                                string postcode = reader.GetString(15);
                                string btwNummer = reader.IsDBNull(16) ? null : reader.GetString(16);

                                int startLocatieID = reader.GetInt32(17);
                                string startLocatieStad = reader.GetString(18);

                                int aankomstLocatieID = reader.GetInt32(19);
                                string aankomstLocatieStad = reader.GetString(20);

                                int arrangementID = reader.GetInt32(21);
                                string arrangementNaam = reader.GetString(22);

                                int autoID = reader.GetInt32(23);
                                string autoNaam = reader.GetString(24);
                                decimal eersteUurPrijs = reader.GetDecimal(25);
                                decimal nightlifePrijs = reader.GetDecimal(26);
                                decimal weddingPrijs = reader.GetDecimal(27);
                                int bouwjaar = reader.GetInt32(28);

                                Klant klant = new Klant(klantID, klantnummer, voornaam, naam, straat, straatnummer, busnummer, plaats, postcode, btwNummer);
                                Locatie startLocatie = new Locatie(startLocatieID, startLocatieStad);
                                Locatie aankomstLocatie = new Locatie(aankomstLocatieID, aankomstLocatieStad);
                                Auto auto = new Auto(autoID, autoNaam, eersteUurPrijs, nightlifePrijs, weddingPrijs, bouwjaar);
                                Arrangement arrangement = new Arrangement(arrangementID, arrangementNaam);

                                // Zoek naar de reservering in de lijst
                                Reservering reservering = reserveringen.FirstOrDefault(r => r.ReserveringID == reserveringID);

                                if (reservering == null)
                                {
                                    // Maak een nieuwe reservering aan als deze nog niet bestaat
                                    reservering = new Reservering(reserveringID, klant, new List<Auto> { auto }, arrangement, startDatum, startUur, aantalUren, soortUur, eenheidsprijs, subtotaal, startLocatie, aankomstLocatie);
                                    reserveringen.Add(reservering);
                                }
                                else
                                {
                                    // Voeg de auto toe aan de bestaande reservering
                                    reservering.Autos.Add(auto);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new ReserveringRepositoryException("Failed to retrieve reservations.", ex);
            }

            return reserveringen;
        }


        public List<Reservering> SearchReserveringen(string searchNaam, DateTime? startDate, DateTime? endDate)
        {
            List<Reservering> reserveringen = new List<Reservering>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT R.ReserveringID, R.StartDatum, R.StartUur, R.AantalUren, R.SoortUur, R.Eenheidsprijs, R.Subtotaal,
                            K.KlantID, K.Klantnummer, K.Voornaam, K.Naam, K.Straat, K.Straatnummer, K.Busnummer, K.Plaats, K.Postcode, K.BTWNummer,
                            L1.LocatieID AS StartLocatieID, L1.Stad AS StartLocatieStad,
                            L2.LocatieID AS AankomstLocatieID, L2.Stad AS AankomstLocatieStad,
                            A.ArrangementID, A.Naam AS ArrangementNaam,
                            RA.AutoID, AU.Naam AS AutoNaam, AU.EersteUurPrijs, AU.NightlifePrijs, AU.WeddingPrijs, AU.Bouwjaar
                     FROM Reservering AS R
                     INNER JOIN Klant AS K ON R.KlantID = K.KlantID
                     INNER JOIN Locatie AS L1 ON R.StartLocatieID = L1.LocatieID
                     INNER JOIN Locatie AS L2 ON R.AankomstLocatieID = L2.LocatieID
                     INNER JOIN Arrangement AS A ON R.ArrangementID = A.ArrangementID
                     INNER JOIN ReserveringAuto AS RA ON R.ReserveringID = RA.ReserveringID
                     INNER JOIN Auto AS AU ON RA.AutoID = AU.AutoID
                     WHERE (@SearchNaam IS NULL OR K.Voornaam LIKE '%' + @SearchNaam + '%' OR K.Naam LIKE '%' + @SearchNaam + '%')
                     AND (@StartDate IS NULL OR R.StartDatum >= @StartDate)
                     AND (@EndDate IS NULL OR R.StartDatum <= @EndDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchNaam", string.IsNullOrWhiteSpace(searchNaam) ? (object)DBNull.Value : searchNaam);
                        command.Parameters.AddWithValue("@StartDate", startDate.HasValue ? startDate.Value.Date : (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EndDate", endDate.HasValue ? endDate.Value.Date.AddDays(1).AddTicks(-1) : (object)DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int reserveringID = reader.GetInt32(0);
                                DateTime startDatum = reader.GetDateTime(1);
                                TimeSpan startUur = reader.GetTimeSpan(2);
                                int aantalUren = reader.GetInt32(3);
                                string soortUur = reader.GetString(4);
                                decimal eenheidsprijs = reader.GetDecimal(5);
                                decimal subtotaal = reader.GetDecimal(6);

                                int klantID = reader.GetInt32(7);
                                string klantnummer = reader.GetString(8);
                                string voornaam = reader.GetString(9);
                                string naam = reader.GetString(10);
                                string straat = reader.GetString(11);
                                string straatnummer = reader.GetString(12);
                                string busnummer = reader.IsDBNull(13) ? null : reader.GetString(13);
                                string plaats = reader.GetString(14);
                                string postcode = reader.GetString(15);
                                string btwNummer = reader.IsDBNull(16) ? null : reader.GetString(16);

                                int startLocatieID = reader.GetInt32(17);
                                string startLocatieStad = reader.GetString(18);

                                int aankomstLocatieID = reader.GetInt32(19);
                                string aankomstLocatieStad = reader.GetString(20);

                                int arrangementID = reader.GetInt32(21);
                                string arrangementNaam = reader.GetString(22);

                                int autoID = reader.GetInt32(23);
                                string autoNaam = reader.GetString(24);
                                decimal eersteUurPrijs = reader.GetDecimal(25);
                                decimal nightlifePrijs = reader.GetDecimal(26);
                                decimal weddingPrijs = reader.GetDecimal(27);
                                int bouwjaar = reader.GetInt32(28);

                                Klant klant = new Klant(klantID, klantnummer, voornaam, naam, straat, straatnummer, busnummer, plaats, postcode, btwNummer);
                                Locatie startLocatie = new Locatie(startLocatieID, startLocatieStad);
                                Locatie aankomstLocatie = new Locatie(aankomstLocatieID, aankomstLocatieStad);
                                Auto auto = new Auto(autoID, autoNaam, eersteUurPrijs, nightlifePrijs, weddingPrijs, bouwjaar);
                                Arrangement arrangement = new Arrangement(arrangementID, arrangementNaam);

                                // Zoek naar de reservering in de lijst
                                Reservering reservering = reserveringen.FirstOrDefault(r => r.ReserveringID == reserveringID);

                                if (reservering == null)
                                {
                                    // Maak een nieuwe reservering aan als deze nog niet bestaat
                                    reservering = new Reservering(reserveringID, klant, new List<Auto> { auto }, arrangement, startDatum, startUur, aantalUren, soortUur, eenheidsprijs, subtotaal, startLocatie, aankomstLocatie);
                                    reserveringen.Add(reservering);
                                }
                                else
                                {
                                    // Voeg de auto toe aan de bestaande reservering
                                    reservering.Autos.Add(auto);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new ReserveringRepositoryException("Failed to retrieve reservations.", ex);
            }

            return reserveringen;
        }



    }
}