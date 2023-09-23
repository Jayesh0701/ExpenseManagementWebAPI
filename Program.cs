using System;
using Microsoft.EntityFrameworkCore;
using TestAppAPI.Data;
using TestAppAPI.Interface;
using TestAppAPI.Manager;

namespace TestAppAPI
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();
      builder.Services.AddDbContext<ExpenseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
      builder.Services.AddScoped<IExpenseManager, ExpenseManager>();
      builder.Services.AddCors(options =>
        options.AddPolicy("TestApp", (builder) => {
          builder.WithOrigins("http://localhost:4200")
          .AllowAnyHeader()
          .WithMethods("GET", "POST", "PUT", "DELETE")
          .WithExposedHeaders("*");
        })
      );
      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();
      app.UseCors("TestApp");

      app.MapControllers();

      app.Run();
    }
  }
}
