using Microsoft.AspNetCore.Mvc;
using NaukaWebApi.Models;
using NaukaWebApi.Services.PersonService;

namespace NaukaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        [Route("GetPeople")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            IEnumerable<Person> result = await this.personService.GetAllAsync();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            Person person = await this.personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPut]
        [Route("PutPerson")]
        public async Task<IActionResult> Put(Person person)
        {
            try
            {
                await this.personService.UpdateAsync(person);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<Person>> Post(Person person)
        {
            try
            {
                await this.personService.CreateAsync(person);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("DeletePerson/{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            Person person = await this.personService.GetByIdAsync(id);
            await this.personService.DeleteAsync(person);
            return person;
        }
    }
}
