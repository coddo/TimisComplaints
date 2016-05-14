using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class DistrictRepository : BaseRepository<District>
    {
        public async Task<IList<Problem>> GetProblemsAsync(Guid id)
        {
            var district = await GetAsync(id, new[]
            {
                nameof(District.Problems)
            });

            return district.Problems.ToList();
        }
    }
}