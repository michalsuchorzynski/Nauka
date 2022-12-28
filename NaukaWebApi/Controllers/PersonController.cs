using Microsoft.AspNetCore.Mvc;
using NaukaWebApi.Models;
using NaukaWebApi.Services.PersonService;

namespace NaukaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;


        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            this._logger = logger;
            this._personService = personService;
            _logger.LogInformation("PersonController init");
        }

        [HttpGet]
        [Route("GetPeople")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            _logger.LogInformation("PersonController execute GetPeople");
            IEnumerable<Person> result = await this._personService.GetAllAsync();
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
            Person person = await this._personService.GetByIdAsync(id);
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
                await this._personService.UpdateAsync(person);
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
                await this._personService.CreateAsync(person);
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
            Person person = await this._personService.GetByIdAsync(id);
            await this._personService.DeleteAsync(person);
            return person;
        }
    }
}
