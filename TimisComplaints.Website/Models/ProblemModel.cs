using System;

namespace TimisComplaints.WebApi.Models
{
    public class ProblemModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Points { get; set; }
    }
}