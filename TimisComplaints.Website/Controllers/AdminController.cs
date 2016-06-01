using System.Threading.Tasks;
using System.Web.Http;

namespace TimisComplaints.Website.Controllers
{
    public class AdminController : ApiController
    {
        private const string USERNAME = "Botici";
        private const string PASSWORD = "Timis#123Complaints@";

        [HttpGet]
        [ActionName("Authenticate")]
        public IHttpActionResult Authenticate(string username, string password)
        {
            if (username != USERNAME || password != PASSWORD)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}