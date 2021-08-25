using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using SharedKernel.WebAPI.Interfaces;

namespace SharedKernel.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void InstallApplicationDependencies(this IServiceCollection services, Type startUpType, IConfiguration configuration)
        {
            var installers = startUpType.Assembly.ExportedTypes
                .Where(e => typeof(IDependencyInstaller).IsAssignableFrom(e))
                .Where(e => !e.IsAbstract && !e.IsInterface)
                .Select(e => Activator.CreateInstance(e))
                .Cast<IDependencyInstaller>()
                .ToList();

            installers.ForEach(e => e.InstallDependencies(services, configuration));
        }
    }
}
