// <copyright file="ArtistAliasesExtensionMappers.cs" company="Structureit">
// Copyright (c) 2016 Structureit. All rights reserved.
// </copyright>
// <summary>Implements the artist aliases extension mappers class</summary>
namespace Structure.DataSource
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An artist aliases extension mappers.
    /// </summary>
    public static class ArtistAliasesExtensionMappers
    {
        /// <summary>
        /// Enumerates map in this collection.
        /// </summary>
        /// <param name="alias">The alias to act on.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process map in this collection.
        /// </returns>
        public static Contracts.ArtistAlias Map(this ArtistAlias alias)
        {
            return new Contracts.ArtistAlias
            {
                Name = alias.Name
            };
        }

        /// <summary>
        /// Enumerates map in this collection.
        /// </summary>
        /// <param name="aliases">The aliases to act on.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process map in this collection.
        /// </returns>
        public static IEnumerable<Contracts.ArtistAlias> Map(this IEnumerable<ArtistAlias> aliases)
        {
            return aliases.Select(alias => alias.Map());
        }

        /// <summary>
        /// Enumerates map in this collection.
        /// </summary>
        /// <param name="aliases">The aliases to act on.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process map in this collection.
        /// </returns>
        public static IEnumerable<string> Simplify(this IEnumerable<ArtistAlias> aliases)
        {
            return aliases.Select(alias => alias.Name);
        }
    }
}
