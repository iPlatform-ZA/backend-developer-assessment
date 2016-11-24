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

        public ArtistService(IArtistRepository artistRepository, IAliasRepository aliasRepository)
        {
            ArtistRepository = artistRepository;
            AliasRepository = aliasRepository;
        }

        public ArtistResponse Search(string criteria, int pageNumber, int pageSize)
        {
            var artistResults = ArtistRepository.SearchArtist(criteria, pageNumber, pageSize);

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


    }
}