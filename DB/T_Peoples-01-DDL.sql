create database T_Peoples
go

use T_Peoples
go


create table Funcionarios (
	IdFuncionario int primary key identity,
	Nome varchar (255) not null,
	Sobrenome varchar (255) not null
);

go
