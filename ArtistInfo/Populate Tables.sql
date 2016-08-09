USE [ArtistInfo]
GO

CREATE TABLE #TempArtist
(
	Name VARCHAR(50),
	Id UNIQUEIDENTIFIER,
	Country VARCHAR(2)
);

INSERT INTO #TempArtist (Name, Id, Country) VALUES
('Metallica', '65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab', 'US'),
('Lady Gaga', '650e7db6-b795-4eb5-a702-5ea2fc46c848', 'US'),
('Mumford & Sons', 'c44e9c22-ef82-4a77-9bcd-af6c958446d6', 'GB'),
('Mott the Hoople', '435f1441-0f43-479d-92db-a506449a686b', 'GB'),
('Megadeth', 'a9044915-8be3-4c7e-b11f-9e2d2ea0a91e', 'US'),
('John Coltrane', 'b625448e-bf4a-41c3-a421-72ad46cdb831', 'US'),
('Mogwai', 'd700b3f5-45af-4d02-95ed-57d301bda93e', 'GB'),
('John Mayer', '144ef525-85e9-40c3-8335-02c32d0861f3', 'US'),
('Johnny Cash', '18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f', 'US'),
('Jack Johnson', '6456a893-c1e9-4e3d-86f7-0008b0a3ac8a', 'US'),
('John Frusciante', 'f1571db1-c672-4a54-a2cf-aaa329f26f0b', 'US'),
('Elton John', 'b83bc61f-8451-4a5d-8b8e-7e9ed295e822', 'GB'),
('Rancid', '24f8d8a5-269b-475c-a1cb-792990b0b2ee', 'US'),
('Transplants', '29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699', 'US'),
('Operation Ivy', '931e1d1f-6b2f-4ff8-9f70-aa537210cd46', 'US');

CREATE TABLE #TempAlias 
(
	ArtistName VARCHAR(100),
	Alias NVARCHAR(100)
);

INSERT INTO #TempAlias (ArtistName, Alias) VALUES
('Metallica', 'Metalica'),
('Metallica', '메탈리카'),
('Lady Gaga', 'Lady Ga Ga'),
('Lady Gaga', 'Stefani Joanne Angelina Germanotta'),
('Mott the Hoople', 'Mott The Hoppie'),
('Mott the Hoople', 'Mott The Hopple'),
('Megadeth', 'Megadeath'),
('John Coltrane', 'John Coltraine'),
('John Coltrane', 'John William Coltrane'),
('Mogwai', 'Mogwa'),
('Johnny Cash', 'Johhny Cash'),
('Johnny Cash', 'Jonny Cash'),
('Jack Johnson', 'Jack Hody Johnson'),
('John Frusciante', 'John Anthony Frusciante'),
('Elton John', 'E. John'),
('Elton John', 'Elthon John'),
('Elton John', 'Elton Jphn'),
('Elton John', 'John Elton'),
('Elton John', 'Reginald Kenneth Dwight'),
('Rancid', 'ランシド'),
('Transplants', 'The Transplants'),
('Operation Ivy', 'Op Ivy');

INSERT INTO Country (Code)
SELECT DISTINCT Country  
FROM #TempArtist
ORDER BY Country;

INSERT INTO Artist (Id, Name, CountryId)
SELECT ta.Id, ta.Name, c.Id
FROM  #TempArtist ta
INNER JOIN Country c ON ta.Country = c.Code
ORDER BY ta.Name, ta.Country;

INSERT INTO ArtistAlias (ArtistId, Alias)
SELECT a.Id, ta.Alias
FROM #TempAlias ta 
INNER JOIN Artist a ON ta.ArtistName = a.Name
ORDER BY a.Name, ta.Alias;
GO