CREATE TABLE [dbo].[UserProblems] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [ProblemId] UNIQUEIDENTIFIER NOT NULL,
    [Order]     INT              NOT NULL,
    CONSTRAINT [PK_UserProblems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserProblems_Problems] FOREIGN KEY ([ProblemId]) REFERENCES [dbo].[Problems] ([Id]),
    CONSTRAINT [FK_UserProblems_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

