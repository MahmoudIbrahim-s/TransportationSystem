using AutoMapper;
using TransportationSystem.DTOs.BusDTO;
using TransportationSystem.Models;

namespace TransportationSystem.Profiles
{
    public class BusProfile :Profile
    {
        public BusProfile()
        {
            CreateMap<Bus,BusDto>();
            CreateMap<BusCreateDto, Bus>();
            CreateMap<BusUpdateDto ,Bus>();
        }
    }
}
