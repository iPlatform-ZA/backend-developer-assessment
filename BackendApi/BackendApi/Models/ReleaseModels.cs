using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendApi.Models
{
    public class Release
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("text-representation")]
        public TextRepresentation TextRepresentation { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("quality")]
        public string Quality { get; set; }
        [JsonProperty("release-group")]
        public ReleaseGroup ReleaseGroup { get; set; }
        [JsonProperty("artist-credit")]
        public ArtistCredit[] Artistcredit { get; set; }
        [JsonProperty("label-info")]
        public LabelInfo[] LabelInfo { get; set; }
        [JsonProperty("media")]
        public Medium[] Media { get; set; }
        [JsonProperty("barcode")]
        public string  Barcode { get; set; }
        [JsonProperty("disambiguation")]
        public object Disambiguation { get; set; }
        [JsonProperty("packaging")]
        public object Packaging { get; set; }
        [JsonProperty("asin")]
        public object ASIN { get; set; }
        [JsonProperty("release-events")]
        public ReleaseEvents[] ReleaseEvents { get; set; }
        [JsonProperty("track-count")]
        public int TrackCount { get; set; }
    }
    public class TextRepresentation
    {
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("script")]
        public string Script { get; set; }
    }

    public class ReleaseGroup
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("primary-type")]
        public string PrimaryType { get; set; }
    }

    public class ArtistCredit
    {
        [JsonProperty("joinphrase")]
        public string joinphrase { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("artist")]

        public ArtistModel Artist { get; set; }
    }

    public class ArtistModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sort-name")]
        public string SortName { get; set; }
        [JsonProperty("disambiguation")]
        public object Disambiguation { get; set; }
    }

    public class LabelInfo
    {
        [JsonProperty("label")]
        public Label Label { get; set; }
        [JsonProperty("catalog-number")]
        public string Catalognumber { get; set; }
    }

    public class Label
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sort-name")]
        public string SortName { get; set; }
        [JsonProperty("label-code")]
        public object LabelCode { get; set; }
        [JsonProperty("disambiguation")]
        public object Disambiguation { get; set; }
    }

    public class Medium
    {
        [JsonProperty("disc-count")]
        public int DiscCount { get; set; }
        [JsonProperty("track-count")]
        public int TrackCount { get; set; }
     
        [JsonProperty("format")]
        public string Format { get; set; }
 
    }

    public class Discid
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("sectors")]
        public int Sectors { get; set; }
    }

    public class Track
    {
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("length")]
        public int Length { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("recording")]
        public Recording Recording { get; set; }
        [JsonProperty("artist-credit")]
        public ArtistCredit[] ArtistCredit { get; set; }
    }

    public class Recording
    {
    }

    public class Alias
    {
        [JsonProperty("sortname")]
        public string SortName { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("locale")]
        public object Locale { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("primary")]
        public object Primary { get; set; }
        [JsonProperty("begin-date")]
        public object BeginDate { get; set; }
        [JsonProperty("end-date")]
        public object EndDate { get; set; }
    }

    public class ReleaseEvents
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("area")]
        public Area Area { get; set; }
    }

    public class Area
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sort-name")]
        public string SortName { get; set; }
        [JsonProperty("iso-3166-1-codes")]
        public string[] ISO31661Codes { get; set; }
    }
}


 