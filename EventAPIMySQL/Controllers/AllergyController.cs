using AutoMapper;
using EventAPIMySQL.Dto.Allergy;
using EventAPIMySQL.Interfaces;
using EventAPIMySQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : Controller
    {
        private readonly IAllergyRepository _allergyRepository;
        private readonly IMapper _mapper;
        public AllergyController(IAllergyRepository allergyRepository, IMapper mapper)
        {
            _allergyRepository = allergyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Allergy>))]
        public IActionResult GetAllergies()
        {
            var allergies = _mapper.Map<List<AllergyDto>>(_allergyRepository.GetAllergies());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(allergies);
        }

        [HttpGet("{allergyId}")]
        [ProducesResponseType(200, Type = typeof(Allergy))]
        [ProducesResponseType(400)]
        public IActionResult GetAllergy(int allergyId)
        {
            if (!_allergyRepository.AllergyExists(allergyId))
                return NotFound();

            var allergy = _mapper.Map<AllergyDto>(_allergyRepository.GetAllergy(allergyId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(allergy);
        }
    }
}
