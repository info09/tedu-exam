﻿using Examination.Domain.AggregateModels.ExamAgregate;
using Examination.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examination.Infrastructure.Repositories
{
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle, IOptions<ExamSettings> settings, IMediator mediator, string collection) : base(mongoClient, clientSessionHandle, settings, mediator, collection)
        {
        }

        public async Task<Exam> GetExamByIdAsync(string id)
        {
            var filter = Builders<Exam>.Filter.Eq(i => i.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Exam>> GetExamListAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }
    }
}
