using Microsoft.AspNetCore.Mvc;
using RestAPIWithASPNET.Model;
using RestAPIWithASPNET.Repository;

namespace RestAPIWithASPNET.Controllers
{
    [ApiVersion("2")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonRepository iPerson;

        public PersonController(IPersonRepository iPerson)
        {
            this.iPerson = iPerson;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(iPerson.ListAll());
        }

        [HttpGet("{firstNumber}")]
        public IActionResult GetById(int firstNumber)
        {
            var person = iPerson.FindById(firstNumber);
            if(person == null) return NotFound();
            
            return Ok(person);
        }


        [HttpPost]
        public IActionResult PostPerson([FromBody] Person p)
        {
            if (p == null) return BadRequest();
            return Ok(iPerson.Create(p));
        }


        [HttpPut]
        public IActionResult UpdatePerson([FromBody]Person p)
        {
            if (p == null) return BadRequest();
            return Ok(iPerson.Update(p));
        }

        [HttpDelete("{deleteId}")]
        public IActionResult DeletePerson(long deleteId)
        {
            iPerson.Delete(deleteId);
            return NoContent();
        }



    }
}
