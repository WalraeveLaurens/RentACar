using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RentACar.BL.Model;
using RentACar.DL.Exceptions;
using RentACar.BL.Interfaces;

namespace RentACar.DL.Repositories
{
    public class KlantRepositoryADO : IKlantRepository
    {
        private readonly string connectionString;

        public KlantRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Klant> GetAll()
        {
            List<Klant> klanten = new List<Klant>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT KlantID, Klantnummer, Voornaam, Naam, Straat, Straatnummer, Busnummer, Plaats, Postcode, BTWNummer FROM Klant";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Klant klant = new Klant(
                                klantID: Convert.ToInt32(reader["KlantID"]),
                                klantnummer: reader["Klantnummer"].ToString(),
                                voornaam: reader["Voornaam"].ToString(),
                                naam: reader["Naam"].ToString(),
                                straat: reader["Straat"].ToString(),
                                straatnummer: reader["Straatnummer"].ToString(),
                                busnummer: reader["Busnummer"].ToString(),
                                plaats: reader["Plaats"].ToString(),
                                postcode: reader["Postcode"].ToString(),
                                btwNummer: reader["BTWNummer"].ToString()
                            );

                            klanten.Add(klant);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new KlantRepositoryException("Er is een fout opgetreden bij het ophalen van klanten.", ex);
            }

            return klanten;
        }

        public void Add(Klant klant)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Klant (Klantnummer, Voornaam, Naam, Straat, Straatnummer, Busnummer, Plaats, Postcode, BTWNummer) " +
                                   "VALUES (@Klantnummer, @Voornaam, @Naam, @Straat, @Straatnummer, @Busnummer, @Plaats, @Postcode, @BTWNummer)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Klantnummer", klant.Klantnummer);
                        command.Parameters.AddWithValue("@Voornaam", klant.Voornaam);
                        command.Parameters.AddWithValue("@Naam", klant.Naam);
                        command.Parameters.AddWithValue("@Straat", klant.Straat);
                        command.Parameters.AddWithValue("@Straatnummer", klant.Straatnummer);

                        // Controleer of het Busnummer-veld leeg is en wijs een null-waarde toe indien nodig
                        string busnummer = string.IsNullOrEmpty(klant.Busnummer) ? null : klant.Busnummer;
                        command.Parameters.AddWithValue("@Busnummer", string.IsNullOrEmpty(busnummer) ? DBNull.Value : (object)busnummer);

                        command.Parameters.AddWithValue("@Plaats", klant.Plaats);
                        command.Parameters.AddWithValue("@Postcode", klant.Postcode);

                        // Controleer of het BTWNummer-veld leeg is en wijs een null-waarde toe indien nodig
                        string btwNummer = string.IsNullOrEmpty(klant.BTWNummer) ? null : klant.BTWNummer;
                        command.Parameters.AddWithValue("@BTWNummer", string.IsNullOrEmpty(btwNummer) ? DBNull.Value : (object)btwNummer);

                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Klant succesvol toegevoegd aan de database.");
            }
            catch (Exception ex)
            {
                throw new KlantRepositoryException("Er is een fout opgetreden bij het toevoegen van een klant.", ex);
            }
        }
    }
}
