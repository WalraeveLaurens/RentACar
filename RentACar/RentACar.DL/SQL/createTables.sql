-- Tabel: Auto
CREATE TABLE Auto (
AutoID INT IDENTITY(1,1) PRIMARY KEY,
Naam NVARCHAR(50),
EersteUurPrijs DECIMAL(10, 2),
NightlifePrijs DECIMAL(10, 2),
WeddingPrijs DECIMAL(10, 2),
Bouwjaar INT
);

-- Tabel: Locatie
CREATE TABLE Locatie (
LocatieID INT IDENTITY(1,1) PRIMARY KEY,
Stad NVARCHAR(50)
);

-- Tabel: Arrangement
CREATE TABLE Arrangement (
ArrangementID INT IDENTITY(1,1) PRIMARY KEY,
Naam NVARCHAR(50)
);

-- Tabel: Klant
CREATE TABLE Klant (
KlantID INT IDENTITY(1,1) PRIMARY KEY,
Klantnummer NVARCHAR(20),
Voornaam NVARCHAR(50),
Naam NVARCHAR(50),
Straat NVARCHAR(50),
Straatnummer NVARCHAR(20),
Busnummer NVARCHAR(10),
Plaats NVARCHAR(50),
Postcode NVARCHAR(10),
BTWNummer NVARCHAR(20)
);

-- Tabel: Reservering
CREATE TABLE Reservering (
ReserveringID INT IDENTITY(1,1) PRIMARY KEY,
KlantID INT,
ArrangementID INT,
StartDatum DATE,
StartUur TIME,
AantalUren INT,
SoortUur NVARCHAR(20),
Eenheidsprijs DECIMAL(10, 2),
Subtotaal DECIMAL(10, 2),
StartLocatieID INT,
AankomstLocatieID INT,
FOREIGN KEY (KlantID) REFERENCES Klant(KlantID),
FOREIGN KEY (ArrangementID) REFERENCES Arrangement(ArrangementID),
FOREIGN KEY (StartLocatieID) REFERENCES Locatie(LocatieID),
FOREIGN KEY (AankomstLocatieID) REFERENCES Locatie(LocatieID)
);

-- Tabel: ReserveringAuto
CREATE TABLE ReserveringAuto (
ReserveringAutoID INT IDENTITY(1,1) PRIMARY KEY,
ReserveringID INT,
AutoID INT,
FOREIGN KEY (ReserveringID) REFERENCES Reservering(ReserveringID),
FOREIGN KEY (AutoID) REFERENCES Auto(AutoID)
);