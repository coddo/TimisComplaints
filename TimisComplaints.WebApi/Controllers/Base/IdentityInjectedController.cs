using System;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.DataLayer;
using TimisComplaints.WebApi.Filters;

namespace TimisComplaints.WebApi.Controllers.Base
{
    public abstract class IdentityInjectedController : ApiController
    {
        protected IdentityInjectedController()
        {
            var cookie = IdentityInjector.GetCookie();

            if (cookie == null)
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    SessionKey = Encryptor.Md5Hash(Guid.NewGuid().ToString())
                };

                Identity = Task.Run(() => UserCore.CreateAsync(user)).ConfigureAwait(false).GetAwaiter().GetResult();

                IdentityInjector.SetCookie(user.SessionKey, DateTime.Now.AddYears(10));
            }
            else
            {
                Identity = Task.Run(() => UserCore.GetAsync(cookie)).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            if (Identity == null)
            {
                Identity = new User();
            }
        }

        protected User Identity { get; }
    }
}