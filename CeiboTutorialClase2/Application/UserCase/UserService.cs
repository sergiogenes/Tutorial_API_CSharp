using CeiboTutorialClase2.Application.UserCase.Dto;
using CeiboTutorialClase2.Domain.Entities.UserModels;
using CeiboTutorialClase2.Domain.Repositories.UserRepositories;

namespace CeiboTutorialClase2.Application.UserCase
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task<User> GetByIdAsync(int id)
        {
            return userRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<User>> GetAllAsync(int page = 1, int limit = 3)
        {

            return userRepository.GetAllAsync(page, limit);
        }

        public async Task<User> CreateAsync(CreateUser createUser)
        {
            var list = await userRepository.GetAllAsync();

            var newUser = new User
            {
                Name = createUser.Name,
                LastName = createUser.LastName,
                Email = createUser.Email,
                Id = list.Any() ? list.Last().Id + 1 : 1,
            };

            return await userRepository.CreateAsync(newUser);
        }

        public async Task<User?> UpdateAsync(int id, PartialUser partialUser)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            user.Name = partialUser.Name ?? partialUser.Name;
            user.LastName = partialUser.LastName ?? partialUser.LastName;

            return await userRepository.UpdateAsync(user);
        }

        public Task<User> DeleteAsync(int id)
        {
            return userRepository.DeleteAsync(id);
        }
    }
}
