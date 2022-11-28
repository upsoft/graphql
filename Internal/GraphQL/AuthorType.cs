using HotChocolate.Types;
using Internal.DataAccess.Models;

namespace Internal.GraphQL
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a =>
            a.FirstName).Type<StringType>();
            descriptor.Field(a =>
            a.LastName).Type<StringType>();
            descriptor.Field<BookResolver>(b =>b.GetBooks(default, default));
        }
    }
}
