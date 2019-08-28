create database DreamBusDB;
go
use DreamBusDB;
go
-- Типы автобусов могут быть одним и тем же. 
-- Указаные параметры: Количество мест, количество этажей, ширина и высота автобуса, также ширина и высота сидения.
Create Table BusTypes
(
	Id int not null primary key identity,
	PlacesCount int not null,
	FloorCount int default 1 not null,
	BusWidth int not null,
	BusHeight int not null,
	SeatWidth int not null,
	SeatHeight int not null
);
go

Create table BusSeats (
	Id int not null primary key identity,
	BusTypeId int not null foreign key references BusTypes(Id),
	XCoord int not null,
	YCoord int not null
);
go
-- К примеру Богдан и Эталон - Одинаково, а производители разные, также качество - удобство (1 - 5 звезд).
Create Table BusModels
(
	Id int not null primary key identity,
	Brand nvarchar(50) not null,
	BusTypeId int not null foreign key references BusTypes(Id),
	ComfortFactor tinyint not null
);
go
--Автобусы - информация об одном автобусе: модель, госномер
create table Buses(
	Id int not null primary key identity,
	BusModelId int not null foreign key references BusModels(Id),
	BusCountryNumber nvarchar(20)
);
go
-- Области
Create Table Regions(
	Id int not null primary key identity,
	Title nvarchar(50) not null 
);
go
-- Города
Create Table Cities(
	Id int not null primary key identity,
	Title nvarchar(50) not null,
	RegionId int not null foreign key references Regions(Id)
);
go

-- Соседние города
Create Table NeighborCities(
	Id int not null primary key identity,
	CityId int not null foreign key references Cities(Id),
	NeighborId int not null foreign key references Cities(Id),
	MinutesInPath int, -- желательно заполнить 
	Distance float --опционально на всякий случай
);
go
-- Рейсы: хранят указатель на автобус
-- начало и конец маршрута,  и время прибытия. Время отправления будет в первом маршруте
Create Table Flights(
	Id int not null primary key identity,
	BusId int not null foreign key references Buses(Id)
	-- Точка отправления, точка прибытия, время отправления и время в конечной брать в MediumPathes.
);
go
/*
	Промежуточные пути рейса.
	Данная таблица хранит промежуточные пути рейса между городами, из которых состоит рейс.
	Пример: Киев - Минск - Москва. Промежуточные пути Киев - Минск (PathNum = 0) и Минск - Москва (PathNum = 1).
*/
Create Table MediumPathes(
	Id int not null primary key identity,
	FlightId int not null foreign key references Flights(Id),
	PathNum int not null, -- Каким по счету будет проходить путь.
	PathId int not null foreign key references NeighborCities(Id),
	DepartureTime Time not null -- время прибытия берется из NeighborCities.MinutesInPath + DepartureTime
);
go

insert Regions values 
	('Киевская область'),
	('Львовская область'),
	('Херсонская область'),
	('Одесская область'),
	('Сумская область'),
	('Николаевская область'),
	('АР Крым'),
	('Винницкая область'),
	('Харьковская область'),
	('Днепровская область'),
	('Запорожская область'),
	('Ужгородская область');

insert Cities values
	('Киев', 1),
	('Львов', 2),
	('Херсон', 3),
	('Одесса', 4),
	('Сумы', 5),
	('Николаев', 6),
	('Армянск',	7),
	('Симферополь',	7),
	('Севастополь',	7);

	select * from Regions
	select * from Cities
	select * from NeighborCities

