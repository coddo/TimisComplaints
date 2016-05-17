﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TimisComplaints.BusinessLogicLayer.Core;
using TimisComplaints.DataLayer;
using TimisComplaints.WebApi.Controllers.Base;
using TimisComplaints.WebApi.Models;
using WebGrease.Css.Extensions;

namespace TimisComplaints.WebApi.Controllers
{
    public class ProblemController : IdentityInjectedController
    {
        public ProblemController()
        {
            
        }

        [HttpGet]
        [ActionName("Get")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            try
            {
                var problem = await ProblemCore.GetAsync(id);
                if (problem == null)
                {
                    return BadRequest("No problem with the given id found");
                }

                var result = new ProblemModel
                {
                    Id = problem.Id,
                    UserId = problem.UserId,
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
        public async Task<IHttpActionResult> GetAll(Guid districtId)
        {
            try
            {
                var district = await DistrictCore.GetAsync(districtId);

                if (district == null)
                {
                    return BadRequest("Invalid districtId");
                }

                var problems = await SortAndComputePoints(district);

                return Ok(problems);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IHttpActionResult> Create([FromBody] ProblemModel model)
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
        public async Task<IHttpActionResult> Update([FromBody] ProblemModel model)
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
        public async Task<IHttpActionResult> Delete(Guid id)
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

        #region Private methods

        private static async Task<IList<ProblemModel>> SortAndComputePoints(District district)
        {
            var modelCollection = new List<ProblemModel>();

            foreach (var problem in district.Problems.Where(p => p.UserId == Guid.Empty))
            {
                var userProblems = await UserProblemCore.GetForDistrictProblemAsync(problem.Id, district.Id);

                modelCollection.Add(new ProblemModel
                {
                    Id = problem.Id,
                    UserId = problem.UserId,
                    Name = problem.Name,
                    Description = problem.Description,
                    Points = userProblems.Sum(userProblem => district.Problems.Count - userProblem.Order)
                });
            }

            return modelCollection;
        }

        #endregion
    }
}