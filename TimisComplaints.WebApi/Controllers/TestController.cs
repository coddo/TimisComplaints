using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TimisComplaints.WebApi.Models;

namespace TimisComplaints.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("test/{userName}")]
        [HttpGet]
        public IHttpActionResult Test(string userName)
        {

            List<ProblemModel> myList = new List<ProblemModel>();

            for (int i = 1; i < 10; i++)
                myList.Add(new ProblemModel() { Id = i, Name = userName + " prb " + i.ToString() });

            return Ok(myList);
        }
    }
}
