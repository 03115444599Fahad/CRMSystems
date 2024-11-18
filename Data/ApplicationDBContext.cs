
using VisaApplicationSystem.Models;
using VisaApplicationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace VisaApplicationSystem.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<User> User { get; set; }
        public DbSet<VisaApplication> VisaApplications { get; set; }

    }
}
