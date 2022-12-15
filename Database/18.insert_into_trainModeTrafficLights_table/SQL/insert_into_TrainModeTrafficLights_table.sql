﻿IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('TrainModeTrafficLights', 'u') IS NOT NULL
INSERT INTO TrainModeTrafficLights
VALUES 
	(1, 'ЧТ', 8),
	(1, 'ЧЧ', 8),
	(1, 'ЧИ', 8),
	(1, 'ЧМ3В', 8),
	(1, 'Ч1А', 8),
	(1, 'Ч2А', 8),
	(1, 'Ч3', 8),
	(1, 'Ч3А', 8),
	(1, 'Ч4А', 8),
	(1, 'Ч5А', 8),
	(1, 'Ч6А', 8),
	(1, 'Ч7А', 8),
	(1, 'Ч8А', 8),
	(1, 'Ч9А', 8),
	(1, 'ЧГ', 8),
	(1, 'ЧГII', 8),
	(1, 'ЧГIII', 8),
	(1, 'Ч1Б', 8),
	(1, 'Ч2Б', 8),
	(1, 'Ч3Б', 8),
	(1, 'Ч4Б', 8),
	(1, 'IЧ', 8),
	
	(0, 'Н', 8),
	(0, 'IНМ', 8),
	(0, 'НМ', 8),
	(0, 'НМГ', 8),
	(0, 'НМ3', 8),
	(0, 'НМ3А', 8),
	(0, 'НА', 8),
	(0, 'Н1А', 8),
	(0, 'Н2А', 8),
	(0, 'Н1Б', 8),
	(0, 'Н2Б', 8),
	(0, 'Н3Б', 8),
	(0, 'Н3В', 8),
	(0, 'Н4А', 8),
	(0, 'Н5А', 8),
	(0, 'Н6А', 8),
	(0, 'Н7А', 8),
	(0, 'Н8А', 8),
	(0, 'Н9А', 8),
	(0, 'НМД', 8),
	(0, 'НОД', 8),

	(1, 'Ч', 9),
	(1, 'ЧМГ', 9),
	(1, 'Ч1', 9),
	(1, 'Ч2', 9),
	(1, 'ЧА1', 9),
	(1, 'ЧА2', 9),
	(1, 'ЧА3', 9),
	(1, 'ЧА4', 9),
	(1, 'ЧА5', 9),
	(1, 'ЧА6', 9),
	(1, 'ЧБ1', 9),
	(1, 'ЧВ1', 9),
	(1, 'ЧВ2', 9),
	(1, 'ЧВ3', 9),
	(1, 'ЧБ5', 9),
	(1, 'ЧБ6', 9),
	(1, 'ЧБ7', 9),
	(1, 'ЧБ8', 9),

	(0, 'Н', 9),
	(0, 'НД', 9),
	(0, 'НМ1', 9),
	(0, 'НМ2', 9),
	(0, 'НБ1', 9),
	(0, 'НВ1', 9),
	(0, 'НВ2', 9),
	(0, 'НВ3', 9),
	(0, 'НВ5', 9),
	(0, 'НВ6', 9),
	(0, 'НВ7', 9),
	(0, 'НБ5', 9),
	(0, 'НБ6', 9),
	(0, 'НБ7', 9),
	(0, 'НБ8', 9),
	(0, 'НО', 9),
	(0, 'НГ', 9),
	(0, 'НМ1Г', 9),
	(0, 'IН', 9),
	(0, 'НМА5', 9),
	(0, 'НА1', 9),
	(0, 'НА2', 9),
	(0, 'НА3', 9),
	(0, 'НА4', 9),
	(0, 'НА5', 9),
	(0, 'НА6', 9),

	(1, 'Ч1Г', 10),
	(1, 'Ч2Г', 10),
	(1, 'Ч3Г', 10),
	(1, 'ЧМ3ГВ', 10),
	(1, 'ЧМ2Г', 10),
	(1, 'ЧМСГ', 10),
	(1, 'ЧМ3Г', 10),
	(1, 'Ч1А', 10),
	(1, 'Ч2А', 10),
	(1, 'Ч3А', 10),
	(1, 'Ч4А', 10),
	(1, 'Ч5А', 10),
	(1, 'Ч6А', 10),
	(1, 'Ч7А', 10),
	(1, 'Ч1', 10),
	(1, 'Ч2', 10),
	(1, 'Ч3', 10),
	(1, 'Ч4', 10),
	(1, 'Ч5', 10),
	(1, 'Ч6', 10),
	(1, 'Ч8', 10),
	(1, 'Ч9', 10),
	(1, 'Ч10', 10),
	(1, 'Ч17', 10),
	(1, 'Ч18', 10),
	(1, 'Ч19', 10),
	(1, 'Ч20', 10),
	(1, 'Ч21', 10),
	(1, 'Ч22', 10),
	(1, 'Ч23', 10),
	(1, 'Ч24', 10),
	(1, 'Ч25', 10),
	(1, 'ЧК', 10),
	(1, 'ЧКМ', 10),
	(1, 'ЧО', 10),
	(1, 'ЧВН', 10),
	(1, 'ЧВНМ', 10),

	(0, 'Н', 10),
	(0, 'НД', 10),
	(0, 'НМ1', 10),
	(0, 'НМ2', 10),
	(0, 'НМ1Г1', 10),
	(0, 'НМ1Г', 10),
	(0, 'Н2Г', 10),
	(0, 'НМ3Г', 10),
	(0, 'НМСГ', 10),
	(0, 'Н4', 10),
	(0, 'Н5', 10),
	(0, 'Н6', 10),
	(0, 'Н1', 10),
	(0, 'Н2', 10),
	(0, 'Н8', 10),
	(0, 'Н9', 10),
	(0, 'Н10', 10),
	(0, 'Н11', 10),
	(0, 'Н12', 10),
	(0, 'Н13', 10),
	(0, 'Н14', 10),
	(0, 'Н15', 10),
	(0, 'Н16', 10),
	(0, 'Н17', 10),
	(0, 'Н18', 10),
	(0, 'Н19', 10),
	(0, 'Н20', 10),
	(0, 'Н21', 10),
	(0, 'Н22', 10),
	(0, 'Н23', 10),
	(0, 'Н24', 10),
	(0, 'Н25', 10),
	(0, 'Н3', 10)