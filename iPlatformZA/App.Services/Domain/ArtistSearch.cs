using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Domain
{
    [DataContract]
    public class ArtistSearch : BaseResponse
    {   
        /// <summary>
        /// Collection of Artist Search Results
        /// </summary>
        [DataMember]
        public ICollection<Results> results { get; set; }        

        /// <summary>
        /// Total Number of Search Results
        /// </summary>
        [DataMember]
        public int numberOfSearchResults { get; set; }

        /// <summary>
        /// Current page of the Artist Search
        /// </summary>
        [DataMember]
        public int page { get; set; }

        /// <summary>
        /// Page Size
        /// </summary>
        [DataMember]
        public int pageSize { get; set; }

        /// <summary>
        /// Number of Pages in the Search Result
        /// </summary>
        [DataMember]
        public int numberOfPages { get; set; }
    }
}
