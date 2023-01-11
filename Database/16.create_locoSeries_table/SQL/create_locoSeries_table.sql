IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('LocoSeries', 'u') IS NULL
CREATE TABLE LocoSeries
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Series NVARCHAR(10),
	LocoType INT REFERENCES LocomotiveTypes (Id)
)


IF OBJECT_ID(N'LocoSeries', 'u') IS NOT NULL
INSERT INTO LocoSeries
VALUES
	(N'�', 1),
	(N'�36', 1),
	
	(N'���2', 2),
	(N'���7', 2),
	(N'���18��', 2),
	(N'���3', 2),
	
	(N'��10', 3),
	(N'��10�', 3),
	(N'��10�', 3),
	(N'��10�', 3),
	(N'��11', 3),
	(N'��11�', 3),
	(N'��11�', 3),
	(N'2��6', 3),
	(N'2��10', 3),
	(N'��60', 3),
	(N'��60�', 3),
	(N'��60�', 3),
	(N'��60�', 3),
	(N'��60��', 3),
	(N'��60��', 3),
	(N'��80�', 3),
	(N'��80�', 3),
	(N'��80�', 3),
	(N'��80�', 3),

	(N'��1h', 4),
	(N'��1', 4)
