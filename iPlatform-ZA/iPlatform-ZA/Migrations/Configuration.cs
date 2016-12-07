using iPlatform_ZA.Models;
namespace iPlatform_ZA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<iPlatform_ZA.Models.iPlatform_ZAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(iPlatform_ZA.Models.iPlatform_ZAContext context)
        {
            context.Artists.AddOrUpdate(p => p.Name,
        new Artist
        {
            Name = "Metallica",
            ArtistId = "65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab",
            Country = "US",
            Aliases = "Metalica,메탈리카",


        },
         new Artist
         {
             Name = "Lady Gaga",
             ArtistId = "650e7db6-b795-4eb5-a702-5ea2fc46c848",
             Country = "US",
             Aliases = "Lady Ga Ga,Stefani Joanne Angelina Germanotta",

         },
         new Artist
         {
             Name = "Mumford & Sons",
             ArtistId = "c44e9c22-ef82-4a77-9bcd-af6c958446d6",
             Country = "GB",
             Aliases = "",

         },
         new Artist
         {
             Name = "Mott the Hoople",
             ArtistId = "435f1441-0f43-479d-92db-a506449a686b",
             Country = "GB",
             Aliases = "Mott The Hoppie,Mott The Hopple",

         },
         new Artist
         {
             Name = "Megadeth",
             ArtistId = "a9044915-8be3-4c7e-b11f-9e2d2ea0a91e",
             Country = "US",
             Aliases = "Megadeath",

         },
         new Artist
         {
             Name = "John Coltrane",
             ArtistId = "b625448e-bf4a-41c3-a421-72ad46cdb831",
             Country = "US",
             Aliases = "John Coltraine,John William Coltrane",

         },
         new Artist
         {
             Name = "Mogwai",
             ArtistId = "d700b3f5-45af-4d02-95ed-57d301bda93e",
             Country = "GB",
             Aliases = "Mogwa",

         },
         new Artist
         {
             Name = "John Mayer",
             ArtistId = "144ef525-85e9-40c3-8335-02c32d0861f3",
             Country = "US",
             Aliases = "",

         },
         new Artist
         {
             Name = "Johnny Cash",
             ArtistId = "18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f",
             Country = "US",
             Aliases = "Johhny Cash,Jonny Cash",

         },
         new Artist
         {
             Name = "Jack Johnson",
             ArtistId = "6456a893-c1e9-4e3d-86f7-0008b0a3ac8a",
             Country = "US",
             Aliases = "Jack Hody Johnson",

         },
         new Artist
         {
             Name = "John Frusciante",
             ArtistId = "f1571db1-c672-4a54-a2cf-aaa329f26f0b",
             Country = "US",
             Aliases = "John Anthony Frusciante",

         },
         new Artist
         {
             Name = "Elton John",
             ArtistId = "b83bc61f-8451-4a5d-8b8e-7e9ed295e822",
             Country = "GB",
             Aliases = "E. John, Elthon John,Elton Jphn,John Elton, Reginald Kenneth Dwight",

         },
         new Artist
         {
             Name = "Rancid",
             ArtistId = "24f8d8a5-269b-475c-a1cb-792990b0b2ee",
             Country = "US",
             Aliases = "ランシド",

         },
         new Artist
         {
             Name = "Transplants",
             ArtistId = "29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699",
             Country = "US",
             Aliases = "The Transplants",

         },
         new Artist
         {
             Name = "Operation Ivy",
             ArtistId = "931e1d1f-6b2f-4ff8-9f70-aa537210cd46",
             Country = "US",
             Aliases = "Op Ivy",

         }
         );
        }
    }
}