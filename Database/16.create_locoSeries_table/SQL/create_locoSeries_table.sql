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
	(N'Ы', 1),
	(N'Я36', 1),
	
	(N'внЬ2', 2),
	(N'внЬ7', 2),
	(N'внЬ18ФЬ', 2),
	(N'зЬн3', 2),
	
	(N'ТЫ10', 3),
	(N'ТЫ10ъ', 3),
	(N'ТЫ10я', 3),
	(N'ТЫ10ѓ', 3),
	(N'ТЫ11', 3),
	(N'ТЫ11ь', 3),
	(N'ТЫ11ъ', 3),
	(N'2нб6', 3),
	(N'2нб10', 3),
	(N'ТЫ60', 3),
	(N'ТЫ60я', 3),
	(N'ТЫ60№', 3),
	(N'ТЫ60ъ', 3),
	(N'ТЫ60яъ', 3),
	(N'ТЫ60ъѓ', 3),
	(N'ТЫ80ё', 3),
	(N'ТЫ80ђ', 3),
	(N'ТЫ80№', 3),
	(N'ТЫ80ъ', 3),

	(N'Ув1h', 4),
	(N'УЯ1', 4)
