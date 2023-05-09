using API_Labb_4.Models;
using API_Labb_4.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Labb_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPersonRepository _personRepository;

        public PeopleController(IPersonRepository apiRepository)
        {
            _personRepository = apiRepository;
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            return Ok(_personRepository.GetAllPersons());
        }


        [HttpGet("{id:int}")]
        public IActionResult GetSinglePerson(int id)
        {
            var person = _personRepository.GetSinglePerson(id);
            if (person != null)
            {
                return Ok(person);
            }
            return NotFound($"ERROR: No user with id {id} found");
        }


        [HttpPost]
        public IActionResult AddNewPerson(Person person)
        {
            _personRepository.AddPerson(person);
            return Created(HttpContext.Request.Scheme +
                    "://" +
                    HttpContext.Request.Host +
                    HttpContext.Request.Path +
                    "/" +
                    person.Id, person);
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var userToDelete = _personRepository.GetSinglePerson(id);
            if (userToDelete != null)
            {
                _personRepository.RemovePerson(userToDelete);
                return Ok();
            }
            return NotFound($"ERROR: No user with id {id} found");
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person personToUpdate)
        {
            var existingUser = _personRepository.GetSinglePerson(id);
            if (existingUser != null)
            {
                existingUser.Id = personToUpdate.Id;
                _personRepository.UpdatePerson(personToUpdate);
            }
            return Ok();
        }
    }
}
