USE [master]
GO
/****** Object:  Database [MusicBrainz]    Script Date: 2017/01/23 11:03:54 PM ******/
CREATE DATABASE [MusicBrainz]
GO
ALTER DATABASE [MusicBrainz] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MusicBrainz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

EXEC sys.sp_db_vardecimal_storage_format N'MusicBrainz', N'ON'
GO

USE [MusicBrainz]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2017/01/23 11:03:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 2017/01/23 11:03:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtistName] [nvarchar](255) NULL,
	[UniqueIdentifier] [nvarchar](255) NULL,
	[Country] [nvarchar](255) NULL,
	[Aliases] [nvarchar](255) NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [MusicBrainz] SET  READ_WRITE 
GO
