IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('BrakeTests', 'u') IS NULL
CREATE TABLE BrakeTests
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Depot INT REFERENCES LocomotiveDepots (Id) NOT NULL,
	IsEvenNumberedDirection TINYINT DEFAULT 1,
	RailwayLine NVARCHAR(50) NOT NULL,
	RequiredSpeed NCHAR(4) NOT NULL,
	Point NCHAR(10) NOT NULL,
	RequiredSpeedForDoubleTrain NCHAR(4) NOT NULL,
	PointForDoubleTrain NCHAR(10) NOT NULL
)

GO

IF OBJECT_ID('BrakeTests', 'u') IS NOT NULL
INSERT INTO BrakeTests
VALUES 
	(1, 1, 'Петропавловск - Токуши', '70', '2638.2', '60', '2638.2'),
	(1, 1, 'Токуши - Ганькино', '60', '2679.6', '60', '2679.6'),
	(1, 1, 'Ганькино - Булаево', '60', '2693.5', '60', '2693.5'),
	(1, 1, 'Булаево - Кара-Гуга', '60', '2714.6', '60', '2714.6'),
	(1, 1, 'Кара-Гуга - Исилькуль', '60', '2740.4', '60', '2740.4'),
	(1, 1, 'Исилькуль - Москаленки', '60', '2774.1', '60', '2773.10'),
	(1, 1, 'Москаленки - Пикетное', '60', '2809.1', '60', '2809.5'),
	(1, 1, 'Пикетное - Мариановка', '60', '2839.1', '60', '2839.4'),
	(1, 1, 'Мариановка - Лузино', '60', '2868.2', '60', '2861.3'),
	(1, 1, 'Лузино - Входная', '-', '-', '-', '-'),
	(1, 1, 'Входная - Карбышево-I', '-', '-', '-', '-'),
	(1, 1, 'Карбышево-I - Московка', '-', '-', '-', '-'),
	(1, 1, 'Карбышево-I - Омск-Пассажирский', '-', '-', '-', '-'),
	(1, 1, 'Омск-Пассажирский - Московка', '-', '-', '-', '-'),

	(1, 1, 'Ишим - Малый Остров', '60', '2434.1', '-', '-'),
	(1, 1, 'Малый Остров - Шаблыкино', '-', '-', '-', '-'),
	(1, 1, 'Шаблыкино - Маслянская', '60', '2456.5', '60', '2456.5'),
	(1, 1, 'Маслянская - Новоандреевский', '60', '2480.1', '60', '2480.1'),
	(1, 1, 'Новоандреевский - Мангут', '60', '2500.5', '60', '2500.5'),
	(1, 1, 'Мангут - Восточный (ОП-46)', '60', '2522.9', '60', '2522.9'),
	(1, 1, 'Восточный (ОП-46) - Называевская', '60', '2545.5', '60', '2545.5'),
	(1, 1, 'Называевская - Кочковатский', '60', '2574.1', '60', '2574.1'),
	(1, 1, 'Кочковатский - Драгунская', '60', '2599.1', '60', '2599.1'),
	(1, 1, 'Драгунская - Любинская', '60', '2622.1', '60', '2622.1'),
	(1, 1, 'Любинская - Петрушенко', '60', '2673.1', '60', '2673.1'),
	(1, 1, 'Петрушенко - Входная', '-', '-', '-', '-'),
	(1, 1, 'Петрушенко - Входная', '60', '2689.1', '60', '2689.1'),
	(1, 1, 'Пламя - Карбышево I', '60', '2699.1', '60', '2699.1'),

	(1, 1, 'Московка - Сыропятское', '70', '2730.1', '60', '2735.1'),
	(1, 1, 'Сыропятское - Кормиловка', '60', '2753.3', '60', '2752.1'),
	(1, 1, 'Кормиловка - Калачинская', '60', '2778.1', '60', '2769.1'),
	(1, 1, 'Калачинская - Валерино', '60', '2797.1', '60', '2800.1'),
	(1, 1, 'Валерино - Колония', '60', '2817.1', '60', '2822.1'),
	(1, 1, 'Колония - Каратканск', '60', '2845.1', '60', '2847.1'),
	(1, 1, 'Каратканск - Татарская', '60', '2869.1', '60', '2872.1'),
	(1, 1, 'Татарская - Кабаклы', '60', '2894.1', '60', '2896.1'),
	(1, 1, 'Кабаклы - Чаны', '60', '2922.1', '-', '-'),
	(1, 1, 'Чаны - Озеро Карачинское', '60', '2939.5', '60', '2938.1'),
	(1, 1, 'Озеро Карачинское - Тебисская', '60', '2964.1', '60', '2964.1'),
	(1, 1, 'Тебисская - Кирзинская', '60', '3000.9', '60', '3001.1'),
	(1, 1, 'Кирзинская - Барабинск', '60', '3026.9', '60', '3027.1'),

	(1, 1, 'Входная - Карбышево-II', '-', '-', '-', '-'),
	(1, 1, 'Карбышево-II - Фадино', '70', '16.9', '70', '17.1'),
	(1, 1, 'Фадино - Стрела', '60', '30.1', '60', '45.1'),
	(1, 1, 'Стрела - Жатва', '60', '63.1', '60', '66.1'),
	(1, 1, 'Жатва - Любовка', '60', '97.1', '60', '109.1'),
	(1, 1, 'Любовка - Иртышское', '60', '129.1', '60', '132.1'),
	(1, 1, 'Карбышево-II - Карбышево-I', '-', '-', '-', '-'),

	(1, 0, 'Московка - Карбышево-I', '50', '8.1', '50', '8.1'),
	(1, 0, 'Московка - Омск-Пассажирский', '50', '2716.1', '-', '-'),
	(1, 0, 'Омск-Пассажирский - Карбышево-I', '-', '-', '-', '-'),
	(1, 0, 'Карбышево-I - Входная', '-', '-', '-', '-'),
	(1, 0, 'Входная - Лузино', '-', '-', '-', '-'),
	(1, 0, 'Лузино - Мариановка', '60', '2869.1', '60', '2865.1'),
	(1, 0, 'Мариановка - Пикетное', '60', '2865.1', '60', '2835.5'),
	(1, 0, 'Пикетное - Москаленки', '60', '2820.6', '60', '2820.6'),
	(1, 0, 'Москаленки - Исилькуль', '60', '2798.5', '60', '2798.7'),
	(1, 0, 'Исилькуль - Кара-Гуга', '60', '2752.10', '60', '2752.10'),
	(1, 0, 'Кара-Гуга - Булаево', '60', '2714.4', '60', '2714.4'),
	(1, 0, 'Булаево - Ганькино', '60', '2702.1', '60', '2702.1'),
	(1, 0, 'Ганькино - Токуши', '60', '2680.3', '60', '2680.3'),
	(1, 0, 'Токуши - Петропавловск', '60', '2638.8', '60', '2638.8'),

	(1, 0, 'Московка - Карбышево-I (обвод)', '50', '8.1', '60', '8.1'),
	(1, 0, 'Московка - Омск-Пассажирский', '50', '2716.1', '-', '-'),
	(1, 0, 'Карбышево-I - Пламя', '60', '2698.1', '60', '2698.1'),
	(1, 0, 'Пламя - Петрушенко', '60', '2688.8', '60', '2688.8'),
	(1, 0, 'Входная - Петрушенко', '50', '7.9', '50', '8.1'),
	(1, 0, 'Петрушенко - Любинская', '60', '2672.1', '60', '2672.1'),
	(1, 0, 'Любинская - Драгунская', '60', '2647.1', '60', '2647.1'),
	(1, 0, 'Драгунская - Кочковатский', '60', '2600.1', '60', '2600.1'),
	(1, 0, 'Кочковатский - Называевская', '60', '2574.1', '60', '2574.1'),
	(1, 0, 'Называевская - Восточный (ОП-46)', '50', '2545.5', '50', '2545.5'),
	(1, 0, 'Восточный (ОП-46) - Мангут', '50', '2534.5', '50', '2534.5'),
	(1, 0, 'Мангут - Новоандреевский', '50', '2511.5', '50', '2511.5'),
	(1, 0, 'Новоандреевский - Маслянская', '50', '2491.5', '50', '2491.5'),
	(1, 0, 'Маслянская - Шаблыкино', '50', '2470.5', '50', '2470.5'),
	(1, 0, 'Шаблыкино - Малый Остров', '50', '2448.5', '50', '2448.5'),
	(1, 0, 'Малый Остров - Ишим', '50', '2438.5', '50', '2438.5'),

	(1, 0, 'Барабинск - Кирзинская', '60', '3023.9', '60', '3024.1'),
	(1, 0, 'Кирзинская - Тебисская', '60', '2998.1', '60', '2983.1'),
	(1, 0, 'Тебисская - Озеро Карачинское', '60', '2966.1', '60', '2966.1'),
	(1, 0, 'Озеро Карачинское - Чаны', '60', '2936.1', '60', '2936.1'),
	(1, 0, 'Чаны - Кабаклы', '60', '2916.1', '60', '2909.1'),
	(1, 0, 'Кабаклы - Татарская', '60', '2892.1', '60', '2894.1'),
	(1, 0, 'Татарская - Каратканск', '60', '2869.1', '60', '2870.1'),
	(1, 0, 'Каратканск - Колония', '60', '2849.1', '60', '2837.1'),
	(1, 0, 'Колония - Валерино', '60', '2817.1', '60', '2809.1'),
	(1, 0, 'Валерино - Калачинская', '60', '2797.1', '60', '2795.1'),
	(1, 0, 'Калачинская - Кормиловка', '60', '2768.1', '60', '2768.5'),
	(1, 0, 'Кормиловка - Сыропятское', '60', '2747.1', '60', '2746.1'),
	(1, 0, 'Сыропятское - Московка', '60', '2725.9', '60', '2726.1'),

	(1, 0, 'Иртышское - Любовка', '70', '151.9', '70', '152.1'),
	(1, 0, 'Любовка - Жатва', '60', '114.1', '60', '109.1'),
	(1, 0, 'Жатва - Стрела', '60', '83.1', '60', '82.1'),
	(1, 0, 'Стрела - Фадино', '60', '49.1', '60', '35.1'),
	(1, 0, 'Фадино - Карбышево-II', '60', '16.1', '60', '15.1'),
	(1, 0, 'Карбышево-II - Входная', '-', '-', '-', '-'),
	(1, 0, 'Карбышево-II - Карбышево-I', '-', '-', '-', '-')