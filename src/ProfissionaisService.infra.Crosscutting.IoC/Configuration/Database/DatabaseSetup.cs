using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.Crosscutting.IoC.Configuration.Database;

public static class DatabaseSetup
{
    public static void AddDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ProfissionalContext>(optionsBuilder =>
        {
            optionsBuilder.UseMySql(configuration.GetConnectionString("Default"),
                ServerVersion.Parse("8.0.28-mysql"));
        });
    }
}