USE [master]
GO
/****** Object:  Database [Homework-Database-Modeling]    Script Date: 8.10.2015 г. 00:04:25 ч. ******/
CREATE DATABASE [Homework-Database-Modeling]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Homework-Database-Modeling', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Homework-Database-Modeling.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Homework-Database-Modeling_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Homework-Database-Modeling_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Homework-Database-Modeling] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Homework-Database-Modeling].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Homework-Database-Modeling] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET ARITHABORT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Homework-Database-Modeling] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Homework-Database-Modeling] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Homework-Database-Modeling] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Homework-Database-Modeling] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET RECOVERY FULL 
GO
ALTER DATABASE [Homework-Database-Modeling] SET  MULTI_USER 
GO
ALTER DATABASE [Homework-Database-Modeling] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Homework-Database-Modeling] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Homework-Database-Modeling] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Homework-Database-Modeling] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Homework-Database-Modeling] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Homework-Database-Modeling', N'ON'
GO
USE [Homework-Database-Modeling]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 8.10.2015 г. 00:04:25 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [nvarchar](300) NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 8.10.2015 г. 00:04:25 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 8.10.2015 г. 00:04:25 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 8.10.2015 г. 00:04:25 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](100) NOT NULL,
	[last_name] [nvarchar](100) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 8.10.2015 г. 00:04:25 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (1, N'"Ropotamo" street', 1)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([id], [name]) VALUES (1, N'Europe')
INSERT [dbo].[Continent] ([id], [name]) VALUES (2, N'Africa')
INSERT [dbo].[Continent] ([id], [name]) VALUES (3, N'Asia')
INSERT [dbo].[Continent] ([id], [name]) VALUES (4, N'Antarctica')
INSERT [dbo].[Continent] ([id], [name]) VALUES (5, N'South America')
INSERT [dbo].[Continent] ([id], [name]) VALUES (6, N'North America')
INSERT [dbo].[Continent] ([id], [name]) VALUES (7, N'Australia')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (2, N'France', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (3, N'Germany', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (4, N'England', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (5, N'USA', 6)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (6, N'Mexico', 6)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (7, N'Canada', 6)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (8, N'Guatemala', 6)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (9, N'Cuba', 6)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (10, N'Brazil', 5)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (11, N'Colombia', 5)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (12, N'Argentina', 5)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (13, N'Chile', 5)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (14, N'Australia', 7)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (15, N'New Zealand', 7)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (16, N'Fiji', 7)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (17, N'Samoa', 7)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (18, N'Nigeria', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (19, N'Ethiopia', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (20, N'Egypt', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (21, N'Tanzania', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (23, N'South Africa', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (24, N'Madagascar', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (25, N'China', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (26, N'India', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (27, N'Japan', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (30, N'North Korea', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (31, N'South Korea', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (32, N'Israel', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (33, N'Iraq', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (34, N'Iran', 3)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (1, N'Ivan', N'Kolev', 1)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Nelly', N'Koleva', 1)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (3, N'Aneliya', N'Daskalova', 1)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (4, N'Mihail', N'Alexandrov', 1)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (2, N'Plovdiv', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (3, N'Varna', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (4, N'Burgas', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (5, N'Ruse', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (6, N'Paris', 2)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (7, N'Lion', 2)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (8, N'Nice', 2)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (9, N'Marseille', 2)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (10, N'London', 4)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (11, N'New York', 5)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (12, N'Chicago', 5)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (13, N'Berlin', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (14, N'Haburg', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (15, N'Munich', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (16, N'Cologne', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (17, N'Frankfurt', 3)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [Homework-Database-Modeling] SET  READ_WRITE 
GO
