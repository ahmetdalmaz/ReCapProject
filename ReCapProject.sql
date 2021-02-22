create database ReCapProject
use ReCapProject

create table Cars(
Id int primary key Identity(1,1),
BrandId int foreign key references Brands(Id),
ColorId int foreign key references Colors(Id),
ModelYear int,
DailyPrice money,
Description nvarchar(50))


create table Colors(
Id int primary key Identity(1,1),
Name nvarchar(50)
)

create table Brands(
Id int primary key Identity(1,1),
Name nvarchar(50)
)


