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
	Series NVARCHAR(10),
	LocoType INT REFERENCES LocomotiveTypes (Id)
)


IF OBJECT_ID('LocoSeries', 'u') IS NOT NULL
INSERT INTO LocoSeries
VALUES
	('Л', 1),
	('П36', 1),
	
	('ТЭМ2', 2),
	('ТЭМ7', 2),
	('ТЭМ18ДМ', 2),
	('ЧМЭ3', 2),
	
	('ВЛ10', 3),
	('ВЛ10к', 3),
	('ВЛ10п', 3),
	('ВЛ10у', 3),
	('ВЛ11', 3),
	('ВЛ11м', 3),
	('ВЛ11к', 3),
	('2ЭС6', 3),
	('2ЭС10', 3),
	('ВЛ80с', 3),
	('ВЛ80т', 3),
	('ВЛ80р', 3),
	('ВЛ80к', 3),

	('ГТ1h', 4),
	('ГП1', 4)
