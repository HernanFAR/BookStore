using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace SharedKernel.WebAPI.Swagger
{
    public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNamespace = controller.ControllerType.Namespace; // e.g. "Controllers.V1"

            if (controllerNamespace is null) return;

            var apiVersion = controllerNamespace.Split('.').Last().ToLower();

            controller.ApiExplorer.GroupName = apiVersion;
        }
    }
}
