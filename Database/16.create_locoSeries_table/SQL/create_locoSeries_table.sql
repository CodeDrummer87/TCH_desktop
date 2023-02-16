IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('LocoSeries', 'u') IS NULL
CREATE TABLE LocoSeries
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Series NVARCHAR(10),
	LocoType INT REFERENCES LocomotiveTypes (Id)
)


IF OBJECT_ID(N'LocoSeries', 'u') IS NOT NULL
INSERT INTO LocoSeries
VALUES
	(N'Л', 1),
	(N'П36', 1),
	
	(N'ТЭМ2', 2),
	(N'ТЭМ7', 2),
	(N'ТЭМ18ДМ', 2),
	(N'ЧМЭ3', 2),
	
	(N'ВЛ10', 3),
	(N'ВЛ10к', 3),
	(N'1.5ВЛ10к', 3),
	(N'2ВЛ10к', 3),
	(N'ВЛ10п', 3),
	(N'ВЛ10у', 3),
	(N'ВЛ11', 3),
	(N'ВЛ11м', 3),
	(N'ВЛ11к', 3),
	(N'1.5ВЛ11к', 3),
	(N'2ВЛ11к', 3),
	(N'2ЭС6', 3),
	(N'3ЭС6', 3),
	(N'3ЭС8', 3),
	(N'2ЭС10', 3),
	(N'ВЛ60', 3),
	(N'ВЛ60п', 3),
	(N'ВЛ60р', 3),
	(N'ВЛ60к', 3),
	(N'ВЛ60пк', 3),
	(N'ВЛ60ку', 3),
	(N'ВЛ80с', 3),
	(N'ВЛ80т', 3),
	(N'ВЛ80р', 3),
	(N'ВЛ80к', 3),

	(N'ГТ1h', 4),
	(N'ГП1', 4)
