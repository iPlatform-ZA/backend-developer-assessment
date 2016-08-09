using System;

namespace WebApi.Repositories.RepositoryModels
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string[] Alias { get; set; }
    }
}
