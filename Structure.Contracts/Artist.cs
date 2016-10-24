// <copyright file="Artist.cs" company="Structureit">
// Copyright (c) 2016 Structureit. All rights reserved.
// </copyright>
// <summary>Implements the artist alias class</summary>
namespace Structure.Contracts
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An artist.
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        public IEnumerable<string> Alias { get; set; }
    }


}
