﻿using Examination.Domain.AggregateModels.ExamResultAggregate;
using Examination.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Examination.Infrastructure.Repositories
{
    public class ExamResultRepository : BaseRepository<ExamResult>, IExamResultRepository
    {
        public ExamResultRepository(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle, IOptions<ExamSettings> settings, IMediator mediator) : base(mongoClient, clientSessionHandle, settings, mediator, Constants.Collections.ExamResult)
        {
        }

        public async Task<ExamResult> GetDetails(string userId, string examId)
        {
            var filter = Builders<ExamResult>.Filter.Where(i => i.ExamId == examId && i.UserId == userId);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
