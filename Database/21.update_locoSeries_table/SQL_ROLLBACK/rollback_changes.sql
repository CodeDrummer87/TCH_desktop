IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('LocoSeries', 'u') IS NOT NULL
DROP TABLE LocoSeries

GO

IF OBJECT_ID('LocoSeries', 'u') IS NULL
CREATE TABLE LocoSeries
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	SeriesFirst NVARCHAR(10),
	lIndex NVARCHAR(5) DEFAULT '',
	isUpperIndex TINYINT DEFAULT 1,
	SeriesSecond NVARCHAR(5) DEFAULT '',
	LocoType INT REFERENCES LocomotiveTypes (Id)
)