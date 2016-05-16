using System.Threading.Tasks;
using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class SessionRepository : BaseRepository<Session>
    {
        public async Task<User> GetUserAsync(string key)
        {
            var session = await FetchSingleAsync(s => s.Key == key, new[]
            {
                nameof(Session.User)
            });

            return session?.User;
        }
    }
}