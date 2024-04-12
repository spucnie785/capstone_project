CREATE TABLE [dbo].[Logins] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
SET IDENTITY_INSERT [dbo].[Logins] ON
INSERT INTO [dbo].[Logins] ([Id], [Username], [Password]) VALUES (1, N'Jake', N'An')
INSERT INTO [dbo].[Logins] ([Id], [Username], [Password]) VALUES (2, N'Dominic', N'Coleman')
INSERT INTO [dbo].[Logins] ([Id], [Username], [Password]) VALUES (3, N'Clara', N'Glock')
INSERT INTO [dbo].[Logins] ([Id], [Username], [Password]) VALUES (4, N'Estefany', N'Nieto')
INSERT INTO [dbo].[Logins] ([Id], [Username], [Password]) VALUES (5, N'Shane', N'Salter')
INSERT INTO [dbo].[Logins] ([Id], [Username], [Password]) VALUES (6, N'Kutay', N'Tiryaki')
SET IDENTITY_INSERT [dbo].[Logins] OFF
