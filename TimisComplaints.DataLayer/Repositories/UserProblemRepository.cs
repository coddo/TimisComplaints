using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class UserProblemRepository : BaseRepository<UserProblem>
    {
        public async Task<IList<UserProblem>> GetUserProblemsAsync(Guid userId)
        {
            var userProblems = await FetchListAsync(p => p.UserId == userId, new []
            {
                nameof(UserProblem.Problem)
            });

            return userProblems.ToList();
        }
    }
}
