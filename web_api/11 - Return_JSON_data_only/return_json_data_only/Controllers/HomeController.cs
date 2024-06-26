using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace return_json_data_only.Controllers
{
    // To Ensure that an ASP.Net Web API returns data in JSON format only, you need to configure the 
    // API to use JSON as the default and only media type formatter. This can be achieved by modifying
    // the configuration of the `HttpConfiguration` object in the `WebApiConfig` class or the `Startup`
    // class depending on the version and setup of your project.

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
    }
}
