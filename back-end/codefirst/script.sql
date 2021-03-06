USE [master]
GO
/****** Object:  Database [codefist]    Script Date: 3/4/2019 4:50:43 PM ******/
CREATE DATABASE [codefist]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'codefist', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.TIEN\MSSQL\DATA\codefist.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'codefist_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.TIEN\MSSQL\DATA\codefist_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [codefist] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [codefist].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [codefist] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [codefist] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [codefist] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [codefist] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [codefist] SET ARITHABORT OFF 
GO
ALTER DATABASE [codefist] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [codefist] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [codefist] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [codefist] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [codefist] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [codefist] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [codefist] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [codefist] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [codefist] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [codefist] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [codefist] SET  ENABLE_BROKER 
GO
ALTER DATABASE [codefist] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [codefist] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [codefist] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [codefist] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [codefist] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [codefist] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [codefist] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [codefist] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [codefist] SET  MULTI_USER 
GO
ALTER DATABASE [codefist] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [codefist] SET DB_CHAINING OFF 
GO
ALTER DATABASE [codefist] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [codefist] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [codefist]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/4/2019 4:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Majors]    Script Date: 3/4/2019 4:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Majors](
	[MajorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Majors] PRIMARY KEY CLUSTERED 
(
	[MajorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 3/4/2019 4:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[StudentName] [ntext] NULL,
	[MajorID] [int] NOT NULL,
	[ImagePath] [nvarchar](255) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/4/2019 4:50:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](255) NULL,
	[FullName] [nvarchar](100) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190215045103_EFCoreCodeFirstSample.Models.Db', N'2.2.1-servicing-10028')
SET IDENTITY_INSERT [dbo].[Majors] ON 

INSERT [dbo].[Majors] ([MajorID], [Name]) VALUES (2, N'Marketing')
INSERT [dbo].[Majors] ([MajorID], [Name]) VALUES (3, N'Accounting')
SET IDENTITY_INSERT [dbo].[Majors] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (2, N'SV1', N'Nguyễn Văn A', 2, NULL)
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (3, N'SV2', N'Nguyễn Văn B', 3, NULL)
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (5, N'SV4', N'Nguyễn Văn D', 2, NULL)
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (6, N'SV4', N'Nguyễn Văn D', 2, NULL)
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (7, N'SV4', N'Nguyễn Văn D', 2, NULL)
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (10, N'SV5', N'Nguyễn Văn EE', 2, N'10_23-5-19-codedolineChaythuDethiVanvan.rar')
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (11, N'SV6', N'Nguyễn Văn E6', 2, NULL)
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (12, N'SV7', N'Nguyễn Văn E7', 2, NULL)
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (13, N'SV7', N'Nguyễn Văn E7', 2, NULL)
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (14, N'SV7', N'Nguyễn Văn E7', 2, NULL)
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (15, N'SV7', N'Nguyễn Văn E8', 2, NULL)
INSERT [dbo].[Students] ([StudentID], [Code], [StudentName], [MajorID], [ImagePath]) VALUES (16, N'SV7', N'Nguyễn Văn E7', 2, NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Password], [FullName]) VALUES (2, N'admin', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', N'Tiến')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Index [IX_Students_MajorID]    Script Date: 3/4/2019 4:50:43 PM ******/
CREATE NONCLUSTERED INDEX [IX_Students_MajorID] ON [dbo].[Students]
(
	[MajorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Majors_MajorID] FOREIGN KEY([MajorID])
REFERENCES [dbo].[Majors] ([MajorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Majors_MajorID]
GO
USE [master]
GO
ALTER DATABASE [codefist] SET  READ_WRITE 
GO
