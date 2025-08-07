using System;
using System.ComponentModel.DataAnnotations; // Required for annotations like [Key]

namespace JobPortal.Models
{
    public class Job
    {
        [Key] // Marks this property as the primary key
        public int JobId { get; set; }

        [Required(ErrorMessage = "Job title is required")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100)]
        public string Location { get; set; }

        public decimal? Salary { get; set; } // The '?' makes it optional

        [StringLength(50)]
        public string JobType { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Contact email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100)]
        public string ContactEmail { get; set; }

        public DateTime PostedDate { get; set; }
    }
}
