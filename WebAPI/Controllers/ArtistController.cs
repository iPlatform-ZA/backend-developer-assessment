using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebAPI.Controllers
{
    [RoutePrefix("api/artist")]
    public class ArtistController : ApiController
    {
        private IRepository _service;
        private IModelFactory _modelFactory;
        const int maxPageSize = 20; //Maximum we can display at a time

        
        //An ideal way would be
        //public ArtistController(IModelFactory modelFactory, IRepository service)
        //{
        //    _service = service;
        //    _modelFactory = modelFactory;
        //}

        public ArtistController(IModelFactory modelFactory)
        {
            _service = new ArtistRepository( new MusicEntities());
            _modelFactory = modelFactory;
        }

        [Route("{id}/albums")]
        public IHttpActionResult Get(string id)
        {
            var artist = _service.GetOne(id);
            if (artist == null)
                return NotFound();
            var realeases =  MusicBrainzClient.GetReleases(artist.ID.ToString()); 

            return Ok(realeases);
        }

        [HttpGet]
        [Route("search/{search_criteria}/{page_number}/{page_size}")]
        public IHttpActionResult Search(string search_criteria ="", int page_number =1, int page_size =10)
        {
            if (page_size > maxPageSize)
                page_size = maxPageSize; 

            if (page_size == 0)
                page_size = maxPageSize; //avoid possible division by zero

            var items  = _service.Search(search_criteria);

            int _totalItems = items.Count();
            int _numberOfPages = ((_totalItems + page_size -1) / page_size);

            var pagedItems = items.OrderBy(a => a.Name).Skip((page_number - 1) * page_size).Take(page_size);
            var models = pagedItems.Select(_modelFactory.Create).ToList();

            var results = new ResultsModel
            {
                Artist = models,
                page = page_number,
                pageSize = page_size,
                numberOfPages = _numberOfPages,
                numberOfSearchResults = models.Count

            };

            return Ok(results);
        }
    }
}
