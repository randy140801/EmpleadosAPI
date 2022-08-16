CREATE DATABASE Empleados

USE Empleados

CREATE TABLE Usuarios(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre varchar(100) NOT NULL,
	Apellido varchar(100) NOT NULL,
	Cedula varchar(11) UNIQUE NOT NULL,
	Departamento varchar(50) NOT NULL,
	Cargo varchar(50) NOT NULL
);