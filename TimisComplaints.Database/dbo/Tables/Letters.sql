﻿CREATE TABLE [dbo].[Letters] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [UserId]  UNIQUEIDENTIFIER NOT NULL,
    [Title] NVARCHAR(200) NOT NULL, 
    [Message] NVARCHAR (MAX)   NOT NULL,
    [Date] DATETIME NOT NULL, 
    CONSTRAINT [PK_Letters] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Letters_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

