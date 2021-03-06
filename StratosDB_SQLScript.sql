CREATE DATABASE [StratosDB]
GO

USE [StratosDB]
GO
CREATE LOGIN [AdministratorUser] WITH PASSWORD=N'P4ssw0rd', 
DEFAULT_DATABASE=[StratosDB], 
DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [AdministratorUser]
GO
ALTER LOGIN [AdministratorUser] ENABLE;
GO

USE [StratosDB]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 14/05/2016 06:58:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Server]    Script Date: 14/05/2016 06:58:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Server](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[URL] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[ClientId] [int] NOT NULL,
 CONSTRAINT [PK_Server] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Name], [Email], [Phone]) VALUES (7, N'Globant', N'hi@globant.com', N'+1 877 215 5230')
INSERT [dbo].[Client] ([Id], [Name], [Email], [Phone]) VALUES (8, N'Neoris', N'info@neoris.com', N'+54-341-512-7400')
INSERT [dbo].[Client] ([Id], [Name], [Email], [Phone]) VALUES (9, N'Rosario Bus', N'info@rosariobus.com.ar', N'+54-341-480-8230')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Server] ON 

INSERT [dbo].[Server] ([Id], [URL], [Username], [Password], [ClientId]) VALUES (18, N'http://192.168.44.155/Server1', N'Admin', N'EjEShwdbUOGwYXIo2P8UqA==', 7)
INSERT [dbo].[Server] ([Id], [URL], [Username], [Password], [ClientId]) VALUES (19, N'http://192.168.44.156/Server2', N'Username', N'dr7t70cOPZtxaJh4cF3sgg==', 7)
INSERT [dbo].[Server] ([Id], [URL], [Username], [Password], [ClientId]) VALUES (20, N'http://192.168.44.157/Server3', N'http://192.168.44.157/Server3', N'dZP6k9MxiSCeVoI0dSxZ3w==', 7)
INSERT [dbo].[Server] ([Id], [URL], [Username], [Password], [ClientId]) VALUES (21, N'http://192.168.31.15/Server1', N'Neoris', N'EjEShwdbUOGwYXIo2P8UqA==', 8)
INSERT [dbo].[Server] ([Id], [URL], [Username], [Password], [ClientId]) VALUES (22, N'http://192.168.31.16/Server2', N'Sudo', N'kHEDIvk1gnFtkvZhPxxnrQ==', 8)
INSERT [dbo].[Server] ([Id], [URL], [Username], [Password], [ClientId]) VALUES (23, N'http://192.168.88.44/Dev', N'RosarioBus', N'VTBFwLoVkM7tDIGSh9NsdA==', 9)
INSERT [dbo].[Server] ([Id], [URL], [Username], [Password], [ClientId]) VALUES (24, N'http://192.168.88.45/QA', N'Admin', N'ZxIcb+489lMpfmCbQy1HnQ==', 9)
SET IDENTITY_INSERT [dbo].[Server] OFF
ALTER TABLE [dbo].[Server]  WITH CHECK ADD  CONSTRAINT [FK_Server_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Server] CHECK CONSTRAINT [FK_Server_Client]
GO
