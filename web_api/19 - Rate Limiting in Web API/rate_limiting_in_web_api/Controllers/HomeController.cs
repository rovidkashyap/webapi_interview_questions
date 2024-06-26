using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace rate_limiting_in_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /*
            Implementing rate limiting in an ASP.NET Core Web API helps protect your API from abuse, 
            ensuring that users do not overwhelm the server with too many requests in a short period. 
            One of the popular libraries to achieve rate limiting in ASP.NET Core is 
            `AspNetCoreRateLimit`.
            
            1. Install NuGet Package `AspNetCoreRateLimit`.
            2. Configure Rate Limiting in `appsettings.json`.   - Check `appsettings.json`.
            3. Configure Services in `Program.cs`.
            4. Define Rate Limiting Rules. (Check `appsettings.json` file).
            5. Testing the Rate Limiting

        */
    }
}
