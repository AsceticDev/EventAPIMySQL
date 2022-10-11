using AutoMapper;
using EventAPIMySQL.Data;
using EventAPIMySQL.Dto.Event;
using EventAPIMySQL.Interfaces;
using EventAPIMySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Event>))]
        public IActionResult GetEvents()
        {
            var events = _mapper.Map<List<EventDto>>(_eventRepository.GetEvents());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{eventId}")]
        [ProducesResponseType(200, Type = typeof(Event))]
        [ProducesResponseType(400)]
        public IActionResult GetEvent(int eventId)
        {
            if (!_eventRepository.EventExists(eventId))
                return NotFound();

            var eventObj = _mapper.Map<EventDto>(_eventRepository.GetEvent(eventId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eventObj);
        }


 
    }
}
