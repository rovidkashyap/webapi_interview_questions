using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace http_methods.Controllers
{
    // HTTP Methods are used in web API's are based on the HTTP protocols and are used interact with
    // RESTful services.
    // Here are only description of HTTP Methods, please do not to run the app as it shows compile-time error.

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // Retrieve the data from server. It's used to request data from a specified resource.
        [HttpGet]
        public IActionResult GetResource()
        {
            // Implementation to retirve resource
        }

        // Submit data to server to create a new resource. The server processes the data enclosed in the request.
        [HttpPost]
        public IActionResult CreateResource([FromBody] ResourceModel resource)
        {
            // Implementation to create resource
        }

        // Update an existing resource on the server. It replace the current representation of target
        // resource with the request payload.
        [HttpPut("{id}")]
        public IActionResult UpdateResource(int id, [FromBody] ResourceModel resource)
        {
            // Implementation to update resource
        }

        // Removes the specified resource from the server
        [HttpDelete("{id}")]
        public IActionResult DeleteResource(int id)
        {
            // Implementation to delete resource
        }

        // Applies partial modifications to a resource. Unlike PUT, which replace the entire resource.
        // PATCH only updates the specific fields.
        [HttpPatch("{id}")]
        public IActionResult PatchResource(int id, [FromBody] JsonPatchDocument<ResourceModel> patchDoc)
        {
            // Implementation to patch resource
        }

        // Similar to GET but without the response body. It's used to retrieve the headers of a resource.
        [HttpHead]
        public IActionResult HeadResource()
        {
            // Implementation to retrieve headers
        }

        // Describes the communication options for the target resource. It allows the client to determine
        // the capabilities of the server.
        [HttpOptions]
        public IAsyncResult OptionsResource()
        {
            // Implementation to retrieve communication options
        }
    }
}
