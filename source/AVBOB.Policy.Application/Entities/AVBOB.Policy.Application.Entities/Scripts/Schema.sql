USE [master]
GO
/****** Object:  Database [AVBOB.Policy.Application]    Script Date: 2023/05/01 11:31:20 ******/
CREATE DATABASE [AVBOB.Policy.Application]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AVBOB.Policy.Application', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AVBOB.Policy.Application.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AVBOB.Policy.Application_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AVBOB.Policy.Application_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AVBOB.Policy.Application] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AVBOB.Policy.Application].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AVBOB.Policy.Application] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET ARITHABORT OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET  MULTI_USER 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AVBOB.Policy.Application] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AVBOB.Policy.Application] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AVBOB.Policy.Application] SET QUERY_STORE = OFF
GO
USE [AVBOB.Policy.Application]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 2023/05/01 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DocumentTypeId] [int] NULL,
	[Title] [nvarchar](max) NOT NULL,
	[OriginalTitle] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Extension] [nvarchar](max) NULL,
	[Size] [nvarchar](max) NULL,
	[DateModified] [datetime] NULL,
	[Url] [nvarchar](max) NOT NULL,
	[iOrder] [int] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Document_Guid] UNIQUE NONCLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 2023/05/01 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[iOrder] [int] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_DocumentType_Guid] UNIQUE NONCLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 2023/05/01 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Policy]    Script Date: 2023/05/01 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PolicyNumber] [varchar](max) NULL,
	[PolicyTypeId] [int] NOT NULL,
	[PolicyHolderId] [int] NOT NULL,
	[CommencementDate] [datetime] NOT NULL,
	[Installment] [varchar](max) NULL,
	[ApplicationFormDocumentId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Policy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PolicyHolder]    Script Date: 2023/05/01 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PolicyHolder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IDNumber] [varchar](max) NULL,
	[Initials] [varchar](max) NULL,
	[Surname] [varchar](max) NULL,
	[DateOfBirth] [varchar](max) NULL,
	[GenderId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_PolicyHolder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PolicyType]    Script Date: 2023/05/01 11:31:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PolicyType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.PolicyType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Document] ADD  CONSTRAINT [DF_Document_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Document] ADD  CONSTRAINT [DF_Document_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[DocumentType] ADD  CONSTRAINT [DF_DocumentType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[DocumentType] ADD  CONSTRAINT [DF_DocumentType_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Gender] ADD  CONSTRAINT [DF_Gender_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Gender] ADD  CONSTRAINT [DF_Gender_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Policy] ADD  CONSTRAINT [DF_Policy_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Policy] ADD  CONSTRAINT [DF_Policy_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[PolicyHolder] ADD  CONSTRAINT [DF_PolicyHolder_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PolicyHolder] ADD  CONSTRAINT [DF_PolicyHolder_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[PolicyType] ADD  CONSTRAINT [DF_PolicyType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PolicyType] ADD  CONSTRAINT [DF_PolicyType_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_DocumentType] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[DocumentType] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_DocumentType]
GO
ALTER TABLE [dbo].[Policy]  WITH CHECK ADD  CONSTRAINT [FK_Policy_Document] FOREIGN KEY([ApplicationFormDocumentId])
REFERENCES [dbo].[Document] ([Id])
GO
ALTER TABLE [dbo].[Policy] CHECK CONSTRAINT [FK_Policy_Document]
GO
ALTER TABLE [dbo].[Policy]  WITH CHECK ADD  CONSTRAINT [FK_Policy_PolicyType] FOREIGN KEY([PolicyTypeId])
REFERENCES [dbo].[PolicyType] ([Id])
GO
ALTER TABLE [dbo].[Policy] CHECK CONSTRAINT [FK_Policy_PolicyType]
GO
ALTER TABLE [dbo].[PolicyHolder]  WITH CHECK ADD  CONSTRAINT [FK_PolicyHolder_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[PolicyHolder] CHECK CONSTRAINT [FK_PolicyHolder_Gender]
GO
ALTER TABLE [dbo].[Policy]  WITH CHECK ADD  CONSTRAINT [FK_Policy_PolicyHolder] FOREIGN KEY([PolicyHolderId])
REFERENCES [dbo].[PolicyHolder] ([Id])
GO
ALTER TABLE [dbo].[Policy] CHECK CONSTRAINT [FK_Policy_PolicyHolder]
GO
USE [master]
GO
ALTER DATABASE [AVBOB.Policy.Application] SET  READ_WRITE 
