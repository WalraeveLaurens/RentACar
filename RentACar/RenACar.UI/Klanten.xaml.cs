using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentACar.BL.Interfaces;
using RentACar.BL.Managers;
using RentACar.BL.Model;
using RentACar.DL.Repositories;


namespace RenACar.UI
{
    /// <summary>
    /// Interaction logic for Klanten.xaml
    /// </summary>
    public partial class Klanten : Window
    {
        private int currentPage = 1;
        private int itemsPerPage = 10;
        private List<Klant> allCustomers;
        private List<Klant> displayedCustomers;
        private KlantManager klantManager;

        public Klanten()
        {
            InitializeComponent();

            // Maak een instantie van de klantrepository met de juiste connection string
            string connectionString = "Server=localhost\\SQLEXPRESS01;Database=RentACar;Trusted_Connection=True;";

            IKlantRepository repo = new KlantRepositoryADO(connectionString);
            klantManager = new KlantManager(repo);


            LoadCustomers();
            UpdatePageLabel();
            DisplayCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                allCustomers = klantManager.GetAllKlanten();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van klanten: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayCustomers()
        {
            int startIndex = (currentPage - 1) * itemsPerPage;
            displayedCustomers = allCustomers.Skip(startIndex).Take(itemsPerPage).ToList();
            CustomersDataGrid.ItemsSource = displayedCustomers;
        }

        private void UpdatePageLabel()
        {
            int totalPages = (int)Math.Ceiling((double)allCustomers.Count / itemsPerPage);
            PageLabel.Content = $"Pagina {currentPage} van {totalPages}";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void CustomersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)allCustomers.Count / itemsPerPage);
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayCustomers();
                UpdatePageLabel();
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCustomers();
                UpdatePageLabel();
            }
        }
    }
}
