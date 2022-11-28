using HotChocolate;
using HotChocolate.Resolvers;
using Internal.DataAccess;
using Internal.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace Internal.GraphQL
{
    public class BookResolver
    {
        private readonly IBookRepository
        _BookRepository;
        public BookResolver([Service]
        IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }
        public IEnumerable<Book> GetBooks(
        Author author, IResolverContext ctx)
        {
            return _BookRepository.GetBooks().Where(b => b.AuthorId == author.Id);
        }
    }
}
