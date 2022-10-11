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
        private readonly IMapper _mapper;
        public GuestController(IGuestRepository guestRepository,IAllergyRepository allergyRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _guestRepository = guestRepository;
            _allergyRepository = allergyRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
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
                    //if not send error invalid allergy.
                    //if it does add it to the guest.
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
        public IActionResult UpdateGuest([FromBody]GuestDto updatedGuest)
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

            var guestMap = _mapper.Map<Guest>(updatedGuest);

            if(!_guestRepository.UpdateGuest(guestMap))
            {
                ModelState.AddModelError("", "Something went wrong updating guest.");
                return StatusCode(500, ModelState);
            }


            var guestDb = _mapper.Map<GuestDto>(_guestRepository.GetGuest(updatedGuest.Id));
            //var guestDb = _guestRepository.GetGuest(updatedGuest.Id);

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
