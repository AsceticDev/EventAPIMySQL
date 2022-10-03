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
                .FirstOrDefaultAsync(x => x.GuestId == guestId);
            if (guest == null) return NotFound();

            return Ok(guest.ToReadGuestDto());
        }

        
        //Create A Guest
        [HttpPost]
        public async Task<ActionResult<List<ReadGuestDto>>> CreateGuest(CreateGuestDto newGuest)
        {
            //Add to table and save changes
            Models.Guest guestModel = newGuest.ToGuestModel();
            _context.Guests.Add(guestModel);

            foreach (ReadAllergyDto allergy in newGuest.Allergies)
            {
                var dbAllergy = _context.Allergies.SingleOrDefault(b => b.AllergyType == allergy.AllergyType);
                if(dbAllergy == null) return BadRequest("Please enter a valid allergy.");
            }

            await _context.SaveChangesAsync();
            _context.Entry(guestModel).GetDatabaseValues();

            foreach (ReadAllergyDto allergy in newGuest.Allergies)
            {
                guestModel.Allergies.Add(allergy.ToAllergyModel());
            }
            

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
            var dbGuest = await _context.Guests.Where(i => i.GuestId == updatedGuest.GuestId).FirstOrDefaultAsync();
            if (dbGuest == null) return NotFound();

            dbGuest.FirstName = updatedGuest.FirstName;
            dbGuest.LastName = updatedGuest.LastName;
            dbGuest.Email = updatedGuest.Email;
            dbGuest.DateOfBirth = updatedGuest.DateOfBirth;

            await _context.SaveChangesAsync();

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
