using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace SharedKernel.WebAPI.Swagger
{
    public class AuthResponsesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var declaringType = context.MethodInfo.DeclaringType;

            if (declaringType is null) return;

            var authAttributes = declaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>();

            if (authAttributes.Any())
            {
                operation.Responses.Add(
                    "401", 
                    new OpenApiResponse 
                    { 
                        Description = "No se ingreso el header de autenticación" 
                    }
                );
            }
        }
    }
}
