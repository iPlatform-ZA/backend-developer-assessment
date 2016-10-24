using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Structure.Contracts;
using System.Web.Http.Description;
using Structure.Adapters.MusicBrainz;
using Structure.Contracts.MusicBrainz;

namespace Structure.Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("artist")]
    public class ArtistController : ApiController
    {
        [HttpGet]
        [Route("search/{name}")]
        public PagedResultSet<Contracts.Artist> Search(string name, int page = 1, int pageSize = 10)
        {
            var provider = new Structure.Providers.ArtistsProvider();
            var searchArgs = new ArtistSearchArgs
            {
                Name = name
            };

            var paging = new PagingArgs
            {
                Page_Number = page,
                Page_Size = pageSize
            };
            var results = provider.Search(searchArgs, paging);
            return results;
        }

        [HttpGet]
        [Route("{artist_id}/releases")]
        public PagedResultSet<Contracts.Release> GetReleases(Guid artist_id, int page = 1, int pageSize = 10)
        {
            var pagingArgs = new PagingArgs
            {
                Page_Number = page,
                Page_Size = pageSize
            };
            MusicBrainzAdapter musicBrainzAdapter = new MusicBrainzAdapter();
            var results = musicBrainzAdapter.GetArtistReleases(artist_id, pagingArgs);
            var response = new PagedResultSet<Contracts.Release>
            {
                Results = results.Releases.Map(),
                NumberOfPages = (int)Math.Floor((double)(results.Count / pagingArgs.Page_Size)),
                NumberOfSearchResults = results.Count,
                Page = pagingArgs.Page_Number,
                PageSize = pagingArgs.Page_Size
            };
            return response;
        }

        //[Route("~api/authors/{authorId}/books")]
        //public IQueryable<BookDto> GetBooksByAuthor(int authorId)
        //{
        //    return db.Books.Include(b => b.Author)
        //        .Where(b => b.AuthorId == authorId)
        //        .Select(AsBookDto);
        //}
    }
}
