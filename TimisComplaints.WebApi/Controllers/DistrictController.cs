using System;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;

namespace TimisComplaints.WebApi.Controllers
{
    public class DistrictController : ApiController
    {
        [HttpGet]
        [ActionName("GetProblems/{id}")]
        public async Task<IHttpActionResult> GetProblemsAsync(Guid id)
        {
            try
            {
                var result = await DistrictCore.GetProblemsAsync(id);
                if (result == null)
                {
                    return BadRequest("No problems found");
                }

                return Ok(result);
            }
            catch
            {
                return InternalServerError();
            }
        } 
    }
}
