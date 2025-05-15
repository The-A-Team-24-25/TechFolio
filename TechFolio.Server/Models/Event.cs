using System;
using System.ComponentModel.DataAnnotations;

namespace UsersApp.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string FeedbackFormUrl { get; set; }

        public bool IsPresent { get; set; }
    }
}
