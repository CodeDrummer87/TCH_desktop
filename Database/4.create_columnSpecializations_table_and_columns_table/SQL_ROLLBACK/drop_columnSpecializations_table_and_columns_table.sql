IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('Columns', 'u') IS NOT NULL
DROP TABLE Columns

GO

IF OBJECT_ID('ColumnSpecializations', 'u') IS NOT NULL
DROP TABLE ColumnSpecializations