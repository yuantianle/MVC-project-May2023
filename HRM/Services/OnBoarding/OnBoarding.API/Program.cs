using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using Infrastructure.Data;
using Infrastructure.Service;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddDbContext<OnBoardingDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("AzureConnector")//DockerForSqlServer"RecruitingDbConnection"
    )
);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

var angularURL = Environment.GetEnvironmentVariable("angularURL");
//app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseCors(policy => policy.WithOrigins(angularURL).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.MapControllers();

app.Run();
