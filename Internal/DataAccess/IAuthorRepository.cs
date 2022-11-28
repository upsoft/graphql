using Internal.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Internal.DataAccess
{
    public interface IAuthorRepository
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(int id);
        public Task<Author> CreateAuthor(Author author);
    }
}
