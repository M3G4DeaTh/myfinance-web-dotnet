create database myfinance
go
use myfinance
go

create table PlanoConta(
	id int not null identity(1,1),
	descricao varchar(50) not null,
	tipo char(1) not null,
	primary key(id)
);
go

create table Transacao(
	id int not null identity(1,1),
	historico varchar(50) null,
	data datetime not null,
	valor decimal(9,2) not null,
	planocontaid int not null,
	primary key	(id)
	foreign key (planocontaid) references PlanoConta(id)
);
go
