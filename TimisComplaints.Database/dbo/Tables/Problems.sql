CREATE TABLE [dbo].[Problems] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [Name]        NVARCHAR (50)    NOT NULL,
    [Description] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Problems] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Problems_Users] FOREIGN KEY (UserId) REFERENCES [Users]([Id])
);

