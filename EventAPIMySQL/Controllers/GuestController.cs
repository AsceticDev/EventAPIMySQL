using AutoMapper;
using EventAPIMySQL.Data;
using EventAPIMySQL.Dtos;
using EventAPIMySQL.Interfaces;
using EventAPIMySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EventAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : Controller
    {
        private readonly IGuestRepository _guestRepository;
        //private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public GuestController(IGuestRepository guestRepository, IMapper mapper)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Guest>))]
        public IActionResult GetGuests()
        {
            var guests = _mapper.Map<List<GuestDto>>(_guestRepository.GetGuests());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(guests);
        }

        [HttpGet("{guestId}")]
        [ProducesResponseType(200, Type = typeof(Guest))]
        [ProducesResponseType(400)]
        public IActionResult GetGuest(int guestId)
        {
            if (!_guestRepository.GuestExists(guestId))
                return NotFound();

            var guest = _mapper.Map<Guest>(_guestRepository.GetGuest(guestId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(guest);
        }

    }
}
