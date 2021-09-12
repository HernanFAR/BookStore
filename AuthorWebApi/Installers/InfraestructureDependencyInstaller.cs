using AuthorInfraestructure.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infraestructure.EntityFramework.Interceptors;
using SharedKernel.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using AuthorDomain.Constants;

namespace AuthorWebApi.Installers
{
    public class InfraestructureDependencyInstaller : IDependencyInstaller
    {
        public void InstallDependencies(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContextPool<ApplicationDbContext, ApplicationDbContext>(
                (factory, options) =>
                {
                    options.UseSqlServer(
                            configuration.GetConnectionString("Database"),
                            options => options.MigrationsHistoryTable("__EFMigrationsHistory", DatabaseConstants.Schema)
                        )
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                        .AddInterceptors(new EventInvokerInterceptor(factory.GetRequiredService<IMediator>()));
                });
        }
    }
}
