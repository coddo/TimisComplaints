CREATE TABLE [dbo].[Letters] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [UserId]  UNIQUEIDENTIFIER NOT NULL,
    [Message] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Letters] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Letters_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

