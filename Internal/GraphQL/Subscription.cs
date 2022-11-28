using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Internal.DataAccess.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Internal.GraphQL
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>>
        OnAuthorCreated([Service]
        ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync
            <string, Author>("AuthorCreated",
            cancellationToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream
        <List<Author>>> OnAuthorsGet([Service]
        ITopicEventReceiver eventReceiver,
           CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string,
            List<Author>>("ReturnedAuthors",
            cancellationToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>>
        OnAuthorGet([Service] ITopicEventReceiver
        eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string,
            Author>("ReturnedAuthor", cancellationToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Book>>
        OnBooksGet([Service] ITopicEventReceiver
        eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string,
            Book>("ReturnedBooks", cancellationToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Book>>
        OnBookGet([Service] ITopicEventReceiver
        eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string,
            Book>("ReturnedBook", cancellationToken);
        }
    }
}
