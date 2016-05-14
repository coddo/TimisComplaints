using System;

namespace TimisComplaints.WebApi.Models
{
    public class ProblemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}