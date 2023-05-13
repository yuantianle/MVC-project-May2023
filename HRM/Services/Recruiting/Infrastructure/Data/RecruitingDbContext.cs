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
        
    }
}
