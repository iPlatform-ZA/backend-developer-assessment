using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Factories
{
    public class ArtistFactory: IArtistFactory
    {
        private IArtistRepository _artistRepository;
        private IArtistAlbumLinkProvider _artistAlbumLinkProvider;

        public ArtistFactory(IArtistRepository artistRepository, IArtistAlbumLinkProvider artistAlbumLinkProvider)
        {
            _artistRepository = artistRepository;
            _artistAlbumLinkProvider = artistAlbumLinkProvider;
        }

        public IEnumerable<CompositeArtist> FindByNameOrAlias(string nameOrAlias)
        {
            List<CompositeArtist> returnValue = new List<CompositeArtist>();

            var dbArtists = _artistRepository.FindByNameOrAlias(nameOrAlias);

            if (dbArtists.Any())
            {
                returnValue.AddRange(dbArtists.ToList().ConvertAll(i => new CompositeArtist()
                {
                    Alias = i.Alias, 
                    ArtistAlbums = _artistAlbumLinkProvider.GetLinkToArtistAlbums(i.Id),
                    Country = i.Country,
                    Name = i.Name
                }));
            }

            return returnValue;
        }

        public CompositeArtist GetById(Guid id)
        {
            CompositeArtist returnValue = null;

            var dbArtists = _artistRepository.GetById(id);

            if (dbArtists != null)
            {
                returnValue = new CompositeArtist()
                {
                    Alias = dbArtists.Alias,
                    ArtistAlbums = _artistAlbumLinkProvider.GetLinkToArtistAlbums(dbArtists.Id),
                    Country = dbArtists.Country,
                    Name = dbArtists.Name
                };
            }

            return returnValue;
        }
    }
}