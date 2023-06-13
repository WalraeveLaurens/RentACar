using RentACar.BL.Model;
using RentACar.BL.Managers;
using RentACar.DL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RentACar.BL.Interfaces;

namespace RenACar.UI
{
    public partial class SearchKlant : Window
    {
        private List<Klant> allCustomers;
        private List<Klant> displayedCustomers;
        private Klant selectedCustomer;
        private KlantManager klantManager;

        public SearchKlant()
        {
            InitializeComponent();
            SearchTextBox.KeyUp += SearchTextBox_KeyUp;
            string connectionString = "Server=localhost\\SQLEXPRESS01;Database=RentACar;Trusted_Connection=True;";
            IKlantRepository repo = new KlantRepositoryADO(connectionString);
            klantManager = new KlantManager(repo);
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            allCustomers = klantManager.GetAllKlanten();
            displayedCustomers = allCustomers.Take(10).ToList();
            DisplayCustomers();
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim().ToLower();

            displayedCustomers = allCustomers
                .Where(c => c.Naam.ToLower().Contains(searchText))
                .ToList();

            DisplayCustomers();
        }

        private void DisplayCustomers()
        {
            CustomersListView.ItemsSource = displayedCustomers;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            selectedCustomer = CustomersListView.SelectedItem as Klant;

            if (selectedCustomer != null)
            {
                NewReservation newReservationPage = new NewReservation(selectedCustomer);
                newReservationPage.Show();
                Close();
            }
        }
    }
}
