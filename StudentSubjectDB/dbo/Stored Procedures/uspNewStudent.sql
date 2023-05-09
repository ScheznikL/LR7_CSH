CREATE PROCEDURE [dbo].[uspNewStudent]  
@name VARCHAR (20),  
@lastname VARCHAR (45),  
@group_number REAL,
@given_id INT
AS  
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Students] WHERE given_id = @given_id AND group_number = @group_number)
    BEGIN
        INSERT INTO [dbo].[Students] (given_id, group_number, name, lastname) 
        VALUES (@given_id, @group_number, @name, @lastname);
    END
END