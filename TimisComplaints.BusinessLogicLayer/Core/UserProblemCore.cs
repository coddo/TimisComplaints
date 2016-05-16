using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimisComplaints.DataLayer;
using TimisComplaints.DataLayer.Repositories;

namespace TimisComplaints.BusinessLogicLayer.Core
{
    public static class UserProblemCore
    {
        public static async Task<UserProblem> CreateAsync(UserProblem userProblem)
        {
            using (var userProblemRepository = new UserProblemRepository())
            {
                return await userProblemRepository.CreateAsync(userProblem);
            }
        }

        public static async Task<IList<UserProblem>> GetUserProblemsAsync(Guid userId)
        {
            using (var userProblemRepository = new UserProblemRepository())
            {
                return await userProblemRepository.GetUserProblemsAsync(userId);
            }
        }

        public static async Task<bool> UpdateOrderAsync(IList<UserProblem> userProblems)
        {
            using (var userProblemRepository = new UserProblemRepository())
            {
                return await userProblemRepository.UpdateOrderAsync(userProblems);
            }
        }
    }
}