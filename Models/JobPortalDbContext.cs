using System.Data.Entity; // Required for DbContext

namespace JobPortal.Models
{
    // This class is the bridge between our application and the database.
    public class JobPortalDbContext : DbContext
    {
        // The constructor tells the DbContext which connection string to use.
        // "JobPortalDB" is the name we gave our connection string in Web.config.
        public JobPortalDbContext() : base("name=JobPortalDB")
        {
        }

        // These DbSet properties represent the tables in our database.
        // EF will use these to query and save data.
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
