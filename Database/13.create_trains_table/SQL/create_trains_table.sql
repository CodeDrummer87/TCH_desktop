IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('Trains', 'u') IS NULL
CREATE TABLE Trains
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Number NCHAR(7) NOT NULL,
	Weight INT,
	Axles INT,
	SpecificLength INT,
	TailCar NCHAR(10),
	TrainFixation NVARCHAR(15)
)