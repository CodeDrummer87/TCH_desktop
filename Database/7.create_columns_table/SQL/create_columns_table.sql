IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('Columns', 'u') IS NULL
CREATE TABLE Columns
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	ColumnNumber INT,
	Abbreviation NVARCHAR(5),
	Specialization INT REFERENCES ColumnSpecializations(Id),
	Depot INT REFERENCES LocomotiveDepots(Id)
)

GO

IF OBJECT_ID('Columns', 'u') IS NOT NULL
INSERT INTO Columns
VALUES
(1, N'ê.1', 1, 1),
(2, N'ê.2', 1, 1),
(3, N'ê.3', 1, 1),
(4, N'ê.4', 5, 1),
(5, N'ê.5', 1, 1),
(6, N'ê.6', 1, 1),
(7, N'ê.7', 1, 1),
(8, N'ê.8', 1, 1),
(9, N'ê.9', 1, 1),
(11, N'ê.11', 1, 1),
(13, N'ê.13', 1, 1),
(15, N'ê.15', 2, 1),
(16, N'ê.16', 1, 1),
(17, N'ê.17', 1, 1),
(18, N'ê.18', 1, 1),
(20, N'ê.20', 1, 1),
(21, N'ê.21', 1, 1),
(22, N'ê.22', 3, 1),
(23, N'ê.23', 1, 1),
(25, N'ê.25', 6, 1),
(26, N'ê.26', 4, 1),
(28, N'ê.28', 1, 1),
(29, N'ê.29', 1, 1),
(30, N'ê.30', 1, 1),
(31, N'ê.31', 1, 1),
(32, N'ê.32', 1, 1),
(33, N'ê.33', 1, 1)
