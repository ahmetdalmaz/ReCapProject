use ReCapProject

create table Users(
Id int primary key Identity(1,1),
FirstName varchar(50),
LastName varchar(50),
Email varchar(40),
Password varchar(25)
)
create table Customers(
Id int primary key identity(1,1),
UserId int foreign key references Users(Id),
CompanyName varchar(60)
)


create table Rentals
(
Id int primary key identity(1,1),
CarId int foreign key references Cars(Id),
CustomerId int foreign key references Customers(Id),
RentDate datetime,
ReturnDate datetime default null
)