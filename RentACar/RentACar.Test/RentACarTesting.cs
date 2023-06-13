using RentACar.BL.Exceptions;
using RentACar.BL.Model;

namespace RentACar.Test;

public class RentACarTesting
{
    //Arrangement
    [Fact]
    public void ZetArrangementID_ValidID_SetsArrangementID()
    {
        // Arrange
        Arrangement arrangement = new Arrangement();
        int validID = 10;

        // Act
        arrangement.ZetArrangementID(validID);

        // Assert
        Assert.Equal(validID, arrangement.ArrangementID);
    }

    [Fact]
    public void ZetArrangementID_InvalidID_ThrowsException()
    {
        // Arrange
        Arrangement arrangement = new Arrangement();
        int invalidID = -1;

        // Act & Assert
        Assert.Throws<ArrangementException>(() => arrangement.ZetArrangementID(invalidID));
    }

    [Fact]
    public void ZetArrangementNaam_ValidName_SetsNaam()
    {
        // Arrange
        Arrangement arrangement = new Arrangement();
        string validName = "Geldig Naam";

        // Act
        arrangement.ZetNaam(validName);

        // Assert
        Assert.Equal(validName, arrangement.Naam);
    }

    [Fact]
    public void ZetArrangementNaam_InvalidName_ThrowsException()
    {
        // Arrange
        Arrangement arrangement = new Arrangement();
        string invalidName = "";

        // Act & Assert
        Assert.Throws<ArrangementException>(() => arrangement.ZetNaam(invalidName));
    }

    //Auto
    [Fact]
    public void ZetAutoID_ValidID_SetsAutoID()
    {
        // Arrange
        Auto auto = new Auto();
        int validID = 10;

        // Act
        auto.ZetAutoID(validID);

        // Assert
        Assert.Equal(validID, auto.AutoID);
    }

    [Fact]
    public void ZetAutoID_InvalidID_ThrowsException()
    {
        // Arrange
        Auto auto = new Auto();
        int invalidID = -1;

        // Act & Assert
        Assert.Throws<AutoException>(() => auto.ZetAutoID(invalidID));
    }

    [Fact]
    public void ZetAutoNaam_ValidName_SetsNaam()
    {
        // Arrange
        Auto auto = new Auto();
        string validName = "Mercedes";

        // Act
        auto.ZetNaam(validName);

        // Assert
        Assert.Equal(validName, auto.Naam);
    }

    [Fact]
    public void ZetAutoNaam_InvalidName_ThrowsException()
    {
        // Arrange
        Auto auto = new Auto();
        string invalidName = "";

        // Act & Assert
        Assert.Throws<AutoException>(() => auto.ZetNaam(invalidName));
    }

    [Fact]
    public void ZetEersteUurPrijs_ValidPrice_SetsEersteUurPrijs()
    {
        // Arrange
        Auto auto = new Auto();
        decimal validPrice = 100;

        // Act
        auto.ZetEersteUurPrijs(validPrice);

        // Assert
        Assert.Equal(validPrice, auto.EersteUurPrijs);
    }

    [Fact]
    public void ZetEersteUurPrijs_InvalidPrice_ThrowsException()
    {
        // Arrange
        Auto auto = new Auto();
        decimal invalidPrice = -1;

        // Act & Assert
        Assert.Throws<AutoException>(() => auto.ZetEersteUurPrijs(invalidPrice));
    }

    [Fact]
    public void ZetNightlifePrijs_ValidPrice_SetsNightlifePrijs()
    {
        // Arrange
        Auto auto = new Auto();
        decimal validPrice = 150;

        // Act
        auto.ZetNightlifePrijs(validPrice);

        // Assert
        Assert.Equal(validPrice, auto.NightlifePrijs);
    }

    [Fact]
    public void ZetNightlifePrijs_InvalidPrice_ThrowsException()
    {
        // Arrange
        Auto auto = new Auto();
        decimal invalidPrice = -1;

        // Act & Assert
        Assert.Throws<AutoException>(() => auto.ZetNightlifePrijs(invalidPrice));
    }

    [Fact]
    public void ZetWeddingPrijs_ValidPrice_SetsWeddingPrijs()
    {
        // Arrange
        Auto auto = new Auto();
        decimal validPrice = 200;

        // Act
        auto.ZetWeddingPrijs(validPrice);

        // Assert
        Assert.Equal(validPrice, auto.WeddingPrijs);
    }

    [Fact]
    public void ZetWeddingPrijs_InvalidPrice_ThrowsException()
    {
        // Arrange
        Auto auto = new Auto();
        decimal invalidPrice = -1;

        // Act & Assert
        Assert.Throws<AutoException>(() => auto.ZetWeddingPrijs(invalidPrice));
    }

    [Fact]
    public void ZetBouwjaar_ValidYear_SetsBouwjaar()
    {
        // Arrange
        Auto auto = new Auto();
        int validYear = 2010;

        // Act
        auto.ZetBouwjaar(validYear);

        // Assert
        Assert.Equal(validYear, auto.Bouwjaar);
    }

    [Fact]
    public void ZetBouwjaar_InvalidYear_ThrowsException()
    {
        // Arrange
        Auto auto = new Auto();
        int invalidYear = 0;

        // Act & Assert
        Assert.Throws<AutoException>(() => auto.ZetBouwjaar(invalidYear));
    }

    //Klant
    public class KlantTests
    {
        [Fact]
        public void ZetKlantID_ValidID_SetsKlantID()
        {
            // Arrange
            Klant klant = new Klant();
            int validID = 10;

            // Act
            klant.ZetKlantID(validID);

            // Assert
            Assert.Equal(validID, klant.KlantID);
        }

        [Fact]
        public void ZetKlantID_InvalidID_ThrowsException()
        {
            // Arrange
            Klant klant = new Klant();
            int invalidID = -1;

            // Act & Assert
            Assert.Throws<KlantException>(() => klant.ZetKlantID(invalidID));
        }

        [Fact]
        public void ZetKlantnummer_ValidKlantnummer_SetsKlantnummer()
        {
            // Arrange
            Klant klant = new Klant();
            string validKlantnummer = "123456";

            // Act
            klant.ZetKlantnummer(validKlantnummer);

            // Assert
            Assert.Equal(validKlantnummer, klant.Klantnummer);
        }

        [Fact]
        public void ZetKlantnummer_InvalidKlantnummer_ThrowsException()
        {
            // Arrange
            Klant klant = new Klant();
            string invalidKlantnummer = "";

            // Act & Assert
            Assert.Throws<KlantException>(() => klant.ZetKlantnummer(invalidKlantnummer));
        }

        [Fact]
        public void ZetVoornaam_ValidVoornaam_SetsVoornaam()
        {
            // Arrange
            Klant klant = new Klant();
            string validVoornaam = "John";

            // Act
            klant.ZetVoornaam(validVoornaam);

            // Assert
            Assert.Equal(validVoornaam, klant.Voornaam);
        }

        [Fact]
        public void ZetVoornaam_InvalidVoornaam_ThrowsException()
        {
            // Arrange
            Klant klant = new Klant();
            string invalidVoornaam = "";

            // Act & Assert
            Assert.Throws<KlantException>(() => klant.ZetVoornaam(invalidVoornaam));
        }

        [Fact]
        public void ZetNaam_ValidNaam_SetsNaam()
        {
            // Arrange
            Klant klant = new Klant();
            string validNaam = "Doe";

            // Act
            klant.ZetNaam(validNaam);

            // Assert
            Assert.Equal(validNaam, klant.Naam);
        }

        [Fact]
        public void ZetNaam_InvalidNaam_ThrowsException()
        {
            // Arrange
            Klant klant = new Klant();
            string invalidNaam = "";

            // Act & Assert
            Assert.Throws<KlantException>(() => klant.ZetNaam(invalidNaam));
        }

        [Fact]
        public void ZetStraat_ValidStraat_SetsStraat()
        {
            // Arrange
            Klant klant = new Klant();
            string validStraat = "Main Street";

            // Act
            klant.ZetStraat(validStraat);

            // Assert
            Assert.Equal(validStraat, klant.Straat);
        }

        [Fact]
        public void ZetStraat_InvalidStraat_ThrowsException()
        {
            // Arrange
            Klant klant = new Klant();
            string invalidStraat = "";

            // Act & Assert
            Assert.Throws<KlantException>(() => klant.ZetStraat(invalidStraat));
        }

        [Fact]
        public void ZetStraatnummer_ValidStraatnummer_SetsStraatnummer()
        {
            // Arrange
            Klant klant = new Klant();
            string validStraatnummer = "10";

            // Act
            klant.ZetStraatnummer(validStraatnummer);

            // Assert
            Assert.Equal(validStraatnummer, klant.Straatnummer);
        }

        [Fact]
        public void ZetStraatnummer_InvalidStraatnummer_ThrowsException()
        {
            // Arrange
            Klant klant = new Klant();
            string invalidStraatnummer = "";

            // Act & Assert
            Assert.Throws<KlantException>(() => klant.ZetStraatnummer(invalidStraatnummer));
        }

        [Fact]
        public void ZetBusnummer_ValidBusnummer_SetsBusnummer()
        {
            // Arrange
            Klant klant = new Klant();
            string validBusnummer = "A1";

            // Act
            klant.ZetBusnummer(validBusnummer);

            // Assert
            Assert.Equal(validBusnummer, klant.Busnummer);
        }

        [Fact]
        public void ZetPlaats_ValidPlaats_SetsPlaats()
        {
            // Arrange
            Klant klant = new Klant();
            string validPlaats = "Amsterdam";

            // Act
            klant.ZetPlaats(validPlaats);

            // Assert
            Assert.Equal(validPlaats, klant.Plaats);
        }

        [Fact]
        public void ZetPlaats_InvalidPlaats_ThrowsException()
        {
            // Arrange
            Klant klant = new Klant();
            string invalidPlaats = "";

            // Act & Assert
            Assert.Throws<KlantException>(() => klant.ZetPlaats(invalidPlaats));
        }

        [Fact]
        public void ZetPostcode_ValidPostcode_SetsPostcode()
        {
            // Arrange
            Klant klant = new Klant();
            string validPostcode = "1234 AB";

            // Act
            klant.ZetPostcode(validPostcode);

            // Assert
            Assert.Equal(validPostcode, klant.Postcode);
        }

        [Fact]
        public void ZetPostcode_InvalidPostcode_ThrowsException()
        {
            // Arrange
            Klant klant = new Klant();
            string invalidPostcode = "";

            // Act & Assert
            Assert.Throws<KlantException>(() => klant.ZetPostcode(invalidPostcode));
        }

        [Fact]
        public void ZetBTWNummer_ValidBTWNummer_SetsBTWNummer()
        {
            // Arrange
            Klant klant = new Klant();
            string validBTWNummer = "NL123456789B01";

            // Act
            klant.ZetBTWNummer(validBTWNummer);

            // Assert
            Assert.Equal(validBTWNummer, klant.BTWNummer);
        }

        [Fact]
        public void ZetBTWNummer_InvalidBTWNummer_SetsBTWNummerToNull()
        {
            // Arrange
            Klant klant = new Klant();
            string invalidBTWNummer = "";

            // Act
            klant.ZetBTWNummer(null);

            // Assert
            Assert.Null(klant.BTWNummer);
        }

        //Locatie
        [Fact]
        public void ZetLocatieID_ValidLocatieID_SetsLocatieID()
        {
            // Arrange
            Locatie locatie = new Locatie();
            int validLocatieID = 1;

            // Act
            locatie.ZetLocatieID(validLocatieID);

            // Assert
            Assert.Equal(validLocatieID, locatie.LocatieID);
        }

        [Fact]
        public void ZetLocatieID_InvalidLocatieID_ThrowsException()
        {
            // Arrange
            Locatie locatie = new Locatie();
            int invalidLocatieID = -1;

            // Act & Assert
            Assert.Throws<LocatieException>(() => locatie.ZetLocatieID(invalidLocatieID));
        }
        [Fact]
        public void ZetStad_ValidStad_SetsStad()
        {
            // Arrange
            Locatie locatie = new Locatie();
            string validStad = "Nevele";

            // Act
            locatie.ZetStad(validStad);

            // Assert
            Assert.Equal(validStad, locatie.Stad);
        }
        
        [Fact]
        public void ZetStad_InvalidStad_ThrowsException()
        {
            // Arrange
            Locatie locatie = new Locatie();
            string invalidStad = "";

            // Act & Assert
            Assert.Throws<LocatieException>(() => locatie.ZetStad(invalidStad));
        }


        /// <summary>
        /// Reservering
        /// </summary>

        [Fact]
        public void ZetReserveringID_ValidReserveringID_SetsReserveringID()
        {
            // Arrange
            Reservering reservering = new Reservering();
            int validReserveringID = 1;

            // Act
            reservering.ZetReserveringID(validReserveringID);

            // Assert
            Assert.Equal(validReserveringID, reservering.ReserveringID);
        }

        [Fact]
        public void ZetReserveringID_InvalidReserveringID_ThrowsException()
        {
            // Arrange
            Reservering reservering = new Reservering();
            int invalidReserveringID = -1;

            // Act & Assert
            Assert.Throws<ReserveringException>(() => reservering.ZetReserveringID(invalidReserveringID));
        }
        [Fact]
        public void ZetKlant_ValidKlant_SetsKlant()
        {
            // Arrange
            Reservering reservering = new Reservering();
            Klant validKlant = new Klant();

            // Act
            reservering.ZetKlant(validKlant);

            // Assert
            Assert.Equal(validKlant, reservering.Klant);
        }

        [Fact]
        public void ZetKlant_NullKlant_ThrowsException()
        {
            // Arrange
            Reservering reservering = new Reservering();

            // Act & Assert
            Assert.Throws<ReserveringException>(() => reservering.ZetKlant(null));
        }
        [Fact]
        public void ZetAutos_ValidAutos_SetsAutos()
        {
            // Arrange
            Reservering reservering = new Reservering();
            List<Auto> validAutos = new List<Auto> { new Auto(), new Auto() };

            // Act
            reservering.ZetAutos(validAutos);

            // Assert
            Assert.Equal(validAutos, reservering.Autos);
        }

        [Fact]
        public void ZetAutos_NullAutos_ThrowsException()
        {
            // Arrange
            Reservering reservering = new Reservering();

            // Act & Assert
            Assert.Throws<ReserveringException>(() => reservering.ZetAutos(null));
        }

        [Fact]
        public void ZetAutos_EmptyAutos_ThrowsException()
        {
            // Arrange
            Reservering reservering = new Reservering();
            List<Auto> emptyAutos = new List<Auto>();

            // Act & Assert
            Assert.Throws<ReserveringException>(() => reservering.ZetAutos(emptyAutos));
        }

        // Valid arrangement and valid startUur for Nightlife
        [Fact]
        public void ZetArrangement_ValidArrangementAndStartUurForNightlife_NoExceptionThrown()
        {
            // Arrange
            var reservering = new Reservering();
            var arrangement = new Arrangement { Naam = "Nightlife" };
            var startUur = new TimeSpan(20, 0, 0);

            // Act
            reservering.ZetArrangement(arrangement, startUur);

            // Assert
            Assert.Equal(arrangement, reservering.Arrangement);
        }

        // Valid arrangement and valid startUur for Wedding
        [Fact]
        public void ZetArrangement_ValidArrangementAndStartUurForWedding_NoExceptionThrown()
        {
            // Arrange
            var reservering = new Reservering();
            var arrangement = new Arrangement { Naam = "Wedding" };
            var startUur = new TimeSpan(10, 0, 0);

            // Act
            reservering.ZetArrangement(arrangement, startUur);

            // Assert
            Assert.Equal(arrangement, reservering.Arrangement);
        }

        // Invalid arrangement
        [Fact]
        public void ZetArrangement_InvalidArrangement_ThrowsReserveringException()
        {
            // Arrange
            var reservering = new Reservering();
            Arrangement arrangement = null;
            var startUur = new TimeSpan(10, 0, 0);

            // Act & Assert
            var exception = Assert.Throws<ReserveringException>(() => reservering.ZetArrangement(arrangement, startUur));
            Assert.Equal("Ongeldig Arrangement", exception.Message);
        }

        // Invalid startUur for Nightlife
        [Fact]
        public void ZetArrangement_InvalidStartUurForNightlife_ThrowsReserveringException()
        {
            // Arrange
            var reservering = new Reservering();
            var arrangement = new Arrangement { Naam = "Nightlife" };
            var startUur = new TimeSpan(19, 0, 0);

            // Act & Assert
            var exception = Assert.Throws<ReserveringException>(() => reservering.ZetArrangement(arrangement, startUur));
            Assert.Equal("Nightlife-arrangement moet starten tussen 20:00 en 24:00", exception.Message);
        }

        // Invalid startUur for Wedding
        [Fact]
        public void ZetArrangement_InvalidStartUurForWedding_ThrowsReserveringException()
        {
            // Arrange
            var reservering = new Reservering();
            var arrangement = new Arrangement { Naam = "Wedding" };
            var startUur = new TimeSpan(15, 0, 0);

            // Act & Assert
            var exception = Assert.Throws<ReserveringException>(() => reservering.ZetArrangement(arrangement, startUur));
            Assert.Equal("Wedding-arrangement moet starten tussen 7:00 en 15:00", exception.Message);
        }
        // Valid startDatum
        [Fact]
        public void ZetStartDatum_ValidStartDatum_StartDatumIsSet()
        {
            // Arrange
            var reservering = new Reservering();
            var startDatum = new DateTime(2023, 6, 1);

            // Act
            reservering.ZetStartDatum(startDatum);

            // Assert
            Assert.Equal(startDatum, reservering.StartDatum);
        }

        // Valid startUur
        [Fact]
        public void ZetStartUur_ValidStartUur_StartUurIsSet()
        {
            // Arrange
            var reservering = new Reservering();
            var startUur = new TimeSpan(10, 0, 0);

            // Act
            reservering.ZetStartUur(startUur);

            // Assert
            Assert.Equal(startUur, reservering.StartUur);
        }

        // Invalid aantalUren
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(12)]
        public void ZetAantalUren_InvalidAantalUren_ThrowsReserveringException(int aantalUren)
        {
            // Arrange
            var reservering = new Reservering();

            // Act & Assert
            var exception = Assert.Throws<ReserveringException>(() => reservering.ZetAantalUren(aantalUren));
            Assert.Equal("Ongeldig AantalUren", exception.Message);
        }

        // Valid startLocatie
        [Fact]
        public void ZetStartLocatie_ValidStartLocatie_StartLocatieIsSet()
        {
            // Arrange
            var reservering = new Reservering();
            var startLocatie = new Locatie();

            // Act
            reservering.ZetStartLocatie(startLocatie);

            // Assert
            Assert.Equal(startLocatie, reservering.StartLocatie);
        }

        // Invalid startLocatie
        [Fact]
        public void ZetStartLocatie_InvalidStartLocatie_ThrowsReserveringException()
        {
            // Arrange
            var reservering = new Reservering();
            Locatie startLocatie = null;

            // Act & Assert
            var exception = Assert.Throws<ReserveringException>(() => reservering.ZetStartLocatie(startLocatie));
            Assert.Equal("Ongeldige StartLocatie", exception.Message);
        }

        // Valid aankomstLocatie
        [Fact]
        public void ZetAankomstLocatie_ValidAankomstLocatie_AankomstLocatieIsSet()
        {
            // Arrange
            var reservering = new Reservering();
            var aankomstLocatie = new Locatie();

            // Act
            reservering.ZetAankomstLocatie(aankomstLocatie);

            // Assert
            Assert.Equal(aankomstLocatie, reservering.AankomstLocatie);
        }

        // Invalid aankomstLocatie
        [Fact]
        public void ZetAankomstLocatie_InvalidAankomstLocatie_ThrowsReserveringException()
        {
            // Arrange
            var reservering = new Reservering();
            Locatie aankomstLocatie = null;

            // Act & Assert
            var exception = Assert.Throws<ReserveringException>(() => reservering.ZetAankomstLocatie(aankomstLocatie));
            Assert.Equal("Ongeldige AankomstLocatie", exception.Message);
        }


        // No arrangement, calculates subtotal based on unit price and aantalUren
        [Fact]
        public void BerekenSubtotaal_NoArrangement_CalculatesSubtotal()
        {
            // Arrange
            var reservering = new Reservering();
            reservering.Eenheidsprijs = 20;
            reservering.AantalUren = 3;

            // Act
            reservering.BerekenSubtotaal();

            // Assert
            Assert.Equal(60, reservering.Subtotaal);
        }

        // Nightlife arrangement, calculates subtotal based on fixed duration
        [Fact]
        public void BerekenSubtotaal_NightlifeArrangement_CalculatesSubtotal()
        {
            // Arrange
            var reservering = new Reservering();
            reservering.Eenheidsprijs = 15;
            reservering.Arrangement = new Arrangement { Naam = "Nightlife" };

            // Act
            reservering.BerekenSubtotaal();

            // Assert
            Assert.Equal(105, reservering.Subtotaal);
        }

        // Wedding arrangement, calculates subtotal based on fixed duration
        [Fact]
        public void BerekenSubtotaal_WeddingArrangement_CalculatesSubtotal()
        {
            // Arrange
            var reservering = new Reservering();
            reservering.Eenheidsprijs = 25;
            reservering.Arrangement = new Arrangement { Naam = "Wedding" };

            // Act
            reservering.BerekenSubtotaal();

            // Assert
            Assert.Equal(175, reservering.Subtotaal);
        }

        // Valid startUur for Night hours
        [Fact]
        public void ZetSoortUur_ValidStartUurNightHours_SetsSoortUurToNachturen()
        {
            // Arrange
            var reservering = new Reservering();
            reservering.ZetSoortUur(new TimeSpan(23, 0, 0));

            // Assert
            Assert.Equal("Nachturen", reservering.SoortUur);
        }

        // Valid startUur for Day hours
        [Fact]
        public void ZetSoortUur_ValidStartUurDayHours_SetsSoortUurToDaguren()
        {
            // Arrange
            var reservering = new Reservering();
            reservering.ZetSoortUur(new TimeSpan(10, 0, 0));

            // Assert
            Assert.Equal("Daguren", reservering.SoortUur);
        }

        // Valid startUur for Night hours spanning two days
        [Fact]
        public void IsNightUur_ValidStartUurNightHoursSpanningTwoDays_ReturnsTrue()
        {
            // Arrange
            var reservering = new Reservering();

            // Act
            var result = reservering.IsNightUur(new TimeSpan(3, 0, 0));

            // Assert
            Assert.True(result);
        }

        // Valid startUur for Day hours
        [Fact]
        public void IsNightUur_ValidStartUurDayHours_ReturnsFalse()
        {
            // Arrange
            var reservering = new Reservering();

            // Act
            var result = reservering.IsNightUur(new TimeSpan(10, 0, 0));

            // Assert
            Assert.False(result);
        }




    }

}