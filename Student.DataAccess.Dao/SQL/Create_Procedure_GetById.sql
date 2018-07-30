USE [VuelingApiD]
GO

CREATE PROCEDURE [dbo].[uspGetByGuid] @GuidOfStudent UNIQUEIDENTIFIER
AS   
    SET NOCOUNT ON;  
	
    SELECT	*
    FROM Alumnos
	WHERE [Guid] = @GuidOfStudent;