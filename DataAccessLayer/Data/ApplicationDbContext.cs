

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
    }
}