using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyWalletAPI.Domain.Handlers;
using MyWalletAPI.Domain.Repositories;
using MyWalletAPI.Infra.Context;
using MyWalletAPI.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("ConnectionString")));

builder.Services.AddTransient<IExpenseRepository, ExpenseRepository>();
builder.Services.AddTransient<ExpenseHandler, ExpenseHandler>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/mywallet-578d1";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/mywallet-578d1",
            ValidateAudience = true,
            ValidAudience = "mywallet-578d1",
            ValidateLifetime = true
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x  
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();