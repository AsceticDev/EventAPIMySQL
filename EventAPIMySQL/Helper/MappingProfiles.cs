using AutoMapper;
using EventAPIMySQL.Dtos;
using EventAPIMySQL.Models;

namespace EventAPIMySQL.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Guest, GuestDto>();
        }
    }
}
