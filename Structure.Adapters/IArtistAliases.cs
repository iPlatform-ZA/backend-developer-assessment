// <copyright file="IArtistAliases.cs" company="Structureit">
// Copyright (c) 2016 Structureit. All rights reserved.
// </copyright>
// <summary>Declares the IArtistAliases interface</summary>
namespace Structure.Adapters
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for artist aliases.
    /// </summary>
    public interface IArtistAliases
    {
        /// <summary>
        /// Adds artistId.
        /// </summary>
        /// <param name="artistId">Identifier for the artist.</param>
        /// <param name="name">The name.</param>
        /// <returns>
        /// The ArtistAlias.
        /// </returns>
        ArtistAlias Add(Guid artistId,string name);

        /// <summary>
        /// Gets an artist alias using the given identifier.
        /// </summary>
        /// <param name="id">The identifier to delete.</param>
        /// <returns>
        /// The ArtistAlias.
        /// </returns>
        ArtistAlias Get(Guid id);

        /// <summary>
        /// Gets the matches in this collection.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process the matches in this collection.
        /// </returns>
        IEnumerable<ArtistAlias> GetMatches(string name);

        /// <summary>
        /// Gets by artist identifier.
        /// </summary>
        /// <param name="artistId">Identifier for the artist.</param>
        /// <returns>
        /// The by artist identifier.
        /// </returns>
        ArtistAlias GetByArtistId(Guid artistId);

        /// <summary>
        /// Updates this IArtistAliases.
        /// </summary>
        /// <param name="id">The identifier to delete.</param>
        /// <param name="name">The name.</param>
        /// <returns>
        /// The ArtistAlias.
        /// </returns>
        ArtistAlias Update(Guid id, string name);

        /// <summary>
        /// Deletes the given ID.
        /// </summary>
        /// <param name="id">The identifier to delete.</param>
        /// <returns>
        /// The ArtistAlias.
        /// </returns>
        ArtistAlias Delete(Guid id);
    }
}
