using System;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.DataLayer;
using TimisComplaints.WebApi.Filters;

namespace TimisComplaints.Website.Controllers
{
    public abstract class IdentityInjectedController : ApiController
    {
        protected IdentityInjectedController()
        {
            var cookie = IdentityInjector.GetCookie();

            Identity = null;
            if (cookie != null)
            {
                Identity = Task.Run(() => UserCore.GetAsync(cookie)).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            if (Identity == null)
            {
                Identity = CreateNewUser();
            }
        }

        protected User Identity { get; }

        private User CreateNewUser()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                SessionKey = Encryptor.Md5Hash(Guid.NewGuid().ToString())
            };

            var createUserTask = Task.Run(() => UserCore.CreateAsync(user)).ConfigureAwait(false);

            IdentityInjector.SetCookie(user.SessionKey, DateTime.Now.AddYears(10));

            return createUserTask.GetAwaiter().GetResult();
        }
    }
}