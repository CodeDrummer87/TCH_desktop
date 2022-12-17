IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('Locomotives', 'u') IS NOT NULL
ALTER TABLE Locomotives
ALTER COLUMN Series NVARCHAR(10)

GO

IF OBJECT_ID('LocoSeries', 'u') IS NOT NULL
DROP TABLE LocoSeries;