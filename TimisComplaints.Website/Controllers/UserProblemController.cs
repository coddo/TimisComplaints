using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.DataLayer;
using TimisComplaints.Website.Models;

namespace TimisComplaints.Website.Controllers
{
    public class UserProblemController : IdentityInjectedController
    {
        [HttpPost]
        [ActionName("Assign")]
        public async Task<IHttpActionResult> Assign([FromBody] AssignUserProblemsModel model)
        {
            try
            {
                var districtId = model.DistrictId;

                var userProblems = await UserProblemCore.GetUserProblemsAsync(Identity.Id, districtId).ConfigureAwait(false);
                if (userProblems != null && userProblems.Count > 0)
                {
                    var result = await UserProblemCore.DeleteAsync(userProblems).ConfigureAwait(false);
                    if (!result)
                    {
                        return InternalServerError();
                    }
                }

                if (model.UserProblems.Count == 0)
                {
                    return Ok();
                }

                var newUserProblems = model.UserProblems.Select(userProblemModel => new UserProblem
                {
                    UserId = Identity.Id,
                    ProblemId = userProblemModel.ProblemId,
                    DistrictId = districtId,
                    Date = DateTime.Now,
                    Order = userProblemModel.Order
                }).ToArray();

                var createdProblems = await UserProblemCore.CreateAsync(newUserProblems).ConfigureAwait(false);
                if (createdProblems == null)
                {
                    return InternalServerError();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IHttpActionResult> Create([FromBody] UserProblemModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userProblem = new UserProblem
                {
                    UserId = Identity.Id,
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

                return Ok(userProblem);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [ActionName("Delete")]
        public async Task<IHttpActionResult> Delete(Guid id)
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
        public async Task<IHttpActionResult> UpdateOrder([FromBody] IEnumerable<UserProblemModel> model)
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
        public async Task<IHttpActionResult> GetAll(Guid districtId)
        {
            try
            {
                var userProblems = await UserProblemCore.GetUserProblemsAsync(Identity.Id, districtId);
                if (userProblems == null)
                {
                    return BadRequest("Invalid input");
                }

                var resultModel = userProblems.Select(userProblem => new UserProblemModel
                {
                    Id = userProblem.Id,
                    UserId = userProblem.UserId,
                    ProblemId = userProblem.ProblemId,
                    DistrictId = userProblem.DistrictId,
                    Name = userProblem.Problem.Name,
                    Description = userProblem.Problem.Description,
                    Order = userProblem.Order
                }).OrderBy(p => p.Order).ToList();

                return Ok(resultModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}