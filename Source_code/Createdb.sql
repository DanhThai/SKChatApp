
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
insert into Person values(1,'Da Nang','Le A',1,'2001-23-04','null');
insert into Person values(2,'Da Nang','Le B',1,'2001-23-03','null');
insert into Person values(3,'Da Nang','Le C',1,'2001-23-02','null');
insert into Person values(4,'Da Nang','Le D',1,'2001-23-01','null');
insert into Person values(5,'Da Nang','Le E',1,'2001-23-05','null');


go
create table Account
(
	Name_user varchar(30) primary key,
	Pass varchar(20),
	Id int,
	CONSTRAINT FK_Id1 FOREIGN KEY (Id)
    REFERENCES Person(Id)
);
insert into Account values('user01','user01',1);
insert into Account values('user02','user02',2);
insert into Account values('user03','user03',3);
insert into Account values('user04','user04',4);
insert into Account values('user05','user05',5);
go
create table Group_chat
(
	Id_group int primary key,
	Name_group nvarchar(50),
);
insert into Group_chat values(1,'Gr1');
insert into Group_chat values(2,'Gr2');
insert into Group_chat values(3,'Gr3');
insert into Group_chat values(4,'Gr4');
insert into Group_chat values(5,'Gr5');
go
create table Box_chat
(
	Wait_mess Ntext,
	Id_group int,
	Id int,
	CONSTRAINT FK_Group foreign key(Id_group) references Group_chat(Id_group),
	CONSTRAINT FK_Id2 FOREIGN KEY (Id) references Person(Id),
)
insert into Box_chat values('null',1,1);
insert into Box_chat values('null',1,2);
insert into Box_chat values('null',1,3);
insert into Box_chat values('null',2,2);
insert into Box_chat values('null',2,3);
insert into Box_chat values('null',2,4);
insert into Box_chat values('null',3,1);
insert into Box_chat values('null',3,5);
insert into Box_chat values('null',3,3);