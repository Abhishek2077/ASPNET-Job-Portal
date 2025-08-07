using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Required for [ForeignKey]

namespace JobPortal.Models
{
    public class JobApplication
    {
        [Key]
        public int ApplicationId { get; set; }

        [ForeignKey("Job")] // Specifies the navigation property for the foreign key
        public int JobId { get; set; }

        [Required(ErrorMessage = "Your name is required")]
        [StringLength(100)]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "Your email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100)]
        public string ApplicantEmail { get; set; }

        public string ResumeFileName { get; set; }

        public string CoverLetter { get; set; }

        public DateTime AppliedDate { get; set; }

        // Navigation property: This tells EF that JobId is a foreign key to the Job table
        public virtual Job Job { get; set; }
    }
}
