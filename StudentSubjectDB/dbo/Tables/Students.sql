CREATE TABLE [dbo].[Students] (
    [idStudents]   INT          IDENTITY (1, 1) NOT NULL,
    [group_number] DECIMAL (18) NOT NULL,
    [name]         VARCHAR (20) NOT NULL,
    [lastname]     VARCHAR (45) NOT NULL,
    [given_id]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([idStudents] ASC),
    CHECK ([group_number]>(0)),
    CHECK ([idStudents]>(0))
);

