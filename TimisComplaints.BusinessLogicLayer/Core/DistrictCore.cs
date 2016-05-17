using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimisComplaints.DataLayer;
using TimisComplaints.DataLayer.Repositories;

namespace TimisComplaints.BusinessLogicLayer.Core
{
    public static class DistrictCore
    {
        public static async Task<District> GetAsync(Guid id)
        {
            using (var districtRepository = new DistrictRepository())
            {
                return await districtRepository.GetAsync(id, new[]
                {
                    nameof(District.Problems),
                    nameof(District.UserProblems)
                });
            }
        }

        public static async Task<IList<Problem>> GetProblemsAsync(Guid districtId)
        {
            using (var districtRepository = new DistrictRepository())
            {
                return await districtRepository.GetProblemsAsync(districtId);
            }
        }

        public static async Task<IList<District>> GetAllAsync()
        {
            using (var districtRepository = new DistrictRepository())
            {
                return await districtRepository.GetAllAsync();
            }
        }
    }
}