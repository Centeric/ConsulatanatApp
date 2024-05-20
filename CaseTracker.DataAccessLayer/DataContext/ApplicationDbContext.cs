using CaseTracker.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            //try
            //{
            //    RelationalDatabaseCreator? dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //    if (dbCreator is not null)
            //    {
            //        if (!dbCreator.CanConnect()) dbCreator.Create();
            //        if (!dbCreator.HasTables()) dbCreator.CreateTables();
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
        }
        public  DbSet<Consultant> Consultants { get; set; }
        public  DbSet<NextSteps> NextSteps { get; set; }
        public DbSet<CommunicationUpdates> CommunicationUpdates { get; set; }
        public DbSet<AttachmentModel> AttachmentModels { get; set; }
        public DbSet<Users> AuthUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Consultant>()
                .HasKey(c => c.Id);  

            modelBuilder.Entity<NextSteps>()
                .HasKey(ns => ns.NextStepId);  
            modelBuilder.Entity<CommunicationUpdates>()
                .HasKey(cu => cu.CommunicationId);  

            modelBuilder.Entity<AttachmentModel>()
                .HasKey(a => a.AttachmentId);
            modelBuilder.Entity<Users>()
               .HasKey(a => a.UserId);

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

            
            modelBuilder.Entity<Consultant>()
                .HasMany(c => c.AttachmentModels)
                .WithOne(am => am.Consultant)
                .HasForeignKey(am => am.ConsultantId)
                .OnDelete(DeleteBehavior.Cascade); 

           
        }
    }
}
