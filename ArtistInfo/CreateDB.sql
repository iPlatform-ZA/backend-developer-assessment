USE [master]
GO

IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = 'ArtistInfo' OR name = 'ArtistInfo')))
BEGIN
	DROP DATABASE ArtistInfo;
END
GO

CREATE DATABASE ArtistInfo
GO

USE ArtistInfo
GO


CREATE TABLE dbo.Country
(
	Id INT IDENTITY(1,1) NOT NULL,
	Code VARCHAR(2) NOT NULL
	CONSTRAINT [PK_Country] PRIMARY KEY (Id),
	CONSTRAINT [UK_Country] UNIQUE(Code)
);

CREATE TABLE dbo.Artist
(
	Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    Name VARCHAR(100) NOT NULL,
	CountryId INT NOT NULL,
	CONSTRAINT [PK_Artist] PRIMARY KEY (Id),
	CONSTRAINT [FK_Artist_Country] FOREIGN KEY (CountryId) REFERENCES dbo.Country (Id)
);

CREATE TABLE dbo.ArtistAlias
(
	Id BIGINT IDENTITY(1,1) NOT NULL,
	ArtistId UNIQUEIDENTIFIER NOT NULL,
	Alias NVARCHAR(50),
	CONSTRAINT [PK_ArtistAlias] PRIMARY KEY (Id),
	CONSTRAINT [UK_ArtistAlias] UNIQUE(ArtistId, Alias),
	CONSTRAINT [FK_ArtistAlias_Artist] FOREIGN KEY (ArtistId) REFERENCES dbo.Artist (Id)
);
GO

USE master
GO

CREATE LOGIN QueryUser WITH PASSWORD = '@5kM3';  
GO

USE ArtistInfo;  
GO  

CREATE USER QueryUser FOR LOGIN QueryUser;  
EXEC sp_addrolemember 'db_datareader', 'QueryUser';
GO   