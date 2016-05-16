using System;
using System.Threading.Tasks;
using TimisComplaints.DataLayer;
using TimisComplaints.DataLayer.Repositories;

namespace TimisComplaints.BusinessLogicLayer.Core
{
    public static class UserCore
    {
        public static async Task<User> GetAsync(Guid id)
        {
            using (var userRepository = new UserRepository())
            {
                return await userRepository.GetAsync(id);
            }
        }

        public static async Task<User> GetAsync(string sessionKey)
        {
            using (var userRepository = new UserRepository())
            {
                return await userRepository.GetAsync(sessionKey);
            }
        }

        public static async Task<User> CreateAsync(User user)
        {
            if (user == null)
            {
                return null;
            }

            if (user.Id == Guid.Empty)
            {
                user.Id = Guid.NewGuid();
            }

            using (var userController = new UserRepository())
            {
                return await userController.CreateAsync(user);
            }
        }
    }
}