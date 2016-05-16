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
    }
}