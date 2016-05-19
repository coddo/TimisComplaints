using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.DataLayer;
using TimisComplaints.WebApi.Models;

namespace TimisComplaints.WebApi.Controllers
{
    public class LetterController : IdentityInjectedController
    {
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var letters = await LetterCore.GetAllAsync();

                IList<LetterModel> result = letters.Select(letter => new LetterModel
                {
                    Title = letter.Title,
                    Message = letter.Message,
                    Email = letter.User.Email,
                    Date = letter.Date
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IHttpActionResult> Create([FromBody] LetterModel model)
        {
            try
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

                var user = await UserCore.GetAsync(Identity.Id);
                if (user.Email == model.Email)
                {
                    return Ok(letter);
                }

                user.Email = model.Email;
                var updatedUser = await UserCore.UpdateAsync(user);
                if (updatedUser == null)
                {
                    return InternalServerError();
                }

                return Ok(letter);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}