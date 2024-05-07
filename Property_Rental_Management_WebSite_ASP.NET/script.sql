USE [master]
GO
/****** Object:  Database [PropertyRentalManagementDB]    Script Date: 11/30/2023 3:43:42 PM ******/
CREATE DATABASE [PropertyRentalManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PropertyRentalManagementDB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PropertyRentalManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PropertyRentalManagementDB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PropertyRentalManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PropertyRentalManagementDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PropertyRentalManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PropertyRentalManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PropertyRentalManagementDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [PropertyRentalManagementDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PropertyRentalManagementDB]
GO
/****** Object:  Table [dbo].[Apartments]    Script Date: 11/30/2023 3:43:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartments](
	[ApartmentId] [int] NOT NULL,
	[BuildingId] [int] NOT NULL,
	[ApartmentNumber] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ApartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 11/30/2023 3:43:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] NOT NULL,
	[PropertyManagerId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[ApartmentId] [int] NOT NULL,
	[AppointmentDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 11/30/2023 3:43:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[BuildingId] [int] NOT NULL,
	[BuildingName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 11/30/2023 3:43:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [int] NOT NULL,
	[SenderId] [int] NOT NULL,
	[ReceiverId] [int] NOT NULL,
	[Content] [text] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 11/30/2023 3:43:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[StatusId] [int] NOT NULL,
	[Description] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/30/2023 3:43:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[UserType] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 11/30/2023 3:43:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[UserTypeId] [int] NOT NULL,
	[UserTypeDescription] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [ApartmentNumber], [StatusId], [Description]) VALUES (1, 2, 101, 3, N'3 and half')
INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [ApartmentNumber], [StatusId], [Description]) VALUES (2, 1, 102, 5, N'near metro')
INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [ApartmentNumber], [StatusId], [Description]) VALUES (3, 2, 201, 3, N'no fourniture')
INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [ApartmentNumber], [StatusId], [Description]) VALUES (4, 1, 1002, 1, N'800 per month')
GO
INSERT [dbo].[Appointments] ([AppointmentId], [PropertyManagerId], [TenantId], [ApartmentId], [AppointmentDateTime]) VALUES (1, 2, 3, 1, CAST(N'2023-11-17T10:00:00.000' AS DateTime))
INSERT [dbo].[Appointments] ([AppointmentId], [PropertyManagerId], [TenantId], [ApartmentId], [AppointmentDateTime]) VALUES (2, 2, 3, 2, CAST(N'2023-11-18T14:30:00.000' AS DateTime))
INSERT [dbo].[Appointments] ([AppointmentId], [PropertyManagerId], [TenantId], [ApartmentId], [AppointmentDateTime]) VALUES (3, 2, 2, 2, CAST(N'2023-11-09T23:04:00.000' AS DateTime))
GO
INSERT [dbo].[Buildings] ([BuildingId], [BuildingName]) VALUES (1, N'Building A')
INSERT [dbo].[Buildings] ([BuildingId], [BuildingName]) VALUES (2, N'Building B')
INSERT [dbo].[Buildings] ([BuildingId], [BuildingName]) VALUES (3, N'b3')
GO
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [Timestamp]) VALUES (1, 5, 2, N'Interested in Apartment 101', CAST(N'2023-11-17T09:30:00.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [Timestamp]) VALUES (2, 2, 3, N'Appointment confirmed for Apartment 101', CAST(N'2023-11-17T10:30:00.000' AS DateTime))
GO
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (1, N'Activated')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (2, N'Inactivated')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (3, N'Available')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (4, N'Rented')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (5, N'Pending')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (6, N'InProcess')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (7, N'Completed')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (8, N'Cancelled')
GO
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [UserType], [StatusId]) VALUES (1, N'Owner1', N'123', 1, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [UserType], [StatusId]) VALUES (2, N'Manager1', N'123', 2, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [UserType], [StatusId]) VALUES (3, N'Tenant1', N'123', 3, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [UserType], [StatusId]) VALUES (4, N'Owner2', N'123', 1, 2)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [UserType], [StatusId]) VALUES (5, N'test', N'111', 3, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [UserType], [StatusId]) VALUES (8, N'Tenant2', N'123', 3, 2)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [UserType], [StatusId]) VALUES (9, N'Owner3', N'123', 3, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [UserType], [StatusId]) VALUES (10, N'test1', N'123', 3, 1)
GO
INSERT [dbo].[UserTypes] ([UserTypeId], [UserTypeDescription]) VALUES (1, N'Owner')
INSERT [dbo].[UserTypes] ([UserTypeId], [UserTypeDescription]) VALUES (2, N'Property Manager')
INSERT [dbo].[UserTypes] ([UserTypeId], [UserTypeDescription]) VALUES (3, N'Tenant')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Users]    Script Date: 11/30/2023 3:43:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UC_Users] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([BuildingId])
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([StatusId])
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartments] ([ApartmentId])
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([PropertyManagerId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([TenantId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD FOREIGN KEY([ReceiverId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD FOREIGN KEY([SenderId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([StatusId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([UserType])
REFERENCES [dbo].[UserTypes] ([UserTypeId])
GO
USE [master]
GO
ALTER DATABASE [PropertyRentalManagementDB] SET  READ_WRITE 
GO
