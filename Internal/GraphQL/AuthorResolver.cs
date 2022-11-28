using HotChocolate;
using HotChocolate.Resolvers;
using Internal.DataAccess;
using Internal.DataAccess.Models;
using System.Linq;

namespace Internal.GraphQL
{
    public class AuthorResolver
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorResolver([Service] IAuthorRepository authorService)
        {
            _authorRepository = authorService;
        }
        public Author GetAuthor(Book blog, IResolverContext ctx)
        {
            return _authorRepository.GetAuthors().Where(a => a.Id == blog.AuthorId).FirstOrDefault();
        }
    }
}
