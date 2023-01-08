IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('TripsBrakeTests', 'u') IS NULL
CREATE TABLE TripsBrakeTests
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Trip INT REFERENCES Trips(Id) NOT NULL,
	BrakeTest INT REFERENCES BrakeTests(Id) NOT NULL
);
