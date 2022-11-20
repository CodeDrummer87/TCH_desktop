IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('LocomotiveDepots', 'u') IS NULL
DROP TABLE LocomotiveDepots