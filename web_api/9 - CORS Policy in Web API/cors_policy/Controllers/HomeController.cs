using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cors_policy.Controllers
{
    // Cross-Origin Resource Sharing (CORS) is a security feature implemented by web browser to restrict
    // web pages from making requests to a different domain than the one that served the original webpage.

    // In context of Web API, CORS becomes relavant when you have a front-end application, running in
    // browser that need to make HTTP request to the API, and the API resides on different domain, port
    // and protocol than the frontend application.

    // If particular ip or domain is not allowed buy CORS policy than domain/IP will not able to access
    // that application.

    // To resolve the CORS issues in a Web API, we typically need to configure the API server to send 
    // appropriate CORS headers in its responses.

    // 1. Enable CORS in API Server.
    // 2. Response Headers.

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
    }
}
