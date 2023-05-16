using ApplicationCode.Contract.Services;
using Infrastructure.Services;

using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ApplicationCode.Contract.Repositories;

namespace RecruitingWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IJobService, JobService>(); //constructor injection
            //builder.Services.AddScoped<IJobService, JobMongoDBService>(); //constructor injection
            //Inject our ConnectionString into DbContext
            builder.Services.AddDbContext<RecruitingDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DockerForSqlServer")//"RecruitingDbConnection"
                )
            );

            builder.Services.AddScoped<IJobRepository, JobRepository>(); //constructor injection

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            /*if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            */

            app.UseRecruitingMiddleware();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}