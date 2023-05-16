using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class InterviewsDbContext : DbContext
    {
        public InterviewsDbContext(DbContextOptions<InterviewsDbContext> options) : base(options)
        {
        }

        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<InterviewTypeLookUp> InterviewTypeLookUps { get; set; }
    }
}
