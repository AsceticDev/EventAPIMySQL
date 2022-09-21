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
                .Select(x => ToReadGuestDto(x))
                .ToList();

            return Ok(readGuestsDto);
        }

        //Get a single Guest by ID
        [HttpGet("{guestId}", Name = "GetGuest")]
        public async Task<ActionResult<List<Guest>>> Get(int guestId)
        {
            var data = await _context.Guests
                .Include(c=>c.Allergies)
                .Include(c=>c.Events)
                .FirstOrDefaultAsync(x => x.Id == guestId);
            if (data == null) return NotFound();

            var dataDto = new ReadGuestDto()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                DateOfBirth = data.DateOfBirth
            };

            foreach (var allergy in data.Allergies)
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

            return Ok(dataDto);
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

        //extension methods
        public static ReadGuestDto ToReadGuestDto(Guest guest)
        {
            return new ReadGuestDto()
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                DateOfBirth = guest.DateOfBirth,
                Allergies = guest.Allergies.Select(a => ToReadAllergyDto(a)).ToList()
            };
        }

        public static ReadAllergyDto ToReadAllergyDto(Allergy allergy)
        {
            return new ReadAllergyDto()
            {
                AllergyType = allergy.AllergyType
            };
        }


    }
}
