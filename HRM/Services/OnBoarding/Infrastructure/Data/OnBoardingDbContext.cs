using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class OnBoardingDbContext : DbContext
    {
        public OnBoardingDbContext(DbContextOptions<OnBoardingDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeStatusLookUp> EmployeeStatusLookUps { get; set; }
    }

    
}
