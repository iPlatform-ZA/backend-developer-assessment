using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicBrainz.Api.Models
{
    public class ResultViewModel
    {
        public List<Result> Results { get; set; }
        public int NumberOfResults { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int NumberOfPages { get; set; }
    }

    public class Result
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public List<string> Alias { get; set; }


    }

    public class Alias
    {

    }
}