using AutoMapper;
using EventAPIMySQL.Data;
using EventAPIMySQL.Dto.Allergy;
using EventAPIMySQL.Dto.Guest;
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
        private readonly IEventRepository _eventRepository;
        private readonly IAllergyRepository _allergyRepository;
        public GuestController(IGuestRepository guestRepository,IAllergyRepository allergyRepository, IEventRepository eventRepository)
        {
            _guestRepository = guestRepository;
            _allergyRepository = allergyRepository;
            _eventRepository = eventRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReadGuestDto>))]
        public IActionResult GetGuests()
        {
            //var guests = _mapper.Map<List<ReadGuestDto>>(_guestRepository.GetGuests());

            var guestsDb = _guestRepository.GetGuests();

            List<ReadGuestDto> guests = guestsDb.Select(a => a.ToReadGuestDto()).ToList();

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

            var guest = _guestRepository.GetGuest(guestId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(guest.ToReadGuestDto());
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGuest([FromBody] CreateGuestDto guestCreate)
        {
            if (guestCreate == null)
                return BadRequest(ModelState);

            var guest = _guestRepository.GetGuestByEmailTrimToUpper(guestCreate);

            if(guest!=null)
            {
                ModelState.AddModelError("", "A GUEST with that EMAIL already exists.");
                return StatusCode(422, ModelState);
            }

            //Validation
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<CreateAllergyDto> allergyList = new List<CreateAllergyDto>();

            if(guestCreate.allergies.Count > 0)
            {
                foreach(CreateAllergyDto item in guestCreate.allergies)
                {
                    if (!_allergyRepository.AllergyExists(item.AllergyType))
                        return BadRequest("The Allergy Type you entered is Invalid.");
                    allergyList.Add(item);
                }
            };

            Guest createdGuest = guestCreate.ToGuestModel();

            if (!_guestRepository.CreateGuest(createdGuest))
            {
                ModelState.AddModelError("", "Something went wrong while saving...");
                return StatusCode(500, ModelState);
            }

            if (guestCreate.allergies.Count > 0)
            {
                if (!_guestRepository.AddAllergiesToGuest(createdGuest.Id, allergyList))
                    return BadRequest("Something went wrong...");
            }

            var guestsDb =_guestRepository.GetGuests();
            List<ReadGuestDto> readGuestList = guestsDb.Select(a => a.ToReadGuestDto()).ToList();

            return Ok(readGuestList);
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateGuest([FromBody]UpdateGuestDto updatedGuest)
        {
            if (updatedGuest == null)
            {
                return BadRequest(ModelState);
            }

            if (!_guestRepository.GuestExists(updatedGuest.Id))
                return NotFound();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Guest updatedGuestModel = updatedGuest.ToGuestModel();

            if (updatedGuest.allergies.Count() > 0)
            {
                var guestAllergiesDb = _allergyRepository.GetAllergiesByGuest(updatedGuest.Id);
                List<UpdateAllergyDto> currentGuestAllergies = guestAllergiesDb.Select(a => a.ToUpdateAllergyDto()).ToList();
                List<UpdateAllergyDto> addAllergyList = new List<UpdateAllergyDto>();
                List<UpdateAllergyDto> removeAllergyList = new List<UpdateAllergyDto>();
                Console.WriteLine("updated guest allergies: ");
                //for each allergy in updated list
                foreach(UpdateAllergyDto allergy in updatedGuest.allergies)
                {
                    if (!currentGuestAllergies.Any(a=>a.AllergyType == allergy.AllergyType))
                    {
                        Console.WriteLine($"No match! \n{allergy.AllergyType} not in currentGuestAllergies...\nAdding to current allergies...");
                        addAllergyList.Add(allergy);
                    }
                }

                //for each allergy in current list
                foreach(UpdateAllergyDto allergy in currentGuestAllergies)
                {
                    //if updated guest allergies contain current allergy
                    if(!updatedGuest.allergies.Any(a=>a.AllergyType == allergy.AllergyType))
                    {
                        Console.WriteLine($"No match! \n{allergy.AllergyType} not in updatedGuest.Allergies...\nDeleting from current allergies...");
                        removeAllergyList.Add(allergy);
                    }
                }

                //update guest and guest allergies
                if (!_guestRepository.UpdateGuestAllergies(updatedGuest, addAllergyList, removeAllergyList) && !_guestRepository.UpdateGuest(updatedGuest.ToGuestModel()))
                {
                    ModelState.AddModelError("", "Something went wrong while saving...");
                    return StatusCode(500, ModelState);
                }
            }

            ReadGuestDto guestDb = _guestRepository.GetGuest(updatedGuest.Id).ToReadGuestDto();

            return Ok(guestDb);
        }

        [HttpDelete("{guestId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGuest(int guestId)
        {
            if (!_guestRepository.GuestExists(guestId))
            {
                return NotFound();
            }

            //var allergiesToDelete
            var guestToDelete = _guestRepository.GetGuest(guestId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_guestRepository.DeleteGuest(guestToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting guest.");
            }

            var guestsDb =_guestRepository.GetGuests();
            List<ReadGuestDto> readGuestList = guestsDb.Select(a => a.ToReadGuestDto()).ToList();

            return Ok(readGuestList);
        }

    }
}
