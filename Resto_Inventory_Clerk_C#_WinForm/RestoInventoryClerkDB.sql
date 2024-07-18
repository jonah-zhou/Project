USE [RestoInventoryClerkDB]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12/1/2023 2:00:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmployeeInformations] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventories]    Script Date: 12/1/2023 2:00:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventories](
	[ItemId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[UnitOfMeasure] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modes]    Script Date: 12/1/2023 2:00:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modes](
	[ModeId] [int] NOT NULL,
	[Mode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Modes] PRIMARY KEY CLUSTERED 
(
	[ModeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/1/2023 2:00:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ItemID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[UnitOfMeasure] [nvarchar](50) NOT NULL,
	[OrderDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thresholds]    Script Date: 12/1/2023 2:00:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thresholds](
	[ThresholdId] [int] NOT NULL,
	[ModeId] [int] NOT NULL,
	[ManagerId] [int] NOT NULL,
	[ThresholdNumber] [int] NOT NULL,
	[ThresholdAlarm] [int] NOT NULL,
 CONSTRAINT [PK_Thresholds] PRIMARY KEY CLUSTERED 
(
	[ThresholdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/1/2023 2:00:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[HashedPassword] [nvarchar](max) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (123456, N'Truongg', N'Pham', N'truong123@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (222222, N'Truong', N'Pham', N'truong@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (333333, N'Nan', N'Zhou', N'nan@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (444444, N'Sakshi', N'Patel', N'patelsakshi@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (555555, N'Pargol Da', N'Pooo', N'Pargol@gmail.ca')
GO
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (1, N'Drumstick', 150, CAST(0.59 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (2, N'Wings', 154, CAST(0.19 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (3, N'Popcorns', 46, CAST(2.00 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (4, N'Lettuce', 15, CAST(2.99 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (5, N'Donuts', 126, CAST(5.00 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (6, N'Coconut', 45, CAST(0.95 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (7, N'Chilly', 50, CAST(1.00 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (8, N'123', 89, CAST(8.00 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (9, N'123', 50, CAST(0.95 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (10, N'123', 89, CAST(0.95 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (11, N'Potatos', 200, CAST(8.00 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (12, N'Honey', 50, CAST(5.00 AS Decimal(18, 2)), N'ml')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (13, N'Tomato', 77, CAST(2.00 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (14, N'Egg', 87, CAST(3.00 AS Decimal(18, 2)), N'lb')
GO
INSERT [dbo].[Modes] ([ModeId], [Mode]) VALUES (1, N'vacation')
INSERT [dbo].[Modes] ([ModeId], [Mode]) VALUES (2, N'manually')
GO
INSERT [dbo].[Orders] ([ItemID], [Name], [Quantity], [UnitPrice], [UnitOfMeasure], [OrderDateTime]) VALUES (1, N'Carrot', 3, CAST(3.00 AS Decimal(18, 2)), N'lb', CAST(N'2023-01-15T12:30:00.000' AS DateTime))
INSERT [dbo].[Orders] ([ItemID], [Name], [Quantity], [UnitPrice], [UnitOfMeasure], [OrderDateTime]) VALUES (3, N'Spinach', 6, CAST(3.00 AS Decimal(18, 2)), N'lb', CAST(N'2023-12-01T03:25:23.667' AS DateTime))
GO
INSERT [dbo].[Thresholds] ([ThresholdId], [ModeId], [ManagerId], [ThresholdNumber], [ThresholdAlarm]) VALUES (1, 1, 123456, 20, 30)
GO
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (1111, N'61B3226787D4AB7228D9D9421CBCE202E4B818B80AFF7F79A480FD228B2F3FCE:A05569408FD3A25902F4C5B1FF2926DF:100000:SHA256', N'Admin')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (123456, N'9780685A63DFA524596DA81FB11CE624A5DD204BE25EF048752DC913F1A1A04A:E90ACE22C0B52DF5B272FDBC1F00A8F5:100000:SHA256', N'Manager')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (222222, N'3AEBE0BF07A65F17C5A236AC0BFE11FC7D1A499F2517A375CC4FCCF0587D20BE:CA5B21B73BEFF2DA8F1C1DAD50C23252:100000:SHA256', N'Manager')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (333333, N'9EB3F83EC72881B3DB6635C96D6C4A3E70EDB9FC0835F49EC663D3D0CF4756F7:31E1DB4F10779A06B20AB7F40DF6B03D:100000:SHA256', N'Staff')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (444444, N'67275357983747170272F1469B9341D6C00AC44A4B596892EDC7168360E66FBC:7A15B147CF4C9AEA7176716570691EEF:100000:SHA256', N'Manager')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (555555, N'110D973E2859226802578FEDF896EF023E3274F727030A573CD424F680EDC799:4BD81B1EF852907D0CC80A66C391D3A6:100000:SHA256', N'Manager')
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users]
GO
ALTER TABLE [dbo].[Thresholds]  WITH CHECK ADD  CONSTRAINT [FK_Thresholds_Modes] FOREIGN KEY([ModeId])
REFERENCES [dbo].[Modes] ([ModeId])
GO
ALTER TABLE [dbo].[Thresholds] CHECK CONSTRAINT [FK_Thresholds_Modes]
GO
ALTER TABLE [dbo].[Thresholds]  WITH CHECK ADD  CONSTRAINT [FK_Thresholds_Users] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Thresholds] CHECK CONSTRAINT [FK_Thresholds_Users]
GO
