using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mediatype_formatters.Controllers
{
    // ASP.Net Core Web API includes several built-in media type formatters, which are configured and
    // utilized through the `AddControllers()` method or extensions like `AddNewtonsoftJson()` for
    // JSON Handling. Here are main formatters:

    // 1. `SystemTextJsonInputFormatter` and `SystemTextJsonOutputFormatter` - Used for JSON data
    // 2. `NewtonsoftJsonInputFormatter` and `NewtonsoftJsonOutputFormatter` - Used for JSON data
    // 3. `XmlSerializerInputFormatter` and `XmlSerializerOutputFormatter` - Used for XML data
    // 4. `FormUrlEncodedFormatter`
    // 5.  Custom MediaTypeFormatters

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
    }
}
