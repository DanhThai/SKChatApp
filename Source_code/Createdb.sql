create database SKChat
go
use SKChat
go 
create table Person
(
	Id int primary key,
	Ipaddress varchar(25),
	Full_name nvarchar(50),
	Gender bit,
	Birthday date,
	Img Image,
)

go
create table Account
(
	Name_user varchar(30) primary key,
	Pass varchar(20),
	Id int,
	CONSTRAINT FK_Id1 FOREIGN KEY (Id)
    REFERENCES Person(Id)
);

go
create table Group_chat
(
	Id_group int primary key,
	Name_group nvarchar(50),
);

go
create table Box_chat
(
	STT int primary key,
	Wait_mess Ntext,
	Id_group int not null,
	Id int not null,
	CONSTRAINT FK_Group foreign key(Id_group) references Group_chat(Id_group),
	CONSTRAINT FK_Id2 FOREIGN KEY (Id) references Person(Id),
)
