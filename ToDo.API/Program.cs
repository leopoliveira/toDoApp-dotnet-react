using Microsoft.EntityFrameworkCore;

using ToDo.API.Domain.Interfaces.Repositories;
using ToDo.API.Infrastructure.Persistence.AppDbContext;
using ToDo.API.Infrastructure.Repositories;

namespace ToDo.API
{
    public class Program
    {
        #region Public Methods

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Entity Framework Core
            string DbConnString = builder.Configuration.GetConnectionString("DevConnString");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(DbConnString));

            // Services Dependecy Injection
            builder.Services.AddScoped<ITodoRepository, TodoRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        #endregion Public Methods
    }
}