using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class UserProblemRepository : BaseRepository<UserProblem>
    {
        public UserProblemRepository()
        {

        }

        public UserProblemRepository(Entities context) : base(context)
        {

        }

        public async Task<bool> UpdateOrderAsync(IList<UserProblem> userProblems)
        {
            foreach (var userProblem in userProblems)
            {
                var userProblemToUpdate = await GetAsync(userProblem.Id);
                userProblemToUpdate.Order = userProblem.Order;

                var result = await UpdateAsync(userProblemToUpdate);
                if (result == null)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<IList<UserProblem>> GetUserProblemsAsync(Guid userId, Guid districtId)
        {
            var userProblems = await FetchListAsync(p => p.UserId == userId && p.DistrictId == districtId, new[]
            {
                nameof(UserProblem.Problem)
            });

            return userProblems.ToList();
        }

        public async Task<IList<UserProblem>> GetForDistrictProblemAsync(Guid problemId, Guid districtId)
        {
            var userProblems = await FetchListAsync(p => p.ProblemId == problemId && p.DistrictId == districtId, new[]
            {
                nameof(UserProblem.Problem)
            });

            return userProblems.ToList();
        }
    }
}