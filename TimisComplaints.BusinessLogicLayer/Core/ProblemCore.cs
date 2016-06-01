using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimisComplaints.DataLayer;
using TimisComplaints.DataLayer.Repositories;

namespace TimisComplaints.BusinessLogicLayer.Core
{
    public static class ProblemCore
    {
        public static async Task<Problem> GetAsync(Guid id)
        {
            using (var problemRepository = new ProblemRepository())
            {
                return await problemRepository.GetAsync(id);
            }
        }

        public static async Task<IList<Problem>> GetAllAsync()
        {
            using (var problemRepository = new ProblemRepository())
            {
                return await problemRepository.GetAllAsync();
            }
        }

        public static async Task<IList<Problem>> GetAllUnaccepted(Guid userId)
        {
            using (var problemRepository = new ProblemRepository())
            {
                return await problemRepository.GetAllUnaccepted(userId);
            }
        }

        public static async Task<IList<Problem>> GetAllUnaccepted()
        {
            using (var problemRepository = new ProblemRepository())
            {
                return await problemRepository.GetAllUnaccepted();
            }
        }

        public static async Task<Problem> CreateAsync(Problem problem)
        {
            using (var problemRepository = new ProblemRepository())
            {
                return await problemRepository.CreateAsync(problem);
            }
        }

        public static async Task<Problem> UpdateAsync(Problem problem)
        {
            using (var problemRepository = new ProblemRepository())
            {
                return await problemRepository.UpdateAsync(problem);
            }
        }

        public static async Task<bool> DeleteAsync(Guid id)
        {
            using (var problemRepository = new ProblemRepository())
            {
                var problemToDelete = await problemRepository.GetAsync(id);

                return await problemRepository.DeleteAsync(problemToDelete);
            }
        }

        public static async Task<Problem> AcceptProblem(Guid id)
        {
            using (var context = new Entities())
            {
                var problemRepository = new ProblemRepository(context);
                var districtRepository = new DistrictRepository(context);

                var districts = await districtRepository.GetAllAsync().ConfigureAwait(false);
                var problem = await problemRepository.GetAsync(id, new[]
                {
                    nameof(Problem.Districts)
                });

                problem.UserId = Guid.Empty;
                foreach (var district in districts)
                {
                    problem.Districts.Add(district);
                }

                return await problemRepository.UpdateAsync(problem);
            }
        }
    }
}