using System;

namespace TimisComplaints.Website.Models
{
    public class UserProblemModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ProblemId { get; set; }

        public Guid DistrictId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }
    }
}