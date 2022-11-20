﻿IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('Railroads', 'u') IS NULL
CREATE TABLE Railroads
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	FullTitle NVARCHAR(50) NOT NULL,
	Abbreviation NVARCHAR(20) NOT NULL,
	Code NVARCHAR(5) NOT NULL
)

GO

IF OBJECT_ID('Railroads', 'u') IS NOT NULL
INSERT INTO Railroads
VALUES 
	('Восточно-Сибирская железная дорога','ВСЖД', '092'),
	('Горьковская железная дорога', 'ГЖД', '024'),
	('Дальневосточная железная дорога', 'ДВЖД', '096'),
	('Забайкальская железная дорога', 'ЗабЖД', '094'),
	('Западно-Сибирская железная дорога', 'ЗСЖД', '083'),
	('Калининградская железная дорога', 'КЖД', '010'),
	('Красноярская железная дорога', 'КрасЖД', '088'),
	('Куйбышевская железная дорога', 'КбшЖД', '063'),
	('Московская железная дорога', 'МЖД', '017'),
	('Октябрьская железная дорога', 'ОЖД', '01'),
	('Приволжская железная дорога', 'ПривЖД', '061'),
	('Свердловская железная дорога', 'СвЖД', '076'),
	('Северная железная дорога', 'СЖД', '028'),
	('Северо-Кавказская железная дорога', 'СКЖД', '051'),
	('Юго-Восточная железная дорога', 'ЮВЖД', '058'),
	('Южно-Уральская железная дорога', 'ЮУЖД', '080');