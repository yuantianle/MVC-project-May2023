using ApplicationCode.Contract.Repositories;
using ApplicationCode.Contract.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IJobService, JobService>(); //constructor injection
                                                       //builder.Services.AddScoped<IJobService, JobMongoDBService>(); //constructor injection
                                                       //Inject our ConnectionString into DbContext
builder.Services.AddScoped<ICandidateService, CandidateService>();

builder.Services.AddDbContext<RecruitingDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("AzureConnector")//DockerForSqlServer"RecruitingDbConnection"
    )
);

builder.Services.AddScoped<IJobRepository, JobRepository>(); //constructor injection
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>(); //constructor injection


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
