// <copyright file="ArtistsExtensionMappers.cs" company="Structureit">
// Copyright (c) 2016 Structureit. All rights reserved.
// </copyright>
// <summary>Implements the artists extension mappers class</summary>
namespace Structure.DataSource
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The artists extension mappers.
    /// </summary>
    public static class ArtistsExtensionMappers
    {
        /// <summary>
        /// Enumerates map in this collection.
        /// </summary>
        /// <param name="artist">The artist to act on.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process map in this collection.
        /// </returns>
        public static Contracts.Artist Map(this Artist artist)
        {
            return new Contracts.Artist
            {
                Name = artist.Name,
                Country = artist.Country,
                Alias = artist.ArtistAliases.Simplify()
            };
        }

        /// <summary>
        /// Enumerates map in this collection.
        /// </summary>
        /// <param name="artists">The artists to act on.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process map in this collection.
        /// </returns>
        public static IEnumerable<Contracts.Artist> Map(this IEnumerable<Artist> artists)
        {
            return artists.Select(artist => artist.Map());
        }
    }
}
