using AutoMapper;
using GeoAPI.Entities;
using GeoAPI.Models;

namespace GeoAPI.Profiles
{
    public class GeoMappingProfile : Profile
    {
        public GeoMappingProfile()
        {
            CreateMap<GeoMarker, MarkerModel>();
        }
    }
}
