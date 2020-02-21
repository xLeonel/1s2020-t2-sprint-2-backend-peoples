select * from Funcionarios

create procedure BuscarFuncionario 
@Nome as Varchar(200)
as
select * from Funcionarios
where Nome like '%' + Nome + '%'