using AutoMapper;

namespace Backend_Assessment.MappingProfiles
{
    public class ArtistAliasProfile : Profile
    {
        public ArtistAliasProfile()
        {
            CreateMap<Models.ArtistAlias, EntityModels.ArtistAlias>()
                .ReverseMap();
        }
    }   
}