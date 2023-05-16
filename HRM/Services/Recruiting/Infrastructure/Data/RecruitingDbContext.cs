using Microsoft.EntityFrameworkCore;
using ApplicationCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class RecruitingDbContext: DbContext
    {
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options) : base(options)
        {

        }



        //DbSets are properties of DbContext that represent a table in the database
        public DbSet<Job> Jobs { get; set; }
        
        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<JobStatusLookUp> JobStatusLookUps { get; set; }

        public DbSet<Submission> Submissions { get; set; }


        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //I can use this method to do Fluent API configuration
            //to do any schema changes just like Data Annotations
            modelBuilder.Entity<Candidate>(ConfigureCandidate);
            //Action<EntityTypeBuilder<Tentity>> buildAction
            //Action<int> buildAction

        }
        private void ConfigureCandidate(EntityTypeBuilder<Candidate> builder)
        {
            // we can establish the rules for candidate table
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x=>x.CreateOn).HasDefaultValueSql("getdate()");
        }
    }
}
