using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Servieces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Config swagger to have authorization button
    var scheme = new OpenApiSecurityScheme()
    {
        Description = "JWT Authorization header using the Bearer scheme. e.g. Bearer xxxxx",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Authorization"
        },
        Scheme = "Authorization",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    };

    c.AddSecurityDefinition("Authorization", scheme);

    var requirement = new OpenApiSecurityRequirement()
    {
        [scheme] = new List<string>()
    };

    c.AddSecurityRequirement(requirement);
});

builder.Services.AddDbContext<InterviewsDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DockerForSqlServer")//"AzureConnector""RecruitingDbConnection"
    )
);

builder.Services.AddScoped<IInterviewService, InterviewService>();

builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();

// Microsoft.AspNetCore.Authentication.JwtBearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = false,
            ValidIssuer = "HRM",
            ValidAudience = "HRM Users",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"]??throw new Exception()))
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

//var angularURL = Environment.GetEnvironmentVariable("angularURL");
//app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//app.UseCors(policy => policy.WithOrigins(angularURL).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.MapControllers();

app.Run();
