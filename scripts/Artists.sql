USE [MusicBrainz]
GO

/****** Object:  Table [dbo].[Artists]    Script Date: 2017/11/11 15:30:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Artists](
	[Id] [nvarchar](128) NOT NULL,
	[ArtistName] [nvarchar](1024) NOT NULL,
	[CountryCode] [nvarchar](5) NULL,
	[ArtistAliases] [nvarchar](1024) NULL,
 CONSTRAINT [PK_dbo.Artists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

