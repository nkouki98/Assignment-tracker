using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using assignment_tracker.Models;

namespace assignment_tracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for Assignments
        public DbSet<Assignment> Assignments { get; set; }

        // Override OnModelCreating if you need to configure entity relationships or constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configurations, if needed
            // For example:
            modelBuilder.Entity<Assignment>()
                .HasOne<ApplicationUser>(a => a.User)
                .WithMany(u => u.Assignments)
                .HasForeignKey(a => a.UserId)
                .IsRequired(false); 
        }
    }
}
