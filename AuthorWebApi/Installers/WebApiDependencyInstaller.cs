using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SharedKernel.WebAPI.Interfaces;
using SharedKernel.WebAPI.Swagger;

namespace AuthorWebApi.Installers
{
    public class WebApiDependencyInstaller : IDependencyInstaller
    {
        public void InstallDependencies(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddControllers(
                options =>
                {
                    options.Conventions.Add(new ApiExplorerGroupPerVersionConvention());
                });

            serviceCollection.AddApiVersioning(
                options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);

                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                })
                .AddSwaggerGen(
                options =>
                {
                    options.OperationFilter<AuthResponsesOperationFilter>();

                    options.EnableAnnotations();

                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Author WebAPI",
                        Version = "v1",
                        Description = "Web API de autores."
                    });
                })
                .Configure<ApiBehaviorOptions>(
                options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
        }
    }
}
