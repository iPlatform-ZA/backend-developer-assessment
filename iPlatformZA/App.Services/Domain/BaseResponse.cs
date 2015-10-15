using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Domain
{   
    [DataContract]
    public class BaseResponse
    {   
        /// <summary>
        /// Base check if Successfull or Not
        /// </summary>
        [DataMember]
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Base Details of the Response
        /// </summary>
        [DataMember]
        public string Details { get; set; }
    }
}
