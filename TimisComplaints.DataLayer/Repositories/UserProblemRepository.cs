using System.Collections.Generic;
using System.Threading.Tasks;
using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class UserProblemRepository : BaseRepository<UserProblem>
    {
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
    }
}
