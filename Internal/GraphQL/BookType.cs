using HotChocolate.Types;
using Internal.DataAccess.Models;

namespace Internal.GraphQL
{
    public class BookType : ObjectType<Book>
    {
        protected override void
        Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.Title).Type<StringType>();
            descriptor.Field(b => b.AuthorId).Type<IntType>();
            descriptor.Field<AuthorResolver>(t =>
            t.GetAuthor(default, default));
        }
    }
}
