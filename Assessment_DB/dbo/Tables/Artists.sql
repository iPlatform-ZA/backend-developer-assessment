﻿CREATE TABLE [dbo].[Artists]
(
	[ArtistIdentifier] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Country] NVARCHAR(5) NOT NULL 
)
