using System;

namespace TimisComplaints.WebApi.Models
{
    public class UserProblemModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProblemId { get; set; }
        public Guid DistrictId { get; set; }
        public int Order { get; set; }
    }
}