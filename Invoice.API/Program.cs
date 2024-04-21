using Invoice.Context;
using Invoice.Domain.Interfaces;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Infra.Data.Repository.Repositories;

namespace Invoice.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            var builder = WebApplication.CreateBuilder(args);

            InstallServices(
                builder.Services,
                configuration
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


            app.MapControllers();

            app.Run();
        }

        private static IConfigurationRoot? GetConfiguration()
        {
            /* É lido o appsettings de acordo com o environment. */
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.Development.json", true)
                .Build();
        }

        private static void InstallServices(
            IServiceCollection services,
            IConfigurationRoot? configuration
        )
        {
            if (configuration is null)
                throw new ArgumentNullException(nameof(configuration));

            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            // services.InstallIoC();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.InstallInvoiceContext(configuration);
        }
    }
}
