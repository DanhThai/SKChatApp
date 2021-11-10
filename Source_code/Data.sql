use SKChat
go
insert into Person values(1,'127.0.0.1:1111','Le A',0,'2001-04-03',null);
insert into Person values(2,'127.0.0.1:2222','Le B',1,'2001-05-03',null);
insert into Person values(3,'127.0.0.1:3333','Le C',1,'2001-04-02',null);
insert into Person values(4,'127.0.0.1:4444','Le D',1,'2001-02-01',null);
insert into Person values(5,'127.0.0.1:5555','Le E',1,'2001-01-05',null);

go
insert into Account values('user01','user01',1);
insert into Account values('user02','user02',2);
insert into Account values('user03','user03',3);
insert into Account values('user04','user04',4);
insert into Account values('user05','user05',5);

go
insert into Group_chat values(1,'Gr1');
insert into Group_chat values(2,'Gr2');
insert into Group_chat values(3,'Gr3');
insert into Group_chat values(4,'Gr4');
insert into Group_chat values(5,'Gr5');

go
insert into Box_chat values(1,null,1,1);
insert into Box_chat values(2,null,1,2);
insert into Box_chat values(3,null,2,1);
insert into Box_chat values(4,null,2,3);
insert into Box_chat values(5,null,3,2);
insert into Box_chat values(6,null,3,4);
insert into Box_chat values(7,null,4,2);
insert into Box_chat values(8,null,4,5);
insert into Box_chat values(9,null,5,3);
insert into Box_chat values(10,null,5,5);
