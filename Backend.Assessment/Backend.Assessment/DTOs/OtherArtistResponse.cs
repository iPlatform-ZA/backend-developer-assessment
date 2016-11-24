using System.Runtime.Serialization;

namespace Backend.Assessment.DTOs
{
    [DataContract]
    public class OtherArtistResponse
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}