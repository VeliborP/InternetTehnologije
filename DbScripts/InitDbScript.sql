USE [master]
GO
/****** Object:  Database [InternetTehnologije]    Script Date: 28-Dec-23 08:39:24 ******/
CREATE DATABASE [InternetTehnologije]
GO
ALTER DATABASE [InternetTehnologije] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InternetTehnologije].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InternetTehnologije] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InternetTehnologije] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InternetTehnologije] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InternetTehnologije] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InternetTehnologije] SET ARITHABORT OFF 
GO
ALTER DATABASE [InternetTehnologije] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InternetTehnologije] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InternetTehnologije] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InternetTehnologije] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InternetTehnologije] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InternetTehnologije] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InternetTehnologije] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InternetTehnologije] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InternetTehnologije] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InternetTehnologije] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InternetTehnologije] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InternetTehnologije] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InternetTehnologije] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InternetTehnologije] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InternetTehnologije] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InternetTehnologije] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InternetTehnologije] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InternetTehnologije] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InternetTehnologije] SET  MULTI_USER 
GO
ALTER DATABASE [InternetTehnologije] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InternetTehnologije] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InternetTehnologije] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InternetTehnologije] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InternetTehnologije] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InternetTehnologije] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [InternetTehnologije] SET QUERY_STORE = ON
GO
ALTER DATABASE [InternetTehnologije] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [InternetTehnologije]
GO
/****** Object:  Table [dbo].[Predmet]    Script Date: 28-Dec-23 08:39:24 ******/
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
/****** Object:  Table [dbo].[PredmetSmer]    Script Date: 28-Dec-23 08:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PredmetSmer](
	[PredmetId] [int] NOT NULL,
	[SmerId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Smer]    Script Date: 28-Dec-23 08:39:24 ******/
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
/****** Object:  Table [dbo].[Student]    Script Date: 28-Dec-23 08:39:24 ******/
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
