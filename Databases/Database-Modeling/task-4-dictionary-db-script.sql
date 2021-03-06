USE [master]
GO
/****** Object:  Database [Homework-Database-Modeling-Dictionary]    Script Date: 8.10.2015 г. 00:05:06 ч. ******/
CREATE DATABASE [Homework-Database-Modeling-Dictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Homework-Database-Modeling-Dictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Homework-Database-Modeling-Dictionary.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Homework-Database-Modeling-Dictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Homework-Database-Modeling-Dictionary_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Homework-Database-Modeling-Dictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET  MULTI_USER 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Homework-Database-Modeling-Dictionary', N'ON'
GO
USE [Homework-Database-Modeling-Dictionary]
GO
/****** Object:  Table [dbo].[Dictionaries]    Script Date: 8.10.2015 г. 00:05:06 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dictionaries](
	[id] [int] NOT NULL,
	[title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Dictionaries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 8.10.2015 г. 00:05:06 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[id] [int] NOT NULL,
	[explanation_text] [nvarchar](350) NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 8.10.2015 г. 00:05:06 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[id] [int] NOT NULL,
	[language_text] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LanguagesInExplanations]    Script Date: 8.10.2015 г. 00:05:06 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguagesInExplanations](
	[explanation_id] [int] NOT NULL,
	[language_id] [int] NOT NULL,
 CONSTRAINT [PK_LanguagesInExplanations] PRIMARY KEY CLUSTERED 
(
	[explanation_id] ASC,
	[language_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 8.10.2015 г. 00:05:06 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[id] [int] NOT NULL,
	[word_text] [nvarchar](150) NOT NULL,
	[synonim_id] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsInDictionaries]    Script Date: 8.10.2015 г. 00:05:06 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsInDictionaries](
	[dictionary_id] [int] NOT NULL,
	[word_id] [int] NOT NULL,
 CONSTRAINT [PK_WordsInDictionary] PRIMARY KEY CLUSTERED 
(
	[dictionary_id] ASC,
	[word_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsInLanguages]    Script Date: 8.10.2015 г. 00:05:06 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsInLanguages](
	[word_id] [int] NOT NULL,
	[language_id] [int] NOT NULL,
	[translation_id] [int] NOT NULL,
 CONSTRAINT [PK_WordsInLanguages] PRIMARY KEY CLUSTERED 
(
	[word_id] ASC,
	[language_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LanguagesInExplanations]  WITH CHECK ADD  CONSTRAINT [FK_LanguagesInExplanations_Explanations] FOREIGN KEY([explanation_id])
REFERENCES [dbo].[Explanations] ([id])
GO
ALTER TABLE [dbo].[LanguagesInExplanations] CHECK CONSTRAINT [FK_LanguagesInExplanations_Explanations]
GO
ALTER TABLE [dbo].[LanguagesInExplanations]  WITH CHECK ADD  CONSTRAINT [FK_LanguagesInExplanations_Languages] FOREIGN KEY([language_id])
REFERENCES [dbo].[Languages] ([id])
GO
ALTER TABLE [dbo].[LanguagesInExplanations] CHECK CONSTRAINT [FK_LanguagesInExplanations_Languages]
GO
ALTER TABLE [dbo].[WordsInDictionaries]  WITH CHECK ADD  CONSTRAINT [FK_WordsInDictionary_Dictionaries] FOREIGN KEY([dictionary_id])
REFERENCES [dbo].[Dictionaries] ([id])
GO
ALTER TABLE [dbo].[WordsInDictionaries] CHECK CONSTRAINT [FK_WordsInDictionary_Dictionaries]
GO
ALTER TABLE [dbo].[WordsInDictionaries]  WITH CHECK ADD  CONSTRAINT [FK_WordsInDictionary_Words] FOREIGN KEY([word_id])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[WordsInDictionaries] CHECK CONSTRAINT [FK_WordsInDictionary_Words]
GO
ALTER TABLE [dbo].[WordsInLanguages]  WITH CHECK ADD  CONSTRAINT [FK_WordsInLanguages_Languages] FOREIGN KEY([language_id])
REFERENCES [dbo].[Languages] ([id])
GO
ALTER TABLE [dbo].[WordsInLanguages] CHECK CONSTRAINT [FK_WordsInLanguages_Languages]
GO
ALTER TABLE [dbo].[WordsInLanguages]  WITH CHECK ADD  CONSTRAINT [FK_WordsInLanguages_Words] FOREIGN KEY([word_id])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[WordsInLanguages] CHECK CONSTRAINT [FK_WordsInLanguages_Words]
GO
ALTER TABLE [dbo].[WordsInLanguages]  WITH CHECK ADD  CONSTRAINT [FK_WordsInLanguages_Words1] FOREIGN KEY([translation_id])
REFERENCES [dbo].[Words] ([id])
GO
ALTER TABLE [dbo].[WordsInLanguages] CHECK CONSTRAINT [FK_WordsInLanguages_Words1]
GO
USE [master]
GO
ALTER DATABASE [Homework-Database-Modeling-Dictionary] SET  READ_WRITE 
GO
