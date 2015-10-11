using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Models.DTO
{
    public class ReleaseInfoDTO
    {
        public string releaseID { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string label { get; set; }
        public int numberOfTracks { get; set; }

        public List<ArtistCreditDTO> otherArtists { get; set; }
    }
}


    //            {
    //  "releases": [
    //    {
    //      "releaseId": "9cc88413-d456-4b96-a0c1-09fa6cc2cf88",
    //      "title": "iTunes Festival: London 2010" ,
    //      "status": "Official",
    //      "label": "Gentlemen of the Road",
    //      "numberOfTracks": "8",
    //      "otherArtists": [
    //        {
    //          "id": "a015074b-e109-412d-9f7b-170b80a0ebbd",
    //          "name": "Dharohar Project"
    //        },
    //        {
    //          "id": "cd9713d6-6e5f-4143-9412-4d12b7bd47f2",
    //          "name": "Laura Marling"
    //        }
    //      ]     
    //    },
    //    //etc
    //  ]
    //}