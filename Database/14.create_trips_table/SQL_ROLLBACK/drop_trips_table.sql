IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('Trips', 'u') IS NULL
DROP TABLE Trips