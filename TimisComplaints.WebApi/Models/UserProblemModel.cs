using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimisComplaints.DataLayer;

namespace TimisComplaints.WebApi.Models
{
    public class UserProblemModel
    {
        public User User { get; set; }

        public Problem Problem { get; set; }
    }
}