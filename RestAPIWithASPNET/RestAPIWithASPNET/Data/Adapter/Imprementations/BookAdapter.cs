using RestAPIWithASPNET.Data.Adapter.Contract;
using RestAPIWithASPNET.Data.DTO;
using RestAPIWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASPNET.Data.Adapter.Imprementations
{
    public class BookAdapter : IParser<BookDTO, Book>, IParser<Book, BookDTO>
    {
        public Book Parse(BookDTO origin)
        {
            if (origin == null) return null;
            return new Book
                {
                    Id = origin.Id,
                    Author = origin.Author,
                    LaunchDate = origin.LaunchDate,
                    Price = origin.Price,
                    Title = origin.Title
                };
            
        }


        public BookDTO Parse(Book origin)
        {
            if (origin == null) return null;
            
            return new BookDTO
                {
                    Id = origin.Id,
                    Author = origin.Author,
                    LaunchDate = origin.LaunchDate,
                    Price = origin.Price,
                    Title = origin.Title
                };
            
        }
        public List<Book> Parse(List<BookDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
;        }

        public List<BookDTO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
