using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend_developer_assessment.Entities;
using backend_developer_assessment.DAL.UoW;
using backend_developer_assessment.DAL.Dto;
using System.Net;
using System.Net.Http;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace backend_developer_assessment.DAL.Service
{
    public class ArtistService : IArtistService 
    {
        IUnitOfWork _unitOfWork;

        public ArtistService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }


        public async Task<object> GetAllArtistReleases(string ArtistId)
        {
            try
            {
                var result = new ReleaseDto();
                var uri = string.Format("http://musicbrainz.org/ws/2/release/?query=arid:{0}", ArtistId);
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
                var content = await httpClient.GetStringAsync(uri);


                var buffer = Encoding.UTF8.GetBytes(content);
                using (var stream = new MemoryStream(buffer))
                {
                    
                    var doc = XDocument.Load(stream, LoadOptions.SetLineInfo);
                    var results = doc.Descendants().Where(x => x.Name.LocalName == "release");
                    var r = from t in results
                            select new
                            {
                                title = (string)t.Descendants().FirstOrDefault(x => x.Name.LocalName == "title"),
                                status = (string)t.Descendants().FirstOrDefault(x => x.Name.LocalName == "status"),
                                releaseId = t.Attribute("id").Value,
                                numberOfTracks = Convert.ToInt32(t.Descendants().First(x => x.Name.LocalName == "medium-list").Attribute("count").Value) > 0 ?
                                        (string)t.Descendants().First(x => x.Name.LocalName == "medium-list").Descendants().FirstOrDefault(x => x.Name.LocalName == "track-count") : "",
                                label = t.Descendants().FirstOrDefault(x => x.Name.LocalName == "label-info-list") != null ? (string)t.Descendants().First(x => x.Name.LocalName == "label-info-list").Descendants()
                                .First(x => x.Name.LocalName == "label-info").Descendants()
                                            .FirstOrDefault(x => x.Name.LocalName == "label").Descendants().FirstOrDefault(x => x.Name.LocalName == "name") : "",
                                otherArtists = t.Descendants().Where(x => x.Name.LocalName == "artist-credit").Select(d => new
                                {
                                    name = (string)d.Descendants().First(x => x.Name.LocalName == "name-credit").Descendants().First(x => x.Name.LocalName == "artist").Descendants().FirstOrDefault(x => x.Name.LocalName == "name"),
                                    id = d.Descendants().First(x => x.Name.LocalName == "name-credit").Descendants().First(x => x.Name.LocalName == "artist").Attribute("id").Value
                                }).ToList()
                            };
                    return r;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ArtistResultDto GetArtists(string artistName, int pageNum, int pageSize)
        {
            var result = new ArtistResultDto();
            var artist = new List<AritstDto>();
            _unitOfWork.AritstRepository.Find(x => x.ArtistAliases.Contains(artistName))
                .ToList().ForEach(x => artist.Add(
                    new AritstDto { name = x.ArtistName,
                        country = x.CountryCode,
                        alias = x.ArtistAliases.Split(',').ToList()
                    }));
            result.results = artist.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            result.numberOfSearchResults = artist.Count();
            result.page = pageNum;
            result.pageSize = pageSize;
            result.numberOfPages = Convert.ToInt32(Math.Ceiling((double)artist.Count() / pageSize));
            return result;
        }
        public void Dispose()
        {
            this._unitOfWork.Dispose();
        }
    }
}
