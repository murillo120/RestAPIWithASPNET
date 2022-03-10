using RestAPIWithASPNET.Data.Adapter.Imprementations;
using RestAPIWithASPNET.Data.DTO;
using RestAPIWithASPNET.Model;
using RestAPIWithASPNET.Repository;
using RestAPIWithASPNET.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASPNET.Business.Implementations
{
    public class BookBusinessImpl : IBookBusiness
    {

        private readonly IRepository<Book> repository;

        private readonly BookAdapter adapter;

        public BookBusinessImpl(IRepository<Book> bookRepository)
        {
            repository = bookRepository;

            adapter = new BookAdapter();
        }

        public List<BookDTO> GetAllBooks()
        {
            return adapter.Parse(repository.ListAll());
        }

        public BookDTO GetBook(long id)
        {
            return adapter.Parse(repository.FindById(id));
        }
        public BookDTO CreateBook(BookDTO bookDTO)
        {
            var bookEntity = adapter.Parse(bookDTO);
            return adapter.Parse(repository.Create(bookEntity));
        }

        public void deleteBook(long id)
        {
            repository.Delete(id);
        }

        
        public BookDTO UpdateBook(BookDTO book)
        {
            var bookEntity = adapter.Parse(book);
            return adapter.Parse(repository.Update(bookEntity));
        }
    }
}
