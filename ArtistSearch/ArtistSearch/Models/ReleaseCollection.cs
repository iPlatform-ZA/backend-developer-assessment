using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ArtistSearch.Models
{

    [XmlRoot("metadata", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class ReleaseMetadata
    {
        [XmlElement("release-list")]
        public ReleaseCollection Collection { get; set; }
    }

    [Serializable]
    [XmlRoot("release-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class ReleaseCollection
    {
        [XmlElement("release")]
        public List<Release> Items { get; set; }
    }

    [Serializable]
    [XmlRoot("release")]
    public class Release
    {
        [XmlAttribute("Id")]
        public string id { get; set; }

        [XmlAttribute("score", Namespace = "http://musicbrainz.org/ns/ext#-2.0")]
        public int Score { get; set; }

        [XmlElement("title")]
        public string title { get; set; }

        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("text-representation")]
        public TextRepresentation textRepresentation { get; set; }

        [XmlArray("artist-credit")]
        [XmlArrayItem("name-credit")]
        public List<NameCredit> Credits { get; set; }


        [XmlElement("release-group")]
        public ReleaseGroup releasegroup { get; set; }

        [XmlElement("cover-art-archive")]
        public CoverArtArchive CoverArtArchive { get; set; }


        [XmlElement("date")]
        public string date { get; set; }

        [XmlElement("country")]
        public string country { get; set; }

        [XmlElement("release-event-list")]
        public ReleaseEventList releaseeventlist { get; set; }

        [XmlArray("label-info-list")]
        [XmlArrayItem("label-info")]
        public List<LabelInfo> Labels { get; set; }

        [XmlElement("medium-list")]
        public MediumList mediumlist { get; set; }
    }

    [XmlRoot("cover-art-archive")]
    public class CoverArtArchive
    {
        [XmlElement("artwork")]
        public bool Artwork { get; set; }


        [XmlElement("count")]
        public int Count { get; set; }


        [XmlElement("front")]
        public bool Front { get; set; }


        [XmlElement("back")]
        public bool Back { get; set; }

        public static Uri GetCoverArtUri(string releaseId)
        {
            string url = "http://coverartarchive.org/release/" + releaseId + "/front-250.jpg";
            return new Uri(url, UriKind.RelativeOrAbsolute);
        }
    }

    [Serializable]
    [XmlRoot("medium-list")]
    public class MediumList
    {
        [XmlElement(ElementName = "track-count")]
        public int TrackCount { get; set; }

        [XmlElement("medium")]
        public List<Medium> Items { get; set; }
    }

    [Serializable]
    [XmlRoot("medium")]
    public class Medium
    {
        [XmlElement("format")]
        public string format { get; set; }

        [XmlElement("disc-list")]
        public DiscList disclist { get; set; }

        [XmlElement("track-list")]
        public TrackList tracklist { get; set; }
    }
    [Serializable]
    [XmlRoot("release-list")]
    public class DiscList
    {
        [XmlAttribute("count")]
        public string count { get; set; }
    }
    [Serializable]
    [XmlRoot("release-list")]
    public class TrackList
    {
        [XmlAttribute("count")]
        public string count { get; set; }
    }
    [Serializable]
    [XmlRoot("release-list")]
    public class LabelInfoList
    {
        [XmlElement("label-info")]
        public LabelInfo labelinfo { get; set; }
    }
    [Serializable]
    [XmlRoot("release-list")]
    public class LabelInfo
    {
        [XmlElement("catalog-number")]
        public string catalognumber { get; set; }

        [XmlElement("label")]
        public Label label { get; set; }
    }
    [Serializable]
    [XmlRoot("release-list")]
    public class Label
    {
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlElement("name")]
        public string name { get; set; }
    }
    [Serializable]
    [XmlRoot("release-list")]
    public class ReleaseEventList
    {
        [XmlElement("release-event")]
        public ReleaseEvent ReleaseEvent { get; set; }
    }
    [Serializable]
    [XmlRoot("release-list")]
    public class ReleaseEvent
    {
        [XmlElement("date")]
        public string date { get; set; }

        [XmlElement("area")]
        public Area area { get; set; }

    }
    [Serializable]
    [XmlRoot("release-list")]
    public class Area
    {
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("sort-name")]
        public string sortname { get; set; }

        [XmlElement("iso-3166-1-code-list")]
        public Iso31661Codelist iso31661codelist { get; set; }
    }
    [Serializable]
    [XmlRoot("release-list")]
    public class Iso31661Codelist
    {
        [XmlElement("iso-3166-1-code")]
        public string iso31661code { get; set; }
    }
    [Serializable]
    [XmlRoot("release-list")]
    public class ReleaseGroup
    {
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlAttribute("type")]
        public string type { get; set; }

        [XmlElement("primary-type")]
        public string primarytype { get; set; }
    }

    [Serializable]
    [XmlRoot("text-representation")]
    public class TextRepresentation
    {
        [XmlElement("language")]
        public string language { get; set; }

        [XmlElement("script")]
        public string script { get; set; }
    }

    [Serializable]
    [XmlRoot("name-credit")]
    public class NameCredit
    {
        [XmlAttribute("joinphrase")]
        public string joinphrase { get; set; }

        [XmlElement("artist")]
        public xmlArtist artist { get; set; }

    }
    [Serializable]
    [XmlRoot("release-list")]
    public class xmlArtist
    {
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("sort-name")]
        public string sortname { get; set; }

        [XmlElement("alias-list")]
        public AliasList aliaslist { get; set; }

    }

    [Serializable]
    [XmlRoot("release-list")]
    public class AliasList
    {
        [XmlArray("alias")]
        [XmlArrayItem("alias", typeof(Alias))]
        public List<Alias> alias { get; set; }



    }
    [Serializable]
    [XmlRoot("release-list")]
    public class Alias
    {
        [XmlAttribute("sort-name")]
        public string name { get; set; }


        [XmlAttribute("type")]
        public string type { get; set; }
    }
}