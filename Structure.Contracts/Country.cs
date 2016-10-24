// <copyright file="Country.cs" company="Structureit">
// Copyright (c) 2016 Structureit. All rights reserved.
// </copyright>
// <summary>Implements the country class</summary>
namespace Structure.Contracts
{
    using System;
    /// <summary>
    /// A country.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ISO 2.
        /// </summary>
        public string ISO2 { get; set; }

        /// <summary>
        /// Gets or sets the ISO 3.
        /// </summary>
        public string ISO3 { get; set; }
    }

}
