using System;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.DataLayer;
using TimisComplaints.WebApi.Models;

namespace TimisComplaints.WebApi.Controllers
{
    public class UserProblemController : ApiController
    {
        [HttpPost]
        [ActionName("Create")]
        public async Task<IHttpActionResult> CreateAsync([FromBody]UserProblemModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                var userProblem = new UserProblem()
                {
                    UserId = model.UserId,
                    ProblemId = model.ProblemId,
                    DistrictId = model.DistrictId,
                    Date = DateTime.Now
                };

                var result = await UserProblemCore.CreateAsync(userProblem);
                if (result == null)
                {
                    return BadRequest("Error adding the problem to the user");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        } 
    }
}
