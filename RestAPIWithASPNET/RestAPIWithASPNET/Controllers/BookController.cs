using Microsoft.AspNetCore.Mvc;
using RestAPIWithASPNET.Business;
using RestAPIWithASPNET.Data.DTO;
using RestAPIWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {
        public IBookBusiness book;
        public BookController(IBookBusiness bookBusiness)
        {
            book = bookBusiness;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(book.GetAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(long id)
        {
            var result = book.GetBook(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] BookDTO bookParam)
        {
            if (bookParam == null) return BadRequest();
            return Ok(book.CreateBook(bookParam));
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] BookDTO bookParam)
        {
            if (bookParam == null) return BadRequest();
            return Ok(book.UpdateBook(bookParam));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(long id)
        {
            book.deleteBook(id);
            return NoContent();
        }
    }
}
