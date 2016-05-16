using System;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.DataLayer;
using TimisComplaints.WebApi.Controllers.Base;
using TimisComplaints.WebApi.Models;

namespace TimisComplaints.WebApi.Controllers
{
    public class LetterController : IdentityInjectedController
    {
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            var letters = await LetterCore.GetAllAsync();

            return Ok(letters);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IHttpActionResult> Create([FromBody] LetterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var letter = new Letter
            {
                UserId = Identity.Id,
                Date = DateTime.Now,
                Message = model.Message,
                Title = model.Title
            };

            letter = await LetterCore.CreateAsync(letter);
            if (letter == null)
            {
                return InternalServerError();
            }

            return Ok(letter);
        }
    }
}
