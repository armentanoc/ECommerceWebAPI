
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Infra.Interfaces;
using ECommerce.Infra.Repositories;
using ECommerce.WebAPI.Filters;
using ECommerce.WebAPI.Middlewares;

namespace ECommerce.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Cors
            //Adicionar

            // ILogger
            builder.Services.AddLogging();

            // Repositories
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<ISaleRepository, SaleRepository>();
            builder.Services.AddSingleton<IRefundRepository, RefundRepository>();
            builder.Services.AddSingleton<IExchangeRepository, ExchangeRepository>();

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
