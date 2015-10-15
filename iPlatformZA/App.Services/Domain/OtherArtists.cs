using System;
using System.Runtime.Serialization;

namespace App.Services.Domain
{
    [DataContract]
    public class OtherArtists
    {   
        /// <summary>
        /// Other Artists Id
        /// </summary>
        [DataMember]
        public Guid id { get; set; }

        /// <summary>
        /// Other Artists Name
        /// </summary>
        [DataMember]
        public string name { get; set; }
    }
}
