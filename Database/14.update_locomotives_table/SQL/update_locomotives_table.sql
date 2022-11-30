IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb

GO

IF OBJECT_ID('Locomotives', 'u') IS NOT NULL
ALTER TABLE Locomotives
ALTER COLUMN Number INT

GO

IF OBJECT_ID('Locomotives', 'u') IS NOT NULL
ALTER TABLE Locomotives
ADD ImagePath NVARCHAR(200)
