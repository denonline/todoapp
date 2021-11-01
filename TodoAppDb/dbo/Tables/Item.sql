CREATE TABLE [dbo].[Item] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (150) NOT NULL,
    [Details] VARCHAR (MAX) NULL,
    [DueDate] DATETIME      NULL,
    [Status]  INT           NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([id] ASC)
);

