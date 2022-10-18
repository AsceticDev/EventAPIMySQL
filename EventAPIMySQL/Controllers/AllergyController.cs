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
        public AllergyController(IAllergyRepository allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Allergy>))]
        public IActionResult GetAllergies()
        {
            var allergiesDb = _allergyRepository.GetAllergies();

            List<ReadAllergyDto> readAllergies = allergiesDb.Select(a => a.ToReadAllergyDto()).ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(readAllergies);
        }

        [HttpGet("{allergyId}")]
        [ProducesResponseType(200, Type = typeof(Allergy))]
        [ProducesResponseType(400)]
        public IActionResult GetAllergy(int allergyId)
        {
            if (!_allergyRepository.AllergyExists(allergyId))
                return NotFound();


            var allergyDb = _allergyRepository.GetAllergy(allergyId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(allergyDb.ToReadAllergyDto());
        }
    }
}
