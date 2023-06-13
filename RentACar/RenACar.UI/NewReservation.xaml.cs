using RentACar.BL.Interfaces;
using RentACar.BL.Managers;
using RentACar.BL.Model;
using RentACar.DL.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RenACar.UI
{
    public partial class NewReservation : Window
    {
        private ReserveringManager reserveringManager;
        private AutoManager autoManager;
        private LocatieManager locatieManager;
        private ArrangementManager arangementManager;
        private Klant selectedKlant;

        public NewReservation(Klant klant)
        {
            InitializeComponent();
            selectedKlant = klant;
            DataContext = this;
            string connectionString = "Server=localhost\\SQLEXPRESS01;Database=RentACar;Trusted_Connection=True;";

            IReserveringRepository reserveringRepository = new ReserveringRepositoryADO(connectionString);
            reserveringManager = new ReserveringManager(reserveringRepository);

            IAutoRepository AutoRepo = new AutoRepositoryADO(connectionString);
            autoManager = new AutoManager(AutoRepo);
            IArrangementRepository ArrangementRepo = new ArrangementRepositoryADO(connectionString);
            arangementManager = new ArrangementManager(ArrangementRepo);
            ILocatieRepository LocatieRepo = new LocatieRepositoryADO(connectionString);
            locatieManager = new LocatieManager(LocatieRepo);

            LoadComboBoxData();
        }

        public ObservableCollection<Auto> AutoList { get; set; }
        public bool IsArrangementSelected { get; set; }

        private void LoadComboBoxData()
        {
            var autoData = autoManager.GetAllAutos();
            /*cmbAuto.ItemsSource = autoData; */
            AutoList = new ObservableCollection<Auto>(autoData);


            var arrangementData = arangementManager.GetAllArrangements();
            cmbArrangment.ItemsSource = arrangementData;

            var locatieData = locatieManager.GetAllLocaties();
            cmbStartLocatie.ItemsSource = locatieData;
            cmbAankomstLocatie.ItemsSource = locatieData;

        }

        private void cmbArrangment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbArrangment.SelectedItem is Arrangement selectedArrangement)
            {
                if (selectedArrangement.Naam == "Wedding" || selectedArrangement.Naam == "Nightlife")
                {
                    txtDuration.Text = "7";
                    txtDuration.IsEnabled = false;
                    IsArrangementSelected = true;
                }
                else
                {
                    txtDuration.Text = string.Empty;
                    txtDuration.IsEnabled = true;
                    IsArrangementSelected = false;
                }
            }
        }

        public Klant SelectedKlant
        {
            get { return selectedKlant; }
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Auto> selectedAutos = lbAuto.SelectedItems.Cast<Auto>().ToList();

                if (selectedAutos.Count == 0)
                {
                    MessageBox.Show("Selecteer minimaal één auto.");
                    return;
                }

                Arrangement selectedArrangement = cmbArrangment.SelectedItem as Arrangement;
                DateTime startDate = dpStartDate.SelectedDate ?? DateTime.MinValue;
                TimeSpan startTime = TimeSpan.Parse(tpStartTime.Text);
                int duration = int.Parse(txtDuration.Text);
                Locatie startLocatie = cmbStartLocatie.SelectedItem as Locatie;
                Locatie aankomstLocatie = cmbAankomstLocatie.SelectedItem as Locatie;

                Reservering newReservation = new Reservering(selectedKlant, selectedAutos, selectedArrangement, startDate, startTime, duration, startLocatie, aankomstLocatie);

                reserveringManager.AddReservering(newReservation);

                MessageBox.Show("Reservering is toegevoegd.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden bij het toevoegen van de reservering: " + ex.Message);
            }
        }

        private void btnCancel(object sender, RoutedEventArgs e)
        {
            SearchKlant searchKlant = new SearchKlant();
            searchKlant.Show();
            Close();
        }
    }
}
