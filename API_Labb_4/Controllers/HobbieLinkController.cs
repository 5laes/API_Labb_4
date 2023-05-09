using API_Labb_4.Models;
using API_Labb_4.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Labb_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbieLinkController : ControllerBase
    {
        private IHobbieLinkRepository _hobbieLinkRepository;
        private IPersonRepository _personRepository;

        public HobbieLinkController(IHobbieLinkRepository apiRepository, IPersonRepository personRepository)
        {
            _hobbieLinkRepository = apiRepository;
            _personRepository = personRepository;
        }


        [HttpGet("{id:int}")]
        public IActionResult GetPersonHobbieLinks(int id)
        {
            var personHobbieLinks = _hobbieLinkRepository.GetHobbieLinksOfPerson(id);
            if (personHobbieLinks == null)
            {
                return NotFound($"ERROR: No user with id {id} found");
            }
            return Ok(personHobbieLinks);
        }


        [HttpPost]
        public IActionResult AddHobbieToPerson(HobbieLink hobbieLink)
        {
            var result = _personRepository.GetSinglePerson(hobbieLink.PersonId);
            if (result != null)
            {
                _hobbieLinkRepository.AddHobbieLinkToPerson(hobbieLink);
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
