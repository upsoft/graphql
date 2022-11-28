﻿using HotChocolate;
using HotChocolate.Subscriptions;
using Internal.DataAccess;
using Internal.DataAccess.Models;
using System.Threading.Tasks;

namespace Internal.GraphQL
{
    public class Mutation
    {
        public async Task<Author> CreateAuthor([Service]
        AuthorRepository authorRepository,
        [Service] ITopicEventSender eventSender, int id,
        string firstName, string lastName)
        {
            var data = new Author
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };
            var result = await
            authorRepository.CreateAuthor(data);
            await eventSender.SendAsync("AuthorCreated", result);
            return result;
        }
    }
}
