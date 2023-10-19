using AutoMapper;
using SQLDataFeedAPI.Models;
using SQLDataFeedAPI.Models.Dto;

namespace SQLDataFeedAPI
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<PrmiseAddress, PrmiseAddressDto>().ReverseMap();
        }
    }
}
