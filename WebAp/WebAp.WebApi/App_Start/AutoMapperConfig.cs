using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAp.Core.Dto;
using WebApCore.Entities;

namespace WebAp.WebApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(cfg => // initialising Automapper and paring of Entity to Dto
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<Artist, ArtistDto>()
                .ForMember(dest => dest.alias, opt => opt.MapFrom(src => src.Aliases));
            });
                      
            Mapper.AssertConfigurationIsValid();
        }
    }
}