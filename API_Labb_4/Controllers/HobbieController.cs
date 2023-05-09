using API_Labb_4.Models;
using API_Labb_4.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Labb_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbieController : ControllerBase
    {
        private IHobbieRepository _hobbieRepository;
        private IPersonRepository _personRepository;

        public HobbieController(IHobbieRepository apiRepository, IPersonRepository personRepository)
        {
            _hobbieRepository = apiRepository;
            _personRepository = personRepository;
        }


        [HttpGet("{id:int}")]
        public IActionResult GetPersonHobbies(int id)
        {
            var personHobbies = _hobbieRepository.GetHobbiesOfPerson(id);
            if (personHobbies == null)
            {
                return NotFound($"ERROR: No user with id {id} found");
            }
            return Ok(personHobbies);
        }


        [HttpPost]
        public IActionResult AddHobbieToPerson(HobbieLink hobbieLink)
        {
            var result = _personRepository.GetSinglePerson(hobbieLink.PersonId);
            if (result != null)
            {
                _hobbieRepository.AddHobbieToPerson(hobbieLink);
                return Created(HttpContext.Request.Scheme +
                    "://" +
                    HttpContext.Request.Host +
                    HttpContext.Request.Path +
                    "/" +
                    hobbieLink.Id, hobbieLink);
            }
            return NotFound($"ERROR: No user with id {hobbieLink.PersonId} found");
        }
    }
}
