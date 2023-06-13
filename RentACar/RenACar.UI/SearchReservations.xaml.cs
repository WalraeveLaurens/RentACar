using RentACar.BL.Interfaces;
using RentACar.BL.Managers;
using RentACar.BL.Model;
using RentACar.DL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RenACar.UI
{
    /// <summary>
    /// Interaction logic for SearchReservations.xaml
    /// </summary>
    public partial class SearchReservations : Window
    {
        private ReserveringManager reserveringManager;
        public List<Reservering> ReservationsList { get; set; }
        public SearchReservations()
        {
            InitializeComponent();
            DataContext = this;
            string connectionString = "Server=localhost\\SQLEXPRESS01;Database=RentACar;Trusted_Connection=True;";

            IReserveringRepository reserveringRepository = new ReserveringRepositoryADO(connectionString);
            reserveringManager = new ReserveringManager(reserveringRepository);
            LoadAllReservations();
        }

        private void LoadAllReservations()
        {
            try
            {
                ReservationsList = reserveringManager.GetReserveringen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden bij het laden van de reserveringen: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TerugNaarHoofdscherm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            string searchName = txtSearchName.Text;
            DateTime? startDate = dpStartDate.SelectedDate;
            DateTime? endDate = dpEndDate.SelectedDate;

            try
            {
                // Voer de zoekopdracht uit met de opgegeven parameters
                ReservationsList = reserveringManager.SearchReserveringen(searchName, startDate, endDate);
                dataReservations.ItemsSource = ReservationsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden bij het uitvoeren van de zoekopdracht: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ReservationsList.Clear();
            txtSearchName.Text = string.Empty;
            dpStartDate.SelectedDate = null;
            dpEndDate.SelectedDate = null;

            // Voer de zoekopdracht opnieuw uit met lege waarden om de DataGrid te resetten
            Search_Click(sender, e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
    }
}
