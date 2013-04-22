CREATE TABLE [dbo].[Album] (
    [name]        NVARCHAR (50)  NOT NULL,
    [owner]       INT            NOT NULL,
    [description] NVARCHAR (MAX) NULL,
    [id]          INT            IDENTITY (0, 1) NOT NULL
);

