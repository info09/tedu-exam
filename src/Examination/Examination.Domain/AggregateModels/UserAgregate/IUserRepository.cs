using System.Threading.Tasks;

namespace Examination.Domain.AggregateModels.UserAgregate
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string externalId);
    }
}
