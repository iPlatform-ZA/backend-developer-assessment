using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace App.Services.Domain
{
    [DataContract]
    public class Results
    {   
        /// <summary>
        /// Results Name
        /// </summary>
        [DataMember]
        public string name { get; set; }

        /// <summary>
        /// Results Country
        /// </summary>
        [DataMember]
        public string country { get; set; }

        /// <summary>
        /// Results Collection of Aliases
        /// </summary>
        [DataMember]
        public string [] aliases { get; set; }
    }
}
