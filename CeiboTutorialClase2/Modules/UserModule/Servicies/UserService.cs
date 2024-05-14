﻿using CeiboTutorialClase2.Modules.UserModule.Repositories;
using CeiboTutorialClase2.Modules.UserModules.Models;
using CeiboTutorialClase2.Modules.UserModules.Models.Dto;

namespace CeiboTutorialClase2.Modules.UserModule.Servicies
{
    public class UserService
    {
        private readonly UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task<User> GetByIdAsync (int id)
        {
            return userRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<User>> GetAllAsync (int page = 1, int limit = 3)
        {
            
            return userRepository.GetAllAsync(page, limit);
        }

        public async  Task<User> CreateAsync(CreateUser createUser)
        {
            var list = await userRepository.GetAllAsync();

            var newUser = new User
            {
                Name = createUser.Name,
                LastName = createUser.Name,
                Email = createUser.Email,
                Id = list.Last().Id + 1,
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

        public Task<User> DeleteAsync (int id)
        {
            return userRepository.DeleteAsync(id);
        }
    }
}
