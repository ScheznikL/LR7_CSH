CREATE PROCEDURE [dbo].[uspNewSubject]  
@caption NVARCHAR (100),  
@grade INT,  
@idStudent INT
AS  
IF NOT EXISTS (
    SELECT 1 
    FROM [dbo].[Subjects] 
    WHERE caption = @caption AND idStudent = @idStudent
)
BEGIN
   INSERT INTO [dbo].[Subjects] (caption, grade, idStudent) VALUES (@caption, @grade, @idStudent)
END