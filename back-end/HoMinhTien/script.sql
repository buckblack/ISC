USE [master]
GO
/****** Object:  Database [banhang]    Script Date: 2/11/2019 11:27:39 AM ******/
CREATE DATABASE [banhang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'banhang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.TIEN\MSSQL\DATA\banhang.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'banhang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.TIEN\MSSQL\DATA\banhang_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [banhang] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [banhang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [banhang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [banhang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [banhang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [banhang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [banhang] SET ARITHABORT OFF 
GO
ALTER DATABASE [banhang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [banhang] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [banhang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [banhang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [banhang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [banhang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [banhang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [banhang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [banhang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [banhang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [banhang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [banhang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [banhang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [banhang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [banhang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [banhang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [banhang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [banhang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [banhang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [banhang] SET  MULTI_USER 
GO
ALTER DATABASE [banhang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [banhang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [banhang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [banhang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [banhang]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/11/2019 11:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[Customer_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [char](10) NULL,
	[CustomerName] [varchar](50) NULL,
	[CustomerAddress] [varchar](100) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/11/2019 11:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[Product_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductID] [char](10) NULL,
	[ProductName] [varchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Receipt_Items]    Script Date: 2/11/2019 11:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt_Items](
	[ReceiptItem_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Product_ID] [bigint] NULL,
	[Receipt_ID] [bigint] NULL,
	[ProductQuantity] [int] NULL,
	[ProductPrice] [money] NULL,
 CONSTRAINT [PK_Receipt_Items] PRIMARY KEY CLUSTERED 
(
	[ReceiptItem_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Receipts]    Script Date: 2/11/2019 11:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipts](
	[Receipt_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [bigint] NULL,
	[ReceiptDate] [datetime] NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[Receipt_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Customer_ID], [CustomerID], [CustomerName], [CustomerAddress]) VALUES (1, N'1         ', N'Tien', N'HCM')
INSERT [dbo].[Customers] ([Customer_ID], [CustomerID], [CustomerName], [CustomerAddress]) VALUES (2, N'2         ', N'Tien2', N'HN')
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Product_ID], [ProductID], [ProductName]) VALUES (1, N'1         ', N'sp1')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Receipt_Items] ON 

INSERT [dbo].[Receipt_Items] ([ReceiptItem_ID], [Product_ID], [Receipt_ID], [ProductQuantity], [ProductPrice]) VALUES (1, 1, 1, 2, 10000.0000)
INSERT [dbo].[Receipt_Items] ([ReceiptItem_ID], [Product_ID], [Receipt_ID], [ProductQuantity], [ProductPrice]) VALUES (2, 1, 3, 2, 10000.0000)
SET IDENTITY_INSERT [dbo].[Receipt_Items] OFF
SET IDENTITY_INSERT [dbo].[Receipts] ON 

INSERT [dbo].[Receipts] ([Receipt_ID], [Customer_ID], [ReceiptDate]) VALUES (1, 1, CAST(0x0000AAF900000000 AS DateTime))
INSERT [dbo].[Receipts] ([Receipt_ID], [Customer_ID], [ReceiptDate]) VALUES (3, 2, CAST(0x0000AAF800000000 AS DateTime))
INSERT [dbo].[Receipts] ([Receipt_ID], [Customer_ID], [ReceiptDate]) VALUES (4, 1, CAST(0x0000AB0200000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Receipts] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [uni_customer_id]    Script Date: 2/11/2019 11:27:39 AM ******/
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [uni_customer_id] UNIQUE NONCLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [uni_product_id]    Script Date: 2/11/2019 11:27:39 AM ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [uni_product_id] UNIQUE NONCLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Receipt_Items]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Items_Products] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[Products] ([Product_ID])
GO
ALTER TABLE [dbo].[Receipt_Items] CHECK CONSTRAINT [FK_Receipt_Items_Products]
GO
ALTER TABLE [dbo].[Receipt_Items]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Items_Receipts] FOREIGN KEY([Receipt_ID])
REFERENCES [dbo].[Receipts] ([Receipt_ID])
GO
ALTER TABLE [dbo].[Receipt_Items] CHECK CONSTRAINT [FK_Receipt_Items_Receipts]
GO
ALTER TABLE [dbo].[Receipts]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Customers] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customers] ([Customer_ID])
GO
ALTER TABLE [dbo].[Receipts] CHECK CONSTRAINT [FK_Receipts_Customers]
GO
USE [master]
GO
ALTER DATABASE [banhang] SET  READ_WRITE 
GO
