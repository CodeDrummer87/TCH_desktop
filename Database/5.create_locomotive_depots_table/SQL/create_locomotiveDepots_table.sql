IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('LocomotiveDepots', 'u') IS NULL
CREATE TABLE LocomotiveDepots
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Railroad INT REFERENCES Railroads (Id),
	ShortTitle NVARCHAR(30),
	FullTitle NVARCHAR(100),
	Address NVARCHAR (200),
	Code NCHAR(10)
)

GO

IF OBJECT_ID('LocomotiveDepots', 'u') IS NOT NULL
INSERT INTO LocomotiveDepots
VALUES
	(5, 'ТЧЭ-2 Омск', 'Эксплуатационное локомотивное депо Омск',
	'Россия, 644020, г.Омск-20, ул.Леконта, д.32', '201'),
	(5, 'ТЧЭ-3 Барабинск', 'Эксплуатационное локомотивное депо Барабинск',
	'Россия, 632335, Новосибирская область, г.Барабинск, ул.Путевая, д.115', '1000'),
	(5, 'ТЧЭ-4 Новосибирск', 'Эксплуатационное локомотивное депо Новосибирск',
	'Россия, 630068, г.Новосибирск, ул.Подбельского, д.51', '987'),
	(5, 'ТЧЭ-7 Барнаул', 'Эксплуатационное локомотивное депо Барнаул',
	'Россия, 656015, г.Барнаул, ул.Привокзальная, д.14', '972'),
	(5, 'ТЧЭ-10 Карасук', 'Эксплуатационное локомотивное депо Карасук',
	'Россия, 632863, Новосибирская область, г.Карасук, ул.Деповская, д.1', ''),
	(5, 'ТЧЭ-12 Тайга', 'Эксплуатационное локомотивное депо Тайга',
	'Россия, 652400, г.Тайга, ул.Никитина, д.1', '1127'),
	(5, 'ТЧЭ-14 Белово', 'Эксплуатационное локомотивное депо Белово',
	'Россия, 652600, г.Белово, ул.Каховская, д.37Б', '914'),
	(5, 'ТЧЭ-15 Новокузнецк', 'Эксплуатационное локомотивное депо Новокузнецк',
	'Россия, 654004, Кемеровская область, г.Новокузнецк, ул.375км, д.4а', '1162'),
	(5, 'ТЧЭ-19 Топки', 'Эксплуатационное локомотивное депо Топки',
	'Россия, 652080, Кемеровская область, г.Топки, ул.Пролетарская, д.109', ''),

	(16, 'ТЧЭ-1 Златоуст', 'Эксплуатационное локомотивное депо Златоуст',
	'Россия, 456205, Челябинская область, г.Златоуст, ул.Павла Аносова, д.188а', ''),
	(16, 'ТЧЭ-2 Челябинск', 'Эксплуатационное локомотивное депо Челябинск',
	'Россия, 454091, г.Челябинск, ул.Красноармейская, д.101', ''),
	(16, 'ТЧЭ-3 Курган', 'Эксплуатационное локомотивное депо Курган',
	'Россия, 640004, г.Курган, ул.Омская, д.3', ''),
	(16, 'ТЧЭ-4 Троицк', 'Эксплуатационное локомотивное депо Троицк',
	'Россия, 457100, Челябинская область, г.Троицк, ул.Кирова, д.43', ''),
	(16, 'ТЧЭ-5 Карталы', 'Эксплуатационное локомотивное депо Карталы', 
	'Россия, 457353, Челябинская область, г.Карталы, ул.Станционная, д.2', ''),
	(16, 'ТЧ-12 Петропавловск', 'Локомотивное депо Петропавловск',
	'Казахстан, Северо-Казахстанская область, г.Петропавловск, ул.Ахременко, д.81', ''),
	(16, 'ТЧЭ-13 Бузулук', 'Эксплуатационное локомотивное депо Бузулук',
	'Россия, 461047, Оренбургская область, г.Бузулук, ул.1-я Аллея, д.8', ''),
	(16, 'ТЧЭ-14 Оренбург', 'Эксплуатационное локомотивное депо Оренбург',
	'Россия, 460009, Оренбургская область, г.Оренбург, ул.Мебельная, д.1а', ''),
	(16, 'ТЧЭ-16 Орск', 'Эксплуатационное локомотивное депо Орск',
	'Россия, 462423, Оренбургская область, г.Орск, ул.Узловая, д.2', ''),

	(12, 'ТЧЭ-1 Смычка', 'Эксплуатационное локомотивное депо Смычка',
	'Россия, 622021, Свердловская область, г.Нижний Тагил, ст.Смычка, Локомотивное Депо', ''),
	(12, 'ТЧЭ-5 Свердловск-сорт.', 'Эксплуатационное локомотивное депо Свердловск-Сортировочный',
	'Россия, 620050, г.Екатеринбург, ул.Электродепо, д.3/1', ''),
	(12, 'ТЧЭ-6 Свердловск-пасс.', 'Эксплуатационное локомотивное депо Свердловск-Пассажирский',
	'Россия, 620107, г.Екатеринбург, ул.Вокзальная, д.6', ''),
	(12, 'ТЧЭ-7 Войновка', 'Эксплуатационное локомотивное депо Войновка',
	'Россия, 625000, г.Тюмень, ул.Привокзальная, д.3', ''),
	(12, 'ТЧЭ-8 Ишим', 'Эксплуатационное локомотивное депо Ишим',
	'Россия, 627750, Тюменская область, г.Ишим, ул.Деповская, д.17', ''),
	(12, 'ТЧЭ-12 Серов-сорт.', 'Эксплуатационное локомотивное депо Серов-Сортировочный',
	'Россия, 620000, Свердловская область, г.Серов, пос.Сортировка, Локомотивное Депо', ''),
	(12, 'ТЧЭ-13 Егоршино', 'Эксплуатационное локомотивное депо Егоршино',
	'Россия, 623782, Свердловская область, г.Артёмовский, ул.Октябрьская, д.1', ''),
	(12, 'ТЧЭ-15 Каменск-Уральский', 'Эксплуатационное локомотивное депо Каменск-Уральский',
	'Россия, 623400, Свердловская область, г.Каменск-Уральский, ул.Привокзальная, д.1', ''),
	(12, 'ТЧЭ-17 Пермь-сорт.', 'Эксплуатационное локомотивное депо Пермь-Сортировочная',
	'Россия, 614031, Пермский край, г.Пермь, ул.Транспортная, д.44', ''),
	(12, 'ТЧЭ-18 Сургут', 'Эксплуатационное локомотивное депо Сургут',
	'Россия, 628414, Ханты-Мансийский автономный округ, г.Сургут, ул.Привокзальная, д.25', ''),
	(12, 'ТЧЭ-19 Камышлов', 'Эксплуатационное локомотивное депо Камышлов',
	'Россия, 624860, Свердловская область, г.Камышлов, ул.Свердлова, д.48', ''),
	
	(8, 'ТЧЭ-3 Пенза', 'Эксплуатационное локомотивное депо Пенза',
	'Россия, 440009, г.Пенза, ул.Тухачевского, д.63', ''),
	(8, 'ТЧЭ-5 Рузаевка', 'Эксплуатационное локомотивное депо Рузаевка',
	'Россия, 431440, республика Мордовия, г.Рузаевка, ул.Станционная, д.2', ''),
	(8, 'ТЧЭ-9 Октябрьск', 'Эксплуатационное локомотивное депо Октябрьск',
	'Россия, 445240, Самарская, область, г.Октябрьск, ул.Ленинградская, д.5', ''),
	(8, 'ТЧЭ-10 Самара', 'Эксплуатационное локомотивное депо Самара',
	'Россия, 443036, г.Самара, ул.Нижнехлебная, д.13', ''),
	(8, 'ТЧЭ-12 Кинель', 'Эксплуатационное локомотивное депо Кинель',
	'Россия, 446433, Самарская область, г.Кинель, ул.Советская ж/д, д.86/Б', ''),
	(8, 'ТЧЭ-14 Ульяновск', 'Эксплуатационное локомотивное депо Ульяновск',
	'Россия, 432009, г.Ульяновск, ул.Железнодорожная, д.48', ''),
	(8, 'ТЧЭ-16 Бугульма', 'Эксплуатационное локомотивное депо Бугульма',
	'Россия, 423239, республика Татарстан, г.Бугульма, ул.Локомотивная, д.1', ''),
	(8, 'ТЧЭ-19 Уфа', 'Эксплуатационное локомотивное депо Уфа',
	'Россия, 450024, республика Башкортостан, г.Уфа, площадь Деповская, д.12', ''),
	(8, 'ТЧЭ-20 Стерлитамак', 'Эксплуатационное локомотивное депо Стерлитамак',
	'Россия, 453107, республика Башкортостан, г.Стерлитамак, ул.Деповская, д.1', '')
