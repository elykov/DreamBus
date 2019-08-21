create database DreamBusDB;
go
use DreamBusDB;
go
-- ���� ��������� ����� ���� ����� � ��� ��
Create Table BusTypes
(
	Id int not null primary key identity,
	PlacesCount int not null,
	BusStruct text not null
);
-- BusStruct text - JSON, ����� �������� �������
go
-- � ������� ������ � ������ - ���������, � ������������� ������, ����� �������� - �������� (1 - 5 �����).
Create Table BusModels
(
	Id int not null primary key identity,
	Brand nvarchar(50) not null,
	BusTypeId int not null foreign key references BusTypes(Id),
	ComfortFactor tinyint not null
);
go
--�������� - ���������� �� ����� ��������: ������, ��������
create table Buses(
	Id int not null primary key identity,
	BusModelId int not null foreign key references BusModels(Id),
	BusCountryNumber nvarchar(20)
);
go
-- �������
Create Table Regions(
	Id int not null primary key identity,
	Title nvarchar(50) not null 
)
go
-- ������
Create Table Cities(
	Id int not null primary key identity,
	Title nvarchar(50) not null,
	RegionId int not null foreign key references Regions(Id)
)
go

-- �������� ������
Create Table NeighborCities(
	Id int not null primary key identity,
	CityId int not null foreign key references Cities(Id),
	NeighborId int not null foreign key references Cities(Id),
	TimeInPath time not null,
	Distance float --����������� �� ������ ������
);
go
-- �����: ������ ��������� �� �������
-- ������ � ����� ��������,  � ����� ��������. ����� ����������� ����� � ������ ��������
Create Table Flights(
	Id int not null primary key identity,
	BusId int not null foreign key references Buses(Id),
	-- ����� �����������, ����� ��������, ����� ����������� � ����� � �������� ����� � MediumPathes.
)
go
/*
	������������� ���� �����.
	������ ������� ������ ������������� ���� ����� ����� ��������, �� ������� ������� ����.
	������: ���� - ����� - ������. ������������� ���� ���� - ����� (PathNum = 0) � ����� - ������ (PathNum = 1).
*/
Create Table MediumPathes(
	Id int not null primary key identity,
	FlightId int not null foreign key references Flights(Id),
	PathNum int not null, -- ����� �� ����� ����� ��������� ����.
	PathId int not null foreign key references NeighborCities(Id)
	-- DepartureTime Time not null
);
go;

insert Regions values 
	('�������� �������'),
	('��������� �������'),
	('���������� �������'),
	('�������� �������'),
	('������� �������'),
	('������������ �������'),
	('�� ����');
go;

insert Cities values
	('����', 1),
	('�����', 2),
	('������', 3),
	('������', 4),
	('����', 5),
	('��������', 6);
go;


