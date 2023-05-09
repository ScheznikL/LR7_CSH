CREATE TABLE [dbo].[Students_has_Subjects] (
    [Students_idStudents] INT NOT NULL,
    [Subjects_id]         INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Students_idStudents] ASC, [Subjects_id] ASC),
    CHECK ([Students_idStudents]>(0)),
    FOREIGN KEY ([Students_idStudents]) REFERENCES [dbo].[Students] ([idStudents]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([Subjects_id]) REFERENCES [dbo].[Subjects] ([idSubjects]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [Students_has_Subjects_FKIndex1]
    ON [dbo].[Students_has_Subjects]([Students_idStudents] ASC);


GO
CREATE NONCLUSTERED INDEX [Students_has_Subjects_FKIndex2]
    ON [dbo].[Students_has_Subjects]([Subjects_id] ASC);

