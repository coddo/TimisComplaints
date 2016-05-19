using System;
using System.ComponentModel.DataAnnotations;

namespace TimisComplaints.Website.Models
{
    public class LetterModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime Date { get; set; }
    }
}