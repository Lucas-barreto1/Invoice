using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Invoice.Collectors.Context
{
    public static class InvoiceCollectorsContextConfiguration
    {
        public static void InstallInvoiceCollectorsContext(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("HTCollectors");

            services.AddDbContext<InvoiceCollectorsContext>(builder =>
            {
                builder.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure(
                            maxRetryCount: 2,
                            maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorNumbersToAdd: null
                        )
                        .MigrationsAssembly("Invoice.Collectors.Infra.Data.Migrations");

                    // opt.MigrationsHistoryTable("EFMigrationsHistoryCurso"); // É possível alterar o nome da tabela onde são armazenados registros de execução do migrations (a tabela padrão do EF para histórico).
                    // IMPORTANTE: Isso deve ser feito antes do primeiro deploy, se não, a tabela anterior (nome padrão) continua.
                });
            });
        }
    }
}