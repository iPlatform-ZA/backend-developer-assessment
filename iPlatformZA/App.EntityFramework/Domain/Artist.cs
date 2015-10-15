using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EntityFramework.Domain
{
    public class Artist
    {   
        /// <summary>
        /// Artist Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Artist Name
        /// </summary>
        public virtual string ArtistName { get; set; }
        
        /// <summary>
        /// Artist Country
        /// </summary>
        public virtual string Country { get; set; }
        
        /// <summary>
        /// Artist Aliases
        /// </summary>
        public virtual string Aliases { get; set; }
    }
}
