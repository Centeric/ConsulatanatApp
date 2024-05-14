

using LawyerApp.Models.Model;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
  

        public DbSet<Consultant> Consultants { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<NextSteps> NextSteps { get; set; }
        public DbSet<CommunicationUpdates> CommunicationUpdates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultant>()
        .HasKey(c => c.Id);

            modelBuilder.Entity<Consultant>()
                .HasMany(c => c.NextSteps)
                .WithOne(ns => ns.Consultant)
                .HasForeignKey(ns => ns.ConsultantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Consultant>()
                .HasMany(c => c.CommunicationUpdates)
                .WithOne(cu => cu.Consultant)
                .HasForeignKey(cu => cu.ConsultantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NextSteps>()
                .HasKey(ns => ns.NextStepId);

            modelBuilder.Entity<CommunicationUpdates>()
                .HasKey(cu => cu.CommunicationId);
        }
    }
}