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
    }
}
