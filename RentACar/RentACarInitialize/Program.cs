using System;
using System.Data.SqlClient;
using OfficeOpenXml;
using RentACar.BL.Interfaces;
using RentACar.BL.Managers;
using RentACar.BL.Model;
using RentACar.DL.Repositories;

namespace RentACar.Initialize
{
    class Program
    {
        static void Main(string[] args)
        {
            string excelFilePath = "C:\\Users\\LaurensW\\Desktop\\OpdrachtenProgGev\\RentACar\\RentACarInitialize\\Data\\DataEindopdracht.xlsx";
            string connectionString = "Server=localhost\\SQLEXPRESS01;Database=RentACar;Trusted_Connection=True;";
            string csvFilePath = "C:\\Users\\LaurensW\\Desktop\\OpdrachtenProgGev\\RentACar\\RentACarInitialize\\Data\\Klanten.csv";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(excelFilePath)))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Verwijder data van tabellen
                        ClearAllTables(connectionString);

                        // Alle ids terug resetten en vanaf 1 laten beginnen
                        ResetIdentitySeeds(connection);

                        // Verwerk het eerste blad ("Autopark Prijzen")
                        ProcessAutoparkPrijzenSheet(package, connection, connectionString);

                        // Verwerk het tweede blad ("Locaties")
                        ProcessLocatiesSheet(package, connection, connectionString);

                        // Verwerk het derde blad ("Arrangementen")
                        ProcessArrangementenSheet(package, connection, connectionString);

                        // Verwerk het vierde blad ("Klanten")
                        ProcessKlantenSheet(package, connection, connectionString);

                        // Verwerk de CSV file ("Klanten")
                        ProcessKlantenCSV(csvFilePath, connection, connectionString);
                    }
                }

                Console.WriteLine("Gegevens succesvol geladen naar de database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het initialiseren van de database: {ex.Message}");
            }

            Console.ReadLine();
        }

        static void ClearAllTables(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL; DELETE FROM ?'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        static void ResetIdentitySeeds(SqlConnection connection)
        {
            try
            {
                SqlCommand command = new SqlCommand("DBCC CHECKIDENT ('Arrangement', RESEED, 0);", connection);
                command.ExecuteNonQuery();

                command = new SqlCommand("DBCC CHECKIDENT ('Auto', RESEED, 0);", connection);
                command.ExecuteNonQuery();

                command = new SqlCommand("DBCC CHECKIDENT ('Klant', RESEED, 0);", connection);
                command.ExecuteNonQuery();

                command = new SqlCommand("DBCC CHECKIDENT ('Locatie', RESEED, 0);", connection);
                command.ExecuteNonQuery();

                command = new SqlCommand("DBCC CHECKIDENT ('Reservering', RESEED, 0);", connection);
                command.ExecuteNonQuery();

                command = new SqlCommand("DBCC CHECKIDENT ('ReserveringAuto', RESEED, 0);", connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Identity seeds zijn succesvol gereset.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het resetten van de identity seeds: {ex.Message}");
            }
        }

        static void ProcessAutoparkPrijzenSheet(ExcelPackage package, SqlConnection connection, string connectionString)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Autopark Prijzen"];
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                string naam = worksheet.Cells[row, 1].GetValue<string>();
                string eersteUurString = worksheet.Cells[row, 2].GetValue<string>();

                if (decimal.TryParse(eersteUurString, out decimal eersteUur))
                {
                    decimal nightlifePrijs = worksheet.Cells[row, 3].GetValue<decimal>();
                    decimal weddingPrijs = worksheet.Cells[row, 4].GetValue<decimal>();
                    int bouwjaar = worksheet.Cells[row, 5].GetValue<int>();

                    Auto auto = new Auto(naam, eersteUur, nightlifePrijs, weddingPrijs, bouwjaar);

                    AutoRepositoryADO autoRepositoryADO = new AutoRepositoryADO(connectionString);
                    AutoManager autoManager = new AutoManager(autoRepositoryADO);
                    autoManager.AddAuto(auto);
                }
                else
                {
                    Console.WriteLine($"Ongeldige waarde voor het eerste uur in rij {row}");
                }
            }
        }

        static void ProcessLocatiesSheet(ExcelPackage package, SqlConnection connection, string connectionString)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Locaties"];
            for (int row = 3; row <= worksheet.Dimension.End.Row; row++)
            {
                string stad = worksheet.Cells[row, 1].GetValue<string>();

                Locatie locatie = new Locatie(stad);


                LocatieRepositoryADO locatieRepositoryADO = new LocatieRepositoryADO(connectionString);
                LocatieManager locatieManager = new LocatieManager(locatieRepositoryADO);
                locatieManager.AddLocatie(locatie);
            }
        }

        static void ProcessArrangementenSheet(ExcelPackage package, SqlConnection connection, string connectionString)
        {
            try
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Arrangementen"];
                

                for (int row = 3; row <= worksheet.Dimension.End.Row; row++)
                {
                    string naam = worksheet.Cells[row, 1].GetValue<string>();

                    Arrangement arrangement = new Arrangement(naam);
                    ArrangementRepositoryADO arrangementRepositoryADO = new ArrangementRepositoryADO(connectionString);
                    ArrangementManager arrangementManager = new ArrangementManager(arrangementRepositoryADO);
                    arrangementManager.AddArrangement(naam);

                }

                Console.WriteLine("Gegevens van het blad 'Arrangementen' succesvol geladen naar de database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het verwerken van het blad 'Arrangementen': {ex.Message}");
            }
        }

        static void ProcessKlantenSheet(ExcelPackage package, SqlConnection connection, string connectionString)
        {
            try
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Klanten"];


                for (int row = 3; row <= worksheet.Dimension.End.Row; row++)
                {
                    string klantnummer = worksheet.Cells[row, 1].GetValue<string>();
                    string voornaam = worksheet.Cells[row, 2].GetValue<string>();
                    string naam = worksheet.Cells[row, 3].GetValue<string>();
                    string straat = worksheet.Cells[row, 4].GetValue<string>();
                    string straatnummer = worksheet.Cells[row, 5].GetValue<string>();
                    string busnummer = worksheet.Cells[row, 6].GetValue<string>();
                    string plaats = worksheet.Cells[row, 7].GetValue<string>();
                    string postcode = worksheet.Cells[row, 8].GetValue<string>();
                    string btwNummer = worksheet.Cells[row, 9].GetValue<string>();

                    Klant klant = new Klant(klantnummer, voornaam, naam, straat, straatnummer, busnummer, plaats, postcode, btwNummer);
                    KlantRepositoryADO klantRepositoryADO = new KlantRepositoryADO(connectionString);
                    KlantManager klantManager = new KlantManager(klantRepositoryADO);
                    klantManager.AddKlant(klant);


                }

                Console.WriteLine("Gegevens van het blad 'Klanten' succesvol geladen naar de database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het verwerken van het blad 'Klanten': {ex.Message}");
            }
        }

        static void ProcessKlantenCSV(string csvFilePath, SqlConnection connection, string connectionString)
        {
            try
            {

                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    string headerLine = reader.ReadLine();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');

                        string klantnummer = fields[0];
                        string voornaam = fields[1];
                        string naam = fields[2];
                        string straat = fields[3];
                        string straatnummer = fields[4];
                        string busnummer = fields[5];
                        string plaats = fields[6];
                        string postcode = fields[7];
                        string btwNummer = fields[8];

                        Klant klant = new Klant(klantnummer, voornaam, naam, straat, straatnummer, busnummer, plaats, postcode, btwNummer);
                        KlantRepositoryADO klantRepositoryADO = new KlantRepositoryADO(connectionString);
                        KlantManager klantManager = new KlantManager(klantRepositoryADO);
                        klantManager.AddKlant(klant);
                    }
                }

                Console.WriteLine("Gegevens van het CSV-bestand 'Klanten.csv' succesvol geladen naar de database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het verwerken van het CSV-bestand 'Klanten.csv': {ex.Message}");
            }
        }
    }
}
