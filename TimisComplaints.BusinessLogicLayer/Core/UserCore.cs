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
    }
}