using AutoMapper;
using System.Linq;

namespace Backend_Assessment.MappingProfiles
{
    public class ReleaseProfile : Profile
    {
        public ReleaseProfile()
        {
            CreateMap<EntityModels.Release, Models.Release>()
                .ForMember(s => s.ReleaseId, m => m.MapFrom(s => s.Id))
                .ForMember(s => s.NumberOfTracks, m => m.MapFrom(s => s.TrackCount))
                .ForMember(s => s.OtherArtists, m => m.MapFrom(s => s.NameCredit.Where(x => x.Id != null)));
        }
    }
}