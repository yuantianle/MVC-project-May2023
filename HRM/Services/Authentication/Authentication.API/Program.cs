using Authentication.API.Data;
using Authentication.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AuthenticationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DockerForSqlServer")//"RecruitingDbConnection"
    )
);

//specific to identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<AuthenticationDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();

//var angularURL = Environment.GetEnvironmentVariable("angularURL");
//app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//app.UseCors(policy => policy.WithOrigins(angularURL, "https://delightful-water-0beca3e0f.3.azurestaticapps.net").AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
