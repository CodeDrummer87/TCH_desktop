﻿IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('Stations', 'u') IS NULL
CREATE TABLE Stations
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL,
	Railroad INT NOT NULL,
	Code NVARCHAR(7) NOT NULL

	FOREIGN KEY (Railroad) REFERENCES Railroads(Id) ON DELETE CASCADE
)

GO

IF OBJECT_ID('Stations', 'u') IS NOT NULL
INSERT INTO Stations
VALUES 
	(N'Входная', 5, '083020'),
	(N'Карбышево-II', 5, '083266'),
	(N'Фадино', 5, '083261'),
	(N'Стрела', 5, '083450'),
	(N'Жатва', 5, '083460'),
	(N'Любовка', 5, '083470'),
	(N'Иртышское', 5, '083500'),
	
	(N'Карбышево I', 5, '083030'),
	(N'Омск-Пассажирский', 5, '083070'),
	(N'Московка', 5, '083000'),
	(N'Сыропятское', 5, '083004'),
	(N'Кормиловка', 5, '083270'),
	(N'Калачинская', 5, '083280'),
	(N'Валерино', 5, '083283'),
	(N'Колония', 5, '083290'),
	(N'Каратканск', 5, '083293'),
	(N'Татарская', 5, '083300'),
	(N'Кабаклы', 5, '083304'),
	(N'Чаны', 5, '083330'),
	(N'Озеро Карачинское', 5, '083346'),
	(N'Тебисская', 5, '083359'),
	(N'Кирзинское', 5, '083355'),
	(N'Барабинск', 5, '083360'),

	(N'Пламя', 5, '083010'),
	(N'Петрушенко', 5, '083051'),
	(N'Любинская', 5, '083180'),
	(N'Драгунская', 5, '083176'),
	(N'Кочковатский', 5, '083164'),
	(N'Называевская', 5, '083160'),
	(N'Восточный (ОП-46)', 12, '079203'),
	(N'Мангут', 12, '079207'),
	(N'Новоандреевский', 12, '079190'),
	(N'Маслянская', 12, '079180'),
	(N'Шаблыкино', 12, '079174'),
	(N'Малый Остров', 12, '079162'),
	(N'Ишим', 12, '079160'),

	(N'Лузино', 5, '083252'),
	(N'Мариановка', 5, '083240'),
	(N'Пикетное', 5, '083230'),
	(N'Москаленки', 5, '083220'),
	(N'Исилькуль', 5, '083200'),
	(N'Кара-Гуга', 16, '082516'),
	(N'Булаево', 16, '082520'),
	(N'Ганькино', 16, '082524'),
	(N'Токуши', 16, '082607'),
	(N'Петропавловск', 16, '082000'),

	(N'Комбинатская', 5, '083150'),
	(N'Омск-Восточный', 5, '083120'),
	(N'Омск-Северный', 5, '083140'),
	(N'Универсальная', 5, '083131'),
	(N'Левобережный (разъезд)', 5, '083141')