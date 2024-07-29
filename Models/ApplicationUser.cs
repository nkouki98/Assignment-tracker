using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace assignment_tracker.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Assignment> Assignments { get; set; }
    }
}
