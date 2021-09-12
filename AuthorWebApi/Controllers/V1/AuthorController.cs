using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthorWebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [SwaggerTag("Crea, borra, actualiza y lee autores del sistema.")]
    public class AuthorController : ControllerBase
    {
    }
}
