USE [master]
GO
/****** Object:  Database [CGCGeneralDB]    Script Date: 23/05/2018 04:05:41 p. m. ******/
CREATE DATABASE [CGCGeneralDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CGCGeneralDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CGCGeneralDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CGCGeneralDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CGCGeneralDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CGCGeneralDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CGCGeneralDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CGCGeneralDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CGCGeneralDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CGCGeneralDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CGCGeneralDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CGCGeneralDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CGCGeneralDB] SET  MULTI_USER 
GO
ALTER DATABASE [CGCGeneralDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CGCGeneralDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CGCGeneralDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CGCGeneralDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CGCGeneralDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CGCGeneralDB', N'ON'
GO
ALTER DATABASE [CGCGeneralDB] SET QUERY_STORE = OFF
GO
USE [CGCGeneralDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

USE [CGCGeneralDB]
GO
/****** Object:  User [CGCOwner]    Script Date: 23/05/2018 04:05:41 p. m. ******/
CREATE USER [CGCOwner] FOR LOGIN [CGCOwner] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [CGCOwner]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [CGCOwner]
GO
ALTER ROLE [db_datareader] ADD MEMBER [CGCOwner]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [CGCOwner]
GO
GRANT CONNECT TO [CGCOwner] AS [dbo]
GO
GRANT VIEW ANY COLUMN ENCRYPTION KEY DEFINITION TO [public] AS [dbo]
GO
GRANT VIEW ANY COLUMN MASTER KEY DEFINITION TO [public] AS [dbo]
GO
/****** Object:  Schema [Bitacora]    Script Date: 23/05/2018 04:05:41 p. m. ******/
CREATE SCHEMA [Bitacora] AUTHORIZATION [CGCOwner]
GO
/****** Object:  Schema [Documento]    Script Date: 23/05/2018 04:05:41 p. m. ******/
CREATE SCHEMA [Documento] AUTHORIZATION [CGCOwner]
GO
/****** Object:  Schema [Seguridad]    Script Date: 23/05/2018 04:05:41 p. m. ******/
CREATE SCHEMA [Seguridad] AUTHORIZATION [CGCOwner]
GO
/****** Object:  Table [Bitacora].[RegMovimientos]    Script Date: 23/05/2018 04:05:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bitacora].[RegMovimientos](
	[IdRegMovimiento] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[IdModulo] [smallint] NOT NULL,
	[TipoMovimiento] [varchar](5) NOT NULL,
	[NombreTabla] [varchar](50) NOT NULL,
	[NombreLlavePrimaria] [varchar](50) NOT NULL,
	[ValorLlavePrimaria] [bigint] NOT NULL,
	[Detalle] [varchar](200) NOT NULL,
	[FechaRegistro] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_RegMovimientos] PRIMARY KEY CLUSTERED 
(
	[IdRegMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [Bitacora].[RegMovimientos] TO  SCHEMA OWNER 
GO
/****** Object:  Table [Bitacora].[RegSesion]    Script Date: 23/05/2018 04:05:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bitacora].[RegSesion](
	[IdRegSesion] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaIniSesion] [smalldatetime] NOT NULL,
	[FechaFinSesion] [smalldatetime] NOT NULL,
	[DuracionSesion] [float] NOT NULL,
 CONSTRAINT [PK_RegSesion] PRIMARY KEY CLUSTERED 
(
	[IdRegSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [Bitacora].[RegSesion] TO  SCHEMA OWNER 
GO
/****** Object:  Table [Bitacora].[RegSesionError]    Script Date: 23/05/2018 04:05:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bitacora].[RegSesionError](
	[IdRegSesionErr] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaSesionErr] [smalldatetime] NOT NULL,
	[CantIntentos] [tinyint] NOT NULL,
 CONSTRAINT [PK_RegSesionError] PRIMARY KEY CLUSTERED 
(
	[IdRegSesionErr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [Bitacora].[RegSesionError] TO  SCHEMA OWNER 
GO
/****** Object:  Table [Documento].[Documentos]    Script Date: 23/05/2018 04:05:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Documento].[Documentos](
	[IdDocumento] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreDoc] [varchar](250) NOT NULL,
	[ExtensionDoc] [varchar](5) NOT NULL,
	[RutaRelativaDoc] [varchar](350) NOT NULL,
	[FechaDoc] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED 
(
	[IdDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [Documento].[Documentos] TO  SCHEMA OWNER 
GO
/****** Object:  Table [Seguridad].[Modulos]    Script Date: 23/05/2018 04:05:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Modulos](
	[IdModulo] [smallint] IDENTITY(1,1) NOT NULL,
	[NombreMod] [varchar](100) NOT NULL,
	[CodigoMod] [nchar](3) NOT NULL,
	[IdModuloPadre] [smallint] NOT NULL,
	[FechaMod] [smalldatetime] NOT NULL,
	[Nivel] [smallint] NOT NULL,
	[InactivoMod] [bit] NOT NULL,
 CONSTRAINT [PK_Modulos] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [Seguridad].[Modulos] TO  SCHEMA OWNER 
GO
/****** Object:  Table [Seguridad].[Permisos]    Script Date: 23/05/2018 04:05:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Permisos](
	[IdPermiso] [smallint] IDENTITY(1,1) NOT NULL,
	[CodigoPerm] [char](3) NOT NULL,
	[NombrePerm] [varchar](100) NOT NULL,
	[DescripPerm] [varchar](250) NOT NULL,
	[FechaPerm] [smalldatetime] NOT NULL,
	[InactivoPerm] [bit] NOT NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [Seguridad].[Permisos] TO  SCHEMA OWNER 
GO
/****** Object:  Table [Seguridad].[PermisosModulos]    Script Date: 23/05/2018 04:05:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[PermisosModulos](
	[IdModulo] [smallint] NOT NULL,
	[IdPermiso] [smallint] NOT NULL,
	[FechaPermiMod] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_PermisosModulos_1] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC,
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [Seguridad].[PermisosModulos] TO  SCHEMA OWNER 
GO
/****** Object:  Table [Seguridad].[Roles]    Script Date: 23/05/2018 04:05:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Roles](
	[IdRol] [smallint] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](50) NOT NULL,
	[DescripcionRol] [varchar](250) NULL,
	[FechaRol] [smalldatetime] NOT NULL,
	[InactivoRol] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [Seguridad].[Roles] TO  SCHEMA OWNER 
GO
ALTER TABLE [Bitacora].[RegMovimientos] ADD  CONSTRAINT [DF_RegMovimientos_IdUsuario]  DEFAULT ((0)) FOR [IdUsuario]
GO
ALTER TABLE [Bitacora].[RegMovimientos] ADD  CONSTRAINT [DF_RegMovimientos_IdModulo]  DEFAULT ((0)) FOR [IdModulo]
GO
ALTER TABLE [Bitacora].[RegSesion] ADD  CONSTRAINT [DF_RegSesion_DuracionSesion]  DEFAULT ((0)) FOR [DuracionSesion]
GO
ALTER TABLE [Bitacora].[RegSesionError] ADD  CONSTRAINT [DF_RegSesionError_CantIntentos]  DEFAULT ((0)) FOR [CantIntentos]
GO
ALTER TABLE [Seguridad].[Modulos] ADD  CONSTRAINT [DF_Modulos_IdModuloPadre]  DEFAULT ((0)) FOR [IdModuloPadre]
GO
ALTER TABLE [Seguridad].[Modulos] ADD  CONSTRAINT [DF_Modulos_Nivel]  DEFAULT ((0)) FOR [Nivel]
GO
ALTER TABLE [Seguridad].[Modulos] ADD  CONSTRAINT [DF_Modulos_InactivoMod]  DEFAULT ((0)) FOR [InactivoMod]
GO
ALTER TABLE [Seguridad].[PermisosModulos] ADD  CONSTRAINT [DF_PermisosModulos_IdModulo]  DEFAULT ((0)) FOR [IdModulo]
GO
ALTER TABLE [Seguridad].[PermisosModulos] ADD  CONSTRAINT [DF_PermisosModulos_IdPermiso]  DEFAULT ((0)) FOR [IdPermiso]
GO
ALTER TABLE [Seguridad].[Roles] ADD  CONSTRAINT [DF_Roles_InactivoRol]  DEFAULT ((0)) FOR [InactivoRol]
GO
ALTER TABLE [Bitacora].[RegMovimientos]  WITH CHECK ADD  CONSTRAINT [FK_RegMovimientos_Modulos] FOREIGN KEY([IdModulo])
REFERENCES [Seguridad].[Modulos] ([IdModulo])
GO
ALTER TABLE [Bitacora].[RegMovimientos] CHECK CONSTRAINT [FK_RegMovimientos_Modulos]
GO
ALTER TABLE [Seguridad].[Modulos]  WITH CHECK ADD  CONSTRAINT [FK_Modulos_Modulos] FOREIGN KEY([IdModuloPadre])
REFERENCES [Seguridad].[Modulos] ([IdModulo])
GO
ALTER TABLE [Seguridad].[Modulos] CHECK CONSTRAINT [FK_Modulos_Modulos]
GO
ALTER TABLE [Seguridad].[PermisosModulos]  WITH CHECK ADD  CONSTRAINT [FK_PermisosModulos_Permisos] FOREIGN KEY([IdPermiso])
REFERENCES [Seguridad].[Permisos] ([IdPermiso])
GO
ALTER TABLE [Seguridad].[PermisosModulos] CHECK CONSTRAINT [FK_PermisosModulos_Permisos]
GO
ALTER TABLE [Seguridad].[PermisosModulos]  WITH CHECK ADD  CONSTRAINT [FK_PermisosModulos_PermisosModulos] FOREIGN KEY([IdModulo])
REFERENCES [Seguridad].[Modulos] ([IdModulo])
GO
ALTER TABLE [Seguridad].[PermisosModulos] CHECK CONSTRAINT [FK_PermisosModulos_PermisosModulos]
GO
ALTER TABLE [Bitacora].[RegMovimientos]  WITH CHECK ADD  CONSTRAINT [CK_RegMovimientos] CHECK  (([TipoMovimiento]='CONSU' OR [TipoMovimiento]='INSER' OR [TipoMovimiento]='MODIF' OR [TipoMovimiento]='ELIMI'))
GO
ALTER TABLE [Bitacora].[RegMovimientos] CHECK CONSTRAINT [CK_RegMovimientos]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Los valores esperados por esta columna consisten en un CHECK CONSTRAINT que espera los siguientes valores: ''CONSU'' = Consulta; ''INSER'' = Nuevo Registro; ''MODIF'' = Registro Modificado; ''ELIMF'' = Registro Eliminado Físicamente; ''ELIML'' = Registro Eliminado Lógicamente' , @level0type=N'SCHEMA',@level0name=N'Bitacora', @level1type=N'TABLE',@level1name=N'RegMovimientos', @level2type=N'COLUMN',@level2name=N'TipoMovimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Corresponde a la acción en específico realizada en la tabla: Valores de registro creados, valores de registro modificados o incluso valores de registro eliminados' , @level0type=N'SCHEMA',@level0name=N'Bitacora', @level1type=N'TABLE',@level1name=N'RegMovimientos', @level2type=N'COLUMN',@level2name=N'Detalle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'''CONSU'' = Consulta; ''INSER'' = Nuevo Registro; ''MODIF'' = Registro Modificado; ''ELIMF'' = Registro Eliminado Físicamente; ''ELIML'' = Registro Eliminado Lógicamente' , @level0type=N'SCHEMA',@level0name=N'Bitacora', @level1type=N'TABLE',@level1name=N'RegMovimientos', @level2type=N'CONSTRAINT',@level2name=N'CK_RegMovimientos'
GO
USE [master]
GO
ALTER DATABASE [CGCGeneralDB] SET  READ_WRITE 
GO
