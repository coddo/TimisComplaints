using System;
using System.Web.Http;
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
    }
}