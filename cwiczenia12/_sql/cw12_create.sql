-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-04-20 04:46:38.52

-- tables
-- Table: cwiczenia12_Client
CREATE TABLE cwiczenia12_Client (
    IdClient int NOT NULL IDENTITY,
    FirstName nvarchar(120) NOT NULL,
    LastName nvarchar(120) NOT NULL,
    Email nvarchar(120) NOT NULL,
    Telephone nvarchar(120) NOT NULL,
    Pesel nvarchar(120) NOT NULL,
    CONSTRAINT cwiczenia12_Client_pk PRIMARY KEY (IdClient)
);

-- Table: cwiczenia12_Client_Trip
CREATE TABLE cwiczenia12_Client_Trip (
    IdClient int NOT NULL,
    IdTrip int NOT NULL,
    RegisteredAt datetime NOT NULL,
    PaymentDate datetime NULL,
    CONSTRAINT cwiczenia12_Client_Trip_pk PRIMARY KEY (IdClient, IdTrip)
);

-- Table: cwiczenia12_Country
CREATE TABLE cwiczenia12_Country (
    IdCountry int NOT NULL IDENTITY,
    Name nvarchar(120) NOT NULL,
    CONSTRAINT cwiczenia12_Country_pk PRIMARY KEY (IdCountry)
);

-- Table: cwiczenia12_Country_Trip
CREATE TABLE cwiczenia12_Country_Trip (
    IdCountry int NOT NULL,
    IdTrip int NOT NULL,
    CONSTRAINT cwiczenia12_Country_Trip_pk PRIMARY KEY (IdCountry, IdTrip)
);

-- Table: cwiczenia12_Trip
CREATE TABLE cwiczenia12_Trip (
    IdTrip int NOT NULL IDENTITY,
    Name nvarchar(120) NOT NULL,
    Description nvarchar(220) NOT NULL,
    DateFrom datetime NOT NULL,
    DateTo datetime NOT NULL,
    MaxPeople int NOT NULL,
    CONSTRAINT cwiczenia12_Trip_pk PRIMARY KEY (IdTrip)
);

-- foreign keys
-- Reference: cwiczenia12_Country_Trip_Country
ALTER TABLE cwiczenia12_Country_Trip ADD CONSTRAINT cwiczenia12_Country_Trip_Country
    FOREIGN KEY (IdCountry)
    REFERENCES cwiczenia12_Country (IdCountry);

-- Reference: cwiczenia12_Country_Trip_Trip
ALTER TABLE cwiczenia12_Country_Trip ADD CONSTRAINT cwiczenia12_Country_Trip_Trip
    FOREIGN KEY (IdTrip)
    REFERENCES cwiczenia12_Trip (IdTrip);

-- Reference: cwiczenia12_Client_Trip_Client
ALTER TABLE cwiczenia12_Client_Trip ADD CONSTRAINT cwiczenia12_Client_Trip_Client
    FOREIGN KEY (IdClient)
    REFERENCES cwiczenia12_Client (IdClient);

-- Reference: cwiczenia12_Client_Trip_Trip
ALTER TABLE cwiczenia12_Client_Trip ADD CONSTRAINT cwiczenia12_Client_Trip_Trip
    FOREIGN KEY (IdTrip)
    REFERENCES cwiczenia12_Trip (IdTrip);

INSERT INTO cwiczenia12_Client (FirstName, LastName, Email, Telephone, Pesel)
VALUES
    ('Jan', 'Kowalski', 'jan.kowalski@example.com', '123456789', '12345678901'),
    ('Anna', 'Nowak', 'anna.nowak@example.com', '987654321', '10987654321');

INSERT INTO cwiczenia12_Country (Name)
VALUES
    ('Polska'),
    ('Niemcy');

INSERT INTO cwiczenia12_Trip (Name, Description, DateFrom, DateTo, MaxPeople)
VALUES
    ('Wycieczka nad morze', 'Relaks nad Bałtykiem', '2025-07-01', '2025-07-07', 30),
    ('Zwiedzanie Berlina', 'Kulturalna wyprawa do Berlina', '2025-08-15', '2025-08-20', 20);


INSERT INTO cwiczenia12_Country_Trip (IdCountry, IdTrip)
VALUES
    (1, 1), 
    (2, 2); 

INSERT INTO cwiczenia12_Client_Trip (IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES
    (1, 1, GETDATE(), NULL), 
    (2, 2, GETDATE(), GETDATE()); 
