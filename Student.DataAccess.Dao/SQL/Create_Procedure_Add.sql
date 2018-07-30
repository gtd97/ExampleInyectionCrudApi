USE [VuelingApiD]
GO

CREATE PROCEDURE [dbo].uspInsertStudent	(	@StudentsGuid UNIQUEIDENTIFIER,
											@StudentsNombre NVARCHAR(50),
											@StudentsApellido NVARCHAR(50),
											@StudentsDni NVARCHAR(14),
											@StudentsEdad INT,
											@StudentsNacimiento DATE,
											@StudentsRegistro DATE	)
AS   
    SET NOCOUNT ON;  
	
    INSERT INTO Alumnos ([Guid], Nombre, Apellidos, Dni, Edad, Nacimiento, Registro) 
		VALUES (@StudentsGuid, @StudentsNombre, @StudentsApellido, @StudentsDni, 
				@StudentsEdad, @StudentsNacimiento, @StudentsRegistro);
