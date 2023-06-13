using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RentACar.BL.Model;
using RentACar.BL.Interfaces;
using RentACar.DL.Exceptions;


namespace RentACar.DL.Repositories
{
    public class AutoRepositoryADO : IAutoRepository
    {
        private readonly string connectionString;

        public AutoRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Auto> GetAll()
        {
            try
            {
                List<Auto> autos = new List<Auto>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT AutoID, Naam, EersteUurPrijs, NightlifePrijs, WeddingPrijs, Bouwjaar FROM Auto";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Auto auto = new Auto
                            (
                                autoID: Convert.ToInt32(reader["AutoID"]),
                                naam: reader["Naam"].ToString(),
                                eersteUurPrijs: Convert.ToDecimal(reader["EersteUurPrijs"]),
                                nightlifePrijs: Convert.ToDecimal(reader["NightlifePrijs"]),
                                weddingPrijs: Convert.ToDecimal(reader["WeddingPrijs"]),
                                bouwjaar: Convert.ToInt32(reader["Bouwjaar"])
                            );

                            autos.Add(auto);
                        }

                        reader.Close();
                    }
                }

                return autos;
            }
            catch (Exception ex)
            {
                throw new AutoRepositoryException("Fout bij het ophalen van alle auto's.", ex);
            }
        }

        public Auto GetById(int id)
        {
            try
            {
                Auto auto = null;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT AutoID, Naam, EersteUurPrijs, NightlifePrijs, WeddingPrijs, Bouwjaar FROM Auto WHERE AutoID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            auto = new Auto
                            (
                                autoID: Convert.ToInt32(reader["AutoID"]),
                                naam: reader["Naam"].ToString(),
                                eersteUurPrijs: Convert.ToDecimal(reader["EersteUurPrijs"]),
                                nightlifePrijs: Convert.ToDecimal(reader["NightlifePrijs"]),
                                weddingPrijs: Convert.ToDecimal(reader["WeddingPrijs"]),
                                bouwjaar: Convert.ToInt32(reader["Bouwjaar"])
                            );
                        }

                        reader.Close();
                    }
                }

                return auto;
            }
            catch (Exception ex)
            {
                throw new AutoRepositoryException($"Fout bij het ophalen van auto met ID {id}.", ex);
            }
        }

        public void Add(Auto auto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Auto (Naam, EersteUurPrijs, NightlifePrijs, WeddingPrijs, Bouwjaar) " +
                                   "VALUES (@Naam, @EersteUurPrijs, @NightlifePrijs, @WeddingPrijs, @Bouwjaar)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Naam", auto.Naam);
                        command.Parameters.AddWithValue("@EersteUurPrijs", auto.EersteUurPrijs);
                        command.Parameters.AddWithValue("@NightlifePrijs", auto.NightlifePrijs);
                        command.Parameters.AddWithValue("@WeddingPrijs", auto.WeddingPrijs);
                        command.Parameters.AddWithValue("@Bouwjaar", auto.Bouwjaar);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new AutoRepositoryException("Fout bij het toevoegen van een auto.", ex);
            }
        }
    }
}
