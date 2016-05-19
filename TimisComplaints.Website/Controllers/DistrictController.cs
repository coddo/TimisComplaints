using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.Website.Models;

namespace TimisComplaints.Website.Controllers
{
    public class DistrictController : IdentityInjectedController
    {
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var districts = await DistrictCore.GetAllAsync();
                if (districts == null)
                {
                    return BadRequest("No districts found");
                }

                IList<DistrictModel> result = districts.Select(district => new DistrictModel()
                {
                    Id = district.Id,
                    Name = district.Name
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [ActionName("GetProblems")]
        public async Task<IHttpActionResult> GetProblems(Guid districtId)
        {
            try
            {
                var problems = await DistrictCore.GetProblemsAsync(districtId);
                if (problems == null)
                {
                    return BadRequest("No problems found");
                }

                IList<ProblemModel> result = problems.Select(problem => new ProblemModel()
                {
                    Id = problem.Id,
                    UserId = problem.UserId,
                    Name = problem.Name,
                    Description = problem.Description
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