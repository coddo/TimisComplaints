using System.Threading.Tasks;
using TimisComplaints.DataLayer;
using TimisComplaints.DataLayer.Repositories;

namespace TimisComplaints.BusinessLogicLayer.Core
{
    public static class SessionCore
    {
        public static async Task<User> GetUserAsync(string key)
        {
            using (var sessionRepository = new SessionRepository())
            {
                return await sessionRepository.GetUserAsync(key);
            }
        } 
    }
}
