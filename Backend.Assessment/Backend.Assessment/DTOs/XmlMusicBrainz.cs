using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Backend.Assessment.DTOs
{
    public class XmlMusicBrainz
    {
    }

    [XmlRoot(ElementName = "text-representation", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Textrepresentation
    {
        [XmlElement(ElementName = "language", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Language { get; set; }
        [XmlElement(ElementName = "script", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Script { get; set; }
    }

    [XmlRoot(ElementName = "alias", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Alias
    {
        [XmlAttribute(AttributeName = "sort-name")]
        public string Sortname { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "alias-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Aliaslist
    {
        [XmlElement(ElementName = "alias", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Alias Alias { get; set; }
    }

    [XmlRoot(ElementName = "artist", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Artist
    {
        [XmlElement(ElementName = "name", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Name { get; set; }
        [XmlElement(ElementName = "sort-name", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Sortname { get; set; }
        [XmlElement(ElementName = "alias-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Aliaslist Aliaslist { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "name-credit", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Namecredit
    {
        [XmlElement(ElementName = "artist", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Artist Artist { get; set; }
    }

    [XmlRoot(ElementName = "artist-credit", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Artistcredit
    {
        [XmlElement(ElementName = "name-credit", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Namecredit Namecredit { get; set; }
    }

    [XmlRoot(ElementName = "release-group", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Releasegroup
    {
        [XmlElement(ElementName = "primary-type", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Primarytype { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "secondary-type-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Secondarytypelist Secondarytypelist { get; set; }
    }

    [XmlRoot(ElementName = "disc-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Disclist
    {
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }

    [XmlRoot(ElementName = "track-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Tracklist
    {
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }

    [XmlRoot(ElementName = "medium", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Medium
    {
        [XmlElement(ElementName = "disc-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Disclist Disclist { get; set; }
        [XmlElement(ElementName = "track-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Tracklist Tracklist { get; set; }
        [XmlElement(ElementName = "format", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Format { get; set; }
    }

    [XmlRoot(ElementName = "medium-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Mediumlist
    {
        [XmlElement(ElementName = "track-count", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Trackcount { get; set; }
        [XmlElement(ElementName = "medium", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Medium Medium { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }

    [XmlRoot(ElementName = "release", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Release
    {
        [XmlElement(ElementName = "title", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Title { get; set; }
        [XmlElement(ElementName = "status", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Status { get; set; }
        [XmlElement(ElementName = "text-representation", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Textrepresentation Textrepresentation { get; set; }
        [XmlElement(ElementName = "artist-credit", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Artistcredit Artistcredit { get; set; }
        [XmlElement(ElementName = "release-group", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Releasegroup Releasegroup { get; set; }
        [XmlElement(ElementName = "medium-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Mediumlist Mediumlist { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "score", Namespace = "http://musicbrainz.org/ns/ext#-2.0")]
        public string Score { get; set; }
        [XmlElement(ElementName = "date", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Date { get; set; }
        [XmlElement(ElementName = "release-event-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Releaseeventlist Releaseeventlist { get; set; }
        [XmlElement(ElementName = "country", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Country { get; set; }
        [XmlElement(ElementName = "barcode", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Barcode { get; set; }
        [XmlElement(ElementName = "asin", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Asin { get; set; }
        [XmlElement(ElementName = "label-info-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Labelinfolist Labelinfolist { get; set; }
        [XmlElement(ElementName = "packaging", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Packaging { get; set; }
        [XmlElement(ElementName = "tag-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Taglist Taglist { get; set; }
    }

    [XmlRoot(ElementName = "release-event", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Releaseevent
    {
        [XmlElement(ElementName = "date", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Date { get; set; }
        [XmlElement(ElementName = "area", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Area Area { get; set; }
    }

    [XmlRoot(ElementName = "release-event-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Releaseeventlist
    {
        [XmlElement(ElementName = "release-event", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Releaseevent Releaseevent { get; set; }
    }

    [XmlRoot(ElementName = "iso-3166-1-code-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Iso31661codelist
    {
        [XmlElement(ElementName = "iso-3166-1-code", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Iso31661code { get; set; }
    }

    [XmlRoot(ElementName = "area", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Area
    {
        [XmlElement(ElementName = "name", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Name { get; set; }
        [XmlElement(ElementName = "sort-name", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Sortname { get; set; }
        [XmlElement(ElementName = "iso-3166-1-code-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Iso31661codelist Iso31661codelist { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "label", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Label
    {
        [XmlElement(ElementName = "name", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "label-info", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Labelinfo
    {
        [XmlElement(ElementName = "catalog-number", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Catalognumber { get; set; }
        [XmlElement(ElementName = "label", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Label Label { get; set; }
    }

    [XmlRoot(ElementName = "label-info-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Labelinfolist
    {
        [XmlElement(ElementName = "label-info", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public List<Labelinfo> Labelinfo { get; set; }
    }

    [XmlRoot(ElementName = "tag", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Tag
    {
        [XmlElement(ElementName = "name", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }

    [XmlRoot(ElementName = "tag-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Taglist
    {
        [XmlElement(ElementName = "tag", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Tag Tag { get; set; }
    }

    [XmlRoot(ElementName = "secondary-type-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Secondarytypelist
    {
        [XmlElement(ElementName = "secondary-type", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public string Secondarytype { get; set; }
    }

    [XmlRoot(ElementName = "release-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Releaselist
    {
        [XmlElement(ElementName = "release", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public List<Release> Release { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
        [XmlAttribute(AttributeName = "offset")]
        public string Offset { get; set; }
    }

    [XmlRoot(ElementName = "metadata", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Metadata
    {
        [XmlElement(ElementName = "release-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
        public Releaselist Releaselist { get; set; }
        [XmlAttribute(AttributeName = "created")]
        public string Created { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "ext", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ext { get; set; }


    }

}