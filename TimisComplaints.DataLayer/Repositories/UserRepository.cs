using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public async Task<IList<UserProblem>> GetUserProblemsAsync(Guid id)
        {
            var user = await GetAsync(id, new[]
            {
                "UserProblems.Problem"
            });

            return user.UserProblems.ToList();
        }
    }
}
