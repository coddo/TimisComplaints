using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class ProblemRepository : BaseRepository<Problem>
    {
        public ProblemRepository()
        {

        }

        public ProblemRepository(Entities context) : base(context)
        {

        }

        public async Task<IList<Problem>> GetAllUnaccepted(Guid userId)
        {
            return await FetchListAsync(problem => problem.UserId == userId);
        }

        public async Task<IList<Problem>> GetAllUnaccepted()
        {
            return await FetchListAsync(problem => problem.UserId != Guid.Empty, new []
            {
                nameof(Problem.User)
            });
        }
    }
}