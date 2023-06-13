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
    /// Interaction logic for Reservations.xaml
    /// </summary>
    public partial class Reservations : Window
    {
        private ReserveringManager reserveringManager;


        public List<Reservering> ReservationsList { get; set; }
        public Reservations()
        {
            InitializeComponent();
            DataContext = this;
            string connectionString = "Server=localhost\\SQLEXPRESS01;Database=RentACar;Trusted_Connection=True;";

            IReserveringRepository reserveringRepository = new ReserveringRepositoryADO(connectionString);
            reserveringManager = new ReserveringManager(reserveringRepository);
            LoadAllReservations();
        }

        private void TerugNaarHoofdscherm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

    }
}
