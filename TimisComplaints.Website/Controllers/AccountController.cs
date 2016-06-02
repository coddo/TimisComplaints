using System;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.Website.Models;

namespace TimisComplaints.Website.Controllers
{
    public class AccountController : IdentityInjectedController
    {
        [HttpGet]
        [ActionName("WhoAmI")]
        public IHttpActionResult WhoAmI()
        {
            try
            {
                if (Identity == null)
                {
                    return Unauthorized();
                }

                var user = new IdentityModel
                {
                    Id = Identity.Id,
                    SessionKey = Identity.SessionKey,
                    Email = Identity.Email,
                    FirstName = Identity.FirstName,
                    LastName = Identity.LastName,
                    Password = Identity.Password
                };

                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [ActionName("GetCount")]
        public async Task<IHttpActionResult> GetCount()
        {
            try
            {
                var result = await UserCore.GetCount();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}