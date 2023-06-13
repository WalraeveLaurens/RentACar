using System;
using System.Collections.Generic;
using System.Windows;
using RentACar.BL.Interfaces;
using RentACar.BL.Managers;
using RentACar.BL.Model;
using RentACar.DL.Repositories;

namespace RenACar.UI
{
    /// <summary>
    /// Interaction logic for ReservationSearchPage.xaml
    /// </summary>
    public partial class ReservationSearchPage : Window
    {
        private ReserveringManager reserveringManager;
        public ReservationSearchPage()
        {
            InitializeComponent();
            string connectionString = "Server=localhost\\SQLEXPRESS01;Database=RentACar;Trusted_Connection=True;";

            IReserveringRepository reserveringRepository = new ReserveringRepositoryADO(connectionString);
            reserveringManager = new ReserveringManager(reserveringRepository);
            LoadAllReservations();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            /*// Get the customer name from the TextBox
            string customerName = txtKlantnaam.Text;

            // Get the start and end dates
            DateTime startDate = dpStartDate.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = dpEndDate.SelectedDate ?? DateTime.MaxValue;

            // Validate the dates
            if (startDate > endDate)
            {
                MessageBox.Show("Invalid date range. Please select valid dates.");
                return;
            }

            try
            {
                // Call the repository method to get reservations for the specified customer name between the dates
                List<Reservering> reservations = reserveringManager.(customerName, startDate, endDate);

                // Clear the ListView
                reservationsListView.ItemsSource = null;
                reservationsListView.Items.Clear();

                if (reservations.Count > 0)
                {
                    // Bind the reservations to the ListView
                    reservationsListView.ItemsSource = reservations;

                    // Show the ListView and hide the result text block
                    reservationsListView.Visibility = Visibility.Visible;
                    txtResultaat.Visibility = Visibility.Collapsed;
                }
                else
                {
                    // Show a message indicating no reservations found
                    reservationsListView.Visibility = Visibility.Collapsed;
                    txtResultaat.Visibility = Visibility.Visible;
                    txtResultaat.Text = "No reservations found.";
                }
            }
            catch (Exception ex)
            {
                // Show an error message
                MessageBox.Show("An error occurred while retrieving reservations: " + ex.Message);
            }*/
        }




        private void TerugButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void LoadAllReservations()
        {
            /*try
            {
                List<ReserveringInfoDetail> reserveringen = new List<ReserveringInfoDetail>();


                reservatieRepository.GetAllReserveringDetails(reserveringen);

                // Clear the ListView
                reservationsListView.Items.Clear();

                // Add the retrieved reservations to the ListView
                foreach (ReserveringInfoDetail reservering in reserveringen)
                {
                    reservationsListView.Items.Add(reservering);
                }

                // Show the ListView
                reservationsListView.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                MessageBox.Show($"Failed to load reservations: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
        }
    }
}
