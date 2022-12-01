IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('TrainModeTrafficLights', 'u') IS NULL
CREATE TABLE TrainModeTrafficLights
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	IsEvenDirection TINYINT,
	Title NVARCHAR(10) NOT NULL,
	Station INT REFERENCES Stations (Id)
)

GO

IF OBJECT_ID('TrainModeTrafficLights', 'u') IS NOT NULL
INSERT INTO TrainModeTrafficLights
VALUES
	(1, 'в31', 1),
	(1, 'в32', 1),
	(1, 'в33', 1),
	(1, 'в34', 1),
	(1, 'в35', 1),
	(1, 'в36', 1),
	(1, 'в37', 1),
	(1, 'в38', 1),
	(1, 'в39', 1),
	(1, 'в40', 1),
	(1, 'в41', 1),
	(1, 'в42', 1),
	(1, 'в43', 1),
	(1, 'в44', 1),
	(1, 'в45', 1),
	(1, 'в46', 1),
	(1, 'в47', 1),
	(1, 'в48', 1),
	(1, 'в5ю', 1),
	(1, 'в3а', 1),
	(1, 'в7', 1),
	(1, 'в8', 1),

	(0, 'м31', 1),
	(0, 'м32', 1),
	(0, 'м33', 1),
	(0, 'м34', 1),
	(0, 'м35', 1),
	(0, 'м36', 1),
	(0, 'м37', 1),
	(0, 'м38', 1),
	(0, 'м39', 1),
	(0, 'м40', 1),
	(0, 'м41', 1),
	(0, 'м42', 1),
	(0, 'м43', 1),
	(0, 'м44', 1),
	(0, 'м45', 1),
	(0, 'м46', 1),
	(0, 'м47', 1),
	(0, 'м48', 1),
	(0, 'мл4д', 1),
	(0, 'мл4ц', 1),
	(0, 'мл7', 1),
	(0, 'мл8', 1)