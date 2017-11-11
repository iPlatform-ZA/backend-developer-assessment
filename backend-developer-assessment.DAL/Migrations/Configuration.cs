namespace backend_developer_assessment.DAL.Migrations
{
    using backend_developer_assessment.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<backend_developer_assessment.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(backend_developer_assessment.DAL.ApplicationDbContext context)
        {
            IList<Artist> artists = new List<Artist>();

            artists.Add(new Artist() { Id = "65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab", ArtistName = "Metallica", CountryCode = "US", ArtistAliases = "Metalica,메탈리카" });
            artists.Add(new Artist() { Id = "c44e9c22-ef82-4a77-9bcd-af6c958446d6", ArtistName = "Mumford & Sons", CountryCode = "GB", ArtistAliases = "" });
            artists.Add(new Artist() { Id = "435f1441-0f43-479d-92db-a506449a686b", ArtistName = "Mott the Hoople", CountryCode = "GB", ArtistAliases = "Mott The Hoppie,Mott The Hopple" });
            artists.Add(new Artist() { Id = "a9044915-8be3-4c7e-b11f-9e2d2ea0a91e", ArtistName = "Megadeth", CountryCode = "US", ArtistAliases = "Megadeath" });
            artists.Add(new Artist() { Id = "b625448e-bf4a-41c3-a421-72ad46cdb831", ArtistName = "John Coltrane", CountryCode = "US", ArtistAliases = "John Coltraine,John William Coltrane" });
            artists.Add(new Artist() { Id = "d700b3f5-45af-4d02-95ed-57d301bda93e", ArtistName = "Mogwai", CountryCode = "GB", ArtistAliases = "Mogwa" });
            artists.Add(new Artist() { Id = "144ef525-85e9-40c3-8335-02c32d0861f3", ArtistName = "John Mayer", CountryCode = "US", ArtistAliases = "" });
            artists.Add(new Artist() { Id = "18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f", ArtistName = "Johnny Cash", CountryCode = "US", ArtistAliases = "Johhny Cash,Jonny Cash" });
            artists.Add(new Artist() { Id = "6456a893-c1e9-4e3d-86f7-0008b0a3ac8a", ArtistName = "Jack Johnson", CountryCode = "US", ArtistAliases = "Jack Hody Johnson" });
            artists.Add(new Artist() { Id = "f1571db1-c672-4a54-a2cf-aaa329f26f0b", ArtistName = "John Frusciante", CountryCode = "US", ArtistAliases = "John Anthony Frusciante" });
            artists.Add(new Artist() { Id = "b83bc61f-8451-4a5d-8b8e-7e9ed295e822", ArtistName = "Elton John", CountryCode = "GB", ArtistAliases = "E. John, Elthon John,Elton Jphn,John Elton, Reginald Kenneth Dwight" });
            artists.Add(new Artist() { Id = "24f8d8a5-269b-475c-a1cb-792990b0b2ee", ArtistName = "Rancid", CountryCode = "US", ArtistAliases = "ランシド" });
            artists.Add(new Artist() { Id = "29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699", ArtistName = "Transplants", CountryCode = "US", ArtistAliases = "The Transplants" });
            artists.Add(new Artist() { Id = "931e1d1f-6b2f-4ff8-9f70-aa537210cd46", ArtistName = "Operation Ivy", CountryCode = "US", ArtistAliases = "Op Ivy" });
            foreach (Artist art in artists)
                context.Artist.Add(art);

            base.Seed(context);
        }
    }
}
