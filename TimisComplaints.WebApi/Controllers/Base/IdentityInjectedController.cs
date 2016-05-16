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
                    SessionKey = Encryptor.Md5Hash(new Guid().ToString())
                };

                Task.Run(async () => Identity = await UserCore.CreateAsync(user));

                IdentityInjector.SetCookie(user.SessionKey, DateTime.Now.AddYears(10));
            }
            else
            {
                Task.Run(async () => Identity = await UserCore.GetAsync(cookie));
            }
        }

        protected User Identity { get; private set; }
    }
}