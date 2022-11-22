IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb

GO

DELETE FROM Columns

GO

sp_rename 'Columns.Abbreviation', 'Abbreviate', 'COLUMN' 

GO

IF OBJECT_ID('Columns', 'u') IS NOT NULL
ALTER TABLE Columns
DROP CONSTRAINT [FK__Columns__Depot__4D5F7D71]

GO

IF OBJECT_ID('Columns', 'u') IS NOT NULL
ALTER TABLE Columns
DROP COLUMN Depot

GO

IF OBJECT_ID('Columns', 'u') IS NOT NULL
ALTER TABLE Columns
ADD Instructor REFERENCES Users (Id)
