IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('LocomotiveTypes', 'u') IS NULL
CREATE TABLE LocomotiveTypes
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	LocoType NVARCHAR(15)
)

GO

IF OBJECT_ID('LocomotiveTypes', 'u') IS NOT NULL
INSERT INTO LocomotiveTypes
VALUES
	('Паровоз'),
	('Тепловоз'),
	('Электровоз'),
	('Газотурбовоз')

GO

IF OBJECT_ID('Locomotives', 'u') IS NULL
CREATE TABLE Locomotives
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	LocoType INT REFERENCES LocomotiveTypes (Id),
	Series INT,
	Number INT NOT NULL,
	Allocation NVARCHAR(50),
	NumberOfBrakeHolders INT,
	ImagePath NVARCHAR(200)
)
