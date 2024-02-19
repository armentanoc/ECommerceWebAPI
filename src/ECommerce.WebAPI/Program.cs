
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Infra.Interfaces;
using ECommerce.Infra.Repositories;
using ECommerce.WebAPI.Filters;

namespace ECommerce.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ILogger
            builder.Services.AddLogging();

            // Repository
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            
            // Service
            builder.Services.AddScoped<IProductService, ProductService>();

            // Controllers
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce Web API v1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
