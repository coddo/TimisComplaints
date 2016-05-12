CREATE TABLE [dbo].[DistrictProblemAssignments] (
    [DistrictId] UNIQUEIDENTIFIER NOT NULL,
    [ProblemId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_DIstrictProblemAssignments] PRIMARY KEY CLUSTERED ([DistrictId] ASC, [ProblemId] ASC),
    CONSTRAINT [FK_DistrictProblemAssignments_Districts] FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[Districts] ([Id]),
    CONSTRAINT [FK_DistrictProblemAssignments_Problems] FOREIGN KEY ([ProblemId]) REFERENCES [dbo].[Problems] ([Id])
);

