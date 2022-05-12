using Microsoft.Extensions.DependencyInjection;

namespace ProfissionaisService.infra.Crosscutting.IoC.Configuration;

public static class DepedencyInjectionSetup
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        NativeInjectorBootstrapper.RegisterServices(services);
    }
}