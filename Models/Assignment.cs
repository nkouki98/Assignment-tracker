using System;
using System.ComponentModel.DataAnnotations;

namespace assignment_tracker.Models
{
    public class Assignment
    {
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime Deadline { get; set; }

    [Required]
    public string Course { get; set; }

    [Required]
    [EmailAddress]
    public string InstructorEmail { get; set; }

    public string? UserId { get; set; } // User ID should be a string

     // Navigation property
    public ApplicationUser? User { get; set; }

    [Required]
    public string Status { get; set; } = "Pending"; // New status property with default value
}

}
