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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnKlanten_Click(object sender, RoutedEventArgs e)
        {
            Klanten klanten = new Klanten();
            klanten.Show();
            Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchKlant searchKlant = new SearchKlant();
            searchKlant.Show();
            Close();
        }

        private void btnReservering_Click(object sender, RoutedEventArgs e)
        {
            Reservations reservations = new Reservations();
            reservations.Show();
            Close();
        }

        private void btnSearchReservering_Click(object sender, RoutedEventArgs e)
        {
            SearchReservations searchReservations = new SearchReservations();
            searchReservations.Show();
            Close();
        }
    }
}
