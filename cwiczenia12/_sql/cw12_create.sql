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
