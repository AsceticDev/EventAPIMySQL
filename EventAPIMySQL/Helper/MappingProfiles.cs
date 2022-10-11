using AutoMapper;
using EventAPIMySQL.Dto.Allergy;
using EventAPIMySQL.Dto.Event;
using EventAPIMySQL.Dto.Guest;
using EventAPIMySQL.Models;

namespace EventAPIMySQL.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Guest, GuestDto>();
            CreateMap<GuestDto, Guest>();
            CreateMap<ReadGuestDto, Guest>();
            CreateMap<Guest, ReadGuestDto>();
            CreateMap<Event, EventDto>();
            CreateMap<Allergy, AllergyDto>();
        }
    }
}
