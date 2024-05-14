using CeiboTutorialClase2.Modules.UserModules.Models.Dto;
using CeiboTutorialClase2.Modules.UserModules.Models;
using CeiboTutorialClase2.Infrasctructure;

namespace CeiboTutorialClase2.Modules.UserModule.Repositories
{
    public class UserRepository
    {
        private readonly List<User> users;
        public UserRepository() 
        {
            this.users = Database.Users;
        }

        public Task<User?> GetByIdAsync(int id)
        {
            var user = this.users.FirstOrDefault(user => user.Id == id);

            return Task.FromResult(user);
        }

        public Task<IEnumerable<User>> GetAllAsync(int page = 1, int limit = 3)
        {
            var list = this.users.Skip((page - 1) * limit).Take(limit);

            return Task.FromResult(list);
        }

        public Task<User> CreateAsync(User createUser)
        {
            return Task.FromResult(createUser);
        }

        public async Task<User?> UpdateAsync(User updatedUser)
        {
            var user = await this.GetByIdAsync(updatedUser.Id);

            user.Name = updatedUser.Name;
            user.LastName = updatedUser.LastName;

            return user;
        }

        public async Task<User> DeleteAsync (int id)
        {
            var user = await this.GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            users.Remove(user);

            return user;

        }
    }
}
