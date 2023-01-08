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
(1, 'к.1', 1, 1),
(2, 'к.2', 1, 1),
(3, 'к.3', 1, 1),
(4, 'к.4', 5, 1),
(5, 'к.5', 1, 1),
(6, 'к.6', 1, 1),
(7, 'к.7', 1, 1),
(8, 'к.8', 1, 1),
(9, 'к.9', 1, 1),
(11, 'к.11', 1, 1),
(13, 'к.13', 1, 1),
(15, 'к.15', 2, 1),
(16, 'к.16', 1, 1),
(17, 'к.17', 1, 1),
(18, 'к.18', 1, 1),
(20, 'к.20', 1, 1),
(21, 'к.21', 1, 1),
(22, 'к.22', 3, 1),
(23, 'к.23', 1, 1),
(25, 'к.25', 6, 1),
(26, 'к.26', 4, 1),
(28, 'к.28', 1, 1),
(29, 'к.29', 1, 1),
(30, 'к.30', 1, 1),
(31, 'к.31', 1, 1),
(32, 'к.32', 1, 1),
(33, 'к.33', 1, 1)
