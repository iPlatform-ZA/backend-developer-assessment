use Assessment
go

------------------
--Insert Countries
------------------

if not exists (select * from Countries where Country = 'US')
	begin
		insert into Countries (Country) values ('US')
	end

if not exists (select * from Countries where Country = 'GB')
	begin
		insert into Countries (Country) values ('GB')
	end

go

-----------------
--Insert Artists
-----------------

declare @identity bigint

--Metallica
if not exists (select * from Artists where [UniqueIdentifier] = '65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Metallica',
			'65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Metalica')
				insert into ArtistAliases (ArtistID, Alias) values (@identity, N'메탈리카')
			end
	end

--Lady Gaga
if not exists (select * from Artists where [UniqueIdentifier] = '650e7db6-b795-4eb5-a702-5ea2fc46c848')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Lady Gaga',
			'650e7db6-b795-4eb5-a702-5ea2fc46c848',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Lady Ga Ga')
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Stefani Joanne Angelina Germanotta')
			end
	end

--Mumford & Sons
if not exists (select * from Artists where [UniqueIdentifier] = 'c44e9c22-ef82-4a77-9bcd-af6c958446d6')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Mumford & Sons',
			'c44e9c22-ef82-4a77-9bcd-af6c958446d6',
			(select top 1 CountryID from Countries where Country = 'GB')
		)
	end

--Mott the Hoople
if not exists (select * from Artists where [UniqueIdentifier] = '435f1441-0f43-479d-92db-a506449a686b')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Mott the Hoople',
			'435f1441-0f43-479d-92db-a506449a686b',
			(select top 1 CountryID from Countries where Country = 'GB')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Mott The Hoppie')
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Mott The Hopple')
			end
	end

--Megadeth 
if not exists (select * from Artists where [UniqueIdentifier] = 'a9044915-8be3-4c7e-b11f-9e2d2ea0a91e')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Megadeth',
			'a9044915-8be3-4c7e-b11f-9e2d2ea0a91e',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Megadeath')
			end
	end

--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = 'b625448e-bf4a-41c3-a421-72ad46cdb831')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'John Coltrane',
			'b625448e-bf4a-41c3-a421-72ad46cdb831',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'John Coltraine')
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'John William Coltrane')
			end
	end

--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = 'b625448e-bf4a-41c3-a421-72ad46cdb831')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Mogwai',
			'b625448e-bf4a-41c3-a421-72ad46cdb831',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Mogwa')
			end
	end

--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = 'd700b3f5-45af-4d02-95ed-57d301bda93e')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Mogwai',
			'd700b3f5-45af-4d02-95ed-57d301bda93e',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Mogwa')
			end
	end

--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = '144ef525-85e9-40c3-8335-02c32d0861f3')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'John Mayer',
			'144ef525-85e9-40c3-8335-02c32d0861f3',
			(select top 1 CountryID from Countries where Country = 'US')
		)
	end

--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = '18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Johnny Cash',
			'18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Johhny Cash')
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Jonny Cash')
			end
	end
	
--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = '6456a893-c1e9-4e3d-86f7-0008b0a3ac8a')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Jack Johnson',
			'6456a893-c1e9-4e3d-86f7-0008b0a3ac8a',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Jack Hody Johnson')
			end
	end
	
--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = 'f1571db1-c672-4a54-a2cf-aaa329f26f0b')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'John Frusciante',
			'f1571db1-c672-4a54-a2cf-aaa329f26f0b',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'John Anthony Frusciante')
			end
	end																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																						
																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																											
--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = 'b83bc61f-8451-4a5d-8b8e-7e9ed295e822')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Elton John',
			'b83bc61f-8451-4a5d-8b8e-7e9ed295e822',
			(select top 1 CountryID from Countries where Country = 'GB')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Elthon John')
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Elton Jphn')
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'John Elton')
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Reginald Kenneth Dwight')
			end
	end																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																										
																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																											
--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = '24f8d8a5-269b-475c-a1cb-792990b0b2ee')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Rancid',
			'24f8d8a5-269b-475c-a1cb-792990b0b2ee',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, N'ランシド')
			end
	end																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																								
					
--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = '29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Transplants',
			'29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'The Transplants')
			end
	end

--All the young dudes carry the news 
if not exists (select * from Artists where [UniqueIdentifier] = '931e1d1f-6b2f-4ff8-9f70-aa537210cd46')
	begin
		insert into Artists (Name, [UniqueIdentifier], CountryID)
		values
		(
			'Operation Ivy',
			'931e1d1f-6b2f-4ff8-9f70-aa537210cd46',
			(select top 1 CountryID from Countries where Country = 'US')
		)

		select @identity = scope_identity();

		--Insert Aliases
		if not exists (select ArtistID from ArtistAliases where ArtistID = @identity)
			begin
				insert into ArtistAliases (ArtistID, Alias) values (@identity, 'Op Ivy')
			end
	end

go