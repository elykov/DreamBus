create database DreamBusDB;
go
use DreamBusDB;
go
-- Типы автобусов могут быть одним и тем же. 
-- Указаные параметры: Количество мест, количество этажей, ширина и высота автобуса, также ширина и высота сидения.
Create Table BusTypes
(
	Id int not null primary key identity,
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
--alter Table BusModels
--add constraint check_rate check(ComfortFactor < 6)
create Table BusModels
(
	Id int not null primary key identity,
	Brand nvarchar(50) not null,
	BusTypeId int not null foreign key references BusTypes(Id),
	ComfortFactor tinyint not null check(ComfortFactor < 6)
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
	-- add rayon 
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
	MinutesInPath int not null
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

if ((select Count(*) from BusTypes) = 0)
begin
	insert BusTypes values 
	(31, 1, 2500, 9750, 50, 50)
end

if ((select Count(*) from BusSeats) = 0)
begin
	insert BusSeats values
	(1, 10, 0),
	(1, 10, 50),
	(1, 10, 100),
	(1, 10, 150),
	(1, 10, 200),
	(1, 90, 0),
	(1, 90, 50),
	(1, 190, 0),
	(1, 190, 50),
	(1, 190, 150),
	(1, 190, 200),
	(1, 250, 0),
	(1, 250, 50),
	(1, 250, 150),
	(1, 250, 200),
	(1, 320, 0),
	(1, 320, 50),
	(1, 320, 150),
	(1, 320, 200),
	(1, 500, 0),
	(1, 500, 50),
	(1, 500, 150),
	(1, 500, 200),
	(1, 600, 0),
	(1, 600, 50),
	(1, 600, 150),
	(1, 600, 200),
	(1, 650, 0),
	(1, 650, 50),
	(1, 650, 150),
	(1, 650, 200)
end;

if ((select Count(*) from BusModels) = 0)
begin
	insert BusModels values 
	('Bogdan A1445', 1, 2)
end

if ((select Count(*) from Buses) = 0)
begin
	insert Buses values 
	(1, 'AA 0001 KP')
end

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
	('Керчь', 7),
	('Феодосия', 7),
	('Армянск',	7),
	('Красноперекопск',	7),
	('Ишунь', 7),
	('Воронцовка', 7),
	('Ильинка', 7),
	('Правда', 7),
	('Матвеевка', 7),
	('Первомайское', 7),
	('Гришино', 7),
	('Войково', 7),
	('Воронцовка', 7),
	('Трактовое', 7),
	('Гвардейское', 7),
	('Симферополь',	7),
	('Приятное свидание', 7),
	('Тополи', 7),
	('Бахчисарай', 7),
	('Железнодорожное', 7),
	('Верхнесадовое', 7),
	('Поворотное', 7),
	('Инкерман', 7),
	('Севастополь',	7);

insert NeighborCities values
	(7, 11, 25),
	(11, 14, 7),
	(14, 15, 13),
	(15, 16, 8),
	(16, 17, 7),
	(17, 18, 4),
	(18, 19, 3),
	(19, 20, 20),
	(20, 21, 20),
	(21, 23, 25),
	(23, 24, 25),
	(24, 8, 15);

insert Flights values 
	(1), -- Армянск - Красноперекопск (8.00)
	(1) -- Красноперекопск - Армянск (8.30)
	--(), -- Армянск - Симферополь

-- Создание маршрута Армянск - Красноперекопск
insert MediumPathes values  
	(1, 0, 4, '8:00:00')


--create procedure GetNeighborCities
	--as 
	--begin
	--	select nc.Id as Id,  c1.Title StartCity, c2.Title EndCity, MinutesInPath from NeighborCities nc
	--	join Cities c1 on CityId = c1.Id 
	--	join Cities c2 on NeighborId = c2.Id 
	--end

select * from Buses
select * from BusModels
select * from BusTypes
select * from BusSeats

select * from Flights
select * from MediumPathes

/*
 продумать обратные пути в MediumPathes
 Если есть Армянск - Симферополь, по при создании Симферополь - Армянск путь будет тот же, 
 но будет Гвардейское - Симферополь, а нужно Симферополь - Гвардейское.
 Для того чтобы понять куда ехать можно добавить поле НазадЛи (IsReverse)

 В приложении должен быть поиск между городами: есть ли такой набор городов, чтобы либо с одной стороны в другую или с другой.
 */	



--select * from Regions;
--select c.Id, c.Title, r.Title from Cities c
--join Regions r on c.RegionId = r.Id;

