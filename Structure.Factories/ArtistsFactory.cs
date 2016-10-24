
namespace Structure.Factories
{
    using Adapters;
    using DataSource;

    /// <summary>
    /// The artists factory.
    /// </summary>
    public static class ArtistsFactory
    {
        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <returns>
        /// The adapter.
        /// </returns>
        public static IArtistsAdapter GetAdapter()
        {
            return new ArtistsAdapter();
        }
    }
}
