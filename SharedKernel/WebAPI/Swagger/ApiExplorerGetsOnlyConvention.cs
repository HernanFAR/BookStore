using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Linq;

namespace SharedKernel.WebAPI.Swagger
{
    public class ApiExplorerGetsOnlyConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            action.ApiExplorer.IsVisible = !action.Attributes.OfType<ObsoleteAttribute>().Any();
        }
    }
}
