using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MusicBrainzApi.Domain.Releases;

namespace App.Services.Domain
{
    [DataContract]
    public class ArtistReleases : BaseResponse
    {   
        /// <summary>
        /// Music Brainz Artist Release
        /// </summary>
        [DataMember]
        public metadataReleaselist Releases { get; set; }
    
    }
}
