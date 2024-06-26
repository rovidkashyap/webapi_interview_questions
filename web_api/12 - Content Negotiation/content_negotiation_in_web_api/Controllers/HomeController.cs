using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace content_negotiation_in_web_api.Controllers
{
    // When Client Send request to a Web API, it can specify the preferred response format using HTTP
    // headers like `Accept`. The server than examines these headers to determine the most appropriate
    // format to use when sending the response. If server supports multiple formats (e.g., JSON, XML),
    // it uses the client's preferences to decide which one to use.

    // HTTP Headers Invocled in Content Negotiation
    
    // 1. `Accept` - the media types that the client is willing to recieve. Let's take one example for this
    //               `Accept: application/json` indicates that the client prefers the JSON format.

    // 2. `Content-Type`: Specifies the media type of the request body, used when the client sends data
    //                      to the server.

    // CLIENT REQUEST :
    //                GET /api/products/1 HTTP/1.1
    //                Host: example.com
    //                Accept: application/json

    // SERVER RESPONSE:
    //                  HTTP/1.1 200 OK
    //                  Content-Type: application/json
    //                  {
    //                      "Id": 1,
    //                      "name": "Product A"
    //                      "price": 100.0
    //                  }

    // Please check `Program.cs` File to setup content negotiation in ASP.Net Core 6 Web API.

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
    }
}
