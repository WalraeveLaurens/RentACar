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
                            // Voeg reservering toe
                            int reserveringID = AddReservering(reservering, connection, transaction);

                            // Voeg reservering-auto's toe
                            AddReserveringAutos(reserveringID, reservering.Autos, connection, transaction);

                            // Commit de transactie
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Er is een fout opgetreden, rol de transactie terug
                            transaction.Rollback();
                            throw new ReserveringRepositoryException("Failed to add reservation.", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
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

            foreach (Auto auto in autos)
            {
                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@ReserveringID", reserveringID);
                    command.Parameters.AddWithValue("@AutoID", auto.AutoID);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Andere methoden van IReserveringRepository...

    }
}
