using Consult.Core.Shared.ModelViews.Erro;
using System.Diagnostics;

namespace Consult.WebApi.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[ApiController]
public class ErrorController : ControllerBase
{
    [Route("error")]
    public ErrorResponse Error()
    {
        Response.StatusCode = 500;
        var id = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
        return new ErrorResponse(id);
    }
}