using System;
using Backend.Assessment.Models;
using Backend.Assessment.Repositories;
using System.Linq;
using System.Collections.Generic;
using Backend.Assessment.DTOs;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Backend.Assessment.Services
{
    public class ArtistService : IArtistService
    {
        //Promote composition instead of inheritance by the use of IoC (simpleInjector used)
        private IArtistRepository ArtistRepository { get; set; }
        private IAliasRepository AliasRepository { get; set; }
        private IAlbumRepository AlbumRepository { get; set; }

        //Use of constructor injection
        public ArtistService(IArtistRepository artistRepository, IAliasRepository aliasRepository, IAlbumRepository albumRepository)
        {
            ArtistRepository = artistRepository;
            AliasRepository = aliasRepository;
            AlbumRepository = albumRepository;
        }

        public ArtistResponse Search(string criteria, int pageNumber, int pageSize)
        {
            //Fetch the unfiltered list from the repository layer so obtain the count of the results
            var artistResults = ArtistRepository.SearchArtist(criteria);

            //Filtered and paginated by LINQ
            var artistListResults = artistResults.OrderBy(a => a.Lastname).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            //Initialize the response to be returned
            var artistResponse = new ArtistResponse { ArtistCollectionResponse = new List<ArtistCollectionResponse>() };

            //Build the response to be returned
            foreach (var artistResult in artistListResults)
            {
                artistResponse.ArtistCollectionResponse.Add(new ArtistCollectionResponse
                {
                    Name = string.Concat(artistResult.Firstname.Trim(), " ", artistResult.Lastname.Trim()).Trim(),
                    Country = artistResult.CountryIso,
                    Alias = new List<string>(AliasRepository.GetByArtistId(artistResult.Id).Select(a => a.Text).ToList())
                });

            }

            //Assign proper values to the 'page' properties
            artistResponse.NumberOfSearchResults = artistResults.Count();

            //Round up the number to prevent decimal. 
            //Example if there are 5 item and 2 per page, there should be 3 pages. so that 2.5 pages should be rounded up to 3 pages
            var numberOfpages = (int)Math.Ceiling((double)artistResponse.NumberOfSearchResults / pageSize);

            artistResponse.Page = pageNumber.ToString();
            artistResponse.PageSize = pageSize.ToString();
            artistResponse.NumberOfPages = numberOfpages.ToString();

            return artistResponse;
        }

        public AlbumResponse GetAlbumByArtist(Guid artistId)
        {
            //Initialising response to be returned by the Service Layer
            var albumResponse = new AlbumResponse { Releases = new List<ReleaseResponse>() };

            //External call to MusicBrainz API with the help of a NuGet package library
            var release = MusicBrainz.Search.Release(arid: artistId.ToString());

            //Build object to be returned
            foreach (var s in release.Data)
            {
                albumResponse.Releases.Add(new ReleaseResponse
                {
                    Label = s.Labelinfolist.Any() ? s.Labelinfolist.FirstOrDefault().Label.Name : "",
                    ReleaseId = s.Id,
                    Status = s.Status,
                    Title = s.Title,
                    NumberOfTracks = s.Mediumlist.Trackcount.ToString(),
                    OtherArtists = new List<OtherArtistResponse>(s.Artistcredit.Any() ? s.Artistcredit.Select(a => new OtherArtistResponse { Id = a.Artist.Id, Name = a.Artist.Name }) : null)
                });
            }

            return albumResponse;
        }

    }
}