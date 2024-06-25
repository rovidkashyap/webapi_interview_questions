using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_api_2._0.Controllers
{
    // Web API 2.0 released as part of ASP.Net Web API, Introduced several enhancement and new
    // features aimed at improving developer productivity, flexibility and ease of use them.
    // Here are some of key updates and features introduced in Web API 2.0

    // 1. Attribute Routing - defines Routes directly on controller actions or methods using attributes.

    // 2. `IHttpActionResult` Interface - It is standarized return type of Web API controller methods.
    //                                  providing more control over HTTP response and facilitating
    //                                  unit testing of API Controllers.

    // 3. OWIN Integration - It integrates with OWIN (Open Web Interface for .Net), allowing developers to
    //                      decouple Web APi from IIS and host in any OWIN-compliant server. This provides
    //                      more flexibility in hosting and deployment options.

    // 4. Attribute-based Model Validation - Enahnced support for model validation using data annotation and
    //                                      attribute-based validations rules, making it easier to validate
    //                                      incoming request data within Web API controllers.

    // 5. CORS Support - Introduce built-in support for CORS (Cross-Origin Resouce Sharing), allowing developers
    //                  to configure CORS policies within Web API to control access from different domains.

    // 6. `IHttpActionResult` and `HttpResponseMessage` - aloowing flexibility in returning HTTP responses
    //                                                  from Web API controller methods.

    // 7. Attribute-based Routing for Versioning - It Versioning API's using attribute-based routing.

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

    }
}
