﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.DataLayer;
using TimisComplaints.WebApi.Models;

namespace TimisComplaints.WebApi.Controllers
{
    public class ProblemController : ApiController
    {
        [HttpGet]
        [ActionName("Get")]
        public async Task<IHttpActionResult> GetAsync(Guid id)
        {
            try
            {
                var problem = await ProblemCore.GetAsync(id);
                if (problem == null)
                {
                    return BadRequest("No problem with the given id found");
                }

                var result = new ProblemModel()
                {
                    Id = problem.Id,
                    Name = problem.Name,
                    Description = problem.Description
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

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

        [HttpPost]
        [ActionName("Create")]
        public async Task<IHttpActionResult> CreateAsync([FromBody] ProblemModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var problem = new Problem()
                {
                    Name = model.Name,
                    Description = model.Description
                };

                var result = await ProblemCore.CreateAsync(problem);
                if (result == null)
                {
                    return BadRequest("Invalid input");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IHttpActionResult> UpdateAsync([FromBody] ProblemModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var problemToUpdate = await ProblemCore.GetAsync(model.Id);
                if (problemToUpdate == null)
                {
                    return BadRequest("Problem couldn't be found");
                }

                problemToUpdate.Name = model.Name;
                problemToUpdate.Description = model.Description;

                var result = await ProblemCore.UpdateAsync(problemToUpdate);
                if (result == null)
                {
                    return BadRequest("Error updating problem");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IHttpActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await ProblemCore.DeleteAsync(id);
                if (!result)
                {
                    return BadRequest("Error deleting problem");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}