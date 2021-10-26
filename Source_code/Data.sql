use SKChat
go
insert into Person values(1,'Da Nang','Le A',0,'2001-04-03',null);
insert into Person values(2,'Da Nang','Le B',1,'2001-05-03',null);
insert into Person values(3,'Da Nang','Le C',1,'2001-04-02',null);
insert into Person values(4,'Da Nang','Le D',1,'2001-02-01',null);
insert into Person values(5,'Da Nang','Le E',1,'2001-01-05',null);

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
insert into Box_chat values(null,1,1);
insert into Box_chat values(null,1,2);
insert into Box_chat values(null,1,3);
insert into Box_chat values(null,2,2);
insert into Box_chat values(null,2,3);
insert into Box_chat values(null,2,4);
insert into Box_chat values(null,3,1);
insert into Box_chat values(null,3,5);
insert into Box_chat values(null,3,3);
