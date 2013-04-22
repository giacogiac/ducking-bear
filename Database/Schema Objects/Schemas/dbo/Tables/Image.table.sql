CREATE TABLE [dbo].[Image] (
    [id]    INT   IDENTITY (0, 1) NOT NULL,
    [size]  INT   NOT NULL,
    [blob]  IMAGE NOT NULL,
    [album] INT   NOT NULL
);

