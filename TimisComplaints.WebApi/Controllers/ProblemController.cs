using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;

namespace TimisComplaints.WebApi.Controllers
{
    public class ProblemController : ApiController
    {
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            var problems = await ProblemCore.GetAllAsync();
            if (problems == null)
            {
                return InternalServerError();
            }

            return Ok(problems);
        }
    }
}
