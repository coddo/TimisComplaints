using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.WebApi.Models;

namespace TimisComplaints.WebApi.Controllers
{
    public class ProblemController : ApiController
    {
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            try
            {
                var problems = await ProblemCore.GetAllAsync();
                if (problems == null)
                {
                    return BadRequest("No problems found");
                }

                IList<ProblemModel> result = problems.Select(problem => new ProblemModel()
                {
                    Id = problem.Id,
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
