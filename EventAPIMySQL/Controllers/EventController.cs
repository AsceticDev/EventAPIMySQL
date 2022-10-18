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
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Event>))]
        public IActionResult GetEvents()
        {
            var eventsDb = _eventRepository.GetEvents();

            List<ReadEventDto> readEvents = eventsDb.Select(a => a.ToReadEventDto()).ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(readEvents);
        }

        [HttpGet("{eventId}")]
        [ProducesResponseType(200, Type = typeof(Event))]
        [ProducesResponseType(400)]
        public IActionResult GetEvent(int eventId)
        {
            if (!_eventRepository.EventExists(eventId))
                return NotFound();

            var eventDb = _eventRepository.GetEvent(eventId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eventDb.ToReadEventDto());
        }


 
    }
}
