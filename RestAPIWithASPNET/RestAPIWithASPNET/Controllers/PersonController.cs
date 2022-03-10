using Microsoft.AspNetCore.Mvc;
using RestAPIWithASPNET.Business.Implementations;
using RestAPIWithASPNET.Data.DTO;
using RestAPIWithASPNET.Model;
using RestAPIWithASPNET.Repository;

namespace RestAPIWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonBusiness iPerson;

        public PersonController(IPersonBusiness iPerson)
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
        public IActionResult PostPerson([FromBody] PersonDTO p)
        {
            if (p == null) return BadRequest();
            return Ok(iPerson.Create(p));
        }


        [HttpPut]
        public IActionResult UpdatePerson([FromBody]PersonDTO p)
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
