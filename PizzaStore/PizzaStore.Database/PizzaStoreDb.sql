use master;
GO

create database PizzaStoreDb;
go

use PizzaStoreDb;
go

create schema Store; --equiv to namespace
GO

create schema Pizza; --equiv to namespace
GO

create schema PizzaOrder; --equiv to namespace
GO

create schema PizzaUser; --equiv to namespace
GO

--CONSTRAINTS
-- = datatype, key, default, check, null, ? 
-- number datatypes = tinyint, smallint, int, bigint, numeric, decimal, money
-- text datatypes = nvarchar (UTF-8), nchar
-- datetime datatypes = date, time, datetime, datetime2
-- boolean datatypes = bit

create table Pizza.Pizza --equiv to class
(
     PizzaId int primary key,
     [Name] nvarchar(250) not null,
     CrustId int,
     SizeId int,
     DateModified datetime2(0) not null,
     Active bit not null,
);

create table Pizza.Crust
(
     CrustId int not null primary key,
     [Name] nvarchar(100) not null,
     DateModified datetime2(0) not null,
     Active bit not null default 1,
);

create table Pizza.Size
(
     SizeId int primary key,
     [Name] nvarchar(250) not null,
     DateModified datetime2(0) not null,
     Active bit not null,
);

create table Pizza.Topping
(
     ToppingId int primary key,
     [Name] nvarchar(250) not null,
     DateModified datetime2(0) not null,
     Active bit not null,
);



--ALTER
alter table Pizza.Pizza
     add constraint FK_Pizza_SizeId foreign key (SizeId) references Pizza.Size(SizeId);


alter table Pizza.Pizza
     add constraint FK_Pizza_CrustId foreign key (CrustId) references Pizza.Crust(CrustId);

go


create table Pizza.PizzaTopping
(
     PizzaToppingId int primary key,
     PizzaId int not null,
     ToppingId int not null,
     Active bit not null,

);
GO

alter table Pizza.PizzaTopping
     add constraint FK_PT_PizzaId foreign key (PizzaId) references Pizza.Pizza(PizzaId);


alter table Pizza.PizzaTopping
     add constraint FK_PT_ToppingId foreign key (ToppingId) references Pizza.Topping(ToppingId);
go

create table PizzaOrder.Orders
(
     OrderId int primary KEY,
     OrderDate datetime2
);
GO


create table PizzaOrder.OrdersPizzaTopping
(
     OPTId int primary key,
     OrderId int,
     PizzaToppingId int,
     constraint FK_PizzaToppingId foreign key (PizzaToppingId) references Pizza.PizzaTopping(PizzaToppingId),
     constraint FK_OrderId foreign key (OrderId) references PizzaOrder.Orders(OrderId),

);
GO

create table PizzaUser.Users
(
     UserId int primary key,
     UserName nvarchar(100) not null,
     PWord nvarchar(100) not null,
     OPTId int,
     constraint FK_OPTId foreign key (OPTId) references PizzaOrder.OrdersPizzaTopping(OPTId),
);
GO

create table Store.Store
(
     StoreId int primary key,
     StoreName nvarchar(100) not null,
     PWord nvarchar(100) not null,
     OPTId int,
     constraint FK_OPTId foreign key (OPTId) references PizzaOrder.OrdersPizzaTopping(OPTId),
);
GO