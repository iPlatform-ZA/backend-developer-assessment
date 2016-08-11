namespace WebApi.Interfaces
{
    public interface IArtistAlbumLinkProvider
    {
        string GetLinkToArtistAlbums<T>(T aritstIdentifier);
    }
}
