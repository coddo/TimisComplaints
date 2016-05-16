using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public async Task<User> GetAsync(string sessionKey, IList<string> navigationProperties = null)
        {
            return await FetchSingleAsync(entity => entity.SessionKey == sessionKey, navigationProperties);
        }
    }
}