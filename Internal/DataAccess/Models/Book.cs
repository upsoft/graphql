using HotChocolate;
using HotChocolate.Types;

namespace Internal.DataAccess.Models
{
    public class Book
    {
        public int Id { get; set; }
        [GraphQLType(typeof(NonNullType<StringType>))]
        public string Title { get; set; }
        [GraphQLNonNullType]
        public int AuthorId { get; set; }
    }
}
