// <copyright file="ArtistsAdapter.cs" company="Structureit">
// Copyright (c) 2016 Structureit. All rights reserved.
// </copyright>
// <summary>Implements the artists adapter class</summary>
namespace Structure.DataSource
{
    using Adapters;
    using Contracts;

    /// <summary>
    /// The artists adapter.
    /// </summary>
    public class ArtistsAdapter : IArtistsAdapter
    {
        /// <summary>
        /// The context.
        /// </summary>
        private StructureContext _context;

        /// <summary>
        /// Gets the context.
        /// </summary>
        private StructureContext context
        {
            get
            {
                return _context ?? (_context = new StructureContext());
            }
        }

        public PagedResultSet<Contracts.Artist> Search(ArtistSearchArgs searchArgs, PagingArgs paging)
        {
            var results = context.Artists.Search(searchArgs)
                .ApplyPaging(paging, artist => artist.Name);

            return new PagedResultSet<Contracts.Artist>
            {
                NumberOfPages = results.NumberOfPages,
                NumberOfSearchResults = results.NumberOfSearchResults,
                Page = results.Page,
                PageSize = results.PageSize,
                Results = results.Results.Map()
            };
        }

    }
}
