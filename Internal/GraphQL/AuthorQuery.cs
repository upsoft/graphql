using HotChocolate;
using HotChocolate.Subscriptions;
using Internal.DataAccess;
using Internal.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Internal.GraphQL
{
    public class Query
    {
        public async Task<List<Author>>
        GetAllAuthors([Service]
        IAuthorRepository authorRepository,
        [Service] ITopicEventSender eventSender)
        {
            List<Author> authors =
            authorRepository.GetAuthors();
            await eventSender.SendAsync("ReturnedAuthors",
            authors);
            return authors;
        }
        public async Task<Author> GetAuthorById([Service]
        IAuthorRepository authorRepository,
        [Service] ITopicEventSender eventSender, int id)
        {
            Author author =
            authorRepository.GetAuthorById(id);
            await eventSender.SendAsync("ReturnedAuthor",
            author);
            return author;
        }
        public async Task<List<Book>>
        GetAllBooks([Service] IBookRepository
        BookRepository,
        [Service] ITopicEventSender eventSender)
        {
            List<Book> Books =
            BookRepository.GetBooks();
            await eventSender.SendAsync("ReturnedBooks",
            Books);
            return Books;
        }
        public async Task<Book> GetBookById([Service]
        IBookRepository BookRepository,
        [Service] ITopicEventSender eventSender, int id)
        {
            Book Book =
            BookRepository.GetBookById(id);
            await eventSender.SendAsync("ReturnedBook",
            Book);
            return Book;
        }
    }
}
