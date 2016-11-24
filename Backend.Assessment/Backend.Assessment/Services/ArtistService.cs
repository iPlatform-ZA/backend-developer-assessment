using System;
using Backend.Assessment.Models;
using Backend.Assessment.Repositories;
using System.Linq;
using System.Collections.Generic;
using Backend.Assessment.DTOs;

namespace Backend.Assessment.Services
{
    public class ArtistService : IArtistService
    {
        private IArtistRepository ArtistRepository { get; set; }
        private IAliasRepository AliasRepository { get; set; }
        private IAlbumRepository AlbumRepository { get; set; }

        public ArtistService(IArtistRepository artistRepository, IAliasRepository aliasRepository, IAlbumRepository albumRepository)
        {
            ArtistRepository = artistRepository;
            AliasRepository = aliasRepository;
            AlbumRepository = albumRepository;
        }

        public ArtistResponse Search(string criteria, int pageNumber, int pageSize)
        {
            var artistResults = ArtistRepository.SearchArtist(criteria);

            var artistListResults = artistResults.OrderBy(a => a.Lastname).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var artistResponse = new ArtistResponse { ArtistCollectionResponse = new List<ArtistCollectionResponse>() };

            foreach (var artistResult in artistListResults)
            {
                artistResponse.ArtistCollectionResponse.Add(new ArtistCollectionResponse
                {
                    Name = string.Concat(artistResult.Firstname, " ", artistResult.Lastname),
                    Country = artistResult.CountryIso,
                    Alias = new List<string>(AliasRepository.GetByArtistId(artistResult.Id).Select(a => a.Text).ToList())
                });

            }

            artistResponse.NumberOfSearchResults = artistResults.Count();

            var numberOfpages = (int)Math.Ceiling((double)artistResponse.NumberOfSearchResults / pageSize);

            artistResponse.Page = pageNumber.ToString();
            artistResponse.PageSize = pageSize.ToString();
            artistResponse.NumberOfPages = numberOfpages.ToString();

            return artistResponse;
        }

        public AlbumResponse GetAlbumByArtist(Guid artistId)
        {
            var albums = AlbumRepository.GetByArtistId(artistId).ToList();

            var albumResponse = new AlbumResponse();


            return albumResponse;

        }


    }
}