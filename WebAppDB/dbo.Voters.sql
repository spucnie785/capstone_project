CREATE TABLE [dbo].[Voters] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (50) NOT NULL,
    [Choice]  VARCHAR (50) NOT NULL,
    [Voted]   BIT          DEFAULT ((0)) NULL,
    [LoginId] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([LoginId]) REFERENCES [dbo].[Logins] ([Id])
);

