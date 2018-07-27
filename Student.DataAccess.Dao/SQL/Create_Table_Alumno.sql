USE VuelingApiD;

IF OBJECT_ID(N'VuelingApiD.dbo.Alumno', N'U') IS NULL
BEGIN

CREATE TABLE dbo.Alumnos
(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	[Guid] uniqueidentifier NOT NULL,
	Nombre [NVARCHAR] (50) NOT NULL,
	Apellidos [NVARCHAR] (50) NOT NULL,
	Dni [NVARCHAR] (14) NOT NULL,
	Edad INT NOT NULL,
	Nacimiento DATE NOT NULL,
	Registro DATE NOT NULL
);
END