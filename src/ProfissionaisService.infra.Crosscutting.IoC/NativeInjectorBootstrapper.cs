using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProfissionaisService.application.Ports;
using ProfissionaisService.infra.data.Adapters.Queries;
using ProfissionaisService.infra.data.Adapters.Repositories;

namespace ProfissionaisService.infra.Crosscutting.IoC;

public static class NativeInjectorBootstrapper
{
    public static void RegisterServices(IServiceCollection serviceCollection)
    {
        RegisterMediatR(serviceCollection);
        RegisterQueries(serviceCollection);
        RegisterRepositories(serviceCollection);
    }

    private static void RegisterMediatR(IServiceCollection serviceCollection)
    {
        const string applicationAssemblyName = "ProfissionaisService.application";
        var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

        serviceCollection.AddMediatR(assembly);
    }

    private static void RegisterQueries(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBuscarProfissionaisQueryService, BuscarProfissionaisQueryService>();
        serviceCollection.AddScoped<IBuscarProfissionalPorIdQueryService, BuscarProfissionalPorIdQueryService>();
        serviceCollection
            .AddScoped<IBuscarProfissionalPorUrlAmigavelQueryService, BuscarProfissionalPorUrlAmigavelQueryService>();
        serviceCollection.AddScoped<IBuscarTiposProfissionalQueryService, BuscarTiposProfissionalQueryService>();
        serviceCollection.AddScoped<IDashboardQueryService, DashboardQueryService>();
    }

    private static void RegisterRepositories(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProfissionalRepository, ProfissionalRepository>();
        serviceCollection.AddScoped<ITipoProfissionalRepository, TipoProfissionalRepository>();
    }
}