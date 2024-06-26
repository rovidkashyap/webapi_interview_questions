using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace api_versioning_in_web_api.Controllers
{
    // API versioning is a technique used to manage changes and updates to an API while ensuring
    // that existing clients can continue to use the API without disruption. It allows developers
    // to introduce new features, improvements, and changes to the API in a controlled manner by
    // creating different versions of the API. This ensures backward compatibility and helps in
    // maintaining a stable interface for clients relying on specific versions.

    // ASP.Net Core Provides Built-in support for API Versioning through
    // `Microsoft.AspNetCore.Mvc.Versioning` package.

    // 1. Install the API Versioning Package (By NuGet Package Manager)
    // 2. Configure API Versioning in `Program.cs` File. (Check `Program.cs` File).
    // 3. Define Versioned Controllers. (Using `ApiVersion` attribute)
    // 4. Specify the API Version in Requests
    //          - Version 1.0: `https://localhost:5001/api/v1/products`
    //          - Version 2.0: `https://localhost:5001/api/v2/products`

    // 5. Additional Versioning Strategies - (Api Versioning using Query String Parameters, Headers,
    //                                          or Media Types)
    // 5.1 - Query String Parameter Versioning: (Check `Program.cs` file)
    // 5.2 - Media Type Versioning: (Check `Program.cs` file)

    [ApiController]
    [Route("api/v{version:apiVersion}/products")]
    [ApiVersion("1.0")]     // Api Version attribute
    public class ProductV1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { "Product A", "Product B" });
        }
    }

    [ApiController]
    [Route("api/v{version:apiVersion}/products")]
    [ApiVersion("2.0")]
    public class ProductV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { "Product A", "Product B", "Product C" });
        }
    }
}
