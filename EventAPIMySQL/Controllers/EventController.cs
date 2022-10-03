using EventAPIMySQL.Data;
using EventAPIMySQL.Dtos.Event;
using EventAPIMySQL.Dtos.Guest;
using EventAPIMySQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly DataContext _context;

        public EventController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadEventDto>>> Get()
        {
            var events = await _context.Events
                .Include(c => c.Guests)
                .ToListAsync();

            List<ReadEventDto> readEventDto = events
                .Select(x => x.ToReadEventDto())
                .ToList();

            return Ok(events);
        }

        [HttpGet("{eventId}", Name = "GetEvent")]
        public async Task<ActionResult<ReadEventDto>> Get(int eventId)
        {
            var events = await _context.Events
                .Include(c => c.Guests)
                .FirstOrDefaultAsync(x => x.EventId == eventId);
            if (events == null) return NotFound();

            return Ok(events.ToReadEventDto());
        }

        [HttpPost]
        public async Task<ActionResult<List<ReadEventDto>>> CreateEvent(CreateEventDto newEvent)
        {
            _context.Events.Add(newEvent.ToEventModel());
            //foreach (var allergy in guest.Allergies)
            if(newEvent.Guests.Count() < 2) return BadRequest("Must have MINIMUM 2 Guests on Event creation.");
            //save
            await _context.SaveChangesAsync();

            List<Event> events = await _context.Events
                .Include(c => c.Guests)
                .ToListAsync();

            List<ReadEventDto> readEventsDto = events
                .Select(x => x.ToReadEventDto())
                .ToList();

            return Ok(readEventsDto);
        }

        [HttpPut]
        public async Task<ActionResult<ReadEventDto>> UpdateEvent(UpdateEventDto updatedEvent)
        {
            if (updatedEvent == null) return BadRequest("Event is null!");
            var dbEvent = await _context.Events.Where(i => i.EventId == updatedEvent.EventId).FirstOrDefaultAsync();
            if (dbEvent == null) return NotFound();

            dbEvent.EventName = updatedEvent.EventName;
            dbEvent.EventDate = updatedEvent.EventDate;
            dbEvent.Guests = updatedEvent.Guests.Select(x => x.ToGuestModel()).ToList();

            await _context.SaveChangesAsync();

            return Ok(await _context.Events.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ReadEventDto>>> Delete(int id)
        {
            var dbEvents = await _context.Events.FindAsync(id);
            if (dbEvents == null) return BadRequest("Event not found.");

            _context.Events.Remove(dbEvents);
            await _context.SaveChangesAsync();

            return Ok(await _context.Events.ToListAsync());
        }

    }
}
