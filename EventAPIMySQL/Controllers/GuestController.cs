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

            return Ok(guests);
        }

        //Get a single Guest by ID
        [HttpGet("{guestId}", Name="GetGuest")]
        public async Task<ActionResult<List<Guest>>> Get(int guestId)
        {
            var guest = await _context.Guests
                .Where(c => c.Id == guestId)
                .Include(c => c.Allergies)
                .Include(c => c.Events)
                .ToListAsync();

            return Ok(guest);
        }

        //Create A Guest
        [HttpPost]
        public async Task<ActionResult<Guest>> CreateGuest(CreateGuestDto request)
        {
            //var guest = await;
            var newGuest = new Guest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                //Allergies = request.
            };

            _context.Guests.Add(newGuest);
            await _context.SaveChangesAsync();

            return Ok(await _context.Guests.ToListAsync());

        }
    }
}
