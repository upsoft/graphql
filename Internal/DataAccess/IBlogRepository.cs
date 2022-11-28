using Internal.DataAccess.Models;
using System.Collections.Generic;

namespace Internal.DataAccess
{
    public interface IBookRepository
    {
        public List<Book> GetBooks();
        public Book GetBookById(int id);
    }
}
