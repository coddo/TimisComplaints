CREATE TABLE [dbo].[Problems] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (50)    NOT NULL,
    [Description] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Problems] PRIMARY KEY CLUSTERED ([Id] ASC)
);

