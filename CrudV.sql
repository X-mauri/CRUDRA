create database CrudU5

Use CrudU5

create table DatosAlumno(

Nombre varchar(100) primary key,
ApellidoPaterno varchar(100),
ApellidoMaterno varchar(100),
NumeroControl varchar(100),
Carrera varchar (100),
)

insert into DatosAlumno values ('Maria','Hernandez','Castañon','22887089','Civil')

select * from DatosAlumno