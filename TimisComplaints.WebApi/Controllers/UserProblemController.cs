using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.DataLayer;
using TimisComplaints.WebApi.Controllers.Base;
using TimisComplaints.WebApi.Models;

namespace TimisComplaints.WebApi.Controllers
{
    public class UserProblemController : IdentityInjectedController
    {
        [HttpPost]
        [ActionName("Create")]
        public async Task<IHttpActionResult> CreateAsync([FromBody] UserProblemModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userProblem = new UserProblem
                {
                    UserId = model.UserId,
                    ProblemId = model.ProblemId,
                    DistrictId = model.DistrictId,
                    Date = DateTime.Now,
                    Order = model.Order
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

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IHttpActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await UserProblemCore.DeleteAsync(id);
                if (!result)
                {
                    return BadRequest("Error deleting user problem");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [ActionName("UpdateOrder")]
        public async Task<IHttpActionResult> UpdateOrder([FromBody] IList<UserProblemModel> model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IList<UserProblem> userProblems = model.Select(m => new UserProblem()
                {
                    Id = m.Id,
                    Order = m.Order
                }).ToList();

                var result = await UserProblemCore.UpdateOrderAsync(userProblems);
                if (!result)
                {
                    return BadRequest("Error updating the user problems order");
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

                IList<UserProblemModel> result = userProblems.Select(userProblem => new UserProblemModel()
                {
                    Id = userProblem.Id,
                    UserId = userProblem.UserId,
                    ProblemId = userProblem.ProblemId,
                    DistrictId = userProblem.DistrictId,
                    Name = userProblem.Problem.Name,
                    Description = userProblem.Problem.Description,
                    Order = userProblem.Order
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