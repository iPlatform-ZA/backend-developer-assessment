using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using BackEndApplication.Utils;

namespace BackEndApplication.MusicBrains
{
    public class ReleaseProcessor
    {
        public static List<Release> GetList(string xmlString, string artistId)
        {
            List<Release> releaseList = new List<Release>();

            XmlDocument releaseDocument = new XmlDocument();
            releaseDocument.LoadXml(xmlString);
            XmlNodeList releaseNodeList = releaseDocument.GetElementsByTagName("release");

            foreach (XmlNode releaseNode in releaseNodeList)
            {  
                XmlNodeList artistCreditXmlList = XMLHelper.GetChildNodes(releaseNode["artist-credit"]);
                List<Artist> artistList = GetArtists(artistCreditXmlList).Where(x => x.id != artistId).ToList<Artist>();

                Release release = new Release
                {
                    id = XMLHelper.GetAttributeValue(releaseNode.Attributes["id"]),
                    title = XMLHelper.GetInnerText(releaseNode["title"]),
                    status = XMLHelper.GetInnerText(releaseNode["status"]),
                    label = XMLHelper.GetInnerText(releaseNode["label-info-list"].FirstChild["label"]),
                    numberOfTracks = XMLHelper.GetInnerText(releaseNode["medium-list"]["track-count"]),
                    otherArtists = artistList
                };

                releaseList.Add(release);

            }

            return releaseList;
        }


        private static List<Artist> GetArtists(XmlNodeList artistCreditXmlList)
        {
            List<Artist> artistList = new List<Artist>();

            foreach (XmlNode artistNode in artistCreditXmlList)
            {
                Artist artist = new Artist
                {
                    name = XMLHelper.GetInnerText(artistNode["artist"]["name"]),
                    id = XMLHelper.GetAttributeValue(artistNode["artist"].Attributes["id"])
                };

                artistList.Add(artist);
            }

            return artistList;
        }
    }

}