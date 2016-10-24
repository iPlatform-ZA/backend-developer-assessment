namespace Structure.DataSource
{
    using System.Collections.Generic;
    using System.Linq;
    public static class ArtistSearchExtensionMappers
    {
        public static IQueryable<Artist> Search(this IQueryable<Artist> query, Contracts.ArtistSearchArgs search)
        {
            return query
                .ApplyNameFilter(search)
                .ApplyAliasFilter(search)
                .ApplyCountryFilter(search);
        }

        private static IQueryable<Artist> ApplyNameFilter(this IQueryable<Artist> query, Contracts.ArtistSearchArgs search)
        {
            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(artist => artist.Name.Contains(search.Name));
            }
            return query;
        }

        private static IQueryable<Artist> ApplyAliasFilter(this IQueryable<Artist> query, Contracts.ArtistSearchArgs search)
        {
            if (!string.IsNullOrEmpty(search.Alias))
            {
                query = query.Where(artists => artists.ArtistAliases.Any(alias => alias.Name.Contains(search.Alias)));
            }
            return query;
        }

        private static IQueryable<Artist> ApplyCountryFilter(this IQueryable<Artist> query, Contracts.ArtistSearchArgs search)
        {
            if (!string.IsNullOrEmpty(search.Country))
            {
                query = query.Where(artist => artist.Country.Contains(search.Country));
            }
            return query;
        }
    }
}
