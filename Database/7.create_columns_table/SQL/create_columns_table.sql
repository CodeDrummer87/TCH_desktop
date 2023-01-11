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
(1, N'�.1', 1, 1),
(2, N'�.2', 1, 1),
(3, N'�.3', 1, 1),
(4, N'�.4', 5, 1),
(5, N'�.5', 1, 1),
(6, N'�.6', 1, 1),
(7, N'�.7', 1, 1),
(8, N'�.8', 1, 1),
(9, N'�.9', 1, 1),
(11, N'�.11', 1, 1),
(13, N'�.13', 1, 1),
(15, N'�.15', 2, 1),
(16, N'�.16', 1, 1),
(17, N'�.17', 1, 1),
(18, N'�.18', 1, 1),
(20, N'�.20', 1, 1),
(21, N'�.21', 1, 1),
(22, N'�.22', 3, 1),
(23, N'�.23', 1, 1),
(25, N'�.25', 6, 1),
(26, N'�.26', 4, 1),
(28, N'�.28', 1, 1),
(29, N'�.29', 1, 1),
(30, N'�.30', 1, 1),
(31, N'�.31', 1, 1),
(32, N'�.32', 1, 1),
(33, N'�.33', 1, 1)
