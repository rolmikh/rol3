set ansi_nulls on
go
set ansi_padding on
go 
set quoted_identifier on
go

create database [Auto_Shop_Database]
go

use [Auto_Shop_Database]
go

select name,is_broker_enabled from sys.databases
where name='Auto_Shop_Database'

create table [dbo].[Role]--Таблица должность
(
	[ID_Role] [int] not null identity(1,1),
	[Name_Role] [varchar] (50) not null,
	constraint [PK_Role] primary key clustered
	([ID_Role] ASC) on [PRIMARY],
	constraint [UQ_Name_Role] unique ([Name_Role])
)
go

insert into [dbo].[Role]([Name_Role])
values('Администратор'),('Сотрудник'),('Пользователь')
go

create table [dbo].[User] --таблица пользователь 
(
	[ID_User] [int] not null identity(1,1),
	[Email_User] [varchar] (50) not null,
	[Login_User] [varchar] (50) not null,
	[Password_User] [varchar] (50) not null,
	[Role_ID] [int] not null
	constraint [PK_User] primary key clustered 
	([ID_User] ASC) on [PRIMARY],
	constraint [FK_Role] foreign key ([Role_ID])
	references [dbo].[Role] ([ID_Role]),
	constraint [CH_Email_User] check ([Email_User] like ('%@%.%')),
	constraint [CH_Password_User] check (len([Password_User]) >= 8),
	constraint [CH_Password_User_Up] check ([Password_User] like ('%[A-Z]%')),
	constraint [CH_Password_User_Lw] check ([Password_User] like ('%[a-z]%')),
	constraint [CH_Password_User_Letter] check ([Password_User] like ('%[!@#$%^&*()]%')),
	constraint [CH_Password_User_Number] check ([Password_User] like ('%[0-9]%[0-9]%[0-9]%')),
	constraint [CH_Login_User] check (len([Login_User]) >= 6)
)
go

insert into [dbo].[User]([Email_User],[Login_User],[Password_User],[Role_ID])
values('user@gmail.com','loginUser','Pa$$w0r3d4',3),('admin1@gmail.com','admin1','Adm!n1*3)7',1),('worker1@gmail.com','worker1','W0rk3er**!2',2)
go

select [ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country] from [dbo].[Firm] inner join [dbo].[Country] on [Country_ID] = [ID_Country] inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm]
go

--insert into [dbo].[User]([Balance],[Email_User],[Login_User],[Password_User],[Role_ID])
--values('user1@gmail.com','loginUser1','Pa$$w0r3d41',3),
--('user2@gmail.com','loginUser2','Pa$$w0r3d42',3),
--('user3@gmail.com','loginUser3','Pa$$w0r3d43',3),
--('user4@gmail.com','loginUser4','Pa$$w0r3d44',3)
--go

select * from [dbo].[User]
go

create table [dbo].[Type_Contract] --таблица тип контракта
(
	[ID_Type_Contract] [int] not null identity(1,1),
	[Name_Type_Contract] [varchar] (50) not null
	constraint [PK_Type_Contract] primary key clustered
	([ID_Type_Contract] ASC) on [PRIMARY],
	constraint [UQ_Name_Type_Contract] unique ([Name_Type_Contract])
)
go
insert into [dbo].[Type_Contract]([Name_Type_Contract])
values('Классический'),('Неоклассический'),('Отношенческий')
go


create table [dbo].[Model]--таблица модель
(
	[ID_Model] [int] not null identity(1,1),
	[Name_Model] [varchar] (50) not null
	constraint [PK_Model] primary key clustered
	([ID_Model] ASC) on [PRIMARY],
	constraint [UQ_Name_Model] unique ([Name_Model])
)
go

insert into [dbo].[Model]([Name_Model])
values('Almera'),('Elantra'),('Polo')
go

create table [dbo].[Brand]--таблица бренд
(
	[ID_Brand] [int] not null identity(1,1),
	[Name_Brand] [varchar] (50) not null
	constraint [PK_Brand] primary key clustered
	([ID_Brand] ASC) on [PRIMARY],
	constraint [UQ_Name_Brand] unique ([Name_Brand])

)
go

insert into [dbo].[Brand]([Name_Brand])
values('Element'),('My car')
go

create table [dbo].[Type_Part] --таблица тип запчасти
(
	[ID_Type_Part] [int] not null identity(1,1),
	[Name_Type_Part] [varchar] (50) not null
	constraint [PK_Type_Part] primary key clustered
	([ID_Type_Part] ASC) on [PRIMARY],
	constraint [UQ_Name_Type_Part] unique ([Name_Type_Part])
)
go

insert into [dbo].[Type_Part]([Name_Type_Part])
values('Оригинальные'),('Лицензионные'),('Неоригинальные')
go

select * from [dbo].[Type_Part]
go

create table [dbo].[Type_Provider]--таблица тип поставщика
(
	[ID_Type_Provider] [int] not null identity(1,1),
	[Name_Type_Provider] [varchar] (50) not null
	constraint [PK_Type_Provider] primary key clustered
	([ID_Type_Provider] ASC) on [PRIMARY],
	constraint [UQ_Name_Type_Provider] unique ([Name_Type_Provider])
)
go
insert into [dbo].[Type_Provider]([Name_Type_Provider])
values('Фирмы'),('Дилеры'),('Небольшие производства'),('Мелкие поставщики'),('Магазины')
go

create table [dbo].[Type_Firm]--таблица тип фирмы
(
	[ID_Type_Firm] [int] not null identity(1,1),
	[Name_Type_Firm] [varchar] (30) not null,
	constraint [PK_Type_Firm] primary key clustered
	([ID_Type_Firm] ASC) on [PRIMARY],
	constraint [UQ_Name_Type_Firm] unique ([Name_Type_Firm])
)
go

insert into [dbo].[Type_Firm] ([Name_Type_Firm])
values('ООО'),('ОАО'),('ПАО'),('АО')
go

create table [dbo].[Country]--таблица страна
(
	[ID_Country] [int] not null identity(1,1),
	[Name_Country] [varchar] (50) not null,
	constraint [PK_Country] primary key clustered
	([ID_Country] ASC) on [PRIMARY],
	constraint [UQ_Name_Country] unique ([Name_Country])
)
go

insert into [dbo].[Country] ([Name_Country])
values('Китай'),('США'),('Япония'),('Германия'),('Республика Корея')
go

select * from [dbo].[Country]
go





create table [dbo].[Provider]-- таблица поставщик
(
	[ID_Provider] [int] not null identity(1,1),
	[Name_Provider] [varchar] (50) not null,
	[Address_Provider] [varchar] (50) not null,
	[Type_Provider_ID] [int] not null,
	constraint [PK_Provider] primary key clustered
	([ID_Provider] ASC) on [PRIMARY],
	constraint [FK_Type_Provider] foreign key ([Type_Provider_ID])
	references [dbo].[Type_Provider] ([ID_Type_Provider])
)
go

insert into [dbo].[Provider]([Name_Provider],[Address_Provider],[Type_Provider_ID])
values('AutoLans','город Волоколамск, пр. Космонавтов, 25',1),
('Forward AutoParts','город Раменское, бульвар Ломоносова, 99',1),
('IXORA','город Орехово-Зуево, спуск Бухарестская, 09',3),
('MYSTORE','город Подольск, пер. 1905 года, 64',3),
('Автоартис','город Луховицы, наб. Чехова, 35',1)
go

create table [dbo].[Firm] --таблица фирма
(
	[ID_Firm] [int] not null identity(1,1),
	[Name_Firm] [varchar] (50) not null,
	[Legal_Address] [varchar] (50) not null,
	[Physical_Address] [varchar] (50) not null,
	[Phone_Number_Firm] [varchar] (17) not null,
	[Email_Firm] [varchar] (50) not null,
	[BIC] [varchar] (9) not null,
	[CHECKPOINT] [int] not null,
	[OGRN] [varchar] (13) not null,
	[INN] [varchar] (10) not null,
	[Type_Firm_ID] [int] not null,
	[Country_ID] [int] not null
	constraint [PK_Firm] primary key clustered
	([ID_Firm] ASC) on [PRIMARY],
	constraint [FK_Type_Firm] foreign key ([Type_Firm_ID])
	references [dbo].[Type_Firm] ([ID_Type_Firm]),
	constraint [FK_Country] foreign key ([Country_ID])
	references [dbo].[Country] ([ID_Country]),
	constraint [Check_Phone_Number_Firm] check ([Phone_Number_Firm] like '+7([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]'),
	constraint [Check_Email] check ([Email_Firm] like '%@%.%'),
	constraint [Check_BIC] check ([BIC] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	constraint [Check_CHECKPOINT] check (len([CHECKPOINT])= 9),
	constraint [Check_OGRN] check ([OGRN] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	constraint [Check_INN] check ([INN] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
)
go

insert into [dbo].[Firm]([Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Type_Firm_ID],[Country_ID])
values('Автомаркет','город Одинцово, ул. Космонавтов, 88','город Серебряные Пруды, пр. Домодедовская, 45','+7(988)563-09-98','automarket@gmail.com','044578594','574839275','5674839876231','9876543567',1,1),
('Автодоктор','город Талдом, ул. Гоголя, 20','город Дмитров, проезд 1905 года, 31','+7(900)875-67-86','autodoctor@gmail.com','465738298','753254769','2342678065432','5566748909',2,2),
('Автомиг','город Одинцово, ул. Славы, 73','город Луховицы, ул. 1905 года, 55','+7(888)645-22-55','automig@gmail.com','136474392','234797547','5463876980002','9887768790',3,3),
('Автолюбитель','город Волоколамск, ул. Гагарина, 78','город Мытищи, въезд Бухарестская, 61','+7(987)234-54-55','autolove@gmail.com','374839420','986576875','1234569876000','1234658868',4,4),
('Автозвук','город Озёры, пер. Ладыгина, 34','город Дорохово, спуск Славы, 80','+7(889)666-66-66','Autozvuk@gmail.com','124575634','542769009','3454466678099','8796870098',1,5)
go

update [dbo].[Firm]
set [Name_Firm] = 'АвтоЗвук'
where [ID_Firm] = 5
go

select * from [dbo].[Firm]
go

create table [dbo].[Firm_Provider]--таблица фирма поставщика
(
	[ID_Firm_Provider] [int] not null identity (1,1),
	[Provider_ID] [int] not null,
	[Firm_ID] [int] not null
	constraint [PK_Firm_Provider] primary key clustered
	([ID_Firm_Provider] ASC) on [PRIMARY],
	constraint [FK_Provider] foreign key ([Provider_ID])
	references [dbo].[Provider] ([ID_Provider]),
	constraint [FK_Firm_Provider] foreign key ([Firm_ID])
	references [dbo].[Firm] ([ID_Firm])
)
go
insert into [dbo].[Firm_Provider] ([Provider_ID],[Firm_ID])
values(1,1),(2,2),(3,3),(4,4),(5,5)
go

create table [dbo].[Part]--таблица запчасть
(
	[ID_Part] [int] not null identity (1,1),
	[Part_Status] [varchar] (50) not null,
	[Name_Part] [varchar] (50) not null,
	[Price_Part] [int] not null,
	[Damage] [varchar] (3) not null,
	[Firm_Provider_ID] [int] not null,
	[Type_Part_ID] [int] not null,
	[Model_ID] [int] not null,
	[Brand_ID] [int] not null,
	[Count] [int] null
	constraint [PK_Part] primary key clustered
	([ID_Part] ASC) on [PRIMARY],
	constraint [FK_Firm_Provider_Part] foreign key ([Firm_Provider_ID])
	references [dbo].[Firm_Provider] ([ID_Firm_Provider]),
	constraint [CH_Damage] check ([Damage] in ('Да','Нет')),
	constraint [FK_Type_Part] foreign key ([Type_Part_ID])
	references [dbo].[Type_Part] ([ID_Type_Part]),
	constraint [FK_Model_Part] foreign key ([Model_ID])
	references [dbo].[Model] ([ID_Model]),
	constraint [FK_Brand_Part] foreign key ([Brand_ID])
	references [dbo].[Brand] ([ID_Brand]),
	constraint [CH_Price_Part] check ([Price_Part] >= 0)
)
go



select [Part_Status] as "Статус", [Name_Part] as "Название", [Price_Part] as "Стоимость",[Name_Firm] as "Название фирмы",
[Name_Provider] as "Название поставщика", [Name_Type_Part] as "Название типа запчасти", [Name_Model] as "Модель", [Name_Brand] as "Бренд" from [dbo].[Part]
inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part]
inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider]
inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm]
inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider]
inner join [dbo].[Model] on [Model_ID] = [ID_Model]
inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]


insert into [dbo].[Part]([Part_Status],[Name_Part],[Price_Part],[Damage],[Firm_Provider_ID],[Type_Part_ID],[Model_ID],[Brand_ID],[Count])
values('В наличии','Тормозные диски',1000,'Нет',1,1,1,1,100),
('В наличии','Фильтр',2000,'Нет',2,1,2,2,140),
('В наличии','Амортизатор',1500,'Да',3,2,2,2,40),
('В наличии','Сцепление',3000,'Нет',4,1,3,1,10),
('В наличии','Коробка передач',5000,'Нет',5,1,1,1,190)
go

create table [dbo].[StoreHouse]--таблица склад
(
	[ID_Storehouse] [int] not null identity(1,1),
	[Count_Storehouse] [int] not null,
	[Number_Storehouse] [varchar] (6) not null,
	[Part_ID] [int] not null
	constraint [PK_Storehouse] primary key clustered
	([ID_Storehouse] ASC) on [PRIMARY],
	constraint [FK_Part_Storehouse] foreign key ([Part_ID])
	references [dbo].[Part] ([ID_Part]),
	constraint [UQ_Number_Storehouse] unique ([Number_Storehouse]),
	constraint [CH_Count_Storehouse] check ([Count_Storehouse] >= 0),
	constraint [CH_Number_Storehouse] check ([Number_Storehouse] like '[0-9][0-9][0-9][0-9][0-9][0-9]')
)
go
insert into [dbo].[StoreHouse] ([Count_Storehouse],[Number_Storehouse],[Part_ID])
values(35,'543624',1),
(135,'123457',2),
(225,'674247',3),
(24,'871235',4),
(15,'569493',5)
go

create table [dbo].[Store]--таблица магазин
(
	[ID_Store] [int] not null identity(1,1),
	[Name_Store] [varchar] (50) not null,
	[Address_Store] [varchar] (50) not null,
	[Storehouse_ID] [int] not null
	constraint [PK_Store] primary key clustered
	([ID_Store] ASC) on [PRIMARY],
	constraint [FK_Storehouse] foreign key ([Storehouse_ID])
	references [dbo].[Storehouse] ([ID_Storehouse])
)
go

insert into [dbo].[Store]([Name_Store],[Address_Store],[Storehouse_ID])
values('Автохит','город Павловский Посад, шоссе Гоголя, 53',1),
('КолесО','город Видное, пер. 1905 года, 63',2),
('Автозамена','город Красногорск, шоссе Ленина, 32',3),
('Гараж','город Талдом, спуск Косиора, 46',4),
('Ремавто','город Орехово-Зуево, ул. Домодедовская, 32',5)
go

--create table [dbo].[Worker] --таблица сотрудник
--(
--	[ID_Worker] [int] not null identity(1,1),
--	[Login_Worker] [varchar] (50) not null,
--	[Password_Worker] [varchar] (50) not null,
--	[Role_ID] [int] not null,
--	[Store_ID] [int] not null
--	constraint [PK_Worker] primary key clustered
--	([ID_Worker] ASC) on [PRIMARY],
--	constraint [FK_Role_Worker] foreign key ([Role_ID])
--	references [dbo].[Role] ([ID_Role]),
--	constraint [FK_Store] foreign key ([Store_ID])
--	references [dbo].[Store] ([ID_Store]),
--	constraint [CH_Password_Worker] check (len([Password_Worker]) >= 8),
--	constraint [CH_Password_Worker_Up] check ([Password_Worker] like ('%[A-Z]%')),
--	constraint [CH_Password_Worker_Lw] check ([Password_Worker] like ('%[a-z]%')),
--	constraint [CH_Password_Worker_Letter] check ([Password_Worker] like ('%[!@#$%^&*()]%')),
--	constraint [CH_Password_Worker_Number] check ([Password_Worker] like ('%[0-9]%[0-9]%[0-9]%')),
--	constraint [CH_Login_Worker] check (len([Login_Worker]) >= 6)
--)
--go

--insert into [dbo].[Worker] ([Login_Worker],[Password_Worker],[Role_ID],[Store_ID])
--values('admin1','Adm!n1*3)7',1,1),('worker1','W0rk3er**!2',2,2)
--go


create table [dbo].[Basket]--таблица корзина
(
	[ID_Basket] [int] not null identity(1,1),
	[Count_Part_Basket] [int] not null,
	[User_ID] [int] not null,
	[Part_ID] [int] not null 
	constraint [PK_Basket] primary key clustered
	([ID_Basket] ASC) on [PRIMARY],
	constraint [FK_User] foreign key ([User_ID])
	references [dbo].[User] ([ID_User]),
	constraint [FK_PartBasket] foreign key ([Part_ID])
	references [dbo].[Part] ([ID_Part]),
	constraint [CH_Count_Part_Basket] check ([Count_Part_Basket] >= 0)
)
go

insert into [dbo].[Basket] ([Count_Part_Basket],[User_ID],[Part_ID])
values(3,1,1),(3,1,2),(1,1,3)
go

select * from [dbo].[Basket]
go

create table [dbo].[Contract] --таблица контракт
(
	[ID_Contract] [int] not null identity(1,1),
	[Number_Contract] [varchar] (6) not null,
	[Date_Contract] [date] null default(getdate()),
	[Express_Contract] [varchar] (3) not null,
	[Sostav_Contract] [varchar] (100) not null,
	[Type_Contract_ID] [int] not null,
	[Store_ID] [int] not null
	constraint [PK_Contract] primary key clustered
	([ID_Contract] ASC) on [PRIMARY],
	constraint [UQ_Number_Contract] unique ([Number_Contract]),
	constraint [CH_Express_Contract] check ([Express_Contract] in ('Да','Нет')),
	constraint [FK_Type_Contract] foreign key ([Type_Contract_ID])
	references [dbo].[Type_Contract] ([ID_Type_Contract]),
	constraint [FK_Store_Contract] foreign key ([Store_ID])
	references [dbo].[Store] ([ID_Store]),
	constraint [CH_Number_Contract] check ([Number_Contract] like '[0-9][0-9][0-9][0-9][0-9][0-9]')
)
go

select [ID_Contract],[Number_Contract],[Date_Contract],[Express_Contract],[Sostav_Contract],[Type_Contract_ID],[ID_Type_Contract],[Name_Type_Contract],[Store_ID],[ID_Store],[Name_Store],[Address_Store],[Storehouse_ID],[ID_Storehouse],[Count_Storehouse],[Number_Storehouse],[Part_ID],[ID_Part],[Part_Status],[Name_Part],[Price_Part],[Img_Part],[Firm_Provider_ID],[ID_Firm_Provider],[Provider_ID],[ID_Provider],[Name_Provider],[Address_Provider],[Type_Provider_ID],[ID_Type_Provider],[Name_Type_Provider],[Firm_ID],[ID_Firm],[Name_Firm],[Legal_Address],[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],[Name_Country],[Type_Part_ID],[ID_Type_Part],[Name_Type_Part],[Model_ID],[ID_Model],[Name_Model],[Brand_ID],[ID_Brand],[Name_Brand] from [dbo].[Contract] 
inner join [dbo].[Type_Contract] on [Type_Contract_ID] = [ID_Type_Contract] 
inner join [dbo].[Store] on [Store_ID] = [ID_Store] 
inner join [dbo].[Storehouse] on [Storehouse_ID] = [ID_Storehouse] 
inner join [dbo].[Part] on [Part_ID] = [ID_Part] 
inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] 
inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] 
inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] 
inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] 
inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] 
inner join [dbo].[Country] on [Country_ID] = [ID_Country] 
inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] 
inner join [dbo].[Model] on [Model_ID] = [ID_Model] 
inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]
go

insert into [dbo].[Contract]([Number_Contract],[Date_Contract],[Express_Contract],[Sostav_Contract],[Type_Contract_ID],[Store_ID])
values('654332','23.01.2019','Да','В соответствии с соглашением Поставщик осуществляет поставку автомобильных запчастей',1,1)
go
insert into [dbo].[Contract]([Number_Contract],[Date_Contract],[Express_Contract],[Sostav_Contract],[Type_Contract_ID],[Store_ID])
values('367968','23.01.2019','Да','В соответствии с соглашением Поставщик осуществляет поставку автомобильных запчастей',1,2),
('239654','28.02.2020','Нет','В соответствии с соглашением Поставщик осуществляет поставку автомобильных запчастей',1,3),
('987549','02.05.2021','Нет','В соответствии с соглашением Поставщик осуществляет поставку автомобильных запчастей',1,4),
('378996','29.07.2019','Нет','В соответствии с соглашением Поставщик осуществляет поставку автомобильных запчастей',1,5)
go

--create table [dbo].[Box_Office]-- таблица касса
--(
--	[ID_Box_Office] [int] not null identity(1,1),
--	[Amount_Box_Office] [decimal] (38,2) not null,
--	[Category_Operation] [varchar] (50) not null,
--	[Date_Operation] [datetime] not null,
--	[Store_ID] [int] not null
--	constraint [PK_Box_Office] primary key clustered
--	([ID_Box_Office] ASC) on [PRIMARY],
--	constraint [CH_Amount_Box_Office] check ([Amount_Box_Office] >=0),
--	constraint [FK_Store_Box_Office] foreign key ([Store_ID])
--	references [dbo].[Store] ([ID_Store])
--)
--go

create table [dbo].[Order] --таблица заказ
(
	[ID_Order] [int] not null identity(1,1),
	[Number_Order] [varchar] (6) not null,
	[Amount] [int] not null,
	[Status] [varchar] (50) not null,
	[Date] [date] null default getdate(),
	[Basket_ID] [int] not null
	constraint [PK_Order] primary key clustered
	([ID_Order] ASC) on [PRIMARY],
	constraint [UQ_Number_Order] unique ([Number_Order]),
	constraint [CH_Amount] check ([Amount] >= 0),
	constraint [FK_Basket_ID] foreign key ([Basket_ID])
	references [dbo].[Basket] ([ID_Basket]),
	constraint [CH_Number_Order] check ([Number_Order] like '[0-9][0-9][0-9][0-9][0-9][0-9]')
)
go

insert into [dbo].[Order]([Number_Order],[Amount],[Status],[Date],[Basket_ID])
values('123457',3000,'Оплачен','12.03.2023',1),
('123489',6000,'Оплачен','01.03.2023',2),
('123400',1500,'Оплачен','01.02.2023',3)
go

select [ID_Order],[Number_Order],[Amount],[Status],[Date],[Basket_ID],[ID_Basket],[Count_Part_Basket],[User_ID],[ID_User],[Email_User],[Login_User],[Password_User],
[Role_ID],[ID_Role],[Name_Role],[Part_ID],[ID_Part],[Part_Status],[Name_Part],[Price_Part],[Damage],[Firm_Provider_ID],[ID_Firm_Provider],[Provider_ID],
[ID_Provider],[Name_Provider],[Address_Provider],[Type_Provider_ID],[ID_Type_Provider],[Name_Type_Provider],[Firm_ID],[ID_Firm],[Name_Firm],[Legal_Address],
[Physical_Address],[Phone_Number_Firm],[Email_Firm],[BIC],[CHECKPOINT],[OGRN],[INN],[Type_Firm_ID],[ID_Type_Firm],[Name_Type_Firm],[Country_ID],[ID_Country],
[Name_Country],[Type_Part_ID],[ID_Type_Part],[Name_Type_Part],[Model_ID],[ID_Model],[Name_Model],[Brand_ID],[ID_Brand],[Name_Brand],[Count] from [dbo].[Order]
inner join [dbo].[Basket] on [Basket_ID] = [ID_Basket]
inner join [dbo].[User] on [User_ID] = [ID_User]
inner join [dbo].[Role] on [Role_ID] = [ID_Role] 
inner join [dbo].[Part] on [Part_ID] = [ID_Part] 
inner join [dbo].[Firm_Provider] on [Firm_Provider_ID] = [ID_Firm_Provider] 
inner join [dbo].[Provider] on [Provider_ID] = [ID_Provider] 
inner join [dbo].[Type_Provider] on [Type_Provider_ID] = [ID_Type_Provider] 
inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm] 
inner join [dbo].[Type_Firm] on [Type_Firm_ID] = [ID_Type_Firm] 
inner join [dbo].[Country] on [Country_ID] = [ID_Country] 
inner join [dbo].[Type_Part] on [Type_Part_ID] = [ID_Type_Part] 
inner join [dbo].[Model] on [Model_ID] = [ID_Model] 
inner join [dbo].[Brand] on [Brand_ID] = [ID_Brand]
go

create table [dbo].[Damage]-- таблица брак
(
	[ID_Damage] [int] not null identity(1,1),
	[Damage_Image] [varchar] (50) null,
	[Damage_Having] [varchar] (3) not null,
	[Part_ID] [int] not null
	constraint [PK_Damage] primary key clustered
	([ID_Damage] ASC) on [PRIMARY],
	constraint [CH_Damage_Having] check ([Damage_Having] in ('Да','Нет')),
	constraint [FK_Part_Damage] foreign key ([Part_ID])
	references [dbo].[Part] ([ID_Part])
)
go

create table [Composition_Request_Buying]--таблица состав заявки на покупку товара
(
	[ID_Composition_Request_Buying] [int] not null identity (1,1),
	[Count_Part] [int] not null,
	[Price_Part] [decimal] (38,2) not null,
	[Part_ID] [int] not null
	constraint [PK_Composition_Request_Buying] primary key clustered
	([ID_Composition_Request_Buying] ASC) on [PRIMARY],
	constraint [FK_Part_Composition_Request_Buying] foreign key ([Part_ID])
	references [dbo].[Part] ([ID_Part]),
	constraint [CH_Count_Part_Composition_Request_Buying] check ([Count_Part] >= 0),
	constraint [CH_Price_Part_Composition_Request_Buying] check ([Price_Part] >= 0)
)
go

create table [dbo].[Request_Buying]--таблица заявка на покупку товара
(
	[ID_Request_Buying] [int] not null identity(1,1),
	[Amount_Request_Buying] [decimal] (38,2) not null,
	[Number_Request_Buying] [varchar] (6) not null,
	[User_ID] [int] not null,
	[Composition_Request_Buying_ID] [int] not null
	constraint [PK_Request_Buying] primary key clustered
	([ID_Request_Buying] ASC) on [PRIMARY],
	constraint [FK_Request_Buying_USer] foreign key ([User_ID])
	references [dbo].[User] ([ID_User]),
	constraint [FK_Request_Buying_Composition_Request_Buying] foreign key ([Composition_Request_Buying_ID])
	references [dbo].[Composition_Request_Buying] ([ID_Composition_Request_Buying]),
	constraint [CH_Amount_Request] check ([Amount_Request_Buying] >= 0),
	constraint [UQ_Number_Request] unique ([Number_Request_Buying]),
	constraint [CH_Number_Request_Buying] check ([Number_Request_Buying] like '[0-9][0-9][0-9][0-9][0-9][0-9]')
)
go

create table [dbo].[Composition_Request_Return]--состав заявки на возврат товара
(
	[ID_Composition_Request_Return] [int] not null identity(1,1),
	[Summa_Return] [decimal] (38,2) not null,
	[Reason_Return] [varchar] (50) not null,
	[Damage_ID] [int] not null
	constraint [PK_Composition_Request_Return] primary key clustered
	([ID_Composition_Request_Return] ASC) on [PRIMARY],
	constraint [CH_Summa_Return] check ([Summa_Return] >= 0),
	constraint [FK_Damage_Return] foreign key ([Damage_ID])
	references [dbo].[Damage] ([ID_Damage])
)
go

create table [dbo].[Request_Return] -- таблица заявка на возврат товара
(
	[ID_Request_Return] [int] not null identity (1,1),
	[Number_Request_Return] [varchar] (6) not null,
	[User_ID] [int] not null,
	[Composition_Request_Return_ID] [int] not null
	constraint [PK_Request_Return] primary key clustered
	([ID_Request_Return] ASC) on [PRIMARY],
	constraint [UQ_Number_Request_Return] unique ([Number_Request_Return]),
	constraint [FK_User_Return] foreign key ([User_ID])
	references [dbo].[User] ([ID_User]),
	constraint [FK_Composition_Request_Return] foreign key ([Composition_Request_Return_ID])
	references [dbo].[Composition_Request_Return] ([ID_Composition_Request_Return]),
	constraint [CH_Number_Request_Return] check ([Number_Request_Return] like '[0-9][0-9][0-9][0-9][0-9][0-9]')
)
go

create table [dbo].[Composition_Request_Part]--состав заяки на заказ товара в магазин
(
	[ID_Composition_Request_Part] [int] not null identity(1,1),
	[Count_Part] [int] not null,
	[Price_Part] [decimal] (38,2) not null,
	[Part_ID] [int] not null
	constraint [PK_Composition_Request_Part] primary key clustered
	([ID_Composition_Request_Part] ASC) on [PRIMARY],
	constraint [CH_Count_Part_Composition_Request_Part] check ([Count_Part] >= 0),
	constraint [CH_Price_Part_Composition_Request_Part] check ([Price_Part] >= 0),
	constraint [FK_Composition_Request_Part] foreign key ([Part_ID])
	references [dbo].[Part] ([ID_Part])
)
go

create table [dbo].[Request_Part]--заявка на заказ товара в магазин
(
	[ID_Request_Part] [int] not null identity(1,1),
	[Number_Request_Part] [varchar] (6) not null,
	[Data_Request_Part] [datetime] not null,
	[Composition_Request_Part_ID] [int] not null,
	[Store_ID] [int] not null
	constraint [PK_Request_Part] primary key clustered
	([ID_Request_Part] ASC) on [PRIMARY],
	constraint [FK_Request_Part] foreign key ([Composition_Request_Part_ID])
	references [dbo].[Composition_Request_Part] ([ID_Composition_Request_Part]),
	constraint [UQ_Number_Request_Part] unique ([Number_Request_Part]),
	constraint [CH_Number_Request_Part] check ([Number_Request_Part] like '[0-9][0-9][0-9][0-9][0-9][0-9]')
)
go


