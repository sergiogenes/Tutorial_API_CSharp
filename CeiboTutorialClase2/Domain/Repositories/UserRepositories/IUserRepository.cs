using CeiboTutorialClase2.Domain.Entities.UserModels;

namespace CeiboTutorialClase2.Domain.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User createUser);
        Task<User> DeleteAsync(int id);
        Task<IEnumerable<User>> GetAllAsync(int page = 1, int limit = 3);
        Task<User?> GetByIdAsync(int id);
        Task<User?> UpdateAsync(User updatedUser);
    }
}