/* =========================================================================================
	Script		: 03_StaticData_Artists
	Description : Insert artists information in Artist table.
 ========================================================================================= */
USE ArtistDB
GO 

-- If table already exists, create the records
IF EXISTS(SELECT TOP 1 1 FROM SYS.TABLES WHERE NAME LIKE 'Artist')
BEGIN
	-- Delete the existing rows
	DELETE FROM dbo.Artist

	-- ============================================================================================
	-- 2. Insert the artists information
	-- ============================================================================================
	INSERT INTO dbo.Artist (Id, Name, CountryCode, Aliases)
	VALUES  ('65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab', 'Metallica', 'US', N'Metalica,메탈리카'),
			('650e7db6-b795-4eb5-a702-5ea2fc46c848', 'Lady Gaga', 'US', N'Lady Ga Ga,Stefani Joanne Angelina Germanotta'),
			('c44e9c22-ef82-4a77-9bcd-af6c958446d6', 'Mumford & Sons', 'GB', NULL),
			('435f1441-0f43-479d-92db-a506449a686b', 'Mott the Hoople', 'GB', N'Mott The Hoppie,Mott The Hopple'),
			('a9044915-8be3-4c7e-b11f-9e2d2ea0a91e', 'Megadeth', 'US', N'Megadeath'),
			('b625448e-bf4a-41c3-a421-72ad46cdb831', 'John Coltrane', 'US', N'John Coltraine,John William Coltrane'),
			('d700b3f5-45af-4d02-95ed-57d301bda93e', 'Mogwai', 'GB', N'Mogwa'),
			('144ef525-85e9-40c3-8335-02c32d0861f3', 'John Mayer', 'US', NULL),
			('18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f', 'Johnny Cash', 'US', N'Johhny Cash,Jonny Cash'),
			('6456a893-c1e9-4e3d-86f7-0008b0a3ac8a', 'Jack Johnson', 'US', N'Jack Hody Johnson'),
			('f1571db1-c672-4a54-a2cf-aaa329f26f0b', 'John Frusciante', 'US', N'John Anthony Frusciante'),
			('b83bc61f-8451-4a5d-8b8e-7e9ed295e822', 'Elton John', 'GB', N'E. John, Elthon John,Elton Jphn,John Elton, Reginald Kenneth Dwight'),
			('24f8d8a5-269b-475c-a1cb-792990b0b2ee', 'Rancid', 'US', N'ランシド'),
			('29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699', 'Transplants', 'US', N'The Transplants'),
			('931e1d1f-6b2f-4ff8-9f70-aa537210cd46', 'Operation Ivy', 'US', N'Op Ivy')
END
