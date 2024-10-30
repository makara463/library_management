using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using library_management_system.Models;

namespace library_management_system.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<library_management_system.Models.Branch> Branch { get; set; } = default!;
        public DbSet<library_management_system.Models.Publication> Publication { get; set; } = default!;
        public DbSet<library_management_system.Models.Student> Student { get; set; } = default!;
        public DbSet<library_management_system.Models.Book> Book { get; set; } = default!;
        public DbSet<library_management_system.Models.Issue> Issue { get; set; } = default!;
        public DbSet<library_management_system.Models.Penalty> Penalty { get; set; } = default!;
    }
}
