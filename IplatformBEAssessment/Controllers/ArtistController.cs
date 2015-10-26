using Domain;
using Persistance;
using Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using IplatformBEAssessment.Models.DTOs;
using IplatformBEAssessment.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Xml;

namespace IplatformBEAssessment.Controllers
{
    public class ArtistController : ApiController
    {
        private IUnitOfWork unitOfWork;
        private readonly string releaseUri = "http://musicbrainz.org/ws/2/release/?query=arid:";
        private string xmlString;

        public ArtistController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Search(int page_number, int page_size, string search_criteria = null)
        {
            var artist = new ArtistViewModel  {
                             Artists = unitOfWork.Repository<Artist>().GetArtists(q => q.Name.Contains(search_criteria))
                             .OrderBy(i => i.Id)
                             .Select(s => new ArtistDTO {
                                         Name = s.Name,
                                         Country = s.Country,
                                         Eliases = s.Eliases.Select(e => new EliasDTO { EliasName = e.EliasName })
                                     })
                             .Skip((page_number - 1) * page_size)
                             .Take(page_size) ,
                             CurrentPage = (int)page_number,
                             ItemsPerPage = (int)page_size,
                             TotalItems = unitOfWork.Repository<Artist>().GetArtists(q => q.Name.Contains(search_criteria)).Count()
                        };

            return Ok(artist);
        }

        // GET api/<controller>/5
        [HttpGet]
        public async Task<IHttpActionResult> Releases(int artist_Id)
        {
            var artist = unitOfWork.Repository<Artist>().GetArtistById(artist_Id);
            if (artist == null)
                return NotFound();
            else
	            {
	                var uri = releaseUri + artist.Identifier;
                    using (var client = new HttpClient())
                    {
                        HttpResponseMessage response =  await client.GetAsync(uri);
                        xmlString = await response.Content.ReadAsStringAsync();
                    }
                    var doc = new XmlDocument();
                    doc.LoadXml(xmlString);
                    string json = JsonConvert.SerializeXmlNode(doc);

                    return Ok(json);     
	            };
        }

        [HttpGet]
        public IHttpActionResult Albums(string identifier)
        {
            return Ok();
        }


        public async void GetReleases(string Identifier)
        {
            var uri = releaseUri + Identifier;

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                xmlString = await response.Content.ReadAsStringAsync();
            }
        }
    }
}