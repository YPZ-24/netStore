CREATE DATABASE DB_PROYECTO;

USE DB_PROYECTO;

CREATE TABLE Suppliers(
	SupplierID				int IDENTITY(1,1) PRIMARY KEY,
	RFCSupplier				varchar(255),
	TaxAddressSupplier		varchar(255),
	DedicatedToSupplier		varchar(255),
	SocialReasonSupplier	varchar(255)
);

CREATE TABLE SupplierServices(
	SupplierServicesID		int IDENTITY(1,1) PRIMARY KEY,
	SupplierID				int,
	DeliveryTimeSS			int,
	DeliveryQualitySS			int,
	PackingQualitySS		int,
	FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);


CREATE TABLE Products(
	ProductID			int IDENTITY(1,1) PRIMARY KEY,
	SupplierID			int,
	NameProduct			varchar(255),
	CountryProduct		varchar(255),
	CategoryProduct		varchar(255),
	CveProduct			varchar(255),
	WeightProduct		float,
	ScoreProduct		int,
	RealPrice			float,
	SuggestedPrice		float,
	PublicPrice			float
	FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

SELECT * FROM SupplierServices;
SELECT * FROM Suppliers;

SELECT SupplierName, SupplierID, AVG(DeliveryQualitySS + PackingQualitySS + DeliveryTimeSS)/3 FROM SupplierServices GROUP BY SupplierID;

INSERT INTO Suppliers(RFCSupplier, TaxAddressSupplier, DedicatedToSupplier, SocialReasonSupplier) VALUES('YEGA0110246N8', 'Alambrada 34', 'Ropa Deportiva', 'Ropa Deportiva S.A. de C.V.')
INSERT INTO Suppliers(RFCSupplier, TaxAddressSupplier, DedicatedToSupplier, SocialReasonSupplier) VALUES('YEGA0110246N9', 'Camino Viejo 18', 'Tecnologia', 'Tecnologia S.A. de C.V.')

INSERT INTO SupplierServices(SupplierID, DeliveryTimeSS, DeliveryQualitySS, PackingQualitySS) VALUES(1, 10, 9, 8);
INSERT INTO SupplierServices(SupplierID, DeliveryTimeSS, DeliveryQualitySS, PackingQualitySS) VALUES(2, 5, 4, 5);
INSERT INTO SupplierServices(SupplierID, DeliveryTimeSS, DeliveryQualitySS, PackingQualitySS) VALUES(1, 7, 9, 8);
INSERT INTO SupplierServices(SupplierID, DeliveryTimeSS, DeliveryQualitySS, PackingQualitySS) VALUES(1, 7, 5, 8);





