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
	ProductID				int IDENTITY(1,1) PRIMARY KEY,
	SupplierID				int,
	NameProduct				varchar(255),
	CountryProduct			varchar(255),
	CategoryProduct			varchar(255),
	CveProduct				varchar(255),
	WeightProduct			float,
	ScoreProduct			int,
	RealPriceProduct		float,
	SuggestedPriceProduct	float,
	PublicPriceProduct		float,
	StockProduct			int,
	FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

SELECT * FROM SupplierServices;
SELECT * FROM Suppliers;

SELECT SupplierID, AVG(DeliveryQualitySS + PackingQualitySS + DeliveryTimeSS)/3 FROM SupplierServices GROUP BY SupplierID;

INSERT INTO Suppliers(RFCSupplier, TaxAddressSupplier, DedicatedToSupplier, SocialReasonSupplier) VALUES('YEGA0110246N8', 'Alambrada 34', 'Ropa Deportiva', 'Ropa Deportiva S.A. de C.V.')
INSERT INTO Suppliers(RFCSupplier, TaxAddressSupplier, DedicatedToSupplier, SocialReasonSupplier) VALUES('YEGA0110246N9', 'Camino Viejo 18', 'Tecnologia', 'Tecnologia S.A. de C.V.')

INSERT INTO SupplierServices(SupplierID, DeliveryTimeSS, DeliveryQualitySS, PackingQualitySS) VALUES(1, 10, 9, 8);
INSERT INTO SupplierServices(SupplierID, DeliveryTimeSS, DeliveryQualitySS, PackingQualitySS) VALUES(2, 5, 4, 5);
INSERT INTO SupplierServices(SupplierID, DeliveryTimeSS, DeliveryQualitySS, PackingQualitySS) VALUES(1, 7, 9, 8);
INSERT INTO SupplierServices(SupplierID, DeliveryTimeSS, DeliveryQualitySS, PackingQualitySS) VALUES(1, 7, 5, 8);

INSERT INTO Products(SupplierID, NameProduct, CountryProduct, CategoryProduct, CveProduct, WeightProduct, ScoreProduct, RealPriceProduct, SuggestedPriceProduct, PublicPriceProduct, StockProduct)
	VALUES(1, 'Playera', 'China', 'Ropa', 'RPP', 20, 5, 200, 250, 260, 1);

INSERT INTO Products(SupplierID, NameProduct, CountryProduct, CategoryProduct, CveProduct, WeightProduct, ScoreProduct, RealPriceProduct, SuggestedPriceProduct, PublicPriceProduct, StockProduct)
	VALUES(1, 'Camisas', 'China', 'Ropa', 'CPP', 10, 3, 300, 350, 360, 180);

INSERT INTO Products(SupplierID, NameProduct, CountryProduct, CategoryProduct, CveProduct, WeightProduct, ScoreProduct, RealPriceProduct, SuggestedPriceProduct, PublicPriceProduct, StockProduct)
	VALUES(2, 'Computadora', 'EU', 'Tecnologia', 'RPP', 30, 10, 1200, 1300, 1400, 20);

SELECT * FROM Products;
SELECT CategoryProduct, SUM(StockProduct) FROM Products GROUP BY CategoryProduct




