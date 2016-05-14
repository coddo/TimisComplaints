using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.DataLayer;

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

        [HttpPost]
        [ActionName("Create")]
        public async Task<IHttpActionResult> Create([FromBody] Problem problem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await ProblemCore.CreateAsync(problem);
                if (result == null)
                {
                    return BadRequest("Invalid input");
                }

                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
