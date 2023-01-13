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
(1, N'к.1', 1, 1),
(2, N'к.2', 1, 1),
(3, N'к.3', 1, 1),
(4, N'к.4', 5, 1),
(5, N'к.5', 1, 1),
(6, N'к.6', 1, 1),
(7, N'к.7', 1, 1),
(8, N'к.8', 1, 1),
(9, N'к.9', 1, 1),
(11, N'к.11', 1, 1),
(13, N'к.13', 1, 1),
(15, N'к.15', 2, 1),
(16, N'к.16', 1, 1),
(17, N'к.17', 1, 1),
(18, N'к.18', 1, 1),
(20, N'к.20', 1, 1),
(21, N'к.21', 1, 1),
(22, N'к.22', 3, 1),
(23, N'к.23', 1, 1),
(25, N'к.25', 6, 1),
(26, N'к.26', 4, 1),
(28, N'к.28', 1, 1),
(29, N'к.29', 1, 1),
(30, N'к.30', 1, 1),
(31, N'к.31', 1, 1),
(32, N'к.32', 1, 1),
(33, N'к.33', 1, 1)
