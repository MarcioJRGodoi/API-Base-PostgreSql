using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API_PostgreSql.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError() =>
            Problem();

        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if(!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }
            var exceptionhandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            return Problem
                (
                detail : exceptionhandlerFeature.Error.StackTrace,
                title: exceptionhandlerFeature.Error.Message
                );
        }
    }
}
