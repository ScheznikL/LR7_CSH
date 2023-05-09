CREATE TABLE [dbo].[Subjects] (
    [caption]    NVARCHAR (100) NOT NULL,
    [grade]      INT            NULL,
    [idSubjects] INT            IDENTITY (1, 1) NOT NULL,
    [idStudent]  INT            NULL,
    CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED ([idSubjects] ASC),
    CHECK ([grade]>(0))
);

