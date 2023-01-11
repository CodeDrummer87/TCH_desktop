IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('ColumnSpecializations', 'u') IS NULL
CREATE TABLE ColumnSpecializations
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name NVARCHAR(25)
)

GO

IF OBJECT_ID('ColumnSpecializations', 'u') IS NOT NULL
INSERT INTO ColumnSpecializations
VALUES
	(N'Грузовая колонна'),
	(N'Пассажирская колонна'),
	(N'Маневровая колонна'),
	(N'Хозяйственная колонна'),
	(N'Передаточная колонна'),
	(N'Экипировочная колонна')
