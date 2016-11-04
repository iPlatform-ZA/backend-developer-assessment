USE [BackendDeveloperAssessment]
GO
SET IDENTITY_INSERT [dbo].[Aliases] ON 

GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (1, N'Metalica', 1)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (2, N'메탈리카', 1)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (3, N'Lady Ga Ga', 2)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (4, N'Stefani Joanne Angelina Germanotta', 2)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (5, N'Mott The Hoppie', 4)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (6, N'Mott The Hopple', 4)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (7, N'Megadeath', 5)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (8, N'John Coltraine', 6)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (9, N'John William Coltrane', 6)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (10, N'Mogwa', 7)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (11, N'Johhny Cash', 9)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (12, N'Jonny Cash', 9)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (13, N'Jack Hody Johnson', 10)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (14, N'John Anthony Frusciante', 11)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (15, N'E. John', 12)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (16, N'Elthon John', 12)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (17, N'Elton Jphn', 12)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (18, N'John Elton', 12)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (19, N'Reginald Kenneth Dwight', 12)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (20, N'ランシド', 13)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (21, N'The Transplants', 14)
GO
INSERT [dbo].[Aliases] ([AliasesId], [AliasName], [ArtistId]) VALUES (22, N'Op Ivy
', 15)
GO
SET IDENTITY_INSERT [dbo].[Aliases] OFF
GO
SET IDENTITY_INSERT [dbo].[Artists] ON 

GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (1, N'Metallica
', N'65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab
', N'US
')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (2, N'Lady Gaga
', N'650e7db6-b795-4eb5-a702-5ea2fc46c848
', N'US
')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (3, N'Mumford & Sons
', N'c44e9c22-ef82-4a77-9bcd-af6c958446d6
', N'GB
')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (4, N'Mott the Hoople
', N'435f1441-0f43-479d-92db-a506449a686b
', N'GB
')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (5, N'Megadeth
', N'a9044915-8be3-4c7e-b11f-9e2d2ea0a91e
', N'US')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (6, N'John Coltrane
', N'b625448e-bf4a-41c3-a421-72ad46cdb831
', N'US')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (7, N'Mogwai
', N'd700b3f5-45af-4d02-95ed-57d301bda93e
', N'GB')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (8, N'John Mayer
', N'144ef525-85e9-40c3-8335-02c32d0861f3
', N'US')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (9, N'Johnny Cash
', N'18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f
', N'US')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (10, N'Jack Johnson
', N'6456a893-c1e9-4e3d-86f7-0008b0a3ac8a
', N'US')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (11, N'John Frusciante
', N'f1571db1-c672-4a54-a2cf-aaa329f26f0b
', N'US')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (12, N'Elton John
', N'b83bc61f-8451-4a5d-8b8e-7e9ed295e822
', N'GB')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (13, N'Rancid
', N'24f8d8a5-269b-475c-a1cb-792990b0b2ee
', N'US')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (14, N'Transplants
', N'29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699
', N'US')
GO
INSERT [dbo].[Artists] ([ArtistId], [ArtistName], [UniqueIdentifier], [Country]) VALUES (15, N'Operation Ivy
', N'931e1d1f-6b2f-4ff8-9f70-aa537210cd46
', N'US')
GO
SET IDENTITY_INSERT [dbo].[Artists] OFF
GO
ALTER TABLE [dbo].[Aliases]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Aliases_dbo.Artists_ArtistId] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([ArtistId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Aliases] CHECK CONSTRAINT [FK_dbo.Aliases_dbo.Artists_ArtistId]
GO