using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        [ActionName("GetAll")]
        public async Task<IHttpActionResult> GetUserProblemsAsync(Guid userId)
        {
            try
            {
                var userProblems = await UserProblemCore.GetUserProblemsAsync(userId);
                if (userProblems == null)
                {
                    return BadRequest("No problems found");
                }

                IList<ProblemModel> result = userProblems.Select(userProblem => new ProblemModel()
                {
                    Id = userProblem.Problem.Id,
                    Name = userProblem.Problem.Name,
                    Description = userProblem.Problem.Description
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
