USE [master]
GO
/****** Object:  Database [Eboarding]    Script Date: 7/1/2025 5:14:20 PM ******/
CREATE DATABASE [Eboarding]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Eboarding', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Eboarding.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Eboarding_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Eboarding_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Eboarding] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Eboarding].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Eboarding] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Eboarding] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Eboarding] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Eboarding] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Eboarding] SET ARITHABORT OFF 
GO
ALTER DATABASE [Eboarding] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Eboarding] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Eboarding] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Eboarding] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Eboarding] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Eboarding] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Eboarding] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Eboarding] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Eboarding] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Eboarding] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Eboarding] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Eboarding] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Eboarding] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Eboarding] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Eboarding] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Eboarding] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Eboarding] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Eboarding] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Eboarding] SET  MULTI_USER 
GO
ALTER DATABASE [Eboarding] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Eboarding] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Eboarding] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Eboarding] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Eboarding] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Eboarding] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Eboarding] SET QUERY_STORE = ON
GO
ALTER DATABASE [Eboarding] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Eboarding]
GO
/****** Object:  Table [dbo].[Airports]    Script Date: 7/1/2025 5:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airports](
	[AirportId] [int] IDENTITY(1,1) NOT NULL,
	[AirportName] [nvarchar](100) NOT NULL,
	[AirportSignal] [nvarchar](100) NOT NULL,
	[Province] [nvarchar](100) NOT NULL,
	[Destination] [nvarchar](100) NOT NULL,
	[FullDestination] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__Airports__E3DBE0EA74734DC3] PRIMARY KEY CLUSTERED 
(
	[AirportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 7/1/2025 5:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[FlightId] [int] IDENTITY(1,1) NOT NULL,
	[FlightNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Flights__8A9E14EE0039821D] PRIMARY KEY CLUSTERED 
(
	[FlightId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passengers]    Script Date: 7/1/2025 5:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passengers](
	[PassId] [int] IDENTITY(1,1) NOT NULL,
	[PassName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__Passenge__C6740AA88629C925] PRIMARY KEY CLUSTERED 
(
	[PassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 7/1/2025 5:14:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[AirportId] [int] NULL,
	[FlightId] [int] NULL,
	[PassId] [int] NULL,
	[DepartDate] [datetime] NULL,
	[Boarding] [datetime] NULL,
	[SeatNumber] [nvarchar](10) NULL,
	[Gate] [nvarchar](10) NULL,
	[Zone] [nvarchar](10) NULL,
	[Seq] [nvarchar](10) NULL,
 CONSTRAINT [PK__Tickets__712CC6074BA8EB46] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Airports] ON 

INSERT [dbo].[Airports] ([AirportId], [AirportName], [AirportSignal], [Province], [Destination], [FullDestination]) VALUES (1, N'Suratthani Airport', N'URT', N'Suratthani', N'DMK', N'Don Mueang International Airport')
INSERT [dbo].[Airports] ([AirportId], [AirportName], [AirportSignal], [Province], [Destination], [FullDestination]) VALUES (2, N'Don Mueang International Airport', N'DMK', N'Bangkok', N'URT', N'Suratthani Airport')
INSERT [dbo].[Airports] ([AirportId], [AirportName], [AirportSignal], [Province], [Destination], [FullDestination]) VALUES (3, N'Chaing Mai International Airport ', N'CNX', N'Chaing Mai', N'DMK', N'Don Mueang International Airport')
INSERT [dbo].[Airports] ([AirportId], [AirportName], [AirportSignal], [Province], [Destination], [FullDestination]) VALUES (5, N'Don Mueang International Airport', N'DMK', N'Bangkok', N'CNX', N'Chiang Mai International Airport')
SET IDENTITY_INSERT [dbo].[Airports] OFF
GO
SET IDENTITY_INSERT [dbo].[Flights] ON 

INSERT [dbo].[Flights] ([FlightId], [FlightNumber]) VALUES (1, N'FD 3332')
INSERT [dbo].[Flights] ([FlightId], [FlightNumber]) VALUES (4, N'FD 5836')
INSERT [dbo].[Flights] ([FlightId], [FlightNumber]) VALUES (5, N'FD 4236')
SET IDENTITY_INSERT [dbo].[Flights] OFF
GO
SET IDENTITY_INSERT [dbo].[Passengers] ON 

INSERT [dbo].[Passengers] ([PassId], [PassName]) VALUES (1, N'Jiinmy Zahkov')
INSERT [dbo].[Passengers] ([PassId], [PassName]) VALUES (2, N'Kistina Alonosoniva')
INSERT [dbo].[Passengers] ([PassId], [PassName]) VALUES (4, N'Ford Lnwza')
SET IDENTITY_INSERT [dbo].[Passengers] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([TicketId], [AirportId], [FlightId], [PassId], [DepartDate], [Boarding], [SeatNumber], [Gate], [Zone], [Seq]) VALUES (1, 1, 1, 1, CAST(N'2025-05-27T17:59:00.000' AS DateTime), CAST(N'2025-05-27T15:59:00.000' AS DateTime), N'87C', N'39', N'3', N'17')
INSERT [dbo].[Tickets] ([TicketId], [AirportId], [FlightId], [PassId], [DepartDate], [Boarding], [SeatNumber], [Gate], [Zone], [Seq]) VALUES (6, 2, 4, 2, CAST(N'2025-05-27T23:35:00.000' AS DateTime), CAST(N'2025-05-28T01:35:00.000' AS DateTime), N'38A', N'-', N'55', N'17')
INSERT [dbo].[Tickets] ([TicketId], [AirportId], [FlightId], [PassId], [DepartDate], [Boarding], [SeatNumber], [Gate], [Zone], [Seq]) VALUES (8, 3, 5, 4, CAST(N'2025-05-28T00:08:00.000' AS DateTime), CAST(N'2025-05-28T02:08:00.000' AS DateTime), N'6A', N'36', N'13', N'-')
INSERT [dbo].[Tickets] ([TicketId], [AirportId], [FlightId], [PassId], [DepartDate], [Boarding], [SeatNumber], [Gate], [Zone], [Seq]) VALUES (9, 5, 1, 1, CAST(N'2025-05-28T00:35:00.000' AS DateTime), CAST(N'2025-05-28T01:36:00.000' AS DateTime), N'17A', N'20', N'-', N'7')
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK__Tickets__Airport__4CA06362] FOREIGN KEY([AirportId])
REFERENCES [dbo].[Airports] ([AirportId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK__Tickets__Airport__4CA06362]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK__Tickets__FlightI__4D94879B] FOREIGN KEY([FlightId])
REFERENCES [dbo].[Flights] ([FlightId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK__Tickets__FlightI__4D94879B]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK__Tickets__PassId__4E88ABD4] FOREIGN KEY([PassId])
REFERENCES [dbo].[Passengers] ([PassId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK__Tickets__PassId__4E88ABD4]
GO
USE [master]
GO
ALTER DATABASE [Eboarding] SET  READ_WRITE 
GO
