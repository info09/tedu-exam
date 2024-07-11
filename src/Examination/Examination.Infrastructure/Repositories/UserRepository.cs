﻿using Examination.Domain.AggregateModels.UserAgregate;
using Examination.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Examination.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle, IOptions<ExamSettings> settings, IMediator mediator, string collection) : base(mongoClient, clientSessionHandle, settings, mediator, collection)
        {
        }

        public async Task<User> GetUserByIdAsync(string externalId)
        {
            var filter = Builders<User>.Filter.Eq(i => i.ExternalId, externalId);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
