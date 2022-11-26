IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('Locomotives', 'u') IS NOT NULL
DROP TABLE Locomotives;

GO

IF OBJECT_ID('LocomotiveTypes', 'u') IS NOT NULL
DROP TABLE LocomotiveTypes;
