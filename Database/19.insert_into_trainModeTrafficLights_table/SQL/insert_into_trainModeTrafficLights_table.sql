﻿IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('TrainModeTrafficLights', 'u') IS NOT NULL
INSERT INTO TrainModeTrafficLights
VALUES 
	(1, 'Ч', 11),
	(1, 'ЧД', 11),
	(1, 'Ч1', 11),
	(1, 'Ч2', 11),
	(1, 'Ч3', 11),
	(1, 'Ч4', 11),
	(1, 'Ч6', 11),

	(0, 'Н', 11),
	(0, 'НД', 11),
	(0, 'Н1', 11),
	(0, 'Н2', 11),
	(0, 'Н3', 11),
	(0, 'Н4', 11),
	(0, 'Н6', 11),

	(1, 'Ч', 12),
	(1, 'ЧД', 12),
	(1, 'Ч1', 12),
	(1, 'Ч2', 12),
	(1, 'Ч3', 12),
	(1, 'Ч4', 12),
	(1, 'Ч5', 12),

	(0, 'Н', 12),
	(0, 'НД', 12),
	(0, 'Н1', 12),
	(0, 'Н2', 12),
	(0, 'Н3', 12),
	(0, 'Н4', 12),
	(0, 'Н5', 12),

	(1, 'Ч', 13),
	(1, 'ЧД', 13),
	(1, 'Ч1', 13),
	(1, 'Ч2', 13),
	(1, 'Ч3', 13),
	(1, 'Ч4', 13),
	(1, 'Ч6', 13),
	(1, 'Ч10', 13),

	(0, 'Н', 13),
	(0, 'НД', 13),
	(0, 'Н1', 13),
	(0, 'Н2', 13),
	(0, 'Н3', 13),
	(0, 'Н4', 13),
	(0, 'Н6', 13),
	(0, 'Н10', 13),

	(1, 'Ч', 14),
	(1, 'ЧД', 14),
	(1, 'Ч1', 14),
	(1, 'Ч2', 14),
	(1, 'Ч3', 14),
	(1, 'Ч4', 14),

	(0, 'Н', 14),
	(0, 'НД', 14),
	(0, 'Н1', 14),
	(0, 'Н2', 14),
	(0, 'Н3', 14),
	(0, 'Н4', 14),

	(1, 'Ч', 15),
	(1, 'ЧД', 15),
	(1, 'Ч1', 15),
	(1, 'Ч2', 15),
	(1, 'Ч4', 15),
	(1, 'Ч5', 15),

	(0, 'Н', 15),
	(0, 'НД', 15),
	(0, 'Н1', 15),
	(0, 'Н2', 15),
	(0, 'Н4', 15),
	(0, 'Н5', 15),

	(1, 'Ч', 16),
	(1, 'ЧД', 16),
	(1, 'Ч1', 16),
	(1, 'Ч2', 16),
	(1, 'Ч3', 16),
	(1, 'Ч4', 16),

	(0, 'Н', 16),
	(0, 'НД', 16),
	(0, 'Н1', 16),
	(0, 'Н2', 16),
	(0, 'Н3', 16),
	(0, 'Н4', 16),

	(1, 'Ч', 17),
	(1, 'ЧД', 17),
	(1, 'ЧО', 17),
	(1, 'ЧМ1З', 17),
	(1, 'ЧМ2З', 17),
	(1, 'ЧМ3З', 17),
	(1, 'ЧМ4З', 17),
	(1, 'Ч1', 17),
	(1, 'Ч2', 17),
	(1, 'Ч3', 17),
	(1, 'Ч4', 17),
	(1, 'Ч5', 17),
	(1, 'Ч6', 17),
	(1, 'Ч7', 17),
	(1, 'Ч8', 17),
	(1, 'Ч9', 17),
	(1, 'Ч10', 17),

	(0, 'Н', 17),
	(0, 'НД', 17),
	(0, 'НС', 17),
	(0, 'НМ1', 17),
	(0, 'НМ2', 17),
	(0, 'НМ3', 17),
	(0, 'НМ4', 17),
	(0, 'НМ5', 17),
	(0, 'НМ6', 17),
	(0, 'НМ7', 17),
	(0, 'НМ8', 17),
	(0, 'НМ9', 17),
	(0, 'НМ10', 17),
	(0, 'Н1З', 17),
	(0, 'Н2З', 17),
	(0, 'Н3З', 17),
	(0, 'Н4З', 17),
	(0, 'НО', 17),

	(1, 'Ч', 18),
	(1, 'ЧД', 18),
	(1, 'Ч1', 18),
	(1, 'Ч2', 18),
	(1, 'Ч3', 18),
	(1, 'Ч4', 18),
	(1, 'Ч6', 18),

	(0, 'Н', 18),
	(0, 'Д', 18),
	(0, 'Н1', 18),
	(0, 'Н2', 18),
	(0, 'Н3', 18),
	(0, 'Н4', 18),
	(0, 'Н6', 18),

	(1, 'Ч', 19),
	(1, 'ЧД', 19),
	(1, 'Ч1', 19),
	(1, 'Ч2', 19),
	(1, 'Ч4', 19),
	(1, 'Ч5', 19),
	(1, 'Ч6', 19),

	(0, 'Н', 19),
	(0, 'НД', 19),
	(0, 'H1', 19),
	(0, 'H2', 19),
	(0, 'H4', 19),
	(0, 'H5', 19),

	(1, 'Ч', 20),
	(1, 'ЧД', 20),
	(1, 'Ч1', 20),
	(1, 'Ч2', 20),
	(1, 'Ч3', 20),
	(1, 'Ч4', 20),

	(0, 'Н', 20),
	(0, 'НД', 20),
	(0, 'Н1', 20),
	(0, 'Н2', 20),
	(0, 'Н3', 20),
	(0, 'Н4', 20),

	(1, 'Ч', 21),
	(1, 'ЧД', 21),
	(1, 'Ч1', 21),
	(1, 'Ч2', 21),
	(1, 'Ч3', 21),
	(1, 'Ч4', 21),

	(0, 'Н', 21),
	(0, 'НД', 21),
	(0, 'Н1', 21),
	(0, 'Н2', 21),
	(0, 'Н3', 21),
	(0, 'Н4', 21),

	(1, 'Ч', 22),
	(1, 'ЧД', 22),
	(1, 'Ч1', 22),
	(1, 'Ч2', 22),
	(1, 'Ч3', 22),
	(1, 'Ч4', 22),

	(0, 'Н', 22),
	(0, 'НД', 22),
	(0, 'Н1', 22),
	(0, 'Н2', 22),
	(0, 'Н3', 22),
	(0, 'Н4', 22),

	(1, 'Ч', 23),
	(1, 'ЧД', 23),
	(1, 'ЧМ', 23),
	(1, 'ЧМ1Г', 23),
	(1, 'ЧМ1', 23),
	(1, 'ЧМ1А', 23),
	(1, 'ЧМ2А', 23),
	(1, 'ЧМ3', 23),
	(1, 'ЧМ4', 23),
	(1, 'ЧМ5', 23),
	(1, 'ЧМ6', 23),
	(1, 'ЧМ8', 23),
	(1, 'ЧМ9', 23),
	(1, 'ЧМ10', 23),
	(1, 'ЧМ11', 23),
	(1, 'ЧМ12', 23),
	(1, 'ЧМ4З', 23),
	(1, 'Ч1', 23),
	(1, 'Ч2', 23),
	(1, 'Ч1В', 23),
	(1, 'Ч2В', 23),
	(1, 'Ч3В', 23),
	(1, 'Ч4В', 23),
	(1, 'Ч5В', 23),
	(1, 'Ч6В', 23),
	(1, 'Ч7В', 23),
	(1, 'Ч8В', 23),
	(1, 'Ч9В', 23),
	(1, 'Ч10В', 23),
	(1, 'Ч11В', 23),
	(1, 'ЧМ27', 23),


	(0, 'Н', 23),
	(0, 'НД', 23),
	(0, 'НО', 23),
	(0, 'Н1', 23),
	(0, 'Н2', 23),
	(0, 'Н2З', 23),
	(0, 'Н3З', 23),
	(0, 'Н4З', 23),
	(0, 'НМ1', 23),
	(0, 'НМ1А', 23),
	(0, 'НМ2А', 23),
	(0, 'НМ3', 23),
	(0, 'НМ5', 23),
	(0, 'НМ6', 23),
	(0, 'НМ8', 23),
	(0, 'НМ9', 23),
	(0, 'НМ10', 23),
	(0, 'НМ11', 23),
	(0, 'НМ12', 23),
	(0, 'НМ', 23),
	(0, 'НМ1Г', 23)