using AutoMapper;
using TransportationSystem.DTOs.BusTypeDTO;
using TransportationSystem.Models;

namespace TransportationSystem.Profiles
{
    public class BusTypeProfile : Profile
    {
        public BusTypeProfile()
        {
            CreateMap<BusType, BusTypeDto>();
            CreateMap<BusTypeCreateDto, BusType>();
            CreateMap<BusTypeUpdateDto, BusType>();
        }

       
    }
}
