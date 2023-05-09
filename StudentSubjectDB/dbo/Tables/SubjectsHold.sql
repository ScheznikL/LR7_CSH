CREATE TABLE [dbo].[SubjectsHold] (
    [sub] NVARCHAR (MAX) NOT NULL,
    [id]  NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CHECK ([id]>(0))
);

