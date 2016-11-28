namespace Backend.Assessment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Album_Artist
    {
        public Guid Id { get; set; }

        public Guid AlbumId { get; set; }

        public Guid ArtistId { get; set; }

        public virtual Album Album { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
