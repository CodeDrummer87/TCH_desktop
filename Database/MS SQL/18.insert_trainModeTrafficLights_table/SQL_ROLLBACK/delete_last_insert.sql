IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID(N'TrainModeTrafficLights', 'u') IS NULL
DELETE FROM TrainModeTrafficLights WHERE Id>730