IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb

GO

IF OBJECT_ID('Columns', 'u') IS NOT NULL
ALTER TABLE Columns
ADD Depot INT REFERENCES LocomotiveDepots(Id)

GO

IF OBJECT_ID('Columns', 'u') IS NOT NULL
ALTER TABLE Columns
DROP CONSTRAINT [FK__Columns__Instruc__5FB337D6]
GO

IF OBJECT_ID('Columns', 'u') IS NOT NULL
ALTER TABLE Columns
DROP COLUMN Instructor

GO

sp_rename 'Columns.Abbreviate', 'Abbreviation', 'COLUMN' 

GO

IF OBJECT_ID('Columns', 'u') IS NOT NULL
INSERT INTO Columns
VALUES
(1, 'ê.1', 1, 1),
(2, 'ê.2', 1, 1),
(3, 'ê.3', 1, 1),
(4, 'ê.4', 5, 1),
(5, 'ê.5', 1, 1),
(6, 'ê.6', 1, 1),
(7, 'ê.7', 1, 1),
(8, 'ê.8', 1, 1),
(9, 'ê.9', 1, 1),
(11, 'ê.11', 1, 1),
(13, 'ê.13', 1, 1),
(15, 'ê.15', 2, 1),
(16, 'ê.16', 1, 1),
(17, 'ê.17', 1, 1),
(18, 'ê.18', 1, 1),
(20, 'ê.20', 1, 1),
(21, 'ê.21', 1, 1),
(22, 'ê.22', 3, 1),
(23, 'ê.23', 1, 1),
(25, 'ê.25', 6, 1),
(26, 'ê.26', 4, 1),
(28, 'ê.28', 1, 1),
(29, 'ê.29', 1, 1),
(30, 'ê.30', 1, 1),
(31, 'ê.31', 1, 1),
(32, 'ê.32', 1, 1),
(33, 'ê.33', 1, 1)