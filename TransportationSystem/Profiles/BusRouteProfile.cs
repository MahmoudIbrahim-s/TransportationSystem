using AutoMapper;
using AutoMapper;
using TransportationSystem.DTOs.BusRouteDTO;
using TransportationSystem.DTOs.BusTypeDTO;
using TransportationSystem.Models;

namespace TransportationSystem.Profiles
{
    public class BusRouteProfile : Profile
    {
        public BusRouteProfile()
        {
            CreateMap<BusRoute, BusTypeDto>();
            CreateMap<BusRouteCreateDto, BusRoute>();
            CreateMap<BusRouteUpdateDto, BusRoute>();
        }
    
    
}
}

