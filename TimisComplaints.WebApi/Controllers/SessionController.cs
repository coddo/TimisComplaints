using System;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;

namespace TimisComplaints.WebApi.Controllers
{
    public class SessionController : ApiController
    {
        [HttpGet]
        [ActionName("GetUser")]
        public async Task<IHttpActionResult> GetUserAsync(string key)
        {
            try
            {
                var user = await SessionCore.GetUserAsync(key);
                if (user == null)
                {
                    return BadRequest("No user with the given key found");
                }

                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        } 
    }
}
