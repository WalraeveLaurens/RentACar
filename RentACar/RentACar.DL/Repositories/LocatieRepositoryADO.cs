using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RentACar.DL.Exceptions;
using RentACar.BL.Model;
using RentACar.BL.Interfaces;

namespace RentACar.DL.Repositories
{
    public class LocatieRepositoryADO : ILocatieRepository
    {
        private readonly string connectionString;

        public LocatieRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Locatie> GetAll()
        {
            try
            {
                List<Locatie> locaties = new List<Locatie>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT LocatieID, Stad FROM Locatie";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Locatie locatie = new Locatie(
                                Convert.ToInt32(reader["LocatieID"]),
                                reader["Stad"].ToString()
                            );

                            locaties.Add(locatie);
                        }

                        reader.Close();
                    }
                }

                return locaties;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new LocatieRepositoryException("Failed to retrieve locations.", ex);
            }
        }

        public void Add(Locatie locatie)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Locatie (Stad) VALUES (@Stad)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Stad", locatie.Stad);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new LocatieRepositoryException("Failed to add location.", ex);
            }
        }
    }
}
