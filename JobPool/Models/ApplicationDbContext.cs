using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobPool.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {

        public DbSet<State> States { get; set; }
        public DbSet<TypeOfJob> TypeOfJobs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<PostedJob> PostedJobs { get; set; }
        public DbSet<JobApplied> JobApplieds { get; set; }




        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplied>().
                HasRequired(a => a.PostedJob).
                WithMany().
                WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}