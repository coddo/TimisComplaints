using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.Website.Models;

namespace TimisComplaints.Website.Controllers
{
    public class AdminController : IdentityInjectedController
    {
        private const string USERNAME = "Botici";
        private const string PASSWORD = "Timis#123Complaints@";

        [HttpPost]
        [ActionName("Authenticate")]
        public async Task<IHttpActionResult> Authenticate([FromBody] AuthenticationModel model)
        {
            if (model.Username != USERNAME || model.Password != PASSWORD)
            {
                await UnauthorizeUser().ConfigureAwait(false);
                return Unauthorized();
            }

            await AuthorizeUser().ConfigureAwait(false);
            return Ok();
        }

        [HttpGet]
        [ActionName("GetAllUnaccepted")]
        public async Task<IHttpActionResult> GetAllUnaccepted()
        {
            try
            {
                if (!IsAuthenticated)
                {
                    return Unauthorized();
                }

                var problems = await ProblemCore.GetAllUnaccepted();
                if (problems == null)
                {
                    return BadRequest("Invalid Id or no problems found");
                }

                var model = problems.Select(p => new ProblemModel
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    Name = p.Name,
                    Description = p.Description
                }).ToArray();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}