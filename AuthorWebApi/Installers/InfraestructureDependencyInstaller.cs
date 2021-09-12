using AuthorInfraestructure.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorWebApi.Installers
{
    public class InfraestructureDependencyInstaller : IDependencyInstaller
    {
        public void InstallDependencies(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContextPool<ApplicationDbContext, ApplicationDbContext>(
                (factory, options) =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"))
                        .AddInterceptors(new EventInvokerInterceptor(factory.GetRequiredService<IMediator>()));
                });
        }
    }
}
