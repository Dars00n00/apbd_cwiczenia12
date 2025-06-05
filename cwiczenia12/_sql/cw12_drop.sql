-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-04-20 04:46:38.52

-- foreign keys
ALTER TABLE cwiczenia12_Country_Trip DROP CONSTRAINT cwiczenia12_Country_Trip_Country;

ALTER TABLE cwiczenia12_Country_Trip DROP CONSTRAINT cwiczenia12_Country_Trip_Trip;

ALTER TABLE cwiczenia12_Client_Trip DROP CONSTRAINT cwiczenia12_Client_Trip_Client;

ALTER TABLE cwiczenia12_Client_Trip DROP CONSTRAINT cwiczenia12_Client_Trip_Trip;

-- tables
DROP TABLE cwiczenia12_Client;

DROP TABLE cwiczenia12_Client_Trip;

DROP TABLE cwiczenia12_Country;

DROP TABLE cwiczenia12_Country_Trip;

DROP TABLE cwiczenia12_Trip;

-- End of file.
