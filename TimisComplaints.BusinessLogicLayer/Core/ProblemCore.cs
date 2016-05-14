using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimisComplaints.DataLayer;
using TimisComplaints.DataLayer.Repositories;

namespace TimisComplaints.BusinessLogicLayer.Core
{
    public static class ProblemCore
    {
        public static async Task<IList<Problem>> GetAllAsync()
        {
            using (var problemRepository = new ProblemRepository())
            {
                return await problemRepository.GetAllAsync(new []
                {
                    nameof(Problem.Districts),
                    nameof(Problem.UserProblems)
                });
            }
        }

        public static async Task<Problem> CreateAsync(Problem problem)
        {
            using (var problemRepository = new ProblemRepository())
            {
                return await problemRepository.CreateAsync(problem);
            }
        }
    }
}
