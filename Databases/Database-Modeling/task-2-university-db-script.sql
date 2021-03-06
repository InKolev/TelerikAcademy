USE [master]
GO
/****** Object:  Database [Homework-Database-Modeling-University]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
CREATE DATABASE [Homework-Database-Modeling-University]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Homework-Database-Modeling-University', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Homework-Database-Modeling-University.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Homework-Database-Modeling-University_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Homework-Database-Modeling-University_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Homework-Database-Modeling-University].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET ARITHABORT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET RECOVERY FULL 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET  MULTI_USER 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Homework-Database-Modeling-University', N'ON'
GO
USE [Homework-Database-Modeling-University]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[id] [int] NOT NULL,
	[department_id] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CoursesInProfessors]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursesInProfessors](
	[professor_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
 CONSTRAINT [PK_CoursesInProfessors] PRIMARY KEY CLUSTERED 
(
	[professor_id] ASC,
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DepartmentsInFaculties]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentsInFaculties](
	[department_id] [int] NOT NULL,
	[faculty_id] [int] NOT NULL,
 CONSTRAINT [PK_DepartmentsInFaculties] PRIMARY KEY CLUSTERED 
(
	[department_id] ASC,
	[faculty_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfessorsInDepartments]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorsInDepartments](
	[department_id] [int] NOT NULL,
	[professor_id] [int] NOT NULL,
 CONSTRAINT [PK_ProfessorsInDepartments] PRIMARY KEY CLUSTERED 
(
	[department_id] ASC,
	[professor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[faculty_number] [nchar](9) NOT NULL,
	[faculty_id] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentsInCourses]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsInCourses](
	[student_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
 CONSTRAINT [PK_StudentsInCourses] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC,
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TitlesInProfessors]    Script Date: 8.10.2015 г. 00:07:49 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TitlesInProfessors](
	[professor_id] [int] NOT NULL,
	[title_id] [int] NOT NULL,
 CONSTRAINT [PK_TitlesInProfessors] PRIMARY KEY CLUSTERED 
(
	[professor_id] ASC,
	[title_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([department_id])
REFERENCES [dbo].[Departments] ([id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[CoursesInProfessors]  WITH CHECK ADD  CONSTRAINT [FK_CoursesInProfessors_Courses] FOREIGN KEY([course_id])
REFERENCES [dbo].[Courses] ([id])
GO
ALTER TABLE [dbo].[CoursesInProfessors] CHECK CONSTRAINT [FK_CoursesInProfessors_Courses]
GO
ALTER TABLE [dbo].[CoursesInProfessors]  WITH CHECK ADD  CONSTRAINT [FK_CoursesInProfessors_Professors] FOREIGN KEY([professor_id])
REFERENCES [dbo].[Professors] ([id])
GO
ALTER TABLE [dbo].[CoursesInProfessors] CHECK CONSTRAINT [FK_CoursesInProfessors_Professors]
GO
ALTER TABLE [dbo].[DepartmentsInFaculties]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentsInFaculties_Departments] FOREIGN KEY([department_id])
REFERENCES [dbo].[Departments] ([id])
GO
ALTER TABLE [dbo].[DepartmentsInFaculties] CHECK CONSTRAINT [FK_DepartmentsInFaculties_Departments]
GO
ALTER TABLE [dbo].[DepartmentsInFaculties]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentsInFaculties_Faculties1] FOREIGN KEY([faculty_id])
REFERENCES [dbo].[Faculties] ([id])
GO
ALTER TABLE [dbo].[DepartmentsInFaculties] CHECK CONSTRAINT [FK_DepartmentsInFaculties_Faculties1]
GO
ALTER TABLE [dbo].[ProfessorsInDepartments]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsInDepartments_Departments] FOREIGN KEY([department_id])
REFERENCES [dbo].[Departments] ([id])
GO
ALTER TABLE [dbo].[ProfessorsInDepartments] CHECK CONSTRAINT [FK_ProfessorsInDepartments_Departments]
GO
ALTER TABLE [dbo].[ProfessorsInDepartments]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsInDepartments_Professors] FOREIGN KEY([professor_id])
REFERENCES [dbo].[Professors] ([id])
GO
ALTER TABLE [dbo].[ProfessorsInDepartments] CHECK CONSTRAINT [FK_ProfessorsInDepartments_Professors]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([faculty_id])
REFERENCES [dbo].[Faculties] ([id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
ALTER TABLE [dbo].[StudentsInCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentsInCourses_Courses] FOREIGN KEY([course_id])
REFERENCES [dbo].[Courses] ([id])
GO
ALTER TABLE [dbo].[StudentsInCourses] CHECK CONSTRAINT [FK_StudentsInCourses_Courses]
GO
ALTER TABLE [dbo].[StudentsInCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentsInCourses_Students] FOREIGN KEY([student_id])
REFERENCES [dbo].[Students] ([id])
GO
ALTER TABLE [dbo].[StudentsInCourses] CHECK CONSTRAINT [FK_StudentsInCourses_Students]
GO
ALTER TABLE [dbo].[TitlesInProfessors]  WITH CHECK ADD  CONSTRAINT [FK_TitlesInProfessors_Professors] FOREIGN KEY([professor_id])
REFERENCES [dbo].[Professors] ([id])
GO
ALTER TABLE [dbo].[TitlesInProfessors] CHECK CONSTRAINT [FK_TitlesInProfessors_Professors]
GO
ALTER TABLE [dbo].[TitlesInProfessors]  WITH CHECK ADD  CONSTRAINT [FK_TitlesInProfessors_Titles] FOREIGN KEY([title_id])
REFERENCES [dbo].[Titles] ([id])
GO
ALTER TABLE [dbo].[TitlesInProfessors] CHECK CONSTRAINT [FK_TitlesInProfessors_Titles]
GO
USE [master]
GO
ALTER DATABASE [Homework-Database-Modeling-University] SET  READ_WRITE 
GO
