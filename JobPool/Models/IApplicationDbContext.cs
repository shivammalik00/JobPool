using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPool.Models
{
    public interface IApplicationDbContext
    {
        DbSet<State> States { get; set; }
        DbSet<TypeOfJob> TypeOfJobs { get; set; }
        DbSet<JobCategory> JobCategories { get; set; }
        DbSet<PostedJob> PostedJobs  { get; set; }
        DbSet<JobApplied> JobApplieds { get; set; }


        int SaveChanges();
    }
}
