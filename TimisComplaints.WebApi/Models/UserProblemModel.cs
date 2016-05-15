using System;

namespace TimisComplaints.WebApi.Models
{
    public class UserProblemModel
    {
        public Guid UserId { get; set; }
        public Guid ProblemId { get; set; }
        public Guid DistrictId { get; set; }
    }
}