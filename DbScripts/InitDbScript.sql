/****** Object:  Database [InternetTehnologije]    Script Date: 11-Jan-24 09:27:09 ******/
CREATE DATABASE [InternetTehnologije]

USE [InternetTehnologije]
GO
/****** Object:  Table [dbo].[Predmet]    Script Date: 11-Jan-24 09:27:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Predmet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sifra] [nvarchar](50) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[ESPB] [int] NOT NULL,
 CONSTRAINT [PK_Smer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PredmetSmer]    Script Date: 11-Jan-24 09:27:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PredmetSmer](
	[PredmetId] [int] NOT NULL,
	[SmerId] [int] NOT NULL,
 CONSTRAINT [PK_PredmetSmer] PRIMARY KEY CLUSTERED 
(
	[PredmetId] ASC,
	[SmerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Smer]    Script Date: 11-Jan-24 09:27:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Smer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sifra] [nvarchar](50) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Smer_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 11-Jan-24 09:27:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[BrojIndeksa] [nvarchar](50) NOT NULL,
	[SmerId] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PredmetSmer]  WITH CHECK ADD  CONSTRAINT [FK_Predmet_Smer] FOREIGN KEY([PredmetId])
REFERENCES [dbo].[Predmet] ([Id])
GO
ALTER TABLE [dbo].[PredmetSmer] CHECK CONSTRAINT [FK_Predmet_Smer]
GO
ALTER TABLE [dbo].[PredmetSmer]  WITH CHECK ADD  CONSTRAINT [FK_PredmetSmer_Smer] FOREIGN KEY([SmerId])
REFERENCES [dbo].[Smer] ([Id])
GO
ALTER TABLE [dbo].[PredmetSmer] CHECK CONSTRAINT [FK_PredmetSmer_Smer]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Smer] FOREIGN KEY([SmerId])
REFERENCES [dbo].[Smer] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Smer]
GO
USE [master]
GO
ALTER DATABASE [InternetTehnologije] SET  READ_WRITE 
GO
