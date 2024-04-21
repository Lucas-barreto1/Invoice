using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Invoice.Context
{
    public static class InvoiceContextConfiguration
    {
        public static void InstallInvoiceContext(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("DBConnection");   

            services.AddDbContext<InvoiceContext>(builder =>
            {
                builder.UseNpgsql(connectionString, options =>
                {
                    options.MigrationsAssembly("Invoice.Infra.Data.Migrations");

                    // opt.MigrationsHistoryTable("EFMigrationsHistoryCurso"); // É possível alterar o nome da tabela onde são armazenados registros de execução do migrations (a tabela padrão do EF para histórico).
                    // IMPORTANTE: Isso deve ser feito antes do primeiro deploy, se não, a tabela anterior (nome padrão) continua.
                });
            });
        }
    }
}