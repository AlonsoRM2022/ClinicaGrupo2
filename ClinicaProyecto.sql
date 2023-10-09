CREATE DATABASE Clinica
GO

USE Clinica
GO

CREATE TABLE Roles(
IdRol  INT IDENTITY,
Nombre VARCHAR(100),
PRIMARY KEY(IdRol))
GO


CREATE TABLE Usuarios(
IdUsuario INT IDENTITY,
Nombre VARCHAR(100),
Apellido VARCHAR(100),
Correo VARCHAR(100),
Edad INT,
Direccion VARCHAR(5000),
Contrase�a VARCHAR(150),
StatusUsuario BIT DEFAULT 1,
FechaRegistro DATETIME DEFAULT GETDATE(),
IdRol INT REFERENCES Roles(IdRol),
PRIMARY KEY(IdUsuario))
GO


/*  TABLA PARA GUARDAR PRECIOS PREDEFINIDOS PARA UNA ESPECIALIDAD*/
CREATE TABLE Precios (
  IdPrecio INT,
  Valor INT,
  PRIMARY KEY (IdPrecio)
)
GO


/*  TABLA PARA GUARDAR LAS AREAS QUE SE PUEDEN ATENDER EN LA CLINICA*/
CREATE TABLE Especialidades (
  IdEspecialidad INT,
  Nombre VARCHAR(50),
  IdPrecio INT REFERENCES Precios(IdPrecio),
  StatusEspecialidad BIT DEFAULT 1,
  PRIMARY KEY (IdEspecialidad)
)
GO


CREATE TABLE Clinicas(
IdClinica INT IDENTITY,
Nombre VARCHAR(200),
Direccion VARCHAR(1000),
Telefono VARCHAR(20),
Correo VARCHAR(50),
PRIMARY KEY(IdClinica))
GO

/*  TABLA PARA GUARDAR LOS DOCTORES Y PODER USARLOS EN LA CREACION DE CITAS (NO ES EL USUARIO)*/
CREATE TABLE Doctores(
IdDoctor INT IDENTITY,
Nombre VARCHAR(50),
Apellido VARCHAR(50),
StatusDoctor BIT DEFAULT 1,
PRIMARY KEY(IdDoctor))
GO


/*  TABLA PARA GUARDAR LOS HORARIOS DISPONIBLES)*/
CREATE TABLE Horarios(
IdHorario INT IDENTITY,
Dia VARCHAR(25),
Hora VARCHAR(25),
StatusHorario BIT DEFAULT 1,
PRIMARY KEY(IdHorario))
GO


/*  TABLA QUE ALMACENA LAS OPCIONES DE CITAS QUE LOS USUARIOS PUEDEN ESCOGER PARA RESERVAR */
CREATE TABLE Citas(
IdCita INT IDENTITY,
IdDoctor INT REFERENCES Doctores(IdDoctor),
IdEspecialidad INT REFERENCES Especialidades(IdEspecialidad),
IdClinica INT REFERENCES Clinicas(IdClinica),
IdHorario INT REFERENCES Horarios(IdHorario),
StatusCita BIT DEFAULT 1,
PRIMARY KEY(IdCita))
GO


/*  TABLA PARA GUARDAR SI UNA CITA ES PENDIENTE-EN PROCESO-FINALIZADA*/
CREATE TABLE StatusReservas(
IdStatusReserva INT IDENTITY,
Nombre VARCHAR(20),
PRIMARY KEY(IdStatusReserva))
GO


CREATE TABLE Reservas(
IdReserva INT IDENTITY,
IdCita INT REFERENCES Citas(IdCita),
IdUsuario INT REFERENCES Usuarios(IdUsuario),
IdStatusReserva INT REFERENCES StatusReservas(IdStatusReserva),
Precio INT,
FechaRegistro DATETIME DEFAULT GETDATE(),
PRIMARY KEY(IdReserva))
GO



CREATE TABLE Facturas(
IdFactura INT IDENTITY,
Total INT,
IdReserva INT REFERENCES Reservas(IdReserva),
FechaRegistro DATETIME DEFAULT GETDATE(),
PRIMARY KEY(IdFactura))
GO



CREATE TABLE Diagnosticos(
IdDiagnostico INT IDENTITY,
Descripcion VARCHAR(MAX),
IdReserva INT REFERENCES Reservas(IdReserva),
PRIMARY KEY(IdDiagnostico))
GO