IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID(N'Trips', 'u') IS NULL
CREATE TABLE Trips
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	AttendanceTime DATETIME NOT NULL,
	Locomotive INT REFERENCES Locomotives (Id) NOT NULL,
	TrafficRoute NVARCHAR(200) NOT NULL,
	ElectricityFactor FLOAT,
	Departure NVARCHAR(20),
	Arrival NVARCHAR(20),
	PassedStations NVARCHAR(200),
	SpeedLimits NVARCHAR(MAX),
	ElectricityAmountRequired INT,
	ElectricityRecoveryRequired FLOAT,
	TechnicalSpeed FLOAT,
	Notes NVARCHAR(MAX),
	Train INT REFERENCES Trains (Id)
)