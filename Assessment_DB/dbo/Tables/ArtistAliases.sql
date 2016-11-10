CREATE TABLE [dbo].[ArtistAliases]
(
	[ArtistIdentifier] UNIQUEIDENTIFIER NOT NULL , 
    [Alias] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_ArtistAliases_Artist] FOREIGN KEY ([ArtistIdentifier]) REFERENCES [Artists]([ArtistIdentifier])
)
