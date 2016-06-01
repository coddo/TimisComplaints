using System;
using System.Collections.Generic;

namespace TimisComplaints.Website.Models
{
    public class AssignUserProblemsModel
    {
        public Guid DistrictId { get; set; }

        public ICollection<UserProblemModel> UserProblems { get; set; }
    }
}