using CeiboTutorialClase2.Domain.Entities.UserModels;
using CeiboTutorialClase2.Domain.Repositories.UserRepositories;

namespace CeiboTutorialClase2.Infrasctructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users;
        public UserRepository()
        {
            users = Database.Users;
        }

        public Task<User?> GetByIdAsync(int id)
        {
            var user = users.FirstOrDefault(user => user.Id == id);

            return Task.FromResult(user);
        }

        public Task<IEnumerable<User>> GetAllAsync(int page = 1, int limit = 3)
        {
            var list = users.Skip((page - 1) * limit).Take(limit);

            return Task.FromResult(list);
        }

        public Task<User> CreateAsync(User createUser)
        {
            return Task.FromResult(createUser);
        }

        public async Task<User?> UpdateAsync(User updatedUser)
        {
            var user = await GetByIdAsync(updatedUser.Id);

            user.Name = updatedUser.Name;
            user.LastName = updatedUser.LastName;

            return user;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            users.Remove(user);

            return user;

        }
    }
}
