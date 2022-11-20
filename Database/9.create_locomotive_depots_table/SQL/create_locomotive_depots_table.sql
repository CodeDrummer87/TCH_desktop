IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'tchDb'))
USE tchDb;

GO

IF OBJECT_ID('LocomotiveDepots', 'u') IS NULL
CREATE TABLE LocomotiveDepots
(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Railroad INT REFERENCES Railroads (Id),
	ShortTitle NVARCHAR(20),
	FullTitle NVARCHAR(100),
	Address NVARCHAR (200),
	Code NCHAR(10)
)

GO

IF OBJECT_ID('LocomotiveDepots', 'u') IS NOT NULL
INSERT INTO LocomotiveDepots
VALUES
	(5, '���-2 ����', '���������������� ������������ ���� ����',
	'������, 644020, �.����-20, ��.�������, �.32', '201'),
	(5, '���-3 ���������', '���������������� ������������ ���� ���������',
	'������, 632335, ������������� �������, �.���������, ��.�������, �.115', '1000'),
	(5, '���-4 �����������', '���������������� ������������ ���� �����������',
	'������, 630068, �.�����������, ��.������������, �.51', '987'),
	(5, '���-7 �������', '���������������� ������������ ���� �������',
	'������, 656015, �.�������, ��.�������������, �.14', '972'),
	(5, '���-10 �������', '���������������� ������������ ���� �������',
	'������, 632863, ������������� �������, �.�������, ��.���������, �.1', ''),
	(5, '���-12 �����', '���������������� ������������ ���� �����',
	'������, 652400, �.�����, ��.��������, �.1', '1127'),
	(5, '���-14 ������', '���������������� ������������ ���� ������',
	'������, 652600, �.������, ��.���������, �.37�', '914'),
	(5, '���-15 �����������', '���������������� ������������ ���� �����������',
	'������, 654004, ����������� �������, �.�����������, ��.375��, �.4�', '1162'),
	(5, '���-19 �����', '���������������� ������������ ���� �����',
	'������, 652080, ����������� �������, �.�����, ��.������������, �.109', '')