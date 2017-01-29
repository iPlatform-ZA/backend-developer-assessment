using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAp.Core.Dto;
using WebApCore.Interfaces;

namespace WebAp.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {//implementing Dependency Injection

        private IArtistRepository _artistrepo;

        public BaseApiController(IArtistRepository artistrepo)
        {
            _artistrepo = artistrepo;
        }

        protected IArtistRepository ArtistDB
        {
            get
            {
                return _artistrepo;
            }
        }

        private ArtistDto _artistDto;

        protected ArtistDto MapToDto
        {
            get
            {
                if (_artistDto == null)
                {
                    _artistDto = new ArtistDto();
                }
                return _artistDto;
            }
        }
    }
}

