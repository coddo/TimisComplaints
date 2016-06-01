using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class DistrictRepository : BaseRepository<District>
    {
        public DistrictRepository()
        {
            
        }

        public DistrictRepository(Entities context) : base(context)
        {
            
        } 

        public async Task<IList<Problem>> GetProblemsAsync(Guid districtId)
        {
            var district = await GetAsync(districtId, new[]
            {
                nameof(District.Problems)
            });

            return district.Problems.ToList();
        }
    }
}