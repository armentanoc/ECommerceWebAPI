using ECommerce.Infra.Context;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Infra.Interfaces;
using ECommerce.WebAPI.Filters;
using ECommerce.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using ECommerce.Infra.Repositories;
using Microsoft.OpenApi.Models;

namespace ECommerce.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var apiName = "E-Commerce Web API";

            var builder = WebApplication.CreateBuilder(args);

            //Cors
            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("DevEnvPolicy", policyBuilder =>
                {
                    policyBuilder
                    .WithOrigins("http://localhost:5000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    ;
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

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = apiName, Version = "v1" });
                c.EnableAnnotations();
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                //Adds Cors Middleware in Dev Environment
                app.UseCors("DevEnvPolicy");
                app.UseSwagger();
                app.UseSwaggerUI();
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
