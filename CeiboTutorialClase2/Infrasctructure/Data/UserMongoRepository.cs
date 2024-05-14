using CeiboTutorialClase2.Application.UserCase.Dto;
using CeiboTutorialClase2.Domain.Entities.UserModels;
using CeiboTutorialClase2.Domain.Repositories.UserRepositories;
using CeiboTutorialClase2.Infrasctructure.Data.Model;
using MongoDB.Driver;

namespace CeiboTutorialClase2.Infrasctructure.Data
{
    public class UserMongoRepository : IUserRepository
    {
        private readonly IMongoCollection<UserModel> users;

        public UserMongoRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConectionString);
            var database = client.GetDatabase(databaseSettings.Name);

            this.users = database.GetCollection<UserModel>("users");
        }

        public async Task<User> CreateAsync(User createUser)
        {
            var newUser = new UserModel { 
                    Id = createUser.Id,
                    Email = createUser.Email, 
                    Name = createUser.Name, 
                    LastName = createUser.LastName, 
                    Password = createUser.Password, 
                    Roles = createUser.Roles };
            
            await users.InsertOneAsync(newUser);

            return createUser;
        }

        public Task<User> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<User>> GetAllAsync(int page = 1, int limit = 3)
        {
            var list =  await users.Aggregate().Skip((page -1) * limit).Limit(limit).ToListAsync();

            return list.Select( s => new User
            {
                Id = s.Id,
                Email = s.Email,
                Name = s.Name,
                LastName = s.LastName,
                Password = s.Password,
                Roles = s.Roles
            });
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateAsync(User updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
