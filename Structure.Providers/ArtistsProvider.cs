
namespace Structure.Providers
{
    using Contracts;
    using Factories;

    public class ArtistsProvider : IArtistsProvider
    {
        /// <summary>
        /// Searches for the first match for the given artist search arguments.
        /// </summary>
        /// <param name="searchArgs">The search arguments.</param>
        /// <returns>
        /// A PagedResultSet<Contracts.Artist>
        /// </returns>
        public PagedResultSet<Artist> Search(ArtistSearchArgs searchArgs, PagingArgs paging)
        {
            var adapter = ArtistsFactory.GetAdapter();
            return adapter.Search(searchArgs, paging);
        }
    }
}
