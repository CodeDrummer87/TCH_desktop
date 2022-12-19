IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb

GO

-- Delete foreign key first

IF OBJECT_ID('Locomotives', 'u') IS NOT NULL
ALTER TABLE Locomotives
ALTER COLUMN Allocation NVARCHAR(50)