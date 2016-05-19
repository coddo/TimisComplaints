using System;

namespace TimisComplaints.WebApi.Models
{
    public class IdentityModel
    {
        public System.Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SessionKey { get; set; }
    }
}