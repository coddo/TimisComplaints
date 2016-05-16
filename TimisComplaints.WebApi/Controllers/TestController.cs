using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.WebApi.Controllers.Base;
using TimisComplaints.WebApi.Models;

namespace TimisComplaints.WebApi.Controllers
{
    public class TestController : IdentityInjectedController
    {
        [HttpGet]
        [ActionName("Test")]
        public async Task<IHttpActionResult> Test(string userName)
        {
            return await Task.Run(() =>
            {
                var myList = new List<ProblemModel>();

                for (var i = 1; i < 10; i++)
                {
                    myList.Add(new ProblemModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = userName + " prb " + i.ToString()
                    });
                }

                return Ok(myList);
            });
        }
    }
}