using RestAPIWithASPNET.Data.DTO;
using RestAPIWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASPNET.Business
{
    public interface IBookBusiness
    {
        List<BookDTO> GetAllBooks();

        BookDTO GetBook(long id);

        BookDTO CreateBook(BookDTO book);

        BookDTO UpdateBook(BookDTO book);

        void deleteBook(long id);
    }
}
