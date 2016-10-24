// <copyright file="IArtistsAdapter.cs" company="Structureit">
// Copyright (c) 2016 Structureit. All rights reserved.
// </copyright>
// <summary>Declares the IArtistsAdapter interface</summary>
namespace Structure.Adapters
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for artists adapter.
    /// </summary>
    public interface IArtistsAdapter
    {   
        /// <summary>
        /// Searches for the first match for the given artist search arguments.
        /// </summary>
        /// <param name="searchArgs">The search arguments.</param>
        /// <returns>
        /// A PagedResultSet<Contracts.Artist>
        /// </returns>
        PagedResultSet<Artist> Search(ArtistSearchArgs searchArgs, PagingArgs paging);
    }
}
