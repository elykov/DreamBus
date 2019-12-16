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
	YCoord int not null,
	SeatNumber tinyint not null
);
go
ALTER TABLE BusSeats ADD DEFAULT 0 FOR SeatNumber;
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
-- начало и конец маршрута,  и время прибытия. 
Create Table Flights(
	Id int not null primary key identity,
	BusId int not null foreign key references Buses(Id),
	DepartureTime Time not null, -- Время отправления. Время прибытия берется из NeighborCities.MinutesInPath + DepartureTime
	IsReverse bit default 0 -- Если 1, то не Армянск - Симферополь, а Симферополь - Армянск
	-- Точка отправления, точка прибытия и время в конечной брать в MediumPathes.
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
	PathId int not null foreign key references NeighborCities(Id)
);
go
Create Table Users(
	Id int primary key identity,
	[Name] nvarchar(50) not null,
	[Password] nvarchar(50) not null,
	[Email] nvarchar(50),
	[PhoneNumber] nvarchar(15)
);
go
-- Билеты: Хранит покупателя, цену, рейс, дату, города начала и конца пути и место в автобусе.
Create Table Tickets(
	Id int not null primary key identity,
	UserId int not null foreign key references Users(Id),
	Price money not null,
	FlightId int not null foreign key references Flights(Id),
	[Date] Date not null,
	StartCityId int not null foreign key references MediumPathes(Id),
	EndCityId int not null foreign key references MediumPathes(Id),
	FinishTime DateTime not null,
	Place int not null,
	IsActive bit default 1 -- Если 0 - история
);
go

if ((select Count(*) from BusTypes) = 0)
begin
	insert BusTypes (FloorCount, BusWidth, BusHeight, SeatWidth, SeatHeight) values 
	(1, 2500, 9750, 50, 50)
end

if ((select Count(*) from BusSeats) = 0)
begin
	insert BusSeats values
	(1, 10, 0, 1),
	(1, 10, 50, 2),
	(1, 10, 100, 3),
	(1, 10, 150, 4),
	(1, 10, 200, 5),
	(1, 90, 0, 5),
	(1, 90, 50, 6),
	(1, 190, 0, 7),
	(1, 190, 50, 8),
	(1, 190, 150, 9),
	(1, 190, 200, 10),
	(1, 250, 0, 11),
	(1, 250, 50, 12),
	(1, 250, 150, 13),
	(1, 250, 200, 14),
	(1, 320, 0, 15),
	(1, 320, 50, 16),
	(1, 320, 150, 17),
	(1, 320, 200, 18),
	(1, 500, 0, 19),
	(1, 500, 50, 20),
	(1, 500, 150, 21),
	(1, 500, 200, 22),
	(1, 600, 0, 23),
	(1, 600, 50, 24),
	(1, 600, 150, 25),
	(1, 600, 200, 26),
	(1, 650, 0, 27),
	(1, 650, 50, 28),
	(1, 650, 150, 29),
	(1, 650, 200, 30)
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

if ((select Count(*) from Regions) = 0)
begin
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
end

if ((select Count(*) from Cities) = 0)
begin
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
end

if ((select Count(*) from NeighborCities) = 0)
begin
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
end

if ((select Count(*) from Flights) = 0)
begin
	insert Flights values 
		(1, '8:00:00', 0), -- Армянск - Красноперекопск (8.00)
		(1, '8:30:00', 1) -- Красноперекопск - Армянск (8.30)
	--(), -- Армянск - Симферополь
end


-- Создание маршрута Армянск - Красноперекопск
if ((select Count(*) from MediumPathes) = 0)
begin
	insert MediumPathes values  
		(1, 0, 4)
end

--create procedure GetNeighborCities
--	as 
--	begin
--		select nc.Id as Id,  c1.Title StartCity, c2.Title EndCity, MinutesInPath from NeighborCities nc
--		join Cities c1 on CityId = c1.Id 
--		join Cities c2 on NeighborId = c2.Id 
--	end

	exec GetNeighborCities

use DreamBusDB;

select * from Buses
select * from BusModels
select * from BusTypes
select * from BusSeats

select * from Flights
select * from MediumPathes

--update BusTypes
--set BusWidth = 975, BusHeight = 250
--where id = 1

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

