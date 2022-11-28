using Internal.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Internal.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbContextFactory
            <ApplicationDbContext> _dbContextFactory;
        public BookRepository(IDbContextFactory
            <ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var applicationDbContext =
                _dbContextFactory.CreateDbContext())
            {
                applicationDbContext.Database
                .EnsureCreated();
            }
        }
        public List<Book> GetBooks()
        {
            using (var applicationDbContext =
                _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.Books.ToList();
            }
        }
        public Book GetBookById(int id)
        {
            using (var applicationDbContext =
                _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.Books
                             .SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
