CREATE PROCEDURE [dbo].[uspInsertFromJSON]
    @jsonData NVARCHAR(MAX)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Students (group_number, name, lastname, given_id)
		SELECT j.group_number, j.name, j.lastName, j.given_id
		FROM OPENJSON(@jsonData)
		WITH(
			group_number decimal '$.Groupnumber',
			name VARCHAR(20) '$.Name',
			lastName VARCHAR(45) '$.LastName',
			given_id INT '$.Id') j
		WHERE NOT EXISTS (
			SELECT 1 FROM Students WHERE given_id = j.given_id AND group_number = j.group_number
		);
        
 
        INSERT INTO dbo.SubjectsHold(sub, id)
        SELECT sub, id
        FROM OPENJSON(@jsonData)
        WITH (
            sub NVARCHAR(MAX) '$.Subjects' AS JSON,
            id NVARCHAR(50) '$.Id'
        )        

		INSERT INTO Subjects(idStudent, caption, grade)
		SELECT idStudent,caption,grade
		FROM OPENJSON(@jsonData)
			WITH(
			idStudent int '$.Id', 
			Subjects nvarchar(MAX) AS JSON) J
		CROSS APPLY OPENJSON(J.Subjects)
					WITH(
					Caption nvarchar(100),
					Grade int) CD
			WHERE NOT EXISTS (
				SELECT 1 FROM Subjects WHERE idStudent = J.idStudent AND caption = CD.Caption AND grade = CD.Grade
		);
        

        INSERT INTO Students_has_Subjects
        SELECT S.idStudents, SB.idSubjects
        FROM Students S
        INNER JOIN Subjects SB ON S.given_id = SB.idStudent
        WHERE NOT EXISTS (
            SELECT 1 FROM Students_has_Subjects SS
            WHERE SS.Students_idStudents = S.idStudents AND SS.Subjects_id = SB.idSubjects
        );
        
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END