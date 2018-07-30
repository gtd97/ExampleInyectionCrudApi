USE [VuelingApiD]
GO

CREATE PROCEDURE [dbo].uspUpdateStudent	(	@GuidOfStudent UNIQUEIDENTIFIER,
											@StudentsGuid UNIQUEIDENTIFIER,
											@StudentsNombre NVARCHAR(50),
											@StudentsApellido NVARCHAR(50),
											@StudentsDni NVARCHAR(14),
											@StudentsEdad INT,
											@StudentsNacimiento DATE,
											@StudentsRegistro DATE	)
AS   
    SET NOCOUNT ON;  
	
	UPDATE Alumnos SET	[Guid]=@StudentsGuid, 
						Nombre=@StudentsNombre, 
						Apellidos=@StudentsApellido, 
						Dni=@StudentsDni, 
						Edad=@StudentsEdad, 
						Nacimiento=@StudentsNacimiento, 
						Registro=@StudentsRegistro  
	WHERE [Guid]=@GuidOfStudent;