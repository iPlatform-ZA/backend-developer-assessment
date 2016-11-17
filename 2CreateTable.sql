USE [BackendDeveloperAssessment]
GO
CREATE TABLE [dbo].[Aliases](
	[AliasesId] [int] IDENTITY(1,1) NOT NULL,
	[AliasName] [nvarchar](max) NULL,
	[ArtistId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Aliases] PRIMARY KEY CLUSTERED 
(
	[AliasesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artists]    Script Date: 04-Nov-16 12:28:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [nvarchar](max) NULL,
	[UniqueIdentifier] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
