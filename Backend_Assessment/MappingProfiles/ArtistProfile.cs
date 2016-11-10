using AutoMapper;
using System.Linq;

namespace Backend_Assessment.MappingProfiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<EntityModels.Artist, Models.Artist>()
                .ForMember(s => s.Identifier, m => m.MapFrom(s => s.ArtistIdentifier))
                .ForMember(s => s.Aliases, m => m.MapFrom(s => s.ArtistAliases.Select(x => x.Alias).ToList()));
        }
    }
}