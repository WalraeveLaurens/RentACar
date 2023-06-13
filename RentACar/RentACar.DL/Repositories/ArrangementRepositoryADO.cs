using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RentACar.BL.Interfaces;
using RentACar.BL.Model;
using RentACar.DL.Exceptions;

namespace RentACar.DL.Repositories
{
    public class ArrangementRepositoryADO : IArrangementRepository
    {
        private readonly string connectionString;

        public ArrangementRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Arrangement> GetAll()
        {
            List<Arrangement> arrangements = new List<Arrangement>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ArrangementID, Naam FROM Arrangement";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            int arrangementID = Convert.ToInt32(reader["ArrangementID"]);
                            string naam = reader["Naam"].ToString();

                            Arrangement arrangement = new Arrangement(arrangementID, naam);
                            arrangements.Add(arrangement);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArrangementRepositoryException("Error occurred while retrieving arrangements.", ex);
            }

            return arrangements;
        }

        public void Add(Arrangement arrangement)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Arrangement (Naam) VALUES (@Naam)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Naam", arrangement.Naam);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArrangementRepositoryException("Error occurred while adding an arrangement.", ex);
            }
        }
    }
}
