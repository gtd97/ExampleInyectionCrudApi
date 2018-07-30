USE [VuelingApiD]
GO

CREATE PROCEDURE [dbo].uspDeleteByGuid @GuidOfStudent UNIQUEIDENTIFIER
AS   
    SET NOCOUNT ON;  
	
    DELETE FROM Alumnos
	WHERE [Guid] = @GuidOfStudent;