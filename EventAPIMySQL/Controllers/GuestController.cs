using EventAPIMySQL.Data;
using EventAPIMySQL.Dtos.Allergy;
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

            var readGuestsDto = guests
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

            ReadGuestDto readGuestDto = new ReadGuestDto
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                DateOfBirth = guest.DateOfBirth,
                Allergies = guest.Allergies.Select(a => a.ToReadAllergyDto()).ToList()
            };

            foreach (var allergy in guest.Allergies)
            {
                Console.WriteLine(allergy.AllergyType);
            }
            /*
              var guest = await _context.Guests
                .Where(c => c.Id == guestId)
                .Include(c => c.Allergies)
                .Include(c => c.Events)
                .ToListAsync();
            */

            return Ok(readGuestDto);
        }

        //Create A Guest
        [HttpPost]
        public async Task<ActionResult<List<ReadGuestDto>>> CreateGuest(CreateGuestDto newGuest)
        {
            //Add to table and save changes
            _context.Guests.Add(newGuest.ToGuestModel());
            await _context.SaveChangesAsync();

            //Get lists of guests
            var guests = await _context.Guests
                .Include(c => c.Allergies)
                .Include(c => c.Events)
                .ToListAsync();

            //Convert guests to ReadGuestsDto
            var readGuestsDto = guests
                .Select(x => x.ToReadGuestDto())
                .ToList();

            return Ok(readGuestsDto);
        }
    }
}
