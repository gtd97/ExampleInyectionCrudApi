USE [VuelingApiD]
GO


CREATE PROCEDURE [dbo].[uspGetAllStudents]
AS   
    SET NOCOUNT ON;  
	
    SELECT	*
    FROM Alumnos;