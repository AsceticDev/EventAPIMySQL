using EventAPIMySQL.Data;
using EventAPIMySQL.Dtos.Guest;
using EventAPIMySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly DataContext _context;

        public GuestController(DataContext context)
        {
            _context = context;
        }

        //Get ALL Guests
        [HttpGet]
        public async Task<ActionResult<List<ReadGuestDto>>> Get()
        {
            var guests = await _context.Guests
                .Include(c => c.Allergies)
                .Include(c => c.Events)
                .ToListAsync();

            List<ReadGuestDto> readGuestsDto = guests
                //.Select(x => ToReadGuestDto(x))
                .Select(x => x.ToReadGuestDto())
                .ToList();

            return Ok(readGuestsDto);
        }

        //Get a single Guest by ID
        [HttpGet("{guestId}", Name = "GetGuest")]
        public async Task<ActionResult<ReadGuestDto>> Get(int guestId)
        {
            var guest = await _context.Guests
                .Include(c=>c.Allergies)
                .Include(c=>c.Events)
                .FirstOrDefaultAsync(x => x.Id == guestId);
            if (guest == null) return NotFound();

            return Ok(guest.ToReadGuestDto());
        }

        
        //Create A Guest
        [HttpPost]
        public async Task<ActionResult<List<ReadGuestDto>>> CreateGuest(CreateGuestDto newGuest)
        {
            //Add to table and save changes
            _context.Guests.Add(newGuest.ToGuestModel());
            await _context.SaveChangesAsync();

            //Get lists of guests
            List<Guest> guests = await _context.Guests
                .Include(c => c.Allergies)
                .Include(c => c.Events)
                .ToListAsync();

            //Convert guests to ReadGuestsDto
            List<ReadGuestDto> readGuestsDto = guests
                .Select(x => x.ToReadGuestDto())
                .ToList();


            return Ok(readGuestsDto);
        }

        [HttpPut]
        public async Task<ActionResult<ReadGuestDto>> UpdateGuest(UpdateGuestDto updatedGuest)
        {
            if(updatedGuest == null) return BadRequest("Guest is null!");
            var dbGuest = await _context.Guests.Where(i => i.Id == updatedGuest.Id).FirstOrDefaultAsync();
            if (dbGuest == null) return NotFound();

           dbGuest.FirstName = updatedGuest.FirstName;
           dbGuest.LastName = updatedGuest.LastName;
           dbGuest.Email = updatedGuest.Email;
           dbGuest.DateOfBirth = updatedGuest.DateOfBirth;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Ok(await _context.Guests.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ReadGuestDto>>> Delete(int id)
        {
            var dbGuest = await _context.Guests.FindAsync(id);
            if (dbGuest == null) return BadRequest("Guest not found.");

            _context.Guests.Remove(dbGuest);
            await _context.SaveChangesAsync();

            return Ok(await _context.Guests.ToListAsync());
        }
    }
}
