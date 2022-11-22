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
(1, '�.1', 1, 1),
(2, '�.2', 1, 1),
(3, '�.3', 1, 1),
(4, '�.4', 5, 1),
(5, '�.5', 1, 1),
(6, '�.6', 1, 1),
(7, '�.7', 1, 1),
(8, '�.8', 1, 1),
(9, '�.9', 1, 1),
(11, '�.11', 1, 1),
(13, '�.13', 1, 1),
(15, '�.15', 2, 1),
(16, '�.16', 1, 1),
(17, '�.17', 1, 1),
(18, '�.18', 1, 1),
(20, '�.20', 1, 1),
(21, '�.21', 1, 1),
(22, '�.22', 3, 1),
(23, '�.23', 1, 1),
(25, '�.25', 6, 1),
(26, '�.26', 4, 1),
(28, '�.28', 1, 1),
(29, '�.29', 1, 1),
(30, '�.30', 1, 1),
(31, '�.31', 1, 1),
(32, '�.32', 1, 1),
(33, '�.33', 1, 1)