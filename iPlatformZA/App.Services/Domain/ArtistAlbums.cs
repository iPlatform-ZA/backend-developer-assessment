using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Domain
{   
    [DataContract]
    public class ArtistAlbums : BaseResponse
    {   

        /// <summary>
        /// Collection of Artist Releases
        /// </summary>
        [DataMember]
        public ICollection<Release> Releases { get; set; }
    }
}
