using Domain;
using Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using IplatformBEAssessment.Models.DTOs;
using IplatformBEAssessment.Models;
using Newtonsoft.Json;
using System.Xml.Linq;



using System.Collections.ObjectModel;
using IplatformBEAssessment.Helpers;
using System.Xml;

namespace IplatformBEAssessment.Controllers
{
    public class ArtistController : ApiController
    {
        private IUnitOfWork unitOfWork;
        private readonly string releaseUri = "http://musicbrainz.org/ws/2/release/?query=arid:";
        private string xmlString;
        private List<OtherArtists> otherArtistList = new List<OtherArtists>();

        public ArtistController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Search(int page_number, int page_size, string search_criteria = null)
        {
            var artist = new ArtistViewModel
            {
                Artists = unitOfWork.Repository<Artist>().GetArtists(q => q.Name.Contains(search_criteria))
                .OrderBy(i => i.Id)
                .Select(s => new ArtistDTO
                {
                    Name = s.Name,
                    Country = s.Country,
                    Eliases = s.Eliases.Select(e => new EliasDTO { EliasName = e.EliasName })
                })
                .Skip((page_number - 1) * page_size)
                .Take(page_size),
                CurrentPage = (int)page_number,
                ItemsPerPage = (int)page_size,
                TotalItems = unitOfWork.Repository<Artist>().GetArtists(q => q.Name.Contains(search_criteria)).Count()
            };

            return Ok(artist);
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Releases(int artist_Id)
        {
            var artist = unitOfWork.Repository<Artist>().GetArtistById(artist_Id);
            
            if (artist == null)
                return NotFound();
            else
            {
                var uri = releaseUri + artist.Identifier;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    xmlString = response.Content.ReadAsStringAsync().Result;
                }

                var xDoc = XDocument.Parse(xmlString);
                XElement root = xDoc.Root;
                var releases = new List<ReleaseDTO>();

                foreach (var element in root.Elements().FirstOrDefault().Elements())
                {
                    ReleaseDTO release = new ReleaseDTO();
                    release.ReleaseId = element.Attribute("id").Value;
                    release.ReleaseTitle = getValueByName(element.Elements(),"title", "title");
                    release.Status = getValueByName(element.Elements(), "status", "status");
                    release.Label = getValueByName(element.Elements(),"label-info-list", "name");
                    release.NumberOfTracks = Convert.ToInt32(getValueByName(element.Elements(), "medium-list", "track-count"));
                    var otherArtists = GetOtherArtist(element.Elements(), "artist-credit", "artist", artist.Identifier);
                    foreach (var item in otherArtists)
                    {
                        release.OtherArtists.Add(item);
                    }
                    releases.Add(release);
                    otherArtists.Clear();
                }

                return Ok(releases);
            }
        }

        private string getValueByName(IEnumerable<XElement> elements, string elementName, string prperty)
        {
            string val = string.Empty;

            if (string.Equals(elementName, prperty, StringComparison.CurrentCultureIgnoreCase))
                foreach (var element in elements)
                {
                    if (string.Equals(element.Name.LocalName, elementName, StringComparison.CurrentCultureIgnoreCase))
                        val = element.Value;
                }
            else
                foreach (var element in elements)
                {
                    if (string.Equals(element.Name.LocalName, elementName, StringComparison.CurrentCultureIgnoreCase))
                        val =getValueByName(element.Elements(), prperty,prperty);
                }

            if (string.IsNullOrEmpty(val))
                foreach (var element in elements)
                {
                    val = getValueByName(element.Elements(),elementName, prperty);
                }

            return val;
        }

        private List<OtherArtists> GetOtherArtist(IEnumerable<XElement> elements, string elementName, string property, string identifier)
        {
            if(string.Equals(elementName,property,StringComparison.CurrentCultureIgnoreCase))
                foreach(var element in elements)
                {
                    if(string.Equals(element.Name.LocalName, elementName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        var artistId = element.Attribute("id").Value;
                        if (!artistId.Equals(identifier))
                        {
                            var artist = new OtherArtists
                                            {
                                                Id = element.Attribute("id").Value,
                                                Name = getValueByName(elements, elementName, "name")
                                            };

                            otherArtistList.Add(artist); 
                        }
                    }
                }
            else
            {
                foreach (var element in elements)
                {
                    if (string.Equals(element.Name.LocalName, elementName, StringComparison.CurrentCultureIgnoreCase))
                        otherArtistList = GetOtherArtist(element.Elements(), property, property, identifier);
                }   
            }


            foreach (var element in elements)
            {
                otherArtistList = GetOtherArtist(element.Elements(), elementName, property, identifier);
            }
            

            return otherArtistList;
        }

        [HttpGet]
        public IHttpActionResult Albums(string identifier)
        {
            return Ok();
        }
    }
}