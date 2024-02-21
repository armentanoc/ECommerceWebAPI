using ECommerce.Infra.Context;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Infra.Interfaces;
using ECommerce.WebAPI.Filters;
using ECommerce.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using ECommerce.Infra.Repositories;

namespace ECommerce.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Cors
            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("localhost", policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://localhost:5000");
                });
            });

            // ILogger
            builder.Services.AddLogging();

            // DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite((builder.Configuration.GetConnectionString("ECommerceSqlite")));
            });

            // Repositories
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();
            builder.Services.AddScoped<IRefundRepository, RefundRepository>();
            builder.Services.AddScoped<IExchangeRepository, ExchangeRepository>();

            // Services
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ISaleService, SaleService>();
            builder.Services.AddScoped<IRefundService, RefundService>();
            builder.Services.AddScoped<IExchangeService, ExchangeService>();

            // Controllers
            builder.Services.AddControllers(options =>
            {
                // Exception Filter
                options.Filters.Add<ExceptionFilter>();
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                //Adds Cors Middleware
                app.UseCors("localhost");
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce Web API v1");
                    c.RoutePrefix = "swagger";
                });
            }

            // Logging Middleware
            app.UseMiddleware<LoggingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
