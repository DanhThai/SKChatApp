create database SKChat
go
use SKChat
go 
create table Person
(
	Id int identity primary key,
	Ipaddress varchar(25),
	Full_name nvarchar(50),
	Gender bit,
	Birthday date,
)

go
create table Account
(
	Name_user varchar(30) primary key,
	Pass varchar(20),
	Id int,
	CONSTRAINT FK_Id1 FOREIGN KEY (Id) REFERENCES Person(Id)
);
go
create table Conversations
(
	Id_group int identity primary key,
	User_one int,
	User_two int,
	CONSTRAINT FK_Id3 FOREIGN KEY (User_one) references Person(Id),
	CONSTRAINT FK_Id4 FOREIGN KEY (User_two) references Person(Id),
);
go
create table Conversation_reply
(
	Id_group int not null,
	Reply Text,
	Id int not null,
	CONSTRAINT FK_Id5 FOREIGN KEY (Id_group) references Conversations(Id_group),
);