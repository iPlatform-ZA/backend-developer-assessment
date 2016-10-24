
namespace Structure.Contracts
{
    public interface IArtistsProvider
    {
        /// <summary>
        /// Searches for artists given artist search arguments.
        /// </summary>
        /// <param name="searchArgs">The search arguments.</param>
        /// <param name="paging">The paging.</param>
        /// <returns>
        /// A PagedResultSet<Contracts.Artist>
        /// </returns>
        PagedResultSet<Artist> Search(ArtistSearchArgs searchArgs, PagingArgs paging);
    }
}
