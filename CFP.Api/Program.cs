using CFP.Api.Middlewares;
using CFP.Application.Extensions;
using CFP.Application.Models;
using CFP.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using DbContext = CFP.Infrastructure.DbContext;

namespace CFP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var conn = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton(_ => new DbContextSettings { DataBaseConnectionString = conn });
            builder.Services.AddDatabaseContext();
            builder.Services.AddRepositories(); 
            builder.Services.AddServices();
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DbContext>();
                context.Database.Migrate();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}