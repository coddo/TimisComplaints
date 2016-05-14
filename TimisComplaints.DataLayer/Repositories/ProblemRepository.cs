using System.Collections.Generic;
using System.Threading.Tasks;
using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class ProblemRepository : BaseRepository<Problem>
    {
        public async Task<IList<Problem>> GetBiggerBla()
        {
            var problems = await FetchListAsync(problem => problem.Description.Length > 5);

            return problems;
        }
    }
}
