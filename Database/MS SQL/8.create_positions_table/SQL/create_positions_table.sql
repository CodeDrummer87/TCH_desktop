IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('Positions', 'u') IS NULL
CREATE TABLE Positions
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	FullName NVARCHAR(30),
	Abbreviate NVARCHAR(20)
)

GO

INSERT INTO Positions
VALUES
	(N'Помощник машиниста', 'ТЧПМ'),
	(N'Машинист', 'ТЧМ'),
	(N'Машинист-инструктор', 'ТЧМИ')