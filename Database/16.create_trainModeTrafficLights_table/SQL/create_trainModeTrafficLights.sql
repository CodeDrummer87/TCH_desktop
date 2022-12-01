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
	(1, '�31', 1),
	(1, '�32', 1),
	(1, '�33', 1),
	(1, '�34', 1),
	(1, '�35', 1),
	(1, '�36', 1),
	(1, '�37', 1),
	(1, '�38', 1),
	(1, '�39', 1),
	(1, '�40', 1),
	(1, '�41', 1),
	(1, '�42', 1),
	(1, '�43', 1),
	(1, '�44', 1),
	(1, '�45', 1),
	(1, '�46', 1),
	(1, '�47', 1),
	(1, '�48', 1),
	(1, '�5�', 1),
	(1, '�3�', 1),
	(1, '�7', 1),
	(1, '�8', 1),

	(0, '�31', 1),
	(0, '�32', 1),
	(0, '�33', 1),
	(0, '�34', 1),
	(0, '�35', 1),
	(0, '�36', 1),
	(0, '�37', 1),
	(0, '�38', 1),
	(0, '�39', 1),
	(0, '�40', 1),
	(0, '�41', 1),
	(0, '�42', 1),
	(0, '�43', 1),
	(0, '�44', 1),
	(0, '�45', 1),
	(0, '�46', 1),
	(0, '�47', 1),
	(0, '�48', 1),
	(0, '��4�', 1),
	(0, '��4�', 1),
	(0, '��7', 1),
	(0, '��8', 1)